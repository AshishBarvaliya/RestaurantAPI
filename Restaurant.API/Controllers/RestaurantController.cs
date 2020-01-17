using AutoMapper;
using DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services;
using Restuarant.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : ControllerBase
    {

       private readonly IRepository _restaurantRepository;
       private readonly IMapper _mapper;

       public RestaurantController(IRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository ??
                    throw new ArgumentNullException(nameof(restaurantRepository));
            _mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get Restaurant by an Id.
        /// </summary>
        /// <param name="restaurantId">The Id of the restaurant you want to get</param>
        /// <returns>details of the restaurant</returns>
        [HttpGet("{restaurantId}",Name ="GetRestaurant")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RestaurantDto>> GetRestaurant(int restaurantId)
        {
            var restaurantFromRepo = await _restaurantRepository.GetRestaurants(restaurantId);
            if (restaurantFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RestaurantDto>(restaurantFromRepo));
        }

        /// <summary>
        /// Get all Restaurants.
        /// </summary>
        /// <param name="state"> filter parameter (filter by State)[optional]</param>
        /// <param name="searchQuery">search query [optional]</param>
        /// <returns>details of restaurants</returns>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetRestaurants(
                                [FromQuery] string state, string searchQuery )
        {
            var restaurantsFromRepo = await _restaurantRepository.GetRestaurants(state, searchQuery);
            return Ok(_mapper.Map<IEnumerable<RestaurantDto>>(restaurantsFromRepo));
        }
        
        /// <summary>
        /// Add a restaurant
        /// </summary>
        /// <param name="restaurantDto">model of restaurant with all entities </param>
        /// <returns>added restaurant</returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult AddRestaurant(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Entity.Restaurant>(restaurantDto);            
            restaurant = _restaurantRepository.AddRestaurant(restaurant);
            _restaurantRepository.Save();
            var _restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return CreatedAtRoute("GetRestaurant",new { restaurantId = _restaurantDto.Id},
                                                        _restaurantDto);
        }
        
        /// <summary>
        /// update details a restaurant
        /// </summary>
        /// <param name="restaurantId">id of restaurant that you want to update</param>
        /// <param name="restaurant">new value of restaurant</param>
        /// <returns>nothing</returns>
        [HttpPut("{restaurantId}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> UpdateRestaurant(int restaurantId, RestaurantDtoForUpdate restaurant)
        {
            if (await _restaurantRepository.RestaurantExists(restaurantId) == false)
                return NotFound();

            await _restaurantRepository.UpdateRestaurant(restaurantId, restaurant);
            _restaurantRepository.Save();
            return Ok();
        }

        /// <summary>
        /// delete a restaurant
        /// </summary>
        /// <param name="restaurantId">id of restaurant that you want to delete</param>
        /// <returns>nothing</returns>
        [HttpDelete("{restaurantId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteRestaurant(int restaurantId)
        {
            if (await _restaurantRepository.RestaurantExists(restaurantId) == false)
                return NotFound();

            await _restaurantRepository.DeleteRestaurant(restaurantId);
            _restaurantRepository.Save();
            return Ok();
        }

        //[HttpPatch("{restaurantId}")]
        //public ActionResult PartiallyUpdateRestaurant(int restaurantId,
        //                                              JsonPatchDocument<RestaurantDtoForUpdate> patchDocument)
        //{
        //    if (!_restaurantRepository.RestaurantExists(restaurantId))
        //        return NotFound();

        //    var restaurantFromRepo = _restaurantRepository.GetRestaurants(restaurantId);
        //    var restaurantToPatch = _mapper.Map<RestaurantDtoForUpdate>(restaurantFromRepo);
        //    patchDocument.ApplyTo(restaurantToPatch);

        //    _restaurantRepository.UpdateRestaurant(restaurantId, restaurantToPatch);
        //    _restaurantRepository.Save();
        //    return CreatedAtRoute("GetRestaurant", new { restaurantId = restaurantFromRepo.Id },
        //                                                restaurantToPatch);
        //}
    }
}

