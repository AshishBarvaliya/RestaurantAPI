using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entity
{
    public class Ratings
    {
        [Required]        
        public int Id { get; set; }
        
        [Required]
        [MaxLength(2)]
        public int Rating { get; set; }

        //Relation
        [ForeignKey("RestaurantId")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
