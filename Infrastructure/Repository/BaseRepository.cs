using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class


    {

        private readonly MovieShopDbContext _context;
        public BaseRepository(MovieShopDbContext connection)
        {
            _context = connection;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync(); ;
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _context.Set<T>().Where(filter).CountAsync();
            }
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }



}
