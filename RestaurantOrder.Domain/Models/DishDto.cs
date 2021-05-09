using System;

namespace RestaurantOrder.Domain.Models
{
    public class DishDto
    {
        public Guid Id { get; set; }

        public string DishName { get; set; }

        public decimal Price { get; set; }
    }
}
