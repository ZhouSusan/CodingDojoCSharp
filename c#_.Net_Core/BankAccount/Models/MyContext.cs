using Microsoft.EntityFrameworkCore;
using BankAccount.Models;

namespace BankAccount.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users{ get; set; }
        public DbSet<Transaction> Transaction {get; set;}

        
    }
}