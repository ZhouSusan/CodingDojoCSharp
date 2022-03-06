using System;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class LogUser
    {
    [Required]
    [EmailAddress]
    public string LoginEmail {get; set;}

    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage="Must be 8 characters or longer!")]
    public string LoginPassword {get; set;}
    }
}