using EducationPortal.Data;
using EducationPortal.Data.Entities;
using EducationPortal.Infostructure.Data;
using EducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Application.Service
{
    public class CourseResultService
    {
        private ICourseResultRepository _repository;
        private ICourseService courseService;
        public CourseResultService(ICourseResultRepository repository)
        {
            _repository = repository;
        }

        public void AddCourse(User user, Course course)
        {
            var courseResult = new CourseResult
            {
                StudentName = user.Username,
                CourseId = course.Id
            };
            _repository.Create(courseResult, DateTime.Now.ToFileTime());
        }

        public List<CourseResultInfo> GetByUser(User user)
        {
            return _repository.List()
                .Where(result => result.StudentName == user.Username)
                .Select(result =>
                {
                    var course = courseService.GetById(result.CourseId);
                    return new CourseResultInfo
                    {
                        Result = result,
                        Course = course
                    };
                }).ToList();
        }
    }

}

