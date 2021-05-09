using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDishes = new List<OrderDishes>();
            CreationDateTime = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [MaxLength(120)]
        public string Customer { get; set; }

        public DateTime CreationDateTime { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrderDishes> OrderDishes { get; set; }
    }
}
