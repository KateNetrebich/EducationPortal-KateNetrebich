using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationPortal.Application.Model
{
    public class AddMaterialToCourseRequest
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int MaterialId { get; set; }
    }
}
