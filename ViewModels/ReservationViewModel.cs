using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.ViewModels
{
    public class ReservationViewModel
    {
        public string MovieID { get; set; }
        public string MovieDate { get; set; }
        public string Cinema { get; set; }
        public List <int> SeatReserved { get; set; } 


    }
}
