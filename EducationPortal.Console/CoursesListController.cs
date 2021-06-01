using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using System;

namespace EducationPortal.Presentation
{
    public class CoursesListController
    {
        private ICourseService _service;
        private IMaterialService _materialService;
        public CoursesListController(ICourseService service, IMaterialService materialService)
        {
            _service = service;
            _materialService = materialService;
        }
        public void Process()
        {
            while (true)
            {
                Console.WriteLine("1.Print all allow courses");
                Console.WriteLine("2.Create Course");
                Console.WriteLine("3.Display Course");
                Console.WriteLine("4.Take a course");
                Console.WriteLine("5.Return");

                var action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                        PrintAll();
                        break;
                    case "2":
                        CreateNewCourse();
                        break;
                    case "3":
                        DisplayCourse();
                        break;
                    case "4":
                        break;
                    case "5":
                        return;
                }
            }
        }

        public void PrintAll()
        {
            var all = _service.GetAll();
            for (int i = 0; i < all.Count; i++)
            {
                var item = all[i];
                Console.WriteLine($"{i + 1}.Name:{item.Name}\nDescription:{item.Description}");
            }
        }

        public void CreateNewCourse()
        {
            CreateCourseRequest course = new CreateCourseRequest();
            Console.WriteLine("Input Course Name");
            course.Name = Console.ReadLine();
            Console.WriteLine("Input Description");
            course.Description = Console.ReadLine();

            _service.CreateCourse(course);
        }

        public void DisplayCourse()
        {
            Console.WriteLine("Choose");
            var inputIndex = Console.ReadLine();
            var index = Int32.Parse(inputIndex);
            var list = _service.GetAll();
            var course = list[index];
            new CourseController(_service, _materialService, new MaterialController(_materialService), course).Process();
        }
    }
}
