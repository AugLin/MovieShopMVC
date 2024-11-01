
using ApplicationCore.Entities;
namespace ApplicationCore.Contracts.Services
{
    public interface ICastService


    {

        Task<Cast> GetById(int Id);

    }
}
