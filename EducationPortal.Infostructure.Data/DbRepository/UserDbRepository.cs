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

        public async void Delete(int entityId)
        {
            try
            {
                var user = new User { Id = entityId };
                _dbContext.Remove(user);
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
            var user = await FindAsync(entity.Id);
            user.Username = entity.Username ?? user.Username;
            user.PasswordHash = entity.PasswordHash ?? user.PasswordHash;

            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        protected string GetPasswordHash(string password)
        {
            string hash = null;
            try
            {
                hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA384, workFactor: 11);
                return hash;
            }
            catch
            {
                return hash;
            }
        }

    }
}
