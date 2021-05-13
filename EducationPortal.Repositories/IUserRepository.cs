using EducationPortal.Models;

namespace EducationPortal.Repositories
{
    public interface IUserRepository : IRepository<User, string>
    {
        public void Register(RegisterRequest request);
        public User SignIn(SignInRequest request);
    }
}
