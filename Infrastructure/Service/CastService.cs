using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public List<Movie> movies = new List<Movie>();
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<Cast> GetById(int Id)
        {
            return await _castRepository.GetById(Id);
        }
    }
}
