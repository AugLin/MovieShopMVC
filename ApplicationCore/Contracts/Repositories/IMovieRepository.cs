using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetAll();
        
        Task<List<Movie>> GetTop30GlossingMovies();
        
        Task<PageResultSet<MovieDetailsModel>> GetMoviesByReleaseDate(int pageNumber, int pageSize);
       
        Task<Movie> GetById(int id);

        Task<List<Review>> GetReviews(int Id);

        Task<PageResultSet<Movie>> GetMoviesByGenre(string genre, int pageNumber = 1, int pageSize = 30);

        Task<PageResultSet<Movie>> GetMoviesByGenreId(int genre, int pageNumber = 1, int pageSize = 30);

        Task<List<MovieCardModel>> GetTopRated30();

        Task<MovieCreateRequestModel> CreateNewMovie(MovieCreateRequestModel model);

        Task<MovieCreateRequestModel> UpdateMovie(MovieCreateRequestModel model);
    }
}
