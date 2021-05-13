using BCrypt.Net;
using EducationPortal.Models;
using System;

namespace EducationPortal.Repositories.FileRepository
{
    public class UserJsonRepository : JsonRepository<User, string> , IUserRepository
    {
        public UserJsonRepository(string filename) : base(filename)
        {
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

            this.Create(user, user.Username);
        }

        public User SignIn(SignInRequest request)
        {
            var user = this.Get(request.Username);
            if(user == null)
            {
                throw new Exception("wrong UserName or password try again");
            }
            var isValid = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.PasswordHash, HashType.SHA384);
            if(!isValid)
            {
                throw new  Exception("wrong UserName or password try again");
            }
            return user;
        }
    }
}
