using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Domain.Models
{
    public class OrderForCreationDto
    {
        public OrderForCreationDto()
        {
            Dishes = new List<DishForOrderCreationDto>();
        }
        
        [MaxLength(120)]
        public string Customer { get; set; }

        public ICollection<DishForOrderCreationDto> Dishes { get; set; }
    }
}
