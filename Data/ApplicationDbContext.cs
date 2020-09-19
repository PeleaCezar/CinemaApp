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
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet <CinemaHall>CinemaHalls { get; set; }
        public DbSet <Seat> Seats { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<RunningTime> RunningTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>()
                .HasKey(t => new { t.MovieID, t.GenreID });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.MovieGenres)
                .HasForeignKey(pt => pt.MovieID);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(pt => pt.Genre)
                .WithMany(t => t.MovieGenres)
                .HasForeignKey(pt => pt.GenreID);



            modelBuilder.Entity<SeatReservation>()
             .HasKey(t => new { t.SeatID, t.ReservationID });

            modelBuilder.Entity<SeatReservation>()
                .HasOne(pt => pt.Seat)
                .WithMany(p => p.SeatReservations)
                .HasForeignKey(pt => pt.SeatID);

            modelBuilder.Entity<SeatReservation>()
                .HasOne(pt => pt.Reservation)
                .WithMany(t => t.SeatReservations)
                .HasForeignKey(pt => pt.ReservationID);



            modelBuilder.Entity<RunningTime>()
            .HasKey(t => new { t.MovieID, t.CinemaHallId, t.StartDate });

            modelBuilder.Entity<RunningTime>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.RunningTimes)
                .HasForeignKey(pt => pt.MovieID);

            modelBuilder.Entity<RunningTime>()
                .HasOne(pt => pt.CinemaHall)
                .WithMany(t => t.RunningTimes)
                .HasForeignKey(pt => pt.CinemaHallId);



            modelBuilder.Entity<Seat>().HasData(
                 new Seat
                {
                    ID = 1,
                    SeatNr = 1,
                    CinemaHallID = 1
                },
                new Seat
                {
                    ID = 2,
                    SeatNr = 2,
                    CinemaHallID = 1
                },
                 new Seat
                {
                    ID = 3,
                    SeatNr = 3,
                    CinemaHallID = 1
                },
                 new Seat
                {
                    ID = 4,
                    SeatNr = 4,
                    CinemaHallID = 1
                },
                new Seat
                {
                    ID = 5,
                    SeatNr = 5,
                    CinemaHallID = 1
                },
                new Seat
                {
                    ID = 6,
                    SeatNr = 6,
                    CinemaHallID = 1
                },
                new Seat
                {
                    ID = 7,
                    SeatNr = 7,
                    CinemaHallID = 1
                },
                new Seat
                {
                    ID = 8,
                    SeatNr = 8,
                    CinemaHallID = 1
                },
                new Seat
                {
                    ID = 9,
                    SeatNr = 9,
                    CinemaHallID = 1
                },
                new Seat
                {
                    ID = 10,
                    SeatNr = 10,
                    CinemaHallID = 1
                },
                 new Seat
                   {
                    ID = 45,
                    SeatNr = 45,
                    CinemaHallID = 1
                      },
                    new Seat
                   {
                    ID = 89,
                    SeatNr = 89,
                    CinemaHallID = 1
                      },
                    new Seat
                   {
                    ID = 99,
                    SeatNr = 99,
                    CinemaHallID = 2
                      }

                );
        }

    }

}
