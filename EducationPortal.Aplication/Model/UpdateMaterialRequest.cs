using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationPortal.Application.Model
{
    public class UpdateMaterialRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
