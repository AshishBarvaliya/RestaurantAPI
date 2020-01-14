using AutoMapper;
using DTOModels;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Entity;
using Restaurant.Services;
using Restuarant.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/restaurants/{restaurantId}/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly IRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RatingsController(IRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository ??
                    throw new ArgumentNullException(nameof(restaurantRepository));
            _mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetRatings")]
        public async Task<ActionResult<IEnumerable<RatingsDto>>> GetRatings(int restaurantId)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
            {
                return NotFound();
            }
            var ratingOfRestaurant = await _restaurantRepository.GetRatings(restaurantId);
            return Ok(_mapper.Map <IEnumerable<RatingsDto>>(ratingOfRestaurant));
        }
        
        [HttpGet("{ratingId}")]
        public async Task<ActionResult<RatingsDto>> GetRating(int restaurantId,int ratingId)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
            {
                return NotFound();
            }
            var ratingOfRestaurant =await _restaurantRepository.GetRatings(restaurantId, ratingId);
            if (ratingOfRestaurant == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RatingsDto>(ratingOfRestaurant));
        }

        [HttpPost]
        public ActionResult<RatingsDto> AddRatings(int restaurantId, RatingsDto ratingsDto)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false))
            {
                return NotFound();
            }
            var ratings = _mapper.Map<Ratings>(ratingsDto);
            ratings = _restaurantRepository.AddRating(restaurantId,ratings);
            _restaurantRepository.Save();
            var _ratingsDto = _mapper.Map<RatingsDto>(ratings);
            return CreatedAtRoute("GetRatings", new { restaurantId = _ratingsDto.Id },
                                                        _ratingsDto);
        }
        
        [HttpPut("{ratingId}")]
        public ActionResult UpdateRatings(int restaurantId, int ratingId, RatingsDto ratings)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false)
                && _restaurantRepository.GetRatings(restaurantId, ratingId) == null)
                return NotFound();

            _restaurantRepository.UpdateRatings(restaurantId, ratingId, ratings);
            _restaurantRepository.Save();
            return Ok();
        }
        [HttpDelete("{ratingId}")]
        public ActionResult DeleteRatingsForRestaurant(int restaurantId, int ratingId)
        {
            if (_restaurantRepository.RestaurantExists(restaurantId) == Task.FromResult(false)
                && _restaurantRepository.GetRatings(restaurantId, ratingId) == null)
                return NotFound();

            _restaurantRepository.DeleteRating(ratingId);
            _restaurantRepository.Save();
            return Ok();
        }
    }
}

