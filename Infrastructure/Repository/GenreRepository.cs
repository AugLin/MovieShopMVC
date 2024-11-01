using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly MovieShopDbContext _context;
        public GenreRepository(MovieShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetGenreList()
        {
            return await _context.Set<Genre>().ToListAsync();
        }
    }
}
