using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using EducationPortal.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Web.Controllers
{
    //[Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService service)
        {
            courseService = service;
        }

        [Route("")]
        [Route("Courses")]
        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> CreateCourse(string name, string description)
        {
            var course = await courseService.CreateCourse(new CreateCourseRequest
            {
                Name = name,
                Description = description
            });
            return Redirect($"{course.Id}");
        }

    }


}
}
