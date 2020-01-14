using Restaurant.Entity;
using Restuarant.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOModels
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        [Required]
        [MaxLength(30)]
        public string Locality { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MaxLength(20)]
        public string State { get; set; }

        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }

        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }

        public ICollection<RatingsDto> Ratings { get; set; } = new List<RatingsDto>();
        public ICollection<CuisineTypeDto> CuisineTypes { get; set; } = new List<CuisineTypeDto>();

    }
}
