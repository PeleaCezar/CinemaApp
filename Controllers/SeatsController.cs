using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Controllers
{
    public class SeatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeatsController (ApplicationDbContext context )
        {
            _context = context;
        }



        public async Task<IActionResult> ListOfSeats(int id, int cinemaHallId)
        {
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
            var mvID = await _context.Movies.FirstOrDefaultAsync(p => p.ID == id);
            cinemaHall.MovieName = mvID.Name;
            cinemaHall.MovieID = mvID.ID;

            


            //seat reservation
            var movieID = await  _context.RunningTimes.FirstOrDefaultAsync(m => m.MovieID == id); 
            // voi schimba sa vina ora si sala de cinema din metoda de corespunzatoare butonului de rezervare
            var cinemaIDs = movieID.CinemaHallId; //voi inlocui cu sala de Cinema venita din metoda de Rezervare
            var date = movieID.StartDate.ToString("F"); // voi schimba cu data pe care el o selecteaza pe client
            cinemaHall.Date = date;
            var reservations = await _context.Reservations.Where(r => r.MovieID == id && r.CinemaHallID == cinemaIDs).ToListAsync();
            if (reservations.Count > 0)
            {
                await FillSeatsStatus(cinemaHall, cinemaIDs, reservations);
            }
            else
            {   var seatModel = new SeatModel();
                
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

        public async Task FillSeatsStatus(ViewModels.CinemaHall cinemaHall, int cinemaIDs, List<Reservation> reservations)
        {
            foreach (var seatViewModel in cinemaHall.RightHall)
            {
                foreach (var seat in seatViewModel.Seats)
                {
                    var seatFromDb = await _context.Seats.FirstOrDefaultAsync(s => s.SeatNr == seat.SeatNr && s.CinemaHallID == cinemaIDs);
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
                            seat.Status = "Liber";
                        }
                    }
                }
            }

            foreach (var seatViewModel in cinemaHall.LeftHall)
            {
                foreach (var seat in seatViewModel.Seats)
                {
                    var seatFromDb = await _context.Seats.FirstOrDefaultAsync(s => s.SeatNr == seat.SeatNr && s.CinemaHallID == cinemaIDs);
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
                            seat.Status = "Liber";
                        }
                    }
                }
            }
        }


        public async  Task<IActionResult> GetSeatStatus(int seatNr)
        {
            var seatReserved = await _context.SeatReservations.Where(p => p.SeatID == seatNr).Select(p => p.ReservationID).ToListAsync();

            var SeatModel = new SeatModel();

            if (seatReserved == null)
            {

                SeatModel.Status = "Liber";               
            }
            else
            {
                SeatModel.Status = "Ocupat";            
            }
            return Json(new { success = true, status = SeatModel.Status});
        }

    }
}
