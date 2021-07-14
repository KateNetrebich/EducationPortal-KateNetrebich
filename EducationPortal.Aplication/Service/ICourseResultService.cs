using EducationPortal.Data.Entities;
using EducationPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public interface ICourseResultService
    {
        public Task AddCourseResult(User user, Course course);
        public Task<List<CourseResultInfo>> GetByUser();
    }
}
