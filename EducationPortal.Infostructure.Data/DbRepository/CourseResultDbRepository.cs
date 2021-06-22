using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Persistence.DbRepository
{
    public class CourseResultDbRepository : ICourseResultRepository
    {

        public Task CreateAsync(CourseResult entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(CourseResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResult> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseResult>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseResult> SaveAsync(CourseResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
