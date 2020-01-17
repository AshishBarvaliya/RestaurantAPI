

using System.ComponentModel.DataAnnotations;

namespace DTOModels

{
    /// <summary>
    ///name of cuisine which serves by restaurants 
    /// </summary>
    public class CuisineTypeDto
    {
        /// <summary>
        /// cuisinetype id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// name of cuisine 
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Type { get; set; }
    }
}
