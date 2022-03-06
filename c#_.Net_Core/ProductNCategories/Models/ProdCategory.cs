
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductNCategories.Models
{
    public class ProdCategory
    {
        [Key]
        public int ProdCategoryId {get; set;}

        public int ProductId {get; set;}
        public int CategoryId {get; set;}

        public Product Product {get; set;}

        public Category Category {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }
}