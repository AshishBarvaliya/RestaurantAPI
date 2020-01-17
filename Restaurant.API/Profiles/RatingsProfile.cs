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
            CreateMap<RatingsDto, Ratings>();
            //CreateMap<RatingsDtoForUpdate, Ratings>();
            //CreateMap<Ratings, RatingsDtoForUpdate>();
        }
    }
}
