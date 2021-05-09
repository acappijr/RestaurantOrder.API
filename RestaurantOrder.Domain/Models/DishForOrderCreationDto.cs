using System;
using System.ComponentModel.DataAnnotations;
//todo validations for bad requests
namespace RestaurantOrder.Domain.Models
{
    public class DishForOrderCreationDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
