using System.ComponentModel.DataAnnotations;

namespace ConstructionBackend1._0.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        [RegularExpression(@"^(?:\+91[\-\s]?|0)?[6-9]\d{9}$",
        ErrorMessage = "Phone number must be 10 digits and can/cannot start include the country code")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; } 
        public string Password { get; set; } = null!;

    }
}
