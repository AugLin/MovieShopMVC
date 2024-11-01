using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService


    {
        public Task<User> GetUserProfile(int id);
        public Task<IEnumerable<Purchase>> GetPurchasesByUserId(int userId);
        public Task<IEnumerable<Favorite>> GetFavoritesByUserId(int userId);
        public Task<Favorite> GetMovieDetailByIdByUser(int userId, int movieId);

        public Task<bool> IsMoviePurchased(int userId, int movieId);

        public Task<bool> IsMovieFavorite(int userId, int id);
    }
}
