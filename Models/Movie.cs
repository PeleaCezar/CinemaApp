using System;
using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class Movie
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Duration { get; set; }

        public string PhotoPath { get; set; }


        public ICollection<RunningTime> RunningTimes { get; set; }

        public ICollection<MyUser> MyUsers { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }

        public ICollection<Reservation> Reservations { get; set; }


    }
}