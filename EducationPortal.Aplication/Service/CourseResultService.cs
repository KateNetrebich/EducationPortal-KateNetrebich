using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using EducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task AddCourse(User user, Course course)
        {
            var courseResult = new CourseResult
            {
                UserId = user.Id,
                CourseId = course.Id
            };
            _repository.CreateAsync(courseResult);
        }

        public async Task<List<CourseResultInfo>> GetByUser()
        {
            throw new Exception();
            //return await _repository.GetAsync()
            //    .Where(result => result.StudentName == user.Username)
            //    .Select(async result =>
            //    {
            //        var course = await courseService.GetById(result.CourseId);
            //        return new CourseResultInfo
            //        {
            //            Result = result,
            //            Course = course
            //        };
            //    }).;
        }
    }

}

