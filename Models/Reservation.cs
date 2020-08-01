using System;

namespace CinemaApp.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        public DateTime ReservedDate { get; set; }

        public decimal Duration { get; set; } //egala cu durata filmului

        public int? MovieID { get; set; }

        public Movie Movie { get; set; }

        public MyUser MyUser { get; set; }
    }
}
