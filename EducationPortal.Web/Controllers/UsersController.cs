using EducationPortal.Application.Service;
using EducationPortal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationPortal.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthService authService;
        private readonly Claims claims;

        public UsersController(IAuthService service, Claims claims)
        {
            authService = service;
            this.claims = claims;
        }

        [HttpGet("Register")]
        public IActionResult RegisterView()
        {
            return View("Register");
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await authService.Register(request);
                    if (user != null)
                    {
                        await Authenticate(user);

                        return RedirectToAction("Index", "Courses");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль, проверьте введенные данные или зарегистрируйтесь");
                }
            }
            return View();
        }

        [HttpGet("SignIn")]
        public IActionResult SignInView()
        {
            return View("SignIn");
        }

        [HttpPost("SignIn")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await authService.SignIn(request);
                    await Authenticate(user);
                    return RedirectToAction("Index", "Courses");
                }
                catch
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            return View();
        }

        private async Task Authenticate(User user)
        {
            ClaimsIdentity id = new ClaimsIdentity(claims.CreateClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn", "Users");
        }
    }
}
