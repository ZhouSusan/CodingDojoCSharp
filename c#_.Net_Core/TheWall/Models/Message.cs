using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TheWall.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        
        [Required]
        [MinLength(2, ErrorMessage ="Message must have at least 2 characters")]
        public string Msg {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<Comment> Comments {get; set;}
    }
}