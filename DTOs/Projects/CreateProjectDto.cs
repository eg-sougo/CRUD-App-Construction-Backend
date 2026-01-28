namespace ConstructionBackend1._0.DTOs.Projects
{
    public class CreateProjectDto
    {
        // Required: project name
        public string ProjectName { get; set; }

        // Optional description
        public string? Description { get; set; }

        // Project start date
        public DateTime StartDate { get; set; }

        // Project end date (optional)
        public DateTime EndDate { get; set; }

        // ID of the user creating the project
        public int CreatorID { get; set; }
    }
}
