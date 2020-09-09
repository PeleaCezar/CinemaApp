using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Controllers
{
    public class RunningTimeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RunningTimeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ViewRanTimeMovie()
        {
            var applicationDbContext = await _context.RunningTimes.ToListAsync();
            List<RunningTimeViewModel> model = new List<RunningTimeViewModel>();
            foreach (var movie in applicationDbContext)
            {
                var movieToModel = new RunningTimeViewModel();
                var movieID = await _context.Movies.FirstOrDefaultAsync(p => p.ID == movie.MovieID);
                movieToModel.MovieName = movieID.Name;
                movieToModel.MovieID = movieID.ID;
                var cinemaID = await _context.CinemaHalls.FirstOrDefaultAsync(p => p.ID == movie.CinemaHallId);
                movieToModel.CinemaName = cinemaID.CinemaName;

                var firstDate = movie.StartDate.ToString("F");
                movieToModel.StartDate = firstDate;

                var secondDate = movie.EndDate.ToString("d");
                movieToModel.EndDate = secondDate;
                ViewData["MovieProgram"] = _context.RunningTimes.Select(p => p.MovieID).Count();

                model.Add(movieToModel);
            }
            return View(model);
        }



        //GET
        public IActionResult AddMovieRunTime()
        {
            ViewData["CinemaName"] = new SelectList(_context.Set<RunningTime>(), "CinemaName", "CinemaName");
            ViewData["MovieName"] = new SelectList(_context.Set<Models.CinemaHall>(), "CinemaName", "CinemaName");
            return View();
        }


    }
}
