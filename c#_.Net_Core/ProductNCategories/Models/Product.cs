using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductNCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}
        
        [Required]
        [MinLength(2, ErrorMessage ="Name needs to be at least 2 characters long")]
        [Display(Name = "Name")]
        public string Name {get; set;}

        [Required]
        [Display(Name = "Description")]
        public string Description {get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Needs to be greate than 0")]
        public decimal Price {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<ProdCategory> ProdCategories {get; set;}
    }
}