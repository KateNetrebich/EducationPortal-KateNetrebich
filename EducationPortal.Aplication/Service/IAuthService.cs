using EducationPortal.Models;

namespace EducationPortal.Application.Service
{
    public interface IAuthService
    {
        void Register(RegisterRequest request);
        User SignIn(SignInRequest request);
    }
}
