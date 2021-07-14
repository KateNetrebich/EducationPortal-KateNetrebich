using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using EducationPortal.Models;
using EducationPortal.Persistence.Contexts;
using System;
using System.Collections.Generic;
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
        private CourseResult CreatCourseResult(Course course, User user, CourseResultCondition condition)
        {
            return new CourseResult
            {
                UserId = user.Id,
                CourseId = course.Id,
                CourseDateTime = DateTime.Now,
                Condition = condition,
            };
        }

        public Task DeleteAsync(CourseResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResult> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseResult>> GetAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResult> SaveAsync(CourseResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
