using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using EducationPortal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Application.Repositories
{
    public interface ICourseResultRepository 
    {
        Task CreatAsync(CourseResult courseResult);
        Task<List<CourseResult>> GetByUser(int userId);
    }
}
