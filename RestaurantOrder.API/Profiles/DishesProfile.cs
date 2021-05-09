using AutoMapper;
using RestaurantOrder.Domain.Entities;
using RestaurantOrder.Domain.Models;

namespace RestaurantOrder.API.Profiles
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();
        }
    }
}
