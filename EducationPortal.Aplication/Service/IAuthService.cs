using EducationPortal.Models;

namespace EducationPortal.Application.Service
{
    public interface IAuthService
    {
        public void Register(RegisterRequest request);
        public User SignIn(SignInRequest request);
    }
}
