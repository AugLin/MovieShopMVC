
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _movieServiceSUT;
        private Mock<IMovieRepository> _mockMovieRepository;

        [TestInitialize]
        public void SetUp()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _movieServiceSUT = new MovieService(_mockMovieRepository.Object);
        }

        [TestMethod]
        public async Task Test_MovieService_GetTopRevenueMovies_Success()
        {
            List<Movie> _movie = new List<Movie>
            {
                new Movie{Id = 1,
                BackdropUrl = "https://image.tmdb.org/t/p/original//s3TBrRGB1iav7gFOCNx3H31MoES.jpg",
                Budget = (decimal)160000000.0000,
                CreatedBy = null,
                CreatedDate = null,
                ImdbUrl = "https://www.imdb.com/title/tt1375666",
                OriginalLanguage = "en",
                Overview = "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
                PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
                Price = null,
                ReleaseDate = DateTime.Parse("2010-07-15 00:00:00.0000000"),
                Revenue = (decimal)825532764.0000,
                Runtime = 148,
                Tagline = "Your mind is the scene of the crime.",
                Title = "Inception",
                TmdbUrl = "https://www.themoviedb.org/movie/27205",
                UpdatedBy = null,
                UpdatedDate = null},
                new Movie{Id = 2,
                    BackdropUrl = "https://image.tmdb.org/t/p/original//s3TBrRGB1iav7gFOCNx3H31MoES.jpg",
                    Budget = (decimal)160000000.0000,
                    CreatedBy = null,
                    CreatedDate = null,
                    ImdbUrl = "https://www.imdb.com/title/tt1375666",
                    OriginalLanguage = "en",
                    Overview = "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
                    PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
                    Price = null,
                    ReleaseDate = DateTime.Parse("2010-07-15 00:00:00.0000000"),
                    Revenue = (decimal)825532764.0000,
                    Runtime = 148,
                    Tagline = "Your mind is the scene of the crime.",
                    Title = "Inception",
                    TmdbUrl = "https://www.themoviedb.org/movie/27205",
                    UpdatedBy = null,
                    UpdatedDate = null},
                new Movie{Id = 3,
                    BackdropUrl = "https://image.tmdb.org/t/p/original//s3TBrRGB1iav7gFOCNx3H31MoES.jpg",
                    Budget = (decimal)160000000.0000,
                    CreatedBy = null,
                    CreatedDate = null,
                    ImdbUrl = "https://www.imdb.com/title/tt1375666",
                    OriginalLanguage = "en",
                    Overview = "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
                    PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
                    Price = null,
                    ReleaseDate = DateTime.Parse("2010-07-15 00:00:00.0000000"),
                    Revenue = (decimal)825532764.0000,
                    Runtime = 148,
                    Tagline = "Your mind is the scene of the crime.",
                    Title = "Inception",
                    TmdbUrl = "https://www.themoviedb.org/movie/27205",
                    UpdatedBy = null,
                    UpdatedDate = null}
            };
            // Arrange
            _mockMovieRepository.Setup(x => x.GetAll()).ReturnsAsync(_movie);

            // MovieService.cs => GetAll()
            var movies = await _movieServiceSUT.GetTopRevenueMovies();

            Assert.IsNotNull(movies);
            Assert.AreEqual(3, movies.Count());
        }
    }
}
