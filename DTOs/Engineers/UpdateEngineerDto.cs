using System.ComponentModel.DataAnnotations;

namespace ConstructionBackend1._0.DTOs.Engineers
{
    public class UpdateEngineerDto
    {
        [StringLength(
            100,
            MinimumLength = 2,
            ErrorMessage = "Number of characters must be between 2- 100 chars"
        )]
        public  string? FullName { get; set; }

        [RegularExpression("^(?:\\+91|91)?[6-9]\\d{9}$\r\n", ErrorMessage = "Invalid PhoneNumber Format")]
        public  string? PhoneNumber { get; set; }

        [EmailAddress]
        public String? Email { get; set; }

    }
}
