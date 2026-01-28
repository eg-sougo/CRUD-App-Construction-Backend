namespace ConstructionBackend1._0.DTOs.Tasks
{
    public class UpdateTaskDto
    {
        public string TaskName { get; set; }
        public string Description { get; set; }

        // Planned | InProgress | Completed (later replace with enum)
        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        // Engineer userId
        public int AssignedTo { get; set; }
    }
}
