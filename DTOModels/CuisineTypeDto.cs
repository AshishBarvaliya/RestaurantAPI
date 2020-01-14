

using System.ComponentModel.DataAnnotations;

namespace DTOModels

{
    public class CuisineTypeDto
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Type { get; set; }
    }
}
