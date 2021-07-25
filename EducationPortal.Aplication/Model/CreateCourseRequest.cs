using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Application.Model
{
    public class CreateCourseRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Skills { get; set; }

        [Required]
        [Range(1,12)]
        public int Grade { get; set; }
    }
}
