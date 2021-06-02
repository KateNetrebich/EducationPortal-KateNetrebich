using EducationPortal.Data;
using EducationPortal.Data.Entities;
using EducationPortal.Repositories.FileRepository;

namespace EducationPortal.Persistence.FileRepository
{
    public class CourseResultJsonRepository : JsonRepository<CourseResult, long>, ICourseResultRepository
    {
        public CourseResultJsonRepository(string filename) : base(filename)
        {
        }
    }
}
