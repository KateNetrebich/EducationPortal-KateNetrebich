using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using System;

namespace EducationPortal.Presentation
{
    public class CourseController
    {
        private ICourseService _service;
        private IMaterialService _materialService;
        private MaterialController _materialController;
        private Course _course;
        public CourseController(ICourseService service, IMaterialService materialService, MaterialController materialController, Course course)
        {
            _service = service;
            _materialService = materialService;
            _materialController = materialController;
            _course = course;
        }

        public void Process()
        {
            while (true)
            {
                Console.WriteLine("1.Print Course Material");
                Console.WriteLine("2.Add existing materials");
                Console.WriteLine("3.Add new materials");
                Console.WriteLine("4.Return");

                var action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                        PrintMyMaterials();
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        AddNewMaterial();
                        break;
                }
            }

        }

        private void PrintMyMaterials()
        {
            var materials = _materialService.GetByCourse(_course);
            for (int i = 0; i < materials.Count; i++)
            {
                var item = materials[i];
                Console.WriteLine($"{i}. {item.Name}");
            }
        }

        private void AddNewMaterial()
        {
           var material = _materialController.Process();
           _course = _service.AddMaterial(_course, material);
        }
    }

}
