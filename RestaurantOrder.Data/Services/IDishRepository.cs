using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Data.Services
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetDishesAsync();
        Task<Dish> GetDishAsync(Guid dishId);
        Task<IEnumerable<Dish>> GetDishesAsync(IEnumerable<Guid> dishIds);
        void AddDish(Dish dish);
        Task<bool> DishExistsAsync(Guid dishId);
        Task<bool> Save();
    }
}
