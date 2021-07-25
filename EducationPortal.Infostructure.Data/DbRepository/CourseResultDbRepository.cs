using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using EducationPortal.Models;
using EducationPortal.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Persistence.DbRepository
{
    public class CourseResultDbRepository : ICourseResultRepository
    {
        protected EducationPortalDbContext _dbContext;
        public CourseResultDbRepository(EducationPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatAsync(CourseResult entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CourseResult>> GetByUser(int userId)
        {
            return await _dbContext.CourseResults
                .Where(u => u.UserId == userId)
                .Include(x => x.User)
                .Include(x => x.Course)
                .ToListAsync();
        }
    }
}
