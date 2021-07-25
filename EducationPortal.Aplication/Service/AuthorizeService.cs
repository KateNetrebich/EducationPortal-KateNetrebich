using BCrypt.Net;
using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public class AuthorizeService : IAuthorizeService
    {
        private IUserRepository _repository;
        protected GetPasswordHash passwordHash;
        private readonly ILogger _logger;
        private readonly TokenManager _tokenManager;

        public AuthorizeService(IUserRepository repository, GetPasswordHash getPasswordHash, ILogger<AuthorizeService> logger, TokenManager tokenManager)
        {
            _repository = repository;
            passwordHash = getPasswordHash;
            _logger = logger;
            _tokenManager = tokenManager;
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

        public async Task<Token> SignIn(SignInRequest request)
        {
            var user = await _repository.FindByUserNameAsync(request.Username);
            var isValid = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password, HashType.SHA384);
            if (!isValid)
            {
                _logger.LogError("Имя пользователя или пароль были введены неправильно");
            }
            return _tokenManager.CreateToken(user); ;
        }

        public async Task<User> Update(UpdateUserRequest request, User currentUser)
        {
            var user = await _repository.FindAsync(currentUser.Id);
            user.Username = request.Username ?? user.Username;
            return await _repository.SaveAsync(user);
        }
    }
}
