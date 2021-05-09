using System;
using System.Collections.Generic;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Domain.Models
{
    public class OrderDishesDto
    {
        public Guid DishId { get; set; }

        public string DishName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
