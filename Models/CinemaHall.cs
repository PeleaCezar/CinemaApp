using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class CinemaHall
    {
        public int ID { get; set; }

        public string CinemaName { get; set; }

        public ICollection<Seat>Seats { get; set; }

        public ICollection <Reservation> Reservations { get; set; }

        public ICollection<RunningTime> RunningTimes { get; set; }
    }
}
