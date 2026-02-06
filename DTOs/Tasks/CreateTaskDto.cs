using System.ComponentModel.DataAnnotations;

namespace ConstructionBackend1._0.DTOs.Tasks
{
    public class CreateTaskDto : IValidatableObject
    {

        [Required]
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

        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public DateTimeOffset DueDate { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "cant be less than 1")]
        public int ProjectId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "cant be less than 1")]
        public int AssignedTo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DueDate <= StartDate)
                yield return new ValidationResult(
                    "DueDate Cannot Be Before The StartDate", new[] { nameof(DueDate) }
                    );
        }
    }
}
