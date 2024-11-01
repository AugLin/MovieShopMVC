using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly MovieShopDbContext _context;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService, MovieShopDbContext context)
        {
            _logger = logger;
            _movieService = movieService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movieCards = await _movieService.GetTopRevenueMovies();
            return View(movieCards);
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
    }
}
