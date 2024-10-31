using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        List<GenreModel> genres = new List<GenreModel>();
        List<CastModel> casts = new List<CastModel>();
        List<TrailerModel> trailers = new List<TrailerModel>();
        List<ReviewRequestModel> movieReviews = new List<ReviewRequestModel>();


        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public async Task<List<MovieCardModel>> GetAll()
        {
            var movies = await _movieRepository.GetAll();
            var res = new List<MovieCardModel>();

            foreach (var m in movies)
            {
                res.Add(new MovieCardModel { Id = m.Id, PosterURL = m.PosterUrl, Title = m.Title });
            }
            return res;
        }
        public async Task<List<MovieCardModel>> GetTop30GlossingMovies()
        {
            var movies = await _movieRepository.GetTop30GlossingMovies();
            var movieCards = new List<MovieCardModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterURL = movie.PosterUrl,
                    Title = movie.Title
                });
            }
            return movieCards;
        }



        public async Task<PageResultSet<MovieCardModel>> GetMoviesByGenre(string genre, int pageNumber = 1, int pageSize = 30)
        { 
            var moviesByPages = await _movieRepository.GetMoviesByGenre(genre, pageNumber, pageSize);
            var movieCards = new List<MovieCardModel>();

            foreach (var movie in moviesByPages.Data)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterURL = movie.PosterUrl,
                    Title = movie.Title
                });
            }
            return new PageResultSet<MovieCardModel>(movieCards, pageNumber, pageSize, moviesByPages.Count);
        }

        public async Task<PageResultSet<MovieCardModel>> GetMoviesByReleaseDate(int pageNumber = 1, int pageSize = 30)
        {
            var moviesByPages = await _movieRepository.GetMoviesByReleaseDate(pageNumber, pageSize);
            var movieCards = new List<MovieCardModel>();

            foreach (var movie in moviesByPages.Data)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterURL = movie.PosterURL,
                    Title = movie.Title
                });
            }
            return new PageResultSet<MovieCardModel>(movieCards, pageNumber, pageSize, moviesByPages.Count);
        }



        public async Task<List<MovieCardModel>> GetTopRated30()
        {
            var movies = await _movieRepository.GetTopRated30();

            return movies;
        }

        public async Task<PageResultSet<MovieCardModel>> GetMoviesByGenreId(int genreId, int pageNumber, int pageSize)
        {
            var moviesByPages = await _movieRepository.GetMoviesByGenreId(genreId, pageNumber, pageSize);
            var movieCards = new List<MovieCardModel>();

            foreach (var movie in moviesByPages.Data)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterURL = movie.PosterUrl,
                    Title = movie.Title
                });
            }
            return new PageResultSet<MovieCardModel>(movieCards, pageNumber, pageSize, moviesByPages.Count);
        }


        public async Task<MovieCreateRequestModel> CreateNewMovie(MovieCreateRequestModel model)
        {
            return await _movieRepository.CreateNewMovie(model);

        }

        public async Task<MovieCreateRequestModel> UpdateMovie(MovieCreateRequestModel model)
        {
            return await _movieRepository.UpdateMovie(model);

        }

        public Task<MovieDetailsModel> GetMovieDetailsById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}