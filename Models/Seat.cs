using System.Collections.Generic;
namespace CinemaApp.Models
{
    public class Seat
    {
        public int ID { get; set; }

        public int SeatNr { get; set; }

        ////Reservation
        public ICollection<SeatReservation> SeatReservations { get; set; }

        //CinemaHall
        public CinemaHall CinemaHall { get; set; }

        public int CinemaHallID { get; set; }


    }
}