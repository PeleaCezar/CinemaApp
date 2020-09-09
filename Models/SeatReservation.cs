
namespace CinemaApp.Models
{
    public class SeatReservation
    {

        public int SeatID { get; set; }
        public Seat Seat { get; set; }

        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }

    }
}