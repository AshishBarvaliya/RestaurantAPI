using AutoMapper;
using DTOModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services;
using Restuarant.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
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

        [HttpGet("{restaurantId}",Name ="GetRestaurant")]
        public async Task<ActionResult<RestaurantDto>> GetRestaurant(int restaurantId)
        {
            var restaurantFromRepo = await _restaurantRepository.GetRestaurants(restaurantId);
            if (restaurantFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RestaurantDto>(restaurantFromRepo));
        }
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetRestaurants(
                                [FromQuery] string state, string searchQuery )
        {
            var restaurantsFromRepo = await _restaurantRepository.GetRestaurants(state, searchQuery);
            return Ok(_mapper.Map<IEnumerable<RestaurantDto>>(restaurantsFromRepo));
        }
        [HttpPost]
        public IActionResult AddRestaurant(RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Entity.Restaurant>(restaurantDto);            
            restaurant = _restaurantRepository.AddRestaurant(restaurant);
            _restaurantRepository.Save();
            var _restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return CreatedAtRoute("GetRestaurant",new { restaurantId = _restaurantDto.Id},
                                                        _restaurantDto);
        }
        [HttpPut("{restaurantId}")]
        public ActionResult UpdateRestaurant(int restaurantId, RestaurantDtoForUpdate restaurant)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
                return NotFound();

            _restaurantRepository.UpdateRestaurant(restaurantId, restaurant);
            _restaurantRepository.Save();
            return Ok();
        }
        
        [HttpDelete("{restaurantId}")]
        public ActionResult DeleteRestaurant(int restaurantId)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
                return NotFound();

            _restaurantRepository.DeleteRestaurant(restaurantId);
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

