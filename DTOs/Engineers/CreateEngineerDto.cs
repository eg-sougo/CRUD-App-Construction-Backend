namespace ConstructionBackend1._0.DTOs.Engineers
{
    public class CreateEngineerDto
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; } = null!;

    }
}
