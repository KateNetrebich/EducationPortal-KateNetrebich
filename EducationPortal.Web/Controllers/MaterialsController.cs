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

        public MaterialsController(IMaterialService service)
        {
            materialService = service;
        }

        [HttpGet("CreateArticle")]
        public async Task<IActionResult> GetCreateArticleView()
        {
            return View("CreateArticle");
        }

        [HttpPost("CreateArticle")]
        public async Task<IActionResult> CreateArticle(string name, string description, string url, DateTime date)
        {
            var article = await materialService.CreateMaterial(new CreateArticleRequest
            {
                Name = name,
                Description = description,
                URL = url,
                PublicationDate = date
            });
            return View(article);
        }

        [HttpGet("CreateVideo")]
        public async Task<IActionResult> GetCreateVideoView()
        {
            return View("CreateVideo");
        }

        [HttpPost("CreateVideo")]
        public async Task<IActionResult> CreateVideo(string name, string description, string duration, string quality)
        {
            var article = await materialService.CreateMaterial(new CreateVideoRequest
            {
                Name = name,
                Description = description,
                Duration = duration,
                Quality = quality
            });
            return View(article);
        }

        [HttpGet("CreateBook")]
        public async Task<IActionResult> GetCreateBookView()
        {
            return View("CreateBook");
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook(string name, string description, string author, int pageNumber, DateTime date)
        {

            var article = await materialService.CreateMaterial(new CreateBookRequest
            {
                Name = name,
                Description = description,
                Author = author,
                PageNumber = pageNumber,
                YearOfPublication = date
            });
            return View(article);


        }
    }
}
