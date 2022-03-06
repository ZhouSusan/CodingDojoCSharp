using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models
{
    public class User
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(4, ErrorMessage ="Field must be 4 characters or more")]
        public string FirstName {get; set;}

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(4, ErrorMessage ="Field must be 4 characters or more")]
        public string LastName {get; set;}

        [Required]
        [Range(0, 200, ErrorMessage ="Age must be a postitive number")]
        public int Age {get; set;}

        [Display(Name ="Email Address")]
        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage ="Field must be 8 characters or more")]
        public string Password {get; set;}
    }
}