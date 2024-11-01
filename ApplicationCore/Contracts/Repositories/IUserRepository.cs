using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(int Id);

        Task<User> GetUserByEmail(string email);
        Task<int> Update(User user);
    }
}