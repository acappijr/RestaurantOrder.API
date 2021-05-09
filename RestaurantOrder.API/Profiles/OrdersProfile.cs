using System;
using System.Linq;
using AutoMapper;
using RestaurantOrder.Domain.Entities;
using RestaurantOrder.Domain.Models;

namespace RestaurantOrder.API.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderDto>();

            CreateMap<OrderForCreationDto, Order>()
                .ForMember(
                    dest => dest.CreationDateTime,
                    opt => opt.MapFrom(src => new DateTime())
                )
                .ForMember(
                    dest => dest.OrderDishes,
                    opt => opt.MapFrom(src => src.Dishes.Select(d => new OrderDishes(){ DishId = d.Id, Quantity = d.Quantity }))
        );
    }
    }
}
