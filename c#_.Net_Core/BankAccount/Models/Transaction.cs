using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get; set;}

        [Required]
        public decimal Amount {get; set;}

        public int UserId {get; set;}
        public User User {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}