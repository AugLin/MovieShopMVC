using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMovieService _movieService;

        IEnumerable<Genre> genres = new List<Genre>();
        IEnumerable<Cast> casts = new List<Cast>();
        IEnumerable<Trailer> trailers = new List<Trailer>();
        IEnumerable<Review> movieReviews = new List<Review>();

        public UserService(IPurchaseRepository purchaseRepository,
            IMovieService movieService,
            IMovieRepository movieRepository,
            IUserRepository userRepository
            )
        {
            _purchaseRepository = purchaseRepository;
            _movieService = movieService;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }


        public async Task<IEnumerable<Purchase>> GetPurchasesByUserId(int userId)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<Favorite>> GetFavoritesByUserId(int userId)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> IsMoviePurchased(int userId, int movieId)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> IsMovieFavorite(int userId, int id)
        {
            return false;
        }
        public async Task<bool> AddMovieReview(Review request)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieDetailByIdByUser(int userId, int movieId)
        {
            return null;
        }

        public Task<User> GetUserProfile(int id)
        {
            throw new NotImplementedException();
        }

        Task<Favorite> IUserService.GetMovieDetailByIdByUser(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}