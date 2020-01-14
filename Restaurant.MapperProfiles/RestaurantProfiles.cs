using AutoMapper;
using DTOModels;
using System;

namespace Restaurant.MapperProfiles
{
    public class RestaurantProfiles: Profile
    {
        public RestaurantProfiles() 
        {
            CreateMap<Entity.Restaurant, RestaurantDto>()
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => $"{src.Street}, {src.Locality}, {src.City}" +
                                            $", {src.State}, {src.Postcode}.") 
                );
        }
    }
}
