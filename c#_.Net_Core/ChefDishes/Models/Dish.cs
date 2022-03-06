
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDishes
{
    public class Dish 
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        [Display(Name = "Name of Dish:")]
        public string DishName {get; set;}

        [Required]
        [Display(Name ="# of Calories:")]
        [Range(1, int.MaxValue, ErrorMessage="Calories must be greater than one")]
        public int Calories {get; set;}

        [Required]
        [Range(1,5, ErrorMessage="Please select a number between 1 -5")]
        public int Tastiness {get; set;}

        [Required]
        [Display(Name = "Description")]
        public string Description {get; set;}


        [Required]
        [Display(Name = "Chef: ")]
        public int ChefId { get; set; }

        public string ChefName {get; set;}

        public Chef Creator{get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        [NotMapped]
        public List<Chef> Chefs { get; set;}
    }
}