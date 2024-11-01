using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext connection) : base(connection)
        {
        }

        public Task<Purchase> Add(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Update(Purchase entity)
        {
            throw new NotImplementedException();
        }


    }
}