using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class VideoMaterial : Material
    {
        public VideoMaterial()
        {

        }

        public VideoMaterial(string name, string description, string duration, string quality) : base(name, description)
        {
            Name = name;
            Description = description;
            Duration = duration;
            Quality = quality;
        }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 10 символов")]
        [DataType(DataType.Text)]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 10 символов")]
        [DataType(DataType.Text)]
        public string Quality { get; set; }
    }
}
