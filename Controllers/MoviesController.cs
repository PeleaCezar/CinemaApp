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

        // get: movies
        public async Task<IActionResult> Index()
        {
            var applicationdbcontext = await _context.Movies.Include(m => m.MovieGenres).ToListAsync();
            List<MovieGenreViewModel> model = new List<MovieGenreViewModel>();
            foreach (var movie in applicationdbcontext)
            {
                var movietomodel = new MovieGenreViewModel();
                movietomodel.Name = movie.Name;
                movietomodel.MovieID = movie.ID;
                movietomodel.Description = movie.Description;
                movietomodel.DateAdded = movie.DateRunning;
                movietomodel.ReleaseDate = movie.ReleaseDate;
                movietomodel.Movie = movie;
                model.Add(movietomodel);
            }
            return View(model);
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
            model.MovieID = movie.ID;
            model.Name = movie.Name;
            model.Movie = movie;
            model.Description = movie.Description;
            model.ReleaseDate = movie.ReleaseDate;
            model.DateAdded = movie.DateRunning;

            model.GenreNames = new List<string>();
            var genres = await _context.MovieGenres.Where(u => u.MovieID == movie.ID).ToListAsync();
             foreach (var genre in genres )
            {
                var genree = await _context.Genres.FirstOrDefaultAsync(p => p.Id == genre.GenreID);
                model.GenreNames.Add(genree.Name);
            }
            listWithMovie.Add(model);
            return View(listWithMovie);
        }


        // GET: Movies/Create
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            var genres = new List<string>();
            await FillGenreFromMovie(genres);
            ViewData["GenreNames"] = genres;

            return View();
        }

        private async Task<object>FillGenreFromMovie (List<string> genres)
        {
            foreach (Genre genre in await _context.Genres.ToListAsync())
            {  
                var genreMovie =  await _context.Genres.FindAsync(genre.Id);
                genres.Add(genreMovie.Name);
            }
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(MovieGenreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (viewModel.Photo != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Photo");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    viewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var movie = new Movie();
                movie.Name = viewModel.Name;
                movie.Description = viewModel.Description;
                movie.DateRunning = viewModel.DateAdded;
                movie.ReleaseDate = viewModel.ReleaseDate;
                movie.PhotoPath = uniqueFileName;
                movie.Duration = viewModel.Duration;
                _context.Add(movie);
                await _context.SaveChangesAsync();
                if (viewModel.GenreNames.Count > 0)
                {
                    foreach (var moviegenre in viewModel.GenreNames)
                    {
                        var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Name.Equals(moviegenre));
                        MovieGenre movieGenre = new MovieGenre();
                        movieGenre.MovieID = movie.ID;
                        movieGenre.GenreID = genre.Id;
                        _context.MovieGenres.Add(movieGenre);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            var movieModel = new MovieGenreViewModel();
            movieModel.MovieID = movie.ID;
            movieModel.Name = movie.Name;
            movieModel.Description = movie.Description;
            movieModel.DateAdded = movie.DateRunning;
            movieModel.ReleaseDate = movie.ReleaseDate;
            movieModel.Duration = movie.Duration;

            var genres = new List<string>();
            await FillGenreFromMovie(genres); // pentru  selectare itemelor din drop-down
            ViewData["GenreNames"] = genres;

            var genreMovie = new List<string>();
            foreach (MovieGenre movieGenre in await _context.MovieGenres.Include(p => p.Genre).Where(u => u.MovieID == id).ToListAsync())
            {
                var genre =  await _context.Genres.FirstOrDefaultAsync(p => p.Id == movieGenre.GenreID);
                genreMovie.Add(genre.Name);
            }
            movieModel.GenreNames = genreMovie;

                return View(movieModel);
        }
        

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, MovieGenreViewModel movieModel)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(p => p.ID == id);

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
            movie.DateRunning = movieModel.DateAdded;
            movie.ReleaseDate = movieModel.ReleaseDate;
            movie.PhotoPath = uniqueFileName;
            movie.Duration = movieModel.Duration;
            _context.Update(movie);

            var movieWithgenres = await _context.MovieGenres.Include(prop => prop.Genre).Where(m => m.MovieID == id).ToListAsync();
            foreach (MovieGenre mg in movieWithgenres)
            {
                _context.MovieGenres.Remove(mg);
                await _context.SaveChangesAsync();
            }
            if (movieModel.GenreNames.Count > 0)
            {
                foreach (var moviegenre in movieModel.GenreNames)
                {
                    var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Name.Equals(moviegenre));
                    MovieGenre movieGenre = new MovieGenre();
                    movieGenre.MovieID = movie.ID;
                    movieGenre.GenreID = genre.Id;
                    _context.MovieGenres.Add(movieGenre);
                    
                }
            }

            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
             var movie = await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            movieModel.MovieID = movie.ID;
            movieModel.Name = movie.Name;
            movieModel.Description = movie.Description;
            movieModel.DateAdded = movie.DateRunning;
            movieModel.ReleaseDate = movie.ReleaseDate;




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
