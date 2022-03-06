using Microsoft.EntityFrameworkCore;
using ProductNCategories.Models;

namespace ProductNCategories
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}

        public DbSet<ProdCategory> ProdCategories {get;set;}

    }   
}