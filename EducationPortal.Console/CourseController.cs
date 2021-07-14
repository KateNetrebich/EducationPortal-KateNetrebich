using EducationPortal.Application.Service;
using EducationPortal.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task Process()
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Materials in Course");
                Console.ResetColor();
                Console.WriteLine("1.Print Course Material");
                Console.WriteLine("2.Add new materials");
                //Console.WriteLine("3.Add existing materials");
                Console.WriteLine("3.Return");
                Console.WriteLine("4.Exit");

                var action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                        await PrintMyMaterials();
                        break;
                    case "2":
                        await AddNewMaterial();
                        break;
                    case "":
                        break;
                    case "3":
                        return;
                    case "4":
                        break;
                }
            }

        }

        public async Task PrintMyMaterials()
        {
            var materials = _materialService.GetByCourse(_course).ToList();
            for (int i = 0; i < materials.Count; i++)
            {
                var item = materials[i];
                Console.WriteLine($"{i + 1}.Name:{item.Name}");
            }
        }

        private async Task AddNewMaterial()
        {
            var material = await _materialController.Process();
            _course = _service.AddMaterial(_course, material).Result;
        }
    }

}
