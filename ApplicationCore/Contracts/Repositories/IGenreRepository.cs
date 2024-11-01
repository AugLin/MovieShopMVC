using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<IEnumerable<Genre>> GetGenreList();
        public Task<Genre> GetById(int Id);
    }
}