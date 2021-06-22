using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Application.Model
{
    public class CreateBookRequest : CreateMaterialRequest
    {
        public string Author { get; set; }
        [Range(1,int.MaxValue)]
        public int PageNumber { get; set; }
        [Range(1985, int.MaxValue)]
        public string YearOfPublication { get; set; }
    }
}
