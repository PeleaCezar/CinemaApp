using System;
using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class Movie
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Duration { get; set; }

        public string PhotoPath { get; set; }

        public ICollection<MyUser> MyUsers { get; set; }

        public int? GenreID { get; set; }

        public Genre Genre { get; set; }

        public ICollection<Reservation> Reservations { get; set; }


    }
}