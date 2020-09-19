using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.ViewModels
{
    public class BookingModel
    {   //Fields for booking
        public string DayOfWeek { get; set; }
        public string HourOfDay { get; set; }
        public int DayOfMonth { get; set; }
        public string MonthOfYear { get; set; }

        public string StartDate { get; set; } //for routing
    }
}
