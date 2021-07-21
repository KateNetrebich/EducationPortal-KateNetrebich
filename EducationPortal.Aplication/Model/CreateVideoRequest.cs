using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Application.Model
{
    public class CreateVideoRequest : CreateMaterialRequest
    {

        [Required]
        [StringLength(10, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Duration { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Quality { get; set; }
    }
}
