using EducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Application.Model
{
    public class CreateMaterialRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
