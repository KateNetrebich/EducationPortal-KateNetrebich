using System;

namespace EducationPortal.Application.Model
{
    public class CreateBookRequest : CreateMaterialRequest
    {
        public string Author { get; set; }
        public int PageNumber { get; set; }
        public DateTime YearOfPublication { get; set; }
    }
}
