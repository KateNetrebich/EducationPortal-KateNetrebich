﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Data.Entities
{
    public class CourseMaterial
    {
        public CourseMaterial(int courseId, int materialId)
        {
            CourseId = courseId;
            MaterialId = materialId;
        }
        public int CourseId { get; set; }
        public int MaterialId { get; set; }

        public Material Material { get; set; }
        public Course Course { get; set; }
    }
}