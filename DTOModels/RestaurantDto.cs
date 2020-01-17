using Restaurant.Entity;
using Restuarant.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOModels
{
    /// <summary>
    /// Restaurant(Dto) with address, ratings and cuisineTypes. 
    /// </summary>
    public class RestaurantDto
    {
        /// <summary>
        /// Unique Id of Restaurant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Restaurant.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Street name of address of a Restaurant.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        /// <summary>
        /// Locality name of address of a Restaurant.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Locality { get; set; }

        /// <summary>
        /// City name of address of a Restaurant.
        /// </summary>

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        /// <summary>
        /// State name of address of a Restaurant.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string State { get; set; }

        /// <summary>
        /// Postcode of address of a Restaurant.
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }

        /// <summary>
        /// Latitude of a Restaurant.
        /// </summary>
        [Required]
        public double Lat { get; set; }

        /// <summary>
        /// Longitude of a Restaurant.
        /// </summary>
        [Required]
        public double Lng { get; set; }

        /// <summary>
        /// Ratings of a Restaurant.
        /// </summary>
        public ICollection<RatingsDto> Ratings { get; set; } = new List<RatingsDto>();
        /// <summary>
        /// Types of Cuisines serves by the Restaurant.
        /// </summary>
        public ICollection<CuisineTypeDto> CuisineTypes { get; set; } = new List<CuisineTypeDto>();

    }
}
