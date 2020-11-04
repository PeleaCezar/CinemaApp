using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using CinemaApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> ListWithMovie()
        {
            var applicationdbcontext = await _context.Movies.Include(m => m.MovieGenres).ToListAsync();
            List<Test> model = new List<Test>();
            foreach (var movie in applicationdbcontext)
            {
                var movietomodel = new Test();
                movietomodel.Name = movie.Name;
                movietomodel.Description = movie.Description;
                movietomodel.ReleaseDate = movie.ReleaseDate;
                model.Add(movietomodel);
            }
            return Json(new { success = true, data = model, message = "Datele au fost trimise " });
        }

        //[HttpGet]
        //public async Task<IActionResult> GetMovies()
        //{
        //    List<MovieViewModel> MovieInfo = new List<MovieViewModel>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(BaseUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage Res = await client.GetAsync("https://localhost:44304/Home/ListWithMovie");

        //        if (Res.IsSuccessStatusCode)
        //        {

        //            var ObjResponse = Res.Content.ReadAsStringAsync().Result;
        //            //var MovieInfo = JsonConvert.DeserializeObject<MovieViewModel>(ObjResponse);

        //        }

        //    }

        //    return null;

       // }
    }
}
