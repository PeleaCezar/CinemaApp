using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class MyUser : IdentityUser
    {
        public string FullName { get; set; }

        public int? MovieID { get; set; }

        public Movie Movie { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
