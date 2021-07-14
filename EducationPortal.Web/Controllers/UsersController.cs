using EducationPortal.Application.Service;
using EducationPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Web.Controllers
{
    public class UsersController : Controller
    {
        public readonly IAuthService authService;

        public UsersController(IAuthService service)
        {
            authService = service;
        }

        [HttpGet("Register")]
        public async Task<IActionResult> RegisterView()
        {
            return View("RegisterUser");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(string username, string password, string role)
        {
            var user = await authService.Register(new RegisterRequest
            {
                Username = username,
                Password = password,
                Role = role
            });
            Redirect("Courses/Index");
            return View(user);
        }

        [HttpGet("SignIn")]
        public async Task<IActionResult> SignInView()
        {
            return View("SignIn");
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            var user = await authService.SignIn(new SignInRequest
            {
                Username = username,
                Password = password
            });
            return Redirect("Courses/Index");
        }
    }
}
