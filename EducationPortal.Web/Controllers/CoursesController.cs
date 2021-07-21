using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EducationPortal.Web.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly ICourseResultService courseResultService;
        private readonly Claims claims;

        public CoursesController(ICourseService service, ICourseResultService resultService, Claims claims)
        {
            courseService = service;
            courseResultService = resultService;
            this.claims = claims;
        }

        [Route("")]
        [Route("Courses")]
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await courseService.GetAll());
        }

        [Route("Courses/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await courseService.GetById(id));
        }

        [HttpGet("Courses/Create")]
        public async Task<IActionResult> GetCreateCourseView()
        {
            return View("CreateCourse");
        }

        [HttpPost("Courses/Create")]
        public async Task<IActionResult> CreateCourse(string name, string description, string skills, int grade)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var course = await courseService.CreateCourse(new CreateCourseRequest
                    {
                        Name = name,
                        Description = description,
                        Skills = skills,
                        Grade = grade
                    });
                    return RedirectToAction("Index", "Courses");
                }
                catch
                {
                    ModelState.AddModelError("", "Проверьте корректность введенных данных");
                }
            }
            return View();
        }

        [HttpGet("Courses/Edit")]
        public IActionResult GetEditCourseView(int courseId)
        {
            ViewBag.courseId = courseId;
            return View("EditCourse");
        }

        [HttpPost("Courses/Edit")]
        public async Task<IActionResult> EditCourse(int courseId, string name, string description)
        {
            var updatedcourse = await courseService.Update(new UpdateCourseRequest
            {
                Name = name,
                Description = description
            }, courseId);
            return Redirect($"{updatedcourse.Id}");
        }

        [HttpPost("Courses/{id:int}/Take")]
        public async Task<IActionResult> TakeCourse(int id)
        {
            var result = await courseResultService.AddCourseResult(new CreateCourseResultRequest
            {
                UserId = claims.GetUserId(User.Claims),
                CourseId = id,
                CourseDateTime = DateTime.Now,
                Condition = CourseResultCondition.Ended
            });
            return RedirectToAction("Index");
        }
    }


}

