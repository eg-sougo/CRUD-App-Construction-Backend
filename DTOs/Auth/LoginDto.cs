namespace ConstructionBackend1._0.DTOs.Auth
{
    public class LoginDto
    {
        public string PhoneNumber { get; set; }
        public string? Email { get; set; } 
        public string Password { get; set; } = null!;

    }
}
