using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using EducationPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public interface ICourseResultService
    {
        public Task<CourseResult> AddCourseResult(CreateCourseResultRequest request);
        public Task<List<CourseResult>> GetByUser(int userId);
    }
}
