using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class ArticleMaterial : Material
    {
        public ArticleMaterial()
        {

        }

        public ArticleMaterial(string name, string description, string url, DateTime publicationDate) : base(name, description)
        {
            Name = name;
            Description = description;
            URL = url;
            PublicationDate = publicationDate;
        }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        [DataType(DataType.Url)]
        public string URL { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
    }
}
