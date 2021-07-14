using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreatAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        Task<List<TEntity>> GetAsync(int pageNumber, int pageSize);
        Task<TEntity> SaveAsync(TEntity entity);
    }
}
