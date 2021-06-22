using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> SaveAsync(TEntity entity);
    }
}
