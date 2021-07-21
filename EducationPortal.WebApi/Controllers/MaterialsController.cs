using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService materialService;
        private readonly ICourseService courseService;
        public MaterialsController(IMaterialService material, ICourseService course)
        {
            materialService = material;
            courseService = course;
        }

        [HttpPost("CreateArticle")]
        public async Task<ActionResult> CreateArticle([FromRoute] int courseId, [FromRoute] string name, [FromRoute] string description, [FromRoute] string url, [FromRoute] DateTime date)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var article = await materialService.CreateMaterial(new CreateArticleRequest
                    {
                        Name = name,
                        Description = description,
                        URL = url,
                        PublicationDate = date
                    });
                    var course = await courseService.GetById(courseId);
                    await courseService.AddMaterial(course, article);
                    return Redirect($"/Courses/{courseId}");
                }
                catch
                {
                    ModelState.AddModelError("", "Проверьте корректность введенных данных");
                }
            }
            return Ok();
        }

        [HttpPost("CreateVideo")]
        public async Task<ActionResult> CreateVideo(int courseId, string name, string description, string duration, string quality, string url)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var video = await materialService.CreateMaterial(new CreateVideoRequest
                    {
                        Name = name,
                        Description = description,
                        URL = url,
                        Duration = duration,
                        Quality = quality
                    });
                    var course = await courseService.GetById(courseId);
                    await courseService.AddMaterial(course, video);
                    return Redirect($"/Courses/{courseId}");
                }
                catch
                {
                    ModelState.AddModelError("", "Проверьте корректность введенных данных");
                }
            }
            return Ok();
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult> CreateBook([FromRoute] int courseId, [FromRoute] string name, [FromRoute] string description, [FromRoute] string author, int pageNumber, [FromRoute] DateTime date, [FromRoute] string url)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var book = await materialService.CreateMaterial(new CreateBookRequest
                    {
                        Name = name,
                        Description = description,
                        URL = url,
                        Author = author,
                        PageNumber = pageNumber,
                        YearOfPublication = date
                    });
                    var course = await courseService.GetById(courseId);
                    await courseService.AddMaterial(course, book);
                    return Redirect($"/Courses/{courseId}");
                }
                catch
                {
                    ModelState.AddModelError("", "Проверьте корректность введенных данных");
                }

            }
            return Ok();
        }

        [HttpPost("Edit")]
        public async Task<ActionResult> EditMaterial([FromRoute] int Id, [FromRoute]string name, [FromRoute]string description)
        {
            var updatedMaterial = await materialService.Update(new UpdateMaterialRequest
            {
                Name = name,
                Description = description
            }, Id);
            return Ok(updatedMaterial);
        }
    }
}
