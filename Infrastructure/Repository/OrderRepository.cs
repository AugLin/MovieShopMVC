using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        private readonly MovieShopDbContext _context;

        public OrderRepository(MovieShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            var entity = await _context.Set<Order>().FindAsync(orderId);
            if (entity != null)
            {
                _context.Set<Order>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Set<Order>().ToListAsync(); ;
        }

        public async Task<IEnumerable<Order>> GetByCustomerId(int customerId)
        {
            return await _context.Set<Order>().Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<int> SaveNewOrder(Order Order)
        {
            await _context.Set<Order>().AddAsync(Order);
            foreach (var orderDetail in Order.Order_Detail)
            {
                await _context.Set<Order_Detail>().AddAsync(orderDetail);
                await _context.SaveChangesAsync();
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateOrder(Order order)
        {
            var orderOnDB = await _context.Set<Order>().FirstOrDefaultAsync(m => m.Id == order.Id);

            orderOnDB.Id = order.Id;
            orderOnDB.Order_Date = order.Order_Date;
            orderOnDB.CustomerId = order.CustomerId;
            orderOnDB.CustomerName = order.CustomerName;
            orderOnDB.PaymentMethod = order.PaymentMethod;
            orderOnDB.PaymentName = order.PaymentName;
            orderOnDB.ShippingAddress = order.ShippingAddress;
            orderOnDB.ShippingMethod = order.ShippingMethod;
            orderOnDB.BillAmount = order.BillAmount;
            orderOnDB.Order_Status = order.Order_Status;

            var orderDetails = _context.Set<Order_Detail>().Where(od => od.OrderId == order.Id);
            _context.Set<Order_Detail>().RemoveRange(orderDetails);
            await _context.SaveChangesAsync();

            foreach (var orderDetail in order.Order_Detail)
            {
                await _context.Set<Order_Detail>().AddAsync(orderDetail);
                await _context.SaveChangesAsync();
            }
            return _context.SaveChanges();
        }
    }
}
