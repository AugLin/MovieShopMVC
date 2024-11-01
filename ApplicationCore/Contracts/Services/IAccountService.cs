using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {


        Task<int> RegisterUser(User model);
        Task<int> CheckEmail(string email);

        Task<int> LoginUser(User model);
    }
}
