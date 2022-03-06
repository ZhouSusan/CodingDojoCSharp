using Microsoft.EntityFrameworkCore;
using ChefDishes.Models;

namespace ChefDishes
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<Chef> Chefs {get; set;}
        public DbSet<Dish> Dishes {get; set;}

    }   
}