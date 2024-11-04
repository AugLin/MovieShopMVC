using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<IEnumerable<Order>> GetAllOrders();

        public Task<int> SaveNewOrder(Order order);

        public Task<IEnumerable<Order>> GetByCustomerId(int customerId);

        public Task<int> DeleteOrder(int orderId);

        public Task<int> UpdateOrder(Order order);
    }
}
