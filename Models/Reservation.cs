using System;
using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        public DateTime ReservedDate { get; set; } //ora

       // public decimal Duration { get; set; } //egala cu durata filmului

       //Movie
        public int? MovieID { get; set; }
        public Movie Movie { get; set; }

        //MyUser
        public MyUser MyUser { get; set; }
        public string MyUserID { get; set; }

        //Seats
        public ICollection<SeatReservation> SeatReservations { get; set; }

        //Cinema
        public int? CinemaHallID { get; set; }
        public CinemaHall CinemaHall { get; set; }


    }
}
