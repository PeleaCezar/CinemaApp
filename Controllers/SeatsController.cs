using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CinemaApp.Controllers
{
    public class SeatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public SeatsController (ApplicationDbContext context,
                                UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public async Task<IActionResult> ListOfSeats(int id, int cinemaRepartition,string StartDate)
        {

            var movie = await _context.Movies.FirstOrDefaultAsync(p => p.ID == id);
            var myDate = await _context.RunningTimes.Where(p=> p.MovieID == id).FirstOrDefaultAsync(p => p.StartDate == Convert.ToDateTime(StartDate));
            var myCinema = await _context.RunningTimes.Where(p => p.MovieID == id).FirstOrDefaultAsync(p => p.CinemaHallId == cinemaRepartition);
            if (movie == null || myDate == null || myCinema ==null)
            {
                return NotFound();
            }

 
            var cinemaHall = new ViewModels.CinemaHall();
            cinemaHall.RightHall = new List<SeatsViewModel>();
            cinemaHall.LeftHall = new List<SeatsViewModel>();
            var seatsCount = 0;

            for (int j = 1; j <= 7; j++)
            {
                var seatsViewModel = new SeatsViewModel();
                seatsViewModel.Seats = new List<SeatModel>();
                seatsViewModel.RowNr = j;
                for (int k = 1; k <= 7; k++)
                {
                    seatsCount++;
                    var seat = new SeatModel();
                    seat.SeatNr = seatsCount;
                    seatsViewModel.Seats.Add(seat);
                }
                cinemaHall.LeftHall.Add(seatsViewModel);
            }
            for (int x = 1; x <= 7; x++)
            {
                var seatsViewModel = new SeatsViewModel();
                seatsViewModel.Seats = new List<SeatModel>();
                seatsViewModel.RowNr = x;
                for (int k = 1; k <= 7; k++)
                {
                    seatsCount++;
                    var seat = new SeatModel();
                    seat.SeatNr = seatsCount;
                    seatsViewModel.Seats.Add(seat);
                }
                cinemaHall.RightHall.Add(seatsViewModel);
            }
            cinemaHall.MovieName = movie.Name;
            cinemaHall.MovieID = movie.ID;
            cinemaHall.CinemaNo = cinemaRepartition;
            

            ////seat reservation
            //var movieID = await  _context.RunningTimes.FirstOrDefaultAsync(m => m.MovieID == id); 
            //// voi schimba sa vina ora si sala de cinema din metoda de corespunzatoare butonului de rezervare
            //var cinemaIDs = movieID.CinemaHallId; //voi inlocui cu sala de Cinema venita din metoda de Rezervare

            var dates = Convert.ToDateTime(StartDate); //convert to DateTime
            var date = dates.ToString("f"); //change the format
            cinemaHall.Date = date;
            var reservations = await _context.Reservations.Where(r => r.MovieID == id && r.CinemaHallID == cinemaRepartition && r.ReservedDate == dates).ToListAsync();
            if (reservations.Count > 0)
            {
                await FillSeatsStatus(cinemaHall, cinemaRepartition, reservations);
            }
            else
            {   
                 
                foreach(var seatViewModel in cinemaHall.RightHall )
                {
                    foreach( var seat in seatViewModel.Seats)
                    {
                        seat.Status = "Liber";
                    }
                }
                foreach (var seatViewModel in cinemaHall.LeftHall)
                {
                    foreach (var seat in seatViewModel.Seats)
                    {
                        seat.Status = "Liber";
                    }
                }
            }
            return View(cinemaHall);
        }

        public async Task FillSeatsStatus(ViewModels.CinemaHall cinemaHall, int cinemaRepartition, List<Reservation> reservations)
        {
            foreach (var seatViewModel in cinemaHall.RightHall)
            {
                foreach (var seat in seatViewModel.Seats)
                {
                    var seatFromDb = await _context.Seats.FirstOrDefaultAsync(s => s.SeatNr == seat.SeatNr && s.CinemaHallID == cinemaRepartition);
                    foreach (var reservation in reservations)
                    {
                        var seatReservation = await _context.SeatReservations
                            .FirstOrDefaultAsync(st => st.SeatID == seatFromDb.ID && st.ReservationID == reservation.ID);
                        if (seatReservation != null)
                        {
                            seat.Status = "Rezervat";
                        }
                        else
                        { 
                            if(seat.Status !="Rezervat")
                            {
                                seat.Status = "Liber";
                            }                            
                        }
                    }
                }
            }

            foreach (var seatViewModel in cinemaHall.LeftHall)
            {
                foreach (var seat in seatViewModel.Seats)
                { 
                    var seatFromDb = await _context.Seats.FirstOrDefaultAsync(s => s.SeatNr == seat.SeatNr && s.CinemaHallID == cinemaRepartition);
                    foreach (var reservation in reservations)
                    {
                        var seatReservation = await _context.SeatReservations
                            .FirstOrDefaultAsync(st => st.SeatID == seatFromDb.ID && st.ReservationID == reservation.ID);
                        if (seatReservation != null)
                        {
                            seat.Status = "Rezervat";
                        }
                        else
                        {
                            if (seat.Status != "Rezervat")
                            {
                                seat.Status = "Liber";
                            }
                                
                        }
                    }
                }
            }
        }


       public async Task<IActionResult>CreateReservation (string jsonResult)
        {
            var myCleanJsonObject = JObject.Parse(jsonResult).ToString();

            var reservation = JsonConvert.DeserializeObject<ReservationViewModel>(myCleanJsonObject);

            var reservationDb = new Reservation();
            reservationDb.ReservedDate = Convert.ToDateTime(reservation.MovieDate);
            reservationDb.MovieID = int.Parse(reservation.MovieID);
            var userId = _userManager.GetUserId(HttpContext.User);
            reservationDb.MyUserID = userId;
            reservationDb.CinemaHallID = int.Parse(reservation.Cinema);
            //var movieID = await _context.RunningTimes.FirstOrDefaultAsync(m => m.MovieID == reservationDb.MovieID); //temporar pana voi obtine  sala de pe client
            //var cinemaID = movieID.CinemaHallId;// temporar
            //reservationDb.CinemaHallID = cinemaID;

            _context.Add(reservationDb);
            await _context.SaveChangesAsync();

            if (reservation.SeatReserved.Count > 0)
            {
                foreach (var seat in reservation.SeatReserved)
                {
                    var seatFromDb = await _context.Seats.FirstOrDefaultAsync(p => p.SeatNr == seat && p.CinemaHallID == reservationDb.CinemaHallID); 
                    SeatReservation seatReservation = new SeatReservation();
                    seatReservation.SeatID = seatFromDb.ID;
                    seatReservation.ReservationID = reservationDb.ID;
                    _context.SeatReservations.Add(seatReservation);
                }
            }
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Rezervarea a fost creata cu succes" });


        }

    }
}
