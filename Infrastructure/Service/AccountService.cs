using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<int> LoginUser(User model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RegisterUser(User model)
        {
            throw new NotImplementedException();
        }
    }
}
