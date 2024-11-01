using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Azure;
using Infrastructure.Repository;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        IEnumerable<Genre> genres = new List<Genre>();
        IEnumerable<Cast> casts = new List<Cast>();
        IEnumerable<Trailer> trailers = new List<Trailer>();
        IEnumerable<Review> movieReviews = new List<Review>();


        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<int> CreateNewMovie(Movie model)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieDetailsById(int id)
        {
            return await _movieRepository.GetById(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId, int pageNumber = 1, int pageSize = 30)
        {
            return await _movieRepository.GetMoviesByGenreId(genreId, pageNumber, pageSize);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByReleaseDate(int pageNumber = 1, int pageSize = 30)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetTopRevenueMovies()
        {
            return _movieRepository.GetMostRevenueMovies();
        }

        public Task<int> UpdateMovie(Movie model)
        {
            throw new NotImplementedException();
        }
    }
}