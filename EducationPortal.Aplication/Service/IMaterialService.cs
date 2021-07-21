using EducationPortal.Application.Model;
using EducationPortal.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public interface IMaterialService
    {
        Task<Material> CreateMaterial(CreateMaterialRequest request);
        Task<Material> Get(int materialId);
        Task<List<Material>> GetAll();
        IEnumerable<Material> GetByCourse(Course course);
        Task<Material> Update(UpdateMaterialRequest request, int id);
    }
}
