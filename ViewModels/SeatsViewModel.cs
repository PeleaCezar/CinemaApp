using CinemaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Models
{
    public class SeatsViewModel
    {
        public int Direction { get; set; }
        public int RowNr { get; set; }
        public List<SeatModel> Seats { get; set; }
    }
}
