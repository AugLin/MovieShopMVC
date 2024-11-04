using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetTopRevenueMovies();
        public Task<Movie> GetMovieDetailsById(int Id);
        public Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId, int pageNumber = 1, int pageSize = 30);
        public Task<IEnumerable<Movie>> GetMoviesByReleaseDate(int pageNumber = 1, int pageSize = 30);

        public Task<int> CreateNewMovie(Movie model);
        public Task<int> UpdateMovie(Movie model);
        public Task<int> GetCountOfMoviesByGenre(int id);

    }
}
