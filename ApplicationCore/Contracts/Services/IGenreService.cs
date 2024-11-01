using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {

        public Task<IEnumerable<Genre>> GetGenreList();

    }
}
