using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Data.Services
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(Guid orderId);
        Task<IEnumerable<Order>> GetOrdersAsync(IEnumerable<Guid> orderIds);
        void AddOrder(Order order);
        Task<bool> OrderExistsAsync(Guid orderId);
        Task<bool> Save();
    }
}
