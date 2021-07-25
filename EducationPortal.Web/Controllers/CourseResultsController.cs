using EducationPortal.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationPortal.Web.Controllers
{
    [Authorize]
    public class CourseResultsController : Controller
    {
        private readonly ICourseResultService courseResultService;
        private readonly Claims claims;

        public CourseResultsController(ICourseResultService service, Claims claims)
        {
            courseResultService = service;
            this.claims = claims;
        }

        [Route("CourseResults")]
        public async Task<IActionResult> Index()
        {
            var userId = claims.GetUserId(HttpContext.User.Claims);
            return View(await courseResultService.GetByUser(userId));
        }
    }
}
