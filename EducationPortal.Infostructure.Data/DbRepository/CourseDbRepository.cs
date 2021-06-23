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
    public class CourseDbRepository : ICourseRepository
    {
        protected EducationPortalDbContext _dbContext;
        public CourseDbRepository(EducationPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Course entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async void DeleteAsync(Course entity)
        {
            try
            {
                var course = new Course { Id = entity.Id };
                _dbContext.Remove(course);
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

        public Task<Course> FindAsync(int id)
        {
            return _dbContext.Courses.Where(u => u.Id == id).Include(x=>x.Materials).FirstOrDefaultAsync() ?? throw new Exception();
        }

        public async Task<List<Course>> GetAsync()
        {
            return await _dbContext.Courses.Include(x=>x.Materials).ToListAsync();
        }

        public async Task<Course> SaveAsync(Course entity)
        {
            var course = await FindAsync(entity.Id);
            course.Name = entity.Name ?? course.Name;
            course.Description = entity.Description ?? course.Description;
            if (entity.Description != null)
            {
                throw new Exception();
            }
            _dbContext.Update(course);
            await _dbContext.SaveChangesAsync();
            return course;
        }
    }
}
