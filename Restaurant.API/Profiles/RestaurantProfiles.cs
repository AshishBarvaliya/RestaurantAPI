using AutoMapper;
using DTOModels;
using Restaurant.API;
using Restaurant.Helpers;
using Restuarant.DTOModels;

namespace Restaurant.MapperProfiles
{
    public class RestaurantProfiles: Profile
    {
        public RestaurantProfiles() 
        {
            CreateMap<Entity.Restaurant, RestaurantDto>()
                .ForMember(dest => dest.CuisineTypes,
                            obj => obj.MapFrom(src => src.GetCuisineTypeFromResCuis()));
                
            CreateMap<RestaurantDto, Entity.Restaurant>()
                .ForMember(dest => dest.RestaurantCuisine,
                            obj => obj.MapFrom(src => src.AddCuisineTypeToResCuis()));

            CreateMap<RestaurantDtoForUpdate, Entity.Restaurant>();
            CreateMap<Entity.Restaurant, RestaurantDtoForUpdate>();
        }
    }
}
