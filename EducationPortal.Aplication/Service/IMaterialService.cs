using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public interface IMaterialService
    {
        public Task<Material> CreateMaterial(CreateMaterialRequest request);
        Task<Material> Get(Material material);
        IEnumerable<Material> GetByCourse(Course course);
    }
}
