using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restuarant.DTOModels
{
    /// <summary>
    /// rating class with id and rating of a restaurant.
    /// </summary>
    public class RatingsDto
    {
        /// <summary>
        /// id of rating
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// rating of restaurant
        /// </summary>
        [Required]
        public int Rating { get; set; }
        //public int RestaurantId { get; set; }
    }
}
