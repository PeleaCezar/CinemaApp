using System;
namespace CinemaApp.Models
{
    public class RunningTime
    {
        public int MovieID { get; set; }
        public Movie Movie { get; set; }


        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
