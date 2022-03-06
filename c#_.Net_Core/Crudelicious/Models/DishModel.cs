using System;
using System.ComponentModel.DataAnnotations;

namespace Crudelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Chef {get; set;}

        [Required]
        [Range(1,5, ErrorMessage="Please select a number")]
        public int Tastiness {get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage="Calories must be greater than zero")]
        public int Calories {get; set;}

        [Required]
        public string Description {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }

    
}