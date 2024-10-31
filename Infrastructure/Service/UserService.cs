using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMovieService _movieService;

        List<GenreModel> genres = new List<GenreModel>();
        List<CastModel> casts = new List<CastModel>();
        List<TrailerModel> trailers = new List<TrailerModel>();
        List<ReviewRequestModel> movieReviews = new List<ReviewRequestModel>();

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


        public async Task<List<PurchaseDetailModel>> GetPurchasesByUserId(int userId)
        {


            var purchases = await _purchaseRepository.GetPurchaseByUserId(userId);

            List<PurchaseDetailModel> movies = new List<PurchaseDetailModel>();

            foreach (var purchase in purchases)
            {
                movies.Add(new PurchaseDetailModel
                {
                    MovieId = purchase.MovieId,
                    Title = purchase.Movie.Title,
                    PosterURL = purchase.Movie.PosterUrl,
                    PurchaseNumber = purchase.PurchaseNumber.ToString(),
                    PurchaseDate = purchase.PurchaseTime,
                    PurchasePrice = purchase.TotalPrice
                });
            }


            return movies;
        }



        public async Task<List<FavoriteDetailModel>> GetFavoritesByUserId(int userId)
        {
            return null;
        }

        public async Task<List<CartDetailModel>> GetCartByUserId(int userId)
        {
            return null;
        }


        public async Task<bool> IsMoviePurchased(int userId, int movieId)
        {
            return await _purchaseRepository.IsMoviePurcahsed(userId, movieId);


        }


        public async Task<bool> IsMovieFavorite(int userId, int id)
        {
            return false;
        }
        public async Task<bool> AddMovieReview(ReviewRequestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDetailByUserModel> GetMovieDetailByIdByUser(int userId, int movieId)
        {
            return null;
        }

        public async Task<bool> AddPurchaseFromCart(List<CartDetailModel> purchases)
        {
            try
            {

                foreach (var item in purchases)
                {
                    await _purchaseRepository.AddPurchaseToUserId(item);

                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("purchase is not successful, please retry later!");
                return false;
            }
        }

        public async Task<Purchase> CreatePurchaseAPI(PurchaseRequestModel purchase)
        {

            try
            {
                return await _purchaseRepository.CreatePurchaseAPI(purchase);
            }
            catch (Exception ex)
            {

                throw new Exception("Purchase is not successful, please try again later!");

            }

        }
        public async Task<UserProfileModel> GetUserProfile(int id)
        {
            var user = await _userRepository.GetById(id);
            var profile = new UserProfileModel
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                DateOfBirth = (DateTime)user.DateOfBirth,
                Email = user.Email,
                Phone = user.PhoneNumber
            };

            return profile;
        }
        public async Task<bool> UpdateUser(UserProfileModel user)
        {
            return await _userRepository.Update(user);
        }
    }
}