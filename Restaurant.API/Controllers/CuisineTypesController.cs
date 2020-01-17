using AutoMapper;
using DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Entity;
using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Produces("application/json")]
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

        /// <summary>
        /// get all cuisineTypes of restaurant serves.  
        /// </summary>
        /// <param name="restaurantId"> id of the restaurant</param>
        /// <returns>all name cuisines</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CuisineTypeDto>>> GetCuisineTypes(int restaurantId)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
            {
                return NotFound();
            }
            var cuisineTypeOfRestaurant =await _restaurantRepository.GetCuisineTypes(restaurantId);
            return Ok(_mapper.Map<IEnumerable<CuisineTypeDto>>(cuisineTypeOfRestaurant));
        }
        /// <summary>
        /// get a cuisine type of restaurant
        /// </summary>
        /// <param name="restaurantId"> id of the restaurant</param>
        /// <param name="cuisineId">id of cuisinetype</param>
        /// <returns>a cuisinetype</returns>
        [HttpGet("{cuisineId}", Name = "GetOneCuisineType")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        
        /// <summary>
        /// add new cuisine to restaurant
        /// </summary>
        /// <param name="restaurantId">id of restaurant</param>
        /// <param name="cuisineTypeDto">cuisnine type that you want to add</param>
        /// <returns>nothing</returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
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

        /// <summary>
        /// delete cuisine from restaurant
        /// </summary>
        /// <param name="restaurantId">id of restaurant</param>
        /// <param name="cuisineId">cuisnine id that you want to delete</param>
        /// <returns>nothing</returns>
        [HttpDelete("{cuisineId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
