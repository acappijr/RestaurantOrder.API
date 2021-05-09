using System;
using System.Collections.Generic;

namespace RestaurantOrder.Domain.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public string Customer { get; set; }

        public decimal Price { get; set; }

    }
}
