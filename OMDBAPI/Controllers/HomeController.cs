using Microsoft.AspNetCore.Mvc;
using OMDBAPI.Models;
using System.Diagnostics;

namespace OMDBAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MovieDAL movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]//Run when you first go to page
        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]//Run when you submit your form
        public IActionResult MovieSearch(string title)
        {
            MovieModel movie = movieDAL.GetMovie(title);
            return View(movie);
        }

        [HttpGet]//Run when you first go to page
        public IActionResult MovieNight()
        {
            return View();
        }
        [HttpPost]//Run when you submit your form
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            List<MovieModel> result = new List<MovieModel>
            {
                movieDAL.GetMovie(title1), 
                movieDAL.GetMovie(title2), 
                movieDAL.GetMovie(title3)
            };
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}