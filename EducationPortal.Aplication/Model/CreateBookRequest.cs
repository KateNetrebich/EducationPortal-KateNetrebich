using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Application.Model
{
    public class CreateBookRequest : CreateMaterialRequest
    {
        public string Author { get; set; }
        public int PageNumber { get; set; }
        public int YearOfPublication { get; set; }
    }
}
