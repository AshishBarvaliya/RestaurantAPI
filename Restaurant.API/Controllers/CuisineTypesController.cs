using AutoMapper;
using DTOModels;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Entity;
using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/restaurants/{restaurantId}/cuisinetypes")]
    public class CuisineTypesController:ControllerBase
    {
        private readonly IRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public CuisineTypesController(IRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository ??
                    throw new ArgumentNullException(nameof(restaurantRepository));
            _mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuisineTypeDto>>> GetCuisineTypes(int restaurantId)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
            {
                return NotFound();
            }
            var cuisineTypeOfRestaurant =await _restaurantRepository.GetCuisineTypes(restaurantId);
            return Ok(_mapper.Map<IEnumerable<CuisineTypeDto>>(cuisineTypeOfRestaurant));
        }
        
        [HttpGet("{cuisineId}", Name = "GetOneCuisineType")]
        public async Task<ActionResult<CuisineTypeDto>> GetOneCuisineType(int restaurantId, int cuisineId)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
            {
                return NotFound();
            }
            var oneRestaurantCuisineObj =await _restaurantRepository.GetCuisineTypes(restaurantId, cuisineId);
            if (oneRestaurantCuisineObj == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CuisineTypeDto>(oneRestaurantCuisineObj.CuisineType));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCuisineType(int restaurantId, CuisineTypeDto cuisineTypeDto)
        {
            if (await _restaurantRepository.RestaurantExists(restaurantId) == false)
            {
                return NotFound();
            }
            var cuisineType = _mapper.Map<CuisineType>(cuisineTypeDto);
            _restaurantRepository.AddCuisineType(restaurantId, cuisineType);
            return Ok();
        }

        [HttpDelete("{cuisineId}")]
        public async Task<IActionResult> DeleteCuisineType(int restaurantId, int cuisineId)
        {
            if (await _restaurantRepository.RestaurantExists(restaurantId) == false
                && _restaurantRepository.GetCuisineTypes(restaurantId, cuisineId) == null)
            {
                return NotFound();
            }

            await _restaurantRepository.DeleteCuisineType(cuisineId);
            _restaurantRepository.Save();
            return Ok();
        }
    }
}
