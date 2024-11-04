using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();

        Task<int> SaveNewOrder(Order Order);

        Task<IEnumerable<Order>> GetByCustomerId(int customerId);

        Task<int> DeleteOrder(int orderId);

        Task<int> UpdateOrder(Order order);
    }
}
