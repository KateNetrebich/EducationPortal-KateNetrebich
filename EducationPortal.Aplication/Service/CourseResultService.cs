using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using EducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public class CourseResultService : ICourseResultService
    {
        private ICourseResultRepository _repository;
        public CourseResultService(ICourseResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<CourseResult> AddCourseResult(CreateCourseResultRequest request)
        {
            var courseResult = new CourseResult
            {
                UserId = request.UserId,
                CourseId = request.CourseId,
                CourseDateTime = request.CourseDateTime,
                Condition = request.Condition
            };
            await _repository.CreatAsync(courseResult);
            return courseResult;
        }


        public async Task<List<CourseResult>> GetByUser(int userId)
        {
            return await _repository.GetByUser(userId);
            
        }
    }

}


