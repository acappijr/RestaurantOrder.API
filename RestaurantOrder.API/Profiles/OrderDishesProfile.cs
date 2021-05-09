using AutoMapper;
using RestaurantOrder.Domain.Entities;
using RestaurantOrder.Domain.Models;

namespace RestaurantOrder.API.Profiles
{
    public class OrderDishesProfile : Profile
    {
        public OrderDishesProfile()
        {
            CreateMap<OrderDishes, OrderDishesDto>()
                .ForMember(
                    dest => dest.DishName,
                    opt => opt.MapFrom(src => src.Dish.DishName)
                )
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Dish.Price * src.Quantity)
                );
        }
    }
}
