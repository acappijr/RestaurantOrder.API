using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Data.Services;
using RestaurantOrder.Domain.Models;

namespace RestaurantOrder.API.Controllers
{
    [ApiController]
    [Route("api/dishes")]
    public class DishesController : ControllerBase
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public DishesController(IDishRepository dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository ?? throw new ArgumentNullException(nameof(dishRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetDishes()
        {
            var dishesRepo = await _dishRepository.GetDishesAsync();
            return Ok(_mapper.Map<IEnumerable<DishDto>>(dishesRepo));
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetDish(Guid dishId)
        {
            var dishRepo = await _dishRepository.GetDishAsync(dishId);
            if (dishRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DishDto>(dishRepo));
        }

        [HttpPatch]
        public IActionResult GetError()
        {
            //todo a custom message will be shown at production environment
            throw new Exception();
        }
    }
}
