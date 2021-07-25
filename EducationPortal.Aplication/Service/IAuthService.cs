using EducationPortal.Models;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public interface IAuthService
    {
        Task<User> Register(RegisterRequest request);
        Task<User> SignIn(SignInRequest request);
    }
}
