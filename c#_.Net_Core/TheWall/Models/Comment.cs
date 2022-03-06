using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TheWall.Models
{
    public class Comment
    {
        [Key]
        public int CommentId {get; set;}
        public int UserId {get; set;}
        public int MessageId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage ="Comment must be at least 2 characters")]
        public string Comet {get; set;}

        public User ComCreator {get; set;}
        public Message Message {get; set;}
    }
}