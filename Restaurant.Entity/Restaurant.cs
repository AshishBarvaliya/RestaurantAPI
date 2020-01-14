using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Entity
{
    public class Restaurant
    {
        [Required]
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

        //Relation
        public ICollection<Ratings> Ratings { get; set; }
        public ICollection<RestaurantCuisine> RestaurantCuisine { get; set; }

    }
}
