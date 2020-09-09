using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaApp.Controllers
{
    public class HallCinemaController : Controller
    {
        private readonly ApplicationDbContext _context;

         public HallCinemaController(ApplicationDbContext context)
        {
            _context = context;
        }


        //POST
        public async Task<IActionResult> AddNewCinemaHall(RunningTimeViewModel viewModel)
        {
            if (ModelState.IsValid)
            { 
                var cinema = new Models.CinemaHall();
                cinema.CinemaName = viewModel.CinemaName;
               _context.Add(cinema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}
