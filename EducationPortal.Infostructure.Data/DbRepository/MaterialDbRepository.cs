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
    public class MaterialDbRepository : IMaterialRepository
    {
        protected EducationPortalDbContext _dbContext;
        public MaterialDbRepository(EducationPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Material entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async void DeleteAsync(Material entity)
        {
            try
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!(ex is InvalidOperationException) && !(ex is DbUpdateConcurrencyException))
                {
                    throw ex;
                }
            }
        }

        public async Task<Material> FindAsync(int id)
        {
            return await _dbContext.BookMaterials.Where(b => b.Id == id).FirstOrDefaultAsync() ?? throw new Exception();
        }

        public async Task<List<Material>> GetAsync()
        {
            return await _dbContext.Materials.ToListAsync();
        }

        public async Task<Material> SaveAsync(Material entity)
        {
            var material = await FindAsync(entity.Id);
            material.Name = entity.Name ?? material.Name;
            material.Description = entity.Description ?? material.Description;
            if (entity.Description != null)
            {
                throw new Exception();
            }
            _dbContext.Update(material);
            await _dbContext.SaveChangesAsync();
            return material;
        }
    }
}
