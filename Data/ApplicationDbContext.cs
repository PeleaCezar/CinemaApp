using CinemaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<UserReservation>()
        //        .HasKey(t => new { t.UserID, t.ReservationID });

        //    modelBuilder.Entity<UserReservation>()
        //        .HasOne(pt => pt.MyUser)
        //        .WithMany(p => p.UserReservation)
        //        .HasForeignKey(pt => pt.UserID);

        //    modelBuilder.Entity<UserReservation>()
        //        .HasOne(pt => pt.Reservation)
        //        .WithMany(t => t.UserReservation)
        //        .HasForeignKey(pt => pt.ReservationID);
        //}

    }

}
