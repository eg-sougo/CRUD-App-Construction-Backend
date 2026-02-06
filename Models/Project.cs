namespace ConstructionBackend1._0.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public required string ProjectName { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }


        public int CreatorID { get; set; }
        public User Creator { get; set; }


        //Navigation

        public ICollection<TaskItem> Tasks { get; set; }

    }
}
