using EducationPortal.Data.Entities;
using EducationPortal.Infostructure.Data;
using EducationPortal.Repositories.FileRepository;

namespace EducationPortal.Persistence.FileRepository
{
    public class CourceJsonRepository : JsonRepository<Course, long>, ICourseRepository
    {
        public CourceJsonRepository(string filename) : base(filename)
        {
        }
    }
}
