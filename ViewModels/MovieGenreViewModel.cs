using CinemaApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.ViewModels
{
    public class MovieGenreViewModel
    {
        //Field for Movie

        public int MovieID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Duration { get; set; }

        public IFormFile Photo { get; set; }

        public Movie Movie { get; set; }

        //Fields for Genre

        public int GenreId { get; set; }

        public string GenreName { get; set; }




    }
}
