using System.Collections.Generic;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CinemaApp.Controllers
{
    public class SeatsController : Controller
    {
        public const int numberOfRows = 7;
        public const int leftDirection = 1;
        public const int rightDirection = 2;

        public IActionResult ListOfSeats()
        {
            var cinemaHall = new CinemaHall();
            for (int i = 1; i <= 2; i++)
            {
                var cinemaLeftHall = new List<SeatsViewModel>();
                var count = 0;
                var seatsViewModel = new SeatsViewModel();
                for (int j = 1; j <= 7; i++)
                {
                    count++;
                    seatsViewModel.RowNr = i;
                }
            }

            // ++
            
            return View();
        }

    }
}
