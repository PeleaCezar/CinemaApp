using CinemaApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace CinemaApp.ViewModels
{
    public class MovieGenreViewModel
    {
        //Field for Movie

        public int MovieID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Duration { get; set; }

        public IFormFile Photo { get; set; }

        public Movie Movie { get; set; }

        public string dateRelease { get; set; }

        //Fields for Genre
        public List<string> GenreNames {get; set; }

        //Fields for CinemaHall
        // public string CinemaName { get; set; }

        //booking
        public List<BookingModel> AllBookings { get; set; }
        


    }
}
