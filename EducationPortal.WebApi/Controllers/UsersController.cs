using EducationPortal.Application.Service;
using EducationPortal.Models;
using EducationPortal.Web.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly Claims claims;

        public UsersController(IAuthService service, Claims claims)
        {
            authService = service;
            this.claims = claims;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            await authService.Register(request);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromQuery] SignInRequest request)
        {
            var user = await authService.SignIn(request);
            return Ok(user);
        }
    }
}
