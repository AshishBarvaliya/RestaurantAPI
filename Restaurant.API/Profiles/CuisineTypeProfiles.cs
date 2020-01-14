using AutoMapper;
using DTOModels;
using Restaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API.Profiles
{
    public class CuisineTypeProfiles:Profile
    {
        public CuisineTypeProfiles()
        {
            CreateMap<CuisineType, CuisineTypeDto>();
            CreateMap<CuisineTypeDto, CuisineType>();
        }
    }
}
