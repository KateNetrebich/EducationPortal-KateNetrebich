using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class BookMaterial : Material
    {
        public BookMaterial()
        {

        }
        public BookMaterial(string name, string description, string author, int pageNumber, DateTime year) : base(name, description)
        {
            Name = name;
            Description = description;
            Author = author;
            PageNumber = pageNumber;
            YearOfPublication = year;
        }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        [DataType(DataType.Text)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(20,1000,ErrorMessage = "Недопустимое кол-во страниц")]
        public int PageNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Date)]
        public DateTime YearOfPublication { get; set; }
    }
}
