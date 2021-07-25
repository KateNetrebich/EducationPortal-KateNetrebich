using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public interface ICourseService
    {
        Task<Course> CreateCourse(CreateCourseRequest request);
        Task<List<Course>> GetAll();
        Task<Course> AddMaterial(Course course, Material material);
        Task<Course> GetById(int courseId);
        Task<Course> Update(UpdateCourseRequest request, int id);
    }
}
