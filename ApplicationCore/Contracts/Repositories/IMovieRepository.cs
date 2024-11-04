using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAll();
        
        Task<IEnumerable<Movie>> GetMostRevenueMovies();
        
       
        Task<Movie> GetById(int id);

        Task<IEnumerable<Review>> GetReviews(int Id);

        Task<IEnumerable<Movie>> GetMoviesByGenreId(int genreId, int pageNumber = 1, int pageSize = 30);

        Task<int> CreateNewMovie(Movie model);

        Task<int> UpdateMovie(Movie model);
        Task<int> GetCountOfMoviesByGenre(int id);
    }
}
