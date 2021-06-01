using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using System;

namespace EducationPortal.Presentation
{
    public class MaterialController
    {
        private IMaterialService _service;
        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        public Material Process()
        {
            Console.WriteLine("1.Create Article Material");
            Console.WriteLine("2.Create Video Material");
            Console.WriteLine("3.Create Book Material");
            Console.WriteLine("4.Return");

            var action = Console.ReadLine();
            Console.Clear();
            switch (action)
            {
                case "1":
                    return CreateArticleMaterial();
                case "2":
                    return CreateVideoMaterial();
                case "3":
                    return CreateBookMaterial();
                case "4":
                    return null;
            }
            throw new Exception();
        }

        private Material CreateArticleMaterial()
        {
            CreateArticleRequest request = new CreateArticleRequest();
            Console.WriteLine("Input Article Name");
            request.Name = Console.ReadLine();
            Console.WriteLine("Input Article URL");
            request.URL = Console.ReadLine();
            Console.WriteLine("Input Article Date of publication");
            request.PublicationDate = Console.ReadLine();
            return _service.CreateMaterial(request);
        }

        private Material CreateVideoMaterial()
        {
            CreateVideoRequest request = new CreateVideoRequest();
            Console.WriteLine("Input Video Name");
            request.Name = Console.ReadLine();
            Console.WriteLine("Input Video Description");
            request.Description = Console.ReadLine();
            Console.WriteLine("Input Video Duration");
            request.Duration = Console.ReadLine();
            Console.WriteLine("Input Video Quality");
            request.Quality = Console.ReadLine();
            return _service.CreateMaterial(request);
        }

        private Material CreateBookMaterial()
        {
            CreateBookRequest request = new CreateBookRequest();
            Console.WriteLine("Input Book Name");
            request.Name = Console.ReadLine();
            Console.WriteLine("Input Book Description");
            request.Description = Console.ReadLine();
            Console.WriteLine("Input Author");
            request.Author = Console.ReadLine();
            Console.WriteLine("Input Pages Number");
            request.PageNumber = Console.Read();
            Console.WriteLine("Input Year of publication");
            request.YearOfPublication = Console.Read();
            return _service.CreateMaterial(request);
        }
    }
}
