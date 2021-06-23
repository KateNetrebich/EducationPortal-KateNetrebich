using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCourse(CreateCourseRequest request)
        {
            var course = new Course
            {
                Name = request.Name,
                Description = request.Description
            };
            await _repository.CreateAsync(course);
        }

        public Task<List<Course>> GetAll()
        {
            return _repository.GetAsync();
        }

        public async Task<Course> AddMaterial(Course course, Material material)
        {
            course.Materials.Add(material);
            _repository.SaveAsync(course);
            return course;
        }

        public async Task<Course> GetById(int courseId)
        {
            return await _repository.FindAsync(courseId);
        }
    }
}
