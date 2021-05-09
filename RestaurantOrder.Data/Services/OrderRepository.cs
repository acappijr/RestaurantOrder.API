using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Data.Services
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly RestaurantOrderContext _context;

        public OrderRepository(RestaurantOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            order.Id = Guid.NewGuid();
            var dishesRepo = _context.Dishes.Where(d => order.OrderDishes.Select(od => od.DishId).Contains(d.Id));
            foreach (var orderDish in order.OrderDishes)
            {
                orderDish.Price = dishesRepo.First(x => x.Id == orderDish.DishId).Price;
            }

            order.Price = order.OrderDishes.Select(od => od.Price * od.Quantity).Sum();
            _context.Orders.Add(order);
        }

        public async Task<bool> OrderExistsAsync(Guid orderId)
        {
            if (orderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(orderId));
            }

            return await _context.Orders.AnyAsync(o => o.Id == orderId);
        }
        
        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            if (orderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(orderId));
            }
            return await _context.Orders.OrderBy(o => o.CreationDateTime).Include(o => o.OrderDishes)
                .ThenInclude(od => od.Dish)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.Include(o => o.OrderDishes)
                .ThenInclude(od => od.Dish).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(IEnumerable<Guid> orderIds)
        {
            if (orderIds == null)
            {
                throw new ArgumentNullException(nameof(orderIds));
            }

            return await _context.Orders.Where(d => orderIds.Contains(d.Id))
                .OrderBy(o => o.CreationDateTime)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
