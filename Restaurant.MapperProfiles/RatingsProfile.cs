using AutoMapper;
using Restaurant.Entity;
using Restuarant.DTOModels;

namespace Restaurant.MapperProfiles
{
    public class RatingsProfile : Profile
    {
        public RatingsProfile() 
        {
            CreateMap<Ratings, RatingsDto>();
        }
    }
}
