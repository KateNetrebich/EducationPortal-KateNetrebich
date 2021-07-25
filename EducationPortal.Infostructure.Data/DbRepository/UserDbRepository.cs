using BCrypt.Net;
using EducationPortal.Application.Repositories;
using EducationPortal.Models;
using EducationPortal.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Persistence.DbRepository
{
    public class UserDbRepository : IUserRepository
    {
        protected EducationPortalDbContext _dbContext;
        public UserDbRepository(EducationPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatAsync(User entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<User> FindAsync(int id)
        {
            return _dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return _dbContext.Users
               .Where(u => u.Username == username)
               .FirstOrDefaultAsync();
        }

        public  Task<List<User>> GetAsync(int pageNumber, int pageSize)
        {
            return _dbContext.Users.Include(x=>x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<User> SaveAsync(User entity)
        { 
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

    }
}
