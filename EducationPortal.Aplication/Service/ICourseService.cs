using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using System.Collections.Generic;

namespace EducationPortal.Application.Service
{
    public interface ICourseService
    {
        void CreateCourse(CreateCourseRequest requst);
        List<Course>GetAll();
        Course AddMaterial(Course course, Material material);
        Course GetById(long courseId);
    }
}
