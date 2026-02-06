using System.ComponentModel.DataAnnotations;

namespace ConstructionBackend1._0.DTOs.Engineers
{
    public class CreateEngineerDto
    {


        [Required]
        [StringLength(
            100,
            MinimumLength = 2,
            ErrorMessage = "Number of characters must be between 2- 100 chars"
        )]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?:\+91[\-\s]?|0)?[6-9]\d{9}$",
        ErrorMessage = "Phone number must be 10 digits and can/cannot start include the country code")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,50}$",
    ErrorMessage = "Password is not strong enough. Must contain a special character, a capital character, and a number")]
        public string Password { get; set; } = null!;


    }
}
