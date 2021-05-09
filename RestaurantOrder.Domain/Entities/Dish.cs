using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Domain.Entities
{
    public class Dish
    {
        public Dish()
        {
            OrderDishes = new List<OrderDishes>();
            CreationDateTime = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string DishName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }

        public ICollection<OrderDishes> OrderDishes { get; set; }
    }
}
