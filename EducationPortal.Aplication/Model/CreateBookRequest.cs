using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Application.Model
{
    public class CreateBookRequest : CreateMaterialRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Author { get; set; }

        [Required]
        [Range(20, 1000)]
        public int PageNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime YearOfPublication { get; set; }
    }
}
