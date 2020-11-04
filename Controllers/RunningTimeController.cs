using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CinemaApp.Controllers
{
    public class RunningTimeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RunningTimeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ViewRanTimeMovie()
        {
            var applicationDbContext = await _context.RunningTimes.OrderBy(p=>p.StartDate).ToListAsync();
            List<RunningTimeViewModel> model = new List<RunningTimeViewModel>();
            foreach (var movie in applicationDbContext)
            {
                var movieToModel = new RunningTimeViewModel();
                var movieFromDb = await _context.Movies.FirstOrDefaultAsync(p => p.ID == movie.MovieID);
                movieToModel.MovieName = movieFromDb.Name;
                movieToModel.MovieID = movieFromDb.ID;
                var cinemaFromDb = await _context.CinemaHalls.FirstOrDefaultAsync(p => p.ID == movie.CinemaHallId);
                movieToModel.CinemaName = cinemaFromDb.CinemaName;
                movieToModel.CinemaID = cinemaFromDb.ID;


                var firstDate = movie.StartDate.ToString("F");
                movieToModel.StartDate = firstDate;

                var secondDate = movie.EndDate.ToString("F");
                movieToModel.EndDate = secondDate;

                model.Add(movieToModel);
            }

            ViewData["MovieNumber"] = _context.RunningTimes.Select(p => p.MovieID).Count();
            ViewData["MovieName"] = new SelectList(_context.Set<Movie>(), "Name", "Name");
            ViewData["CinemaHalls"] = new SelectList(_context.Set<Models.CinemaHall>(), "CinemaName", "CinemaName");
            return View(model);
        }

        public async Task<IActionResult> AddMovieRunTime(string jsonResult)
        {
            var myCleanJsonObject = JObject.Parse(jsonResult).ToString();
            var reservation = JsonConvert.DeserializeObject<RunningTimeViewModel>(myCleanJsonObject);

            var cinema = await _context.CinemaHalls.FirstOrDefaultAsync(p => p.CinemaName.Equals(reservation.CinemaName));
            var movie = await _context.Movies.FirstOrDefaultAsync(p => p.Name.Equals(reservation.MovieName));
            
            var cinemaHalls = await _context.CinemaHalls.ToListAsync();
            foreach (var cinemaHall in cinemaHalls)
            {
                var runTime = await _context.RunningTimes.FirstOrDefaultAsync(p => p.CinemaHallId == cinema.ID && p.MovieID == movie.ID 
                && p.StartDate < (Convert.ToDateTime(reservation.EndDate)) && p.EndDate > (Convert.ToDateTime(reservation.StartDate))); //(StartA <= EndB) and (EndA >= StartB)


                if (runTime == null)
                {
                    var runningTime = new RunningTime();
                    runningTime.StartDate = Convert.ToDateTime(reservation.StartDate);
                    runningTime.EndDate = Convert.ToDateTime(reservation.EndDate);
                    runningTime.CinemaHallId = cinema.ID;
                    runningTime.MovieID = movie.ID;
                    _context.Add(runningTime);
                    await _context.SaveChangesAsync();

                }

            }

            return Json(new { success = true, message = "A fost adaugat un nou interval orar" });

        }
        [HttpGet]
        public async Task<IActionResult> EditMovieRunTime(int id,int content,string dateStart)
        {
            if ( id == 0 || dateStart == null || content == 0)
            {
                return Json(new { error = true, message = "Editarea nu se poate efectua !" });
            }
            var runningTimes = await _context.RunningTimes.FirstOrDefaultAsync(e => e.MovieID == id && e.StartDate == Convert.ToDateTime(dateStart) && e.CinemaHallId == content);
             if(runningTimes == null)
            {
                return Json(new { error = true, message = "Editarea nu se poate efectua !" });
            }
            else
            {
                var viewModel = new RunningTimeViewModel();
                var cinema = await _context.CinemaHalls.FirstOrDefaultAsync(p => p.ID.Equals(runningTimes.CinemaHallId));
                var movie = await _context.Movies.FirstOrDefaultAsync(p => p.ID.Equals(runningTimes.MovieID));

                viewModel.CinemaName = cinema.CinemaName;
                viewModel.MovieName = movie.Name;
                viewModel.StartDate = runningTimes.StartDate.ToString("g").Replace('/','.');
                viewModel.EndDate = runningTimes.EndDate.ToString("g").Replace('/', '.');

                return Json(new { success = true, data = viewModel, message = "Datele au fost trimise catre client." });
            
            }
            
        }
        //GET
        public async Task<IActionResult> Delete(int id, int content, string dateStart)
        {
            if (id == 0 || dateStart == null || content == 0)
            {
                return Json(new { error = true, message = "Stergerea nu a putut fi efectuata !" });
            }
            var runningTime = await _context.RunningTimes.FirstOrDefaultAsync(p => p.MovieID == id && p.StartDate ==Convert.ToDateTime(dateStart) && p.CinemaHallId ==content);
            if (runningTime == null)
            {
                return Json(new { error = true, message = "Stergerea nu a putut fi efectuata !" });
            }
            else
            {
                _context.RunningTimes.Remove(runningTime);
                await _context.SaveChangesAsync();
                if (!RunningTimeExists(id,content, dateStart))
                {
                    var reservations = await _context.Reservations.Where(p => p.MovieID == id && p.ReservedDate == Convert.ToDateTime(dateStart) && p.CinemaHallID == content).ToListAsync();

                    foreach (Reservation reservation in reservations)
                    {
                        _context.Remove(reservation);
                        await _context.SaveChangesAsync();
                    }
                }               
                return Json(new { success = true, message = "Stergerea a fost efectuata cu succes !" });

            }

        }

        private bool RunningTimeExists(int movieId,int cinemaId,string dateStart )
        {
            return _context.RunningTimes.Any(p => p.MovieID == movieId && p.StartDate == Convert.ToDateTime(dateStart) && p.CinemaHallId == cinemaId);
        }

        public async Task<IActionResult> VerifyCinemaHallandDate(int id,string StartDate,int cinemaRepartition)
        {
            var dates = Convert.ToDateTime(StartDate);
            var cinemaHalls = await _context.CinemaHalls.ToListAsync();
            foreach( var cinemaHall in cinemaHalls)
            {
                var ok = 0;
                var programMovie = await _context.RunningTimes.Where(p => p.MovieID == id && p.StartDate == dates).ToListAsync();
                foreach (var cinemaProgram in programMovie)
                {
                    var count = 0;
                    
                    var seatsDb = await _context.Seats.Where(p => p.CinemaHallID == cinemaProgram.CinemaHallId).ToListAsync();
                    foreach (var seat in seatsDb)
                    {
                        var reservations = await _context.Reservations.Where(r => r.MovieID == id && r.CinemaHallID == cinemaProgram.CinemaHallId && r.ReservedDate == dates).ToListAsync();
                        foreach (var reservation in reservations)
                        {
                            var seatReserved = await _context.SeatReservations.FirstOrDefaultAsync(p => p.SeatID == seat.ID && p.ReservationID == reservation.ID);
                            if (seatReserved != null)
                            {
                                count++;
                            }
                        }

                    }
                    var seatsWithRes = count;
                    if (seatsWithRes < 98)
                    {
                        cinemaRepartition = cinemaProgram.CinemaHallId;
                        ok = 1;
                        break;
                    }
                }
                    if ( ok == 1)
                    {
                        break;
                    }
                                   
            }        
             if(cinemaRepartition == 0)
            {
                return View("CinemaNotFound",id);
            }
            return RedirectToAction("ListOfSeats", "Seats", new { id,StartDate,cinemaRepartition });

        }
    }
}
