using EducationPortal.Data;
using EducationPortal.Data.Entities;
using EducationPortal.Repositories.FileRepository;

namespace EducationPortal.Persistence.FileRepository
{
    public class MaterialJsonRepository : JsonRepository<Material, long>, IMaterialRepository
    {
        public MaterialJsonRepository(string filename) : base(filename)
        {
        }
    }
}
