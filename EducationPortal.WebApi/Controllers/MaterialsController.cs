using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        public async Task<ActionResult> CreateArticle([FromRoute] int courseId, [FromQuery] string name, [FromQuery] string description, [FromQuery] string url, [FromQuery] DateTime date)
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
            return Ok();

        }

        [HttpPost("CreateVideo")]
        public async Task<ActionResult> CreateVideo([FromRoute] int courseId, [FromQuery] string name, [FromQuery] string description, [FromQuery] string duration, [FromQuery] string quality, [FromQuery] string url)
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
            return Ok();

        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult> CreateBook([FromRoute] int courseId, [FromQuery] string name, [FromQuery] string description, [FromQuery] string author, [FromQuery] int pageNumber, [FromBody] DateTime date, [FromQuery] string url)
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
            return Ok();
        }

        [HttpPatch("Edit")]
        public async Task<ActionResult> EditMaterial([FromRoute] int Id, [FromQuery] string name, [FromQuery] string description)
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
