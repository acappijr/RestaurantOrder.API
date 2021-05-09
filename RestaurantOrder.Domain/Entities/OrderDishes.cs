using System;

namespace RestaurantOrder.Domain.Entities
{
    public class OrderDishes
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
