using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Data.Services;
using RestaurantOrder.Domain.Models;

namespace RestaurantOrder.API.Controllers
{
    [ApiController]
    [Route("api/orders/{orderId}/dishes")]
    public class OrderDishesController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderDishesController(IOrderRepository orderRepository, IDishRepository dishRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<OrderDishesDto>> GetDishesForOrder(Guid orderId)
        {
            if (!await _orderRepository.OrderExistsAsync(orderId))
            {
                return NotFound();
            }

            var orderRepo = await _orderRepository.GetOrderAsync(orderId);
            return Ok(_mapper.Map<IEnumerable<OrderDishesDto>>(orderRepo.OrderDishes));
        }
    }
}
