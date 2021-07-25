using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Application.Model
{
    public class CreateMaterialRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string URL { get; set; }
    }
}
