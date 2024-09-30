using Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Core.Models.Requests
{
    public class UserRegRequest : IValidatableObject
    {
        [Required]
        public string FullName { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public Job JobTitle { get; set; }

        // as an alternative, we can use Fluent Validation lib
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            
          //  if (!InputValidator.IsEmailValid(Email)) results.Add(new ValidationResult("Invalid email address"));

           // if (!InputValidator.IsPasswordValid(Password)) results.Add(new ValidationResult("Invalid password"));

            return results;
        }
    }
}
