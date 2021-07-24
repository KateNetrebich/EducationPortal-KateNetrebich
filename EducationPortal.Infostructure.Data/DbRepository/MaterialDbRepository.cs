using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using EducationPortal.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Persistence.DbRepository
{
    public class MaterialDbRepository : IRepository<Material>
    {
        protected EducationPortalDbContext _dbContext;
        public MaterialDbRepository(EducationPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreatAsync(Material entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Material entity)
        {
             _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            
        }

        public async Task<Material> FindAsync(int id)
        {
            return await _dbContext.Materials.Where(b => b.Id == id).Include(x=>x.Courses).FirstOrDefaultAsync();
        }

        public Task<List<Material>> GetAsync(int pageNumber , int pageSize)
        {
            return _dbContext.Materials.Include(x=>x.Courses).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Material> SaveAsync(Material entity)
        {  
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
