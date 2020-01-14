using System.ComponentModel.DataAnnotations;

namespace Restaurant.Entity
{
    public class RestaurantCuisine
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RestaurantId { get; set; }
        
        [Required]
        public int CuisineTypeId { get; set; }

        //Relation
        public Restaurant Restaurant { get; set; }
        public CuisineType CuisineType { get; set; }

    }
}
