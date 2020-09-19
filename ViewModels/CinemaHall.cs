using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.ViewModels
{
    public class CinemaHall
    {
        public List<SeatsViewModel> LeftHall { get; set; }
        public List<SeatsViewModel> RightHall { get; set; }


        public string MovieName {get;set;}
        public string Date { get; set; }
        public int MovieID { get; set; }
        public int CinemaNo { get; set; }
    }
}
