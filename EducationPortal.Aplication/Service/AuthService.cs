using BCrypt.Net;
using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Models;
using System;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public class AuthService : IAuthService
    {
        private IUserRepository _repository;
        public AuthService(IUserRepository repository)
        {
            _repository = repository;
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
        public async Task<User> Register(RegisterRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role
            };

            await _repository.CreateAsync(user);
            return user;
        }

        public async Task<User> SignIn(SignInRequest request)
        {
            var user = await _repository.FindByUserNameAsync(request.Username);
            if (user == null)
            {
                throw new Exception("wrong UserName or password try again");
            }
            var isValid = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.PasswordHash, HashType.SHA384);
            if (!isValid)
            {
                throw new Exception("wrong UserName or password try again");
            }
            return user;
        }

        public async Task<User> Update(UpdateUserRequest request, User currentUser)
        {
            var user = await _repository.FindAsync(currentUser.Id);
            user.Username = request.Username ?? user.Username;
            user.PasswordHash = GetPasswordHash(request.Password) ?? user.PasswordHash;
            if (request.Role != null)
            {
                throw new Exception();
            }
            return await _repository.SaveAsync(user);
        }
    }
}
