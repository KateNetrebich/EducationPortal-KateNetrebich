using EducationPortal.Data.Entities;
using EducationPortal.Repositories;

namespace EducationPortal.Infostructure.Data
{
    public interface ICourseRepository : IRepository<Course, long>
    {
    }
}
