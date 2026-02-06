using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ConstructionBackend1._0.DTOs.Projects
{
    public class CreateProjectDto : IValidatableObject
    {
        [Required]
        [StringLength(
            200,
            MinimumLength = 3,
            ErrorMessage = "Number of characters must be between 3- 200 chars"
        )]
        public string ProjectName { get; set; }


        [MaxLength(1000, ErrorMessage = "Number of characters must be below 1000 chars")]
        public string? Description { get; set; }


        [Required]
        public DateTimeOffset StartDate { get; set; }


        [Required]
        public DateTimeOffset EndDate { get; set; }


        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="cant be less than 1")]
        // ID of the user creating the project
        public int CreatorID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate <= StartDate)
                yield return new ValidationResult(
                    "EndDate Cannot Be Before The StartDate",new[] {nameof(EndDate)}
                    );
        }
    }
}
