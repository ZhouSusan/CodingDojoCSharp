using System.ComponentModel.DataAnnotations;

namespace DojoSurveyValidator.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2, ErrorMessage ="Field must be 2 characters or more")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Please select a location")]
        public string Location {get; set;}

        [Required(ErrorMessage ="Please select a language")]
        public string Language {get; set;}

        [MaxLength(20, ErrorMessage ="Field be less than 20 characters")]
        public string Comment {get; set;}
    }
}