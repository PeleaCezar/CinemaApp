using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace CinemaApp.Controllers
{    
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MoviesController(ApplicationDbContext context,
                                IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.Movies.Include(m => m.Genre).ToListAsync();
            List<MovieGenreViewModel> model = new List<MovieGenreViewModel>();
            foreach(var movie in applicationDbContext)
            {
                var movieToModel = new MovieGenreViewModel();
                movieToModel.Movie = movie;
                movieToModel.MovieID = movie.ID;
                movieToModel.Name = movie.Name;
                //astea se vor muta in details
                movieToModel.Description = movie.Description;
                movieToModel.DateAdded = movie.DateAdded;
                movieToModel.ReleaseDate = movie.ReleaseDate;
                var genre =  await _context.Genres.FirstOrDefaultAsync(p => p.Id == movie.GenreID);
                movieToModel.GenreName = genre.Name;
                model.Add(movieToModel);
            }
            return View(model);
            //var applicationDbContext = _context.Movies.Include(m => m.Genre);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<MovieGenreViewModel> listWithMovie = new List<MovieGenreViewModel>();
            var model = new MovieGenreViewModel();
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);
            model.Name = movie.Name;
            model.Movie = movie;
            model.Description = movie.Description;
            model.ReleaseDate = movie.ReleaseDate;
            model.DateAdded = movie.DateAdded;

            var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Id == movie.GenreID);
            model.GenreName = genre.Name;
            listWithMovie.Add(model);
            return View(listWithMovie);




            //var movie = await _context.Movies
            //    .Include(m => m.Genre)
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            //return View(movie);
        }


        // GET: Movies/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["GenreName"] = new SelectList(_context.Set<Genre>(), "Name", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(MovieGenreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(viewModel.Photo!= null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Photo");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    viewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
               
                var movie = new Movie();
                movie.Name = viewModel.Name;
                movie.Description = viewModel.Description;
                movie.DateAdded = viewModel.DateAdded;
                movie.ReleaseDate = viewModel.ReleaseDate;
                movie.PhotoPath = uniqueFileName;
                movie.Duration = viewModel.Duration;
                var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Name.Equals(viewModel.GenreName));
                genre.Name = viewModel.GenreName;
                movie.GenreID = genre.Id;
                //movie.GenreID = genreId;
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(viewModel);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            
            if (movie == null)
            {
                return NotFound();
            }           
                var movieModel = new MovieGenreViewModel();
                movieModel.MovieID = movie.ID;
                movieModel.Name = movie.Name;
                movieModel.Description = movie.Description;
                movieModel.DateAdded = movie.DateAdded;
                movieModel.ReleaseDate = movie.ReleaseDate;
                movieModel.Duration = movie.Duration;
                var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Id == movie.GenreID);
                movieModel.GenreName = genre.Name;



            ViewData["GenreName"] = new SelectList(_context.Set<Genre>(), "Name", "Name");
            return View(movieModel);
        }
        
        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, MovieGenreViewModel movieModel)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(p => p.ID == id);
            var genre = await _context.Genres.FirstOrDefaultAsync(m => m.Name.Equals(movieModel.GenreName));
           

            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;
                    if (movieModel.Photo != null)
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Photo");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + movieModel.Photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        movieModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                    movie.Name = movieModel.Name;
                    movie.Description = movieModel.Description;
                    movie.DateAdded = movieModel.DateAdded;
                    movie.ReleaseDate = movieModel.ReleaseDate;
                    movie.PhotoPath = uniqueFileName;
                    movie.Duration = movieModel.Duration;
                    movie.GenreID = genre.Id;
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "Id", "Id", movie.GenreID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieModel = new MovieGenreViewModel();
            var movie = await _context.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            movieModel.MovieID = movie.ID;
            movieModel.Name = movie.Name;
            movieModel.Description = movie.Description;
            movieModel.DateAdded = movie.DateAdded;
            movieModel.ReleaseDate = movie.ReleaseDate;
            var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Id == movie.GenreID);
            movieModel.GenreName = genre.Name;



            return View(movieModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}
