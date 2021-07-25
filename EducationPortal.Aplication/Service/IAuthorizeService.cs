using EducationPortal.Application.Model;
using EducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public interface IAuthorizeService
    {
        Task<User> Register(RegisterRequest request);
        Task<Token> SignIn(SignInRequest request);
    }
}
