using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CinemaApp.Models
{
    public class MyUser : IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
