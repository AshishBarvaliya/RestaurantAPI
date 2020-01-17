using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restuarant.DTOModels
{
    /// <summary>
    /// restaurant(update dto), get values from user to update resturant details. 
    /// </summary>
    public class RestaurantDtoForUpdate
    {
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
    }
}
