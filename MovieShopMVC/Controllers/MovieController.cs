using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace MovieShopMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public MovieController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        [HttpGet]
        [Route("Movie/Genre/{id}/{page?}")]
        public async Task<IActionResult> Genre(int id, int page = 1, int pageSize = 30)
        {
            var movies = await _movieService.GetMoviesByGenre(id, page, pageSize);
            var movieSize = await _movieService.GetCountOfMoviesByGenre(id);
            ViewBag.CurrentPage = page;
            ViewBag.CurrentGenreId = id;
            ViewBag.TotalPages = movieSize / pageSize;

            return View(movies);
        }
    }
}
