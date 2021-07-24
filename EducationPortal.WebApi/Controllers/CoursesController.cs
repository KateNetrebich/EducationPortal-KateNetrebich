using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EducationPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly ICourseResultService courseResultService;

        public CoursesController(ICourseService service)
        {
            courseService = service;
        }

        [HttpGet("Get Courses")]
        public async Task<ActionResult> GetCourses()
        {
            var courses = await courseService.GetAll();
            return Ok(courses);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCourse([FromBody] string name, [FromQuery] string description, [FromQuery] string skills, [FromQuery] int grade)
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
                    return Ok();
                }
                catch
                {
                    ModelState.AddModelError("", "Проверьте корректность введенных данных");
                }
            }
            return Ok();
        }

        [HttpPost("Edit")]
        public async Task<ActionResult> EditCourse([FromRoute] int courseId, [FromQuery] string name, [FromQuery] string description)
        {
            var updatedcourse = await courseService.Update(new UpdateCourseRequest
            {
                Name = name,
                Description = description
            }, courseId);
            return Ok(updatedcourse);
        }

        [HttpPost("CourseResults")]
        public async Task<ActionResult> CourseResults([FromQuery] int userId, [FromQuery] int courseId, [FromQuery] CourseResultCondition condition)
        {
            var result = await courseResultService.AddCourseResult(new CreateCourseResultRequest
            {
                UserId = userId,
                CourseId = courseId,
                CourseDateTime = DateTime.Now,
                Condition = condition
            });
            return Ok(result);
        }
    }
}
