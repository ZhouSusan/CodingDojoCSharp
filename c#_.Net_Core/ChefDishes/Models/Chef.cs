
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDishes
{
    public class Chef 
    {
        [Key]
        public int ChefId {get; set;}

        [Required]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [Required]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        [Required]
        [MinAge(18)]
        [Display(Name ="Date of Birth")]
        public DateTime Birthday {get; set;}

        public int Age 
        {
            get 
            {
                return DateTime.Now.Year - Birthday.Year;
            }
        }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<Dish> Dishes { get; set;}


            public class MinAge : ValidationAttribute
            {
                private int _Limit;
                public MinAge(int Limit)
                {
                    this._Limit = Limit;
                }
                protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
                {
                    DateTime bday = DateTime.Parse(value.ToString());
                    DateTime today = DateTime.Today;
                    int age = today.Year - bday.Year;
                    if (bday > today.AddYears(-age))
                    {
                        age--; 
                    }
                    if (age < _Limit)
                    {
                        var result = new ValidationResult("Chef must be 18 years or older");
                        return result; 
                    }            
                    return null;
                    }
                }
// public int DishCount()
//         {
//         if (Dishes == null)
//         {
//             return 0;
//         }
//         return Dishes.Count();
//     }
    }
}