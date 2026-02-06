namespace ConstructionBackend1._0.DTOs.Tasks
{
    public class ResponseTaskDto
    {
        public int TaskItemId { get; set; }
        public string TaskName { get; set; }

        public string Status { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DueDate { get; set; }

        // Project info
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        // Engineer info
        public int EngineerId { get; set; }
        public string EngineerName { get; set; }
    }
}
