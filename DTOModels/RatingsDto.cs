using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restuarant.DTOModels
{
    public class RatingsDto
    {
        public int Id { get; set; }
        
        [Required]
        public int Rating { get; set; }
        //public int RestaurantId { get; set; }
    }
}
