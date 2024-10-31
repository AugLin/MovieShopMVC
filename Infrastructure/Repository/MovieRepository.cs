using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MovieRepository : Repository<Movie>, IMovieRepository

{
    private readonly MovieShopDbContext _context;
    public MovieRepository(MovieShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Movie>> GetAll()
    {
        return await _context.Set<Movie>().ToListAsync();
    }

    public async Task<List<Movie>> GetTop30GlossingMovies()
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


    public async Task<PageResultSet<Movie>> GetMoviesByGenre(string genre, int pageNumber = 1, int pageSize = 30)
    {
        var genreId = _context.Set<Genre>().FirstOrDefault(g => g.Name == genre).Id;
        var totalMovieCount = await _context.Set<MovieGenre>().Where(m => m.GenreId == genreId).CountAsync();
        var movies = await _context.Set<MovieGenre>()
            .Where(mg => mg.GenreId == genreId)
            .Include(m => m.Movie)
            .OrderByDescending(m => m.Movie.Revenue)
            .Select(mg => new Movie { Id = mg.MovieId, Title = mg.Movie.Title, PosterUrl = mg.Movie.PosterUrl })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pageOfMovies = new PageResultSet<Movie>(movies, pageNumber, pageSize, totalMovieCount);
        return pageOfMovies;
    }


    public Task<List<Review>> GetReviews(int Id)
    {
        var reviews = _context.Set<Review>()
            .Include(r => r.Movie)
            .Where(r => r.MovieId == Id).ToListAsync();

        return reviews;
    }


    public async Task<PageResultSet<MovieDetailsModel>> GetMoviesByReleaseDate(int pageNumber, int pageSize)
    {
        var totalMovieCount = await _context.Set<Movie>().CountAsync();
        var movies = await _context.Set<Movie>()
            .OrderByDescending(m => m.ReleaseDate)
            .Select(m => new MovieDetailsModel { Id = m.Id, Title = m.Title, PosterURL = m.PosterUrl })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pageOfMovies = new PageResultSet<MovieDetailsModel>(movies, pageNumber, pageSize, totalMovieCount);
        return pageOfMovies;
    }


    public async Task<List<MovieCardModel>> GetTopRated30()
    {
        var movies = from r in _context.Set<Review>().Include(r => r.Movie)
                     group r by r.MovieId into mr
                     orderby mr.Average(r => r.Rating) descending
                     select new MovieCardModel
                     {
                         Id = mr.FirstOrDefault().Movie.Id,
                         Title = mr.FirstOrDefault().Movie.Title,
                         PosterURL = mr.FirstOrDefault().Movie.PosterUrl
                     };

        return await movies.ToListAsync();
    }

    public async Task<PageResultSet<Movie>> GetMoviesByGenreId(int genreId, int pageNumber, int pageSize)
    {
        var totalMovieCount = await _context.Set<MovieGenre>().Where(m => m.GenreId == genreId).CountAsync();
        var movies = await _context.Set<MovieGenre>()
            .Where(mg => mg.GenreId == genreId)
            .Include(m => m.Movie)
            .OrderByDescending(m => m.Movie.Revenue)
            .Select(mg => new Movie { Id = mg.MovieId, Title = mg.Movie.Title, PosterUrl = mg.Movie.PosterUrl })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pageOfMovies = new PageResultSet<Movie>(movies, pageNumber, pageSize, totalMovieCount);
        return pageOfMovies;
    }


    public async Task<MovieCreateRequestModel> CreateNewMovie(MovieCreateRequestModel model)
    {
        var movie = new Movie
        {
            Title = model.Title,
            BackdropUrl = model.BackdropURL,
            Budget = model.Budget,
            Overview = model.Overview,
            Tagline = model.TagLine,
            Revenue = model.Revenue,
            ImdbUrl = model.ImdbURL,
            TmdbUrl = model.TmdbURL,
            PosterUrl = model.PosterURL,
            OriginalLanguage = model.OriginalLanguage,
            ReleaseDate = (DateTime)model.ReleaseDate,
            Runtime = model.RunTime,
            Price = model.Price


        };
        await _context.Set<Movie>().AddAsync(movie);
        await _context.SaveChangesAsync();

        var movieCreated = await _context.Set<Movie>().FirstOrDefaultAsync(M => M.Title == model.Title);
        if (movieCreated == null)
        {
            throw new Exception("Create new movie failed!");
        }

        foreach (var mg in model.Genres)
        {
            var movieGenre = new MovieGenre { GenreId = mg.GenreId, MovieId = mg.MovieId };
            await _context.Set<MovieGenre>().AddAsync(movieGenre);
            await _context.SaveChangesAsync();

        }

        model.Id = movieCreated.Id;
        return model;
    }


    public async Task<MovieCreateRequestModel> UpdateMovie(MovieCreateRequestModel model)
    {

        var movie = await _context.Set<Movie>().FirstOrDefaultAsync(m => m.Id == model.Id);
        if (movie == null)
        {
            throw new Exception("No such movie found, please recheck movie Id!");
        }

        movie.Title = model.Title;
        movie.PosterUrl = model.PosterURL;
        movie.Price = model.Price;
        movie.BackdropUrl = model.BackdropURL;
        movie.Budget = model.Budget;
        movie.ImdbUrl = model.ImdbURL;
        movie.OriginalLanguage = model.OriginalLanguage;
        movie.Overview = model.Overview;
        movie.ReleaseDate = (DateTime)model.ReleaseDate;
        movie.Revenue = model.Revenue;
        movie.Runtime = model.RunTime;
        movie.Tagline = model.TagLine;
        movie.TmdbUrl = model.TmdbURL;

        var moviegenres = _context.Set<MovieGenre>().Where(mg => mg.MovieId == mg.MovieId);
        _context.Set<MovieGenre>().RemoveRange(moviegenres);
        await _context.SaveChangesAsync();

        foreach (var mg in model.Genres)
        {
            var movieGenre = new MovieGenre { GenreId = mg.GenreId, MovieId = mg.MovieId };
            await _context.Set<MovieGenre>().AddAsync(movieGenre);
            await _context.SaveChangesAsync();

        }
        return model;
    }
}
