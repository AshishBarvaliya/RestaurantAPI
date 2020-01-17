using DTOModels;
using Restaurant.Entity;
using System;
using System.Collections.Generic;

namespace Restaurant.Helpers
{
    public static class GetData
    {
        //private static readonly IMapper _mapper;
        //public GetData(IMapper mapper)
        //{
        //    _mapper = mapper ??
        //           throw new ArgumentNullException(nameof(mapper));
        //}
        public static List<CuisineType> GetCuisineTypeFromResCuis(
            this Entity.Restaurant restaurant)
        {
            List<CuisineType> cuisineTypes = new List<CuisineType>();
            foreach (RestaurantCuisine restaurantCuisine in restaurant.RestaurantCuisine)
                cuisineTypes.Add(restaurantCuisine.CuisineType);
            
            return cuisineTypes;
        }
        public static List<RestaurantCuisine> AddCuisineTypeToResCuis(
            this RestaurantDto restaurantDto)
        {
            List<RestaurantCuisine> restaurantCuisineTypes = new List<RestaurantCuisine>();
           
            foreach (var cuisineTypeDto in restaurantDto.CuisineTypes)
            {
                CuisineType temp =new CuisineType();
                RestaurantCuisine restaurantCuisine = new RestaurantCuisine();
                temp.Type = cuisineTypeDto.Type;
                restaurantCuisine.CuisineType = temp;
                restaurantCuisineTypes.Add(restaurantCuisine);
            }
            return restaurantCuisineTypes;
        }
    }
}
