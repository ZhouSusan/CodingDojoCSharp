
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductNCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage ="Name must be at least two characters")]
        public string Name {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<ProdCategory> ProdCategories {get; set;}
    }
}