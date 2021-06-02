using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using EducationPortal.Infostructure.Data;
using System;
using System.Collections.Generic;

namespace EducationPortal.Application.Service
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _repository;
        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }
        public void CreateCourse(CreateCourseRequest requst)
        {
            var course = new Course
            {
                Name = requst.Name,
                Description = requst.Description,
                MaterialsIds = new List<long>()
            };
            _repository.Create(course, DateTime.Now.ToFileTime());
        }

        public List<Course> GetAll()
        {
            return  _repository.List();
        }

        public Course AddMaterial(Course course, Material material)
        {
            course.MaterialsIds.Add(material.Id);
            _repository.Update(course.Id, course);
            return course;
        }

        public Course GetById(long courseId)
        {
            return _repository.Get(courseId);
        }
    }
}
