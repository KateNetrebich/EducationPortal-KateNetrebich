using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EducationPortal.Web.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly IMaterialService materialService;
        private readonly ICourseService courseService;

        public MaterialsController(IMaterialService material, ICourseService course)
        {
            materialService = material;
            courseService = course;
        }

        [HttpGet("Materials/CreateArticle")]
        public IActionResult GetCreateArticleView(int courseId)
        {
            ViewBag.courseId =courseId;
            return View("CreateArticle");
        }

        [HttpPost("Materials/CreateArticle")]
        public async Task<IActionResult> CreateArticle(int courseId, string name, string description, string url, DateTime date)
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
            return View();
        }

        [HttpGet("Materials/CreateVideo")]
        public IActionResult GetCreateVideoView(int courseId)
        {
            ViewBag.courseId = courseId;
            return View("CreateVideo");
        }

        [HttpPost("Materials/CreateVideo")]
        public async Task<IActionResult> CreateVideo(int courseId, string name, string description, string duration, string quality, string url)
        {
            if(ModelState.IsValid)
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
            return View();
        }

        [HttpGet("Materials/CreateBook")]
        public IActionResult GetCreateBookView(int courseId)
        {
            ViewBag.courseId = courseId;
            return View("CreateBook");
        }

        [HttpPost("Materials/CreateBook")]
        public async Task<IActionResult> CreateBook(int courseId, string name, string description, string author, int pageNumber, DateTime date, string url)
        {
            if(ModelState.IsValid)
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
            return View();
        }

        [HttpGet("Materials/Edit")]
        public  IActionResult GetEditMaterialView(int Id)
        {
            ViewBag.Id = Id;
            return View("EditMaterial");
        }

        [HttpPost("Materials/Edit")]
        public async Task<IActionResult> EditMaterial([FromRoute]int Id,string name,string description)
        {
            var updatedMaterial = await materialService.Update(new UpdateMaterialRequest
            {
                Name = name,
                Description = description
            }, Id);
            return Redirect("Courses");
        }
    }
}
