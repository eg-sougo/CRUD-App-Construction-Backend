using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionBackend1._0.Models
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DueDate { get; set; }

        // Foreign Keys
        public int ProjectId { get; set; }
        public Project Project { get; set; }


        public int AssignedTo { get; set; }
        [ForeignKey(nameof(AssignedTo))]
        public User Engineer { get; set; }
    }
}
