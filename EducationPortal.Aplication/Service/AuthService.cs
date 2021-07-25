using BCrypt.Net;
using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public class AuthService : IAuthService
    {
        private IUserRepository _repository;
        protected GetPasswordHash passwordHash;
        private readonly ILogger _logger;

        public AuthService(IUserRepository repository, GetPasswordHash getPasswordHash, ILogger<AuthService> logger)
        {
            _repository = repository;
            passwordHash = getPasswordHash;
            _logger = logger;
        }
        
        public async Task<User> Register(RegisterRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Password = passwordHash.PasswordHash(request.Password),
            };

            await _repository.CreatAsync(user);
            return user;
        }

        public async Task<User> SignIn(SignInRequest request)
        {
            var user = await _repository.FindByUserNameAsync(request.Username);
            var isValid = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password, HashType.SHA384);
            if (!isValid)
            {
                _logger.LogError("Имя пользователя или пароль были введены неправильно");
            }
            return user;
        }

        public async Task<User> Update(UpdateUserRequest request, User currentUser)
        {
            var user = await _repository.FindAsync(currentUser.Id);
            user.Username = request.Username ?? user.Username;
            return await _repository.SaveAsync(user);
        }
    }
}
