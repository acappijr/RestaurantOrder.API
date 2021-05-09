using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Data.Services
{
    public class DishRepository : IDishRepository, IDisposable
    {
        private readonly RestaurantOrderContext _context;

        public DishRepository(RestaurantOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddDish(Dish dish)
        {
            if (dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }

            dish.Id = Guid.NewGuid();

            _context.Dishes.Add(dish);
        }

        public async Task<bool> DishExistsAsync(Guid dishId)
        {
            if (dishId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(dishId));
            }

            return await _context.Dishes.AnyAsync(d => d.Id == dishId);
        }

        public async Task<Dish> GetDishAsync(Guid dishId)
        {
            if (dishId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(dishId));
            }

            return await _context.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync()
        {
            return await _context.Dishes.ToListAsync<Dish>();
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync(IEnumerable<Guid> dishIds)
        {
            if (dishIds == null)
            {
                throw new ArgumentNullException(nameof(dishIds));
            }

            return await _context.Dishes.Where(d => dishIds.Contains(d.Id))
                .OrderBy(d => d.DishName)
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
