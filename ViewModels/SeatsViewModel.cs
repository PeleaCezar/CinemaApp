using CinemaApp.ViewModels;
using System.Collections.Generic;
namespace CinemaApp.Models
{
    public class SeatsViewModel
    {
        public int RowNr { get; set; }
        public List<SeatModel> Seats { get; set; }
    }
}
