﻿using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Application.Service
{
    public interface IMaterialService
    {
        public Material CreateMaterial(CreateMaterialRequest request);
        List<Material> GetAll();
        List<Material> GetByCourse(Course course);
    }
}
