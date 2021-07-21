using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using EducationPortal.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService service)
        {
            courseService = service;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCourse([FromRoute] string name, [FromRoute] string description, [FromRoute] string skills, [FromRoute] int grade)
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
            return Ok();
        }

        [HttpPost("Edit")]
        public async Task<ActionResult> EditCourse([FromRoute]int courseId, [FromRoute] string name, [FromRoute] string description)
        {
            var updatedcourse = await courseService.Update(new UpdateCourseRequest
            {
                Name = name,
                Description = description
            }, courseId);
            return Ok(updatedcourse);
        }
    }
}
