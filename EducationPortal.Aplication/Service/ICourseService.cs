using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Application.Service
{
    public interface ICourseService
    {
        void CreateCourse(CreateCourseRequest requst);
        List<Course>GetAll();
        Course AddMaterial(Course course, Material material);
    }
}
