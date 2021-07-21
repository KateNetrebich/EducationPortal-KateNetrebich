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
    public class CourseDbRepository : IRepository<Course>
    {
        protected EducationPortalDbContext _dbContext;
        public CourseDbRepository(EducationPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatAsync(Course entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Course entity)
        {

            var course = new Course { Id = entity.Id };
            _dbContext.Remove(course);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Course> FindAsync(int id)
        {
            return _dbContext.Courses.Where(u => u.Id == id).Include(x => x.Materials).FirstOrDefaultAsync();
        }

        public Task<List<Course>> GetAsync(int pageNumber, int pageSize)
        {
            return _dbContext.Courses.Include(x => x.Materials).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Course> SaveAsync(Course entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
