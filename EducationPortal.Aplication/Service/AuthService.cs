using BCrypt.Net;
using EducationPortal.Models;
using EducationPortal.Repositories;
using System;

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
        public void Register(RegisterRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role
            };

            _repository.Create(user, user.Username);
        }

        public User SignIn(SignInRequest request)
        {
            var user = _repository.Get(request.Username);
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
    }
}
