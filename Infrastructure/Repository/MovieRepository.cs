using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Azure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository

{
    private readonly MovieShopDbContext _context;
    public MovieRepository(MovieShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAll()
    {
        return await _context.Set<Movie>().ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetMostRevenueMovies()
    {
        var movies = await _context.Set<Movie>().OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
        return movies;
    }

    public async Task<Movie> GetById(int Id)
    {

        var movie = await _context.Set<Movie>()
                    .Include(m => m.Genres).ThenInclude(m => m.Genre)
                    .Include(m => m.Casts).ThenInclude(m => m.Cast)
                    .Include(m => m.Trailers)
                    .FirstOrDefaultAsync(m => m.Id == Id);

        return movie;
    }


    public async Task<IEnumerable<Movie>> GetMoviesByGenreId(int genreId, int pageNumber = 1, int pageSize = 30)
    {
        var movies = await _context.Movies
                 .Join(
                     _context.MovieGenres,
                     movie => movie.Id,
                     movieGenre => movieGenre.MovieId,
                     (movie, movieGenre) => new { movie, movieGenre }
                 )
                 .Where(mg => mg.movieGenre.GenreId == genreId)
                 .Select(mg => mg.movie)
                 .OrderByDescending(m => m.Revenue)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .Distinct()
                 .ToListAsync();

        return movies;
    }


    public async Task<IEnumerable<Review>> GetReviews(int Id)
    {
        var reviews = await _context.Set<Review>()
            .Include(r => r.Movie)
            .Where(r => r.MovieId == Id).ToListAsync();

        return reviews;
    }


    public async Task<IEnumerable<Movie>> GetTopRevenueMovies()
    {
        return await _context.Movies.OrderByDescending(x => x.Revenue).Take(24).ToListAsync();
    }

    public async Task<int> GetCountAllAsync(int id)
    {
        return await _context.Movies
                     .Join(
                         _context.MovieGenres,
                         movie => movie.Id,
                         movieGenre => movieGenre.MovieId,
                         (movie, movieGenre) => new { movie, movieGenre }
                     )
                     .Where(mg => mg.movieGenre.GenreId == id)
                     .CountAsync();
    }

    public async Task<int> CreateNewMovie(Movie model)
    {
        throw new NotImplementedException();
    }


    public async Task<int> UpdateMovie(Movie model)
    {

        throw new NotImplementedException();
    }

}
