using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public class CourseService : ICourseService
    {
        private IRepository<Course> _repository;

        public CourseService(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<Course> CreateCourse(CreateCourseRequest request)
        {
            var course = new Course
            {
                Name = request.Name,
                Description = request.Description,
                Skills = request.Skills,
                Garde =request.Grade
            };
            await _repository.CreatAsync(course);
            return course;
        }

        public Task<List<Course>> GetAll()
        {
            return _repository.GetAsync(1, 10);
        }

        public async Task<Course> AddMaterial(Course course, Material material)
        {
            course.Materials.Add(material);
            await _repository.SaveAsync(course);
            return course;
        }

        public async Task<Course> GetById(int courseId)
        {
            return await _repository.FindAsync(courseId);
        }

        public async Task<Course> Update(UpdateCourseRequest request,int id)
        {
            var course = await _repository.FindAsync(id+1);
            course.Name = request.Name ?? course.Name;
            return await _repository.SaveAsync(course);
        }
    }
}
