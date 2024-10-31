using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : IRepository<Purchase>, IPurchaseRepository
    {
        private readonly MovieShopDbContext _context;

        public PurchaseRepository(MovieShopDbContext context)
        {
            _context = context;
        }
        public Task<Purchase> Add(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Purchase>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Update(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Purchase>> GetPurchaseByUserId(int userId)
        {
            var purchase = await _context.Set<Purchase>()
                .Include(p => p.Movie)
                .Where(x => x.UserId == userId).ToListAsync();

            return purchase;
        }


        public async Task<bool> AddPurchaseToUserId(CartDetailModel entity)
        {
            throw new Exception();
        }

        public Task<Purchase> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Purchase> CreatePurchaseAPI(PurchaseRequestModel entity)
        {
            throw new Exception();
        }


        public async Task<bool> IsMoviePurcahsed(int userId, int movieId)
        {
            var p = await _context.Set<Purchase>().FirstOrDefaultAsync(p => p.UserId == userId && p.MovieId == movieId);
            return p != null;

        }

        public async Task<Purchase> GetPurchaseDetailByMovieId(int userId, int movieId)
        {
            var purchase = await _context.Set<Purchase>().FirstOrDefaultAsync(p => p.UserId == userId && p.MovieId == movieId);
            if (purchase != null)
            {
                return purchase;
            }
            throw new Exception("no such purchase exists!");

        }
    }
}