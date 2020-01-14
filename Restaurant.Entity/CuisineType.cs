using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Entity
{
    public class CuisineType
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        public ICollection<RestaurantCuisine> RestaurantCuisine { get; set; }
    }
}