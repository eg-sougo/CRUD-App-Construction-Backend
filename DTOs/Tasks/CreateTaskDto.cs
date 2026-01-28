namespace ConstructionBackend1._0.DTOs.Tasks
{
    public class CreateTaskDto
    {
        public string TaskName { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        // Foreign keys
        public int ProjectId { get; set; }
        public int AssignedTo { get; set; }
    }
}
