using System.ComponentModel.DataAnnotations;

namespace ConstructionBackend1._0.DTOs.Projects
{
    public class UpdateProjectDto
    {
        [StringLength(
            200,
            MinimumLength = 3,
            ErrorMessage = "Number of characters must be between 3- 200 chars"
        )]
        public string ProjectName { get; set; }

        [StringLength(
            1000,
            ErrorMessage = "Number of characters must be below 1000 hars"
        )]
        public string Description { get; set; }

        [StringLength(
            50,
            MinimumLength =1,
            ErrorMessage = "Number of characters must be below 1000 hars"
        )]
        public string Status { get; set; }
    }

}
