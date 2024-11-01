using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetGenreList()
        {
            var genres = await _genreRepository.GetGenreList();

            var res = new List<Genre>();

            foreach (var genre in genres)
            {
                res.Add(new Genre { Id = genre.Id, Name = genre.Name });
            }

            return res;
        }
    }


}
