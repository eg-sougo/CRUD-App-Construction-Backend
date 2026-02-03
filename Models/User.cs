namespace ConstructionBackend1._0.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }   // MANAGER, SUPERVISOR, ENGINEER
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //Authorization Fields
        public string? HashedPassword { get; set; } = null!;

        // Navigation Properties
        public ICollection<Project>? ProjectsCreated { get; set; }
        public ICollection<TaskItem>? TasksAssigned { get; set; }
    }
}
