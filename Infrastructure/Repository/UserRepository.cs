using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly MovieShopDbContext _context;

        public UserRepository(MovieShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Set<User>().Include(u => u.Favorites).ThenInclude(f => f.Movie)
                        .Include(u => u.Purchases).ThenInclude(p => p.Movie).FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<int> Add(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return await _context.SaveChangesAsync();
        }

        public async Task<User> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int Id)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == Id);

        }

        public async Task<int> Update(User userUpdated)
        {
            try
            {
                var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == userUpdated.Id);
                user.FirstName = userUpdated.FirstName;
                user.LastName = userUpdated.LastName;
                user.Email = userUpdated.Email;
                user.PhoneNumber = userUpdated.PhoneNumber;
                user.DateOfBirth = userUpdated.DateOfBirth;

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("update is failed! Please try again!");
            }
        }
    }
}
