using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            return await _orderRepository.Delete(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<IEnumerable<Order>> GetByCustomerId(int customerId)
        {
            return await _orderRepository.GetByCustomerId(customerId);
        }

        public async Task<int> SaveNewOrder(Order Order)
        {
            return await _orderRepository.SaveNewOrder(Order);
        }

        public async Task<int> UpdateOrder(Order order)
        {
            return await _orderRepository.UpdateOrder(order);
        }
    }
}
