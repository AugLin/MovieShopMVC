using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("GetAllOrders")]
        [HttpPost]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            if (orders == null)
            {
                return NotFound("No Order found");
            }
            return Ok(orders);
        }

        [Route("SaveNewOrder/{order}")]
        [HttpPost]
        public async Task<IActionResult> SaveNewOrder(Order order)
        {
            var orderResponse = await _orderService.SaveNewOrder(order);
            if (orderResponse == null)
            {
                return BadRequest("Can not Save a new Order");
            }

            return Ok(orderResponse);
        }

        [Route("GetByCustomerId/{id}")]
        [HttpPost]
        public async Task<IActionResult> GetOrderByCustomerId(int id)
        {
            var orders = await _orderService.GetByCustomerId(id);

            if (orders == null)
            {
                return BadRequest("No order found");
            }

            return Ok(orders);
        }

        [Route("DeleteOrder/{id}")]
        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleteResponse = await _orderService.DeleteOrder(id);
            if (deleteResponse == null)
            {
                return BadRequest("Unable to Delete order");
            }
            return Ok(deleteResponse);
        }

        [Route("UpdateOrder/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            var updateResponse = await _orderService.UpdateOrder(order);
            if (updateResponse == null)
            {
                return BadRequest("Unable to Update Order");
            }
            return Ok(updateResponse);
        }
    }
}
