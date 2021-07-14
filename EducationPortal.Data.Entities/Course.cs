using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class Course
    {
        public Course()
        {

        }

        public Course(int id, string name, string description, int materialsIds)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 256 символов")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public virtual List<Material> Materials { get; set; }
    }
}
