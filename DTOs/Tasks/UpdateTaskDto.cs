using System.ComponentModel.DataAnnotations;

namespace ConstructionBackend1._0.DTOs.Tasks
{
    public class UpdateTaskDto
    {

        [StringLength(
            200,
            MinimumLength = 3,
            ErrorMessage = "Number of characters must be between 3- 200 chars"
        )]
        public string TaskName { get; set; }

        [StringLength(
            1000,
            ErrorMessage = "Number of characters must be below 1000 hars"
        )]
        public string Description { get; set; }

        [StringLength(
           50,
           MinimumLength = 1,
           ErrorMessage = "Number of characters must be below 1000 hars"
       )]
        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        
        [Range(1, int.MaxValue, ErrorMessage = "cant be less than 1")]
        public int AssignedTo { get; set; }
    }
}
