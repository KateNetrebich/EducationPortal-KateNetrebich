using EducationPortal.Application.Service;
using EducationPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthorizeService authService;

        public UsersController(IAuthorizeService service)
        {
            authService = service;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            await authService.Register(request);
            return Ok();
        }

        [HttpPost("SignIn")]
        public ActionResult SignIn([FromQuery] SignInRequest request)
        {
            var token = authService.SignIn(request);
            return Ok(token);
        }
    }
}
