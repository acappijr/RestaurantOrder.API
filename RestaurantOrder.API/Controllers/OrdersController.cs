using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Data.Services;
using RestaurantOrder.Domain.Entities;
using RestaurantOrder.Domain.Models;

namespace RestaurantOrder.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var ordersRepo = await _orderRepository.GetOrdersAsync();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(ordersRepo));
        }

        [HttpGet("{orderId}", Name = "GetOrderAsync")]
        public async Task<ActionResult<OrderDto>> GetOrders(Guid orderId)
        {
            var orderRepo = await _orderRepository.GetOrderAsync(orderId);
            if (orderRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OrderDto>(orderRepo));
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderForCreationDto order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _orderRepository.AddOrder(orderEntity);
            await _orderRepository.Save();

            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return CreatedAtRoute("GetOrderAsync",
                new {orderId = orderToReturn.Id},
                orderToReturn);
        }
    }
}
