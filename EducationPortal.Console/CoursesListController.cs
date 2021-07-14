using EducationPortal.Application.Model;
using EducationPortal.Application.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Presentation
{
    public class CoursesListController
    {
        private ICourseService _service;
        private IMaterialService _materialService;
        private ICourseResultService _courseResultService;
        public CoursesListController(ICourseService service, IMaterialService materialService)
        {
            _service = service;
            _materialService = materialService;
            //_courseResultService = courseResultService;
        }
        public async Task Process()
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Course Menu");
                Console.ResetColor(); 
                Console.WriteLine("1.Print all available courses");
                Console.WriteLine("2.Create Course");
                Console.WriteLine("3.Display Course");
                Console.WriteLine("4.Take a course");
                Console.WriteLine("5.Return");
                Console.WriteLine("6.Exit");
                Console.WriteLine();

                var action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                        Console.WriteLine("All available courses");
                        await PrintAll();
                        break;
                    case "2":
                        await CreateNewCourse();
                        break;
                    case "3":
                        await DisplayCourse ();
                        break;
                    case "4":
                        await TakeACourse ();
                        break;
                    case "5":
                        return;
                    case "6":
                        break;
                }
            }
        }

        public async Task PrintAll()
        {
            var all = await _service.GetAll();
            for (int i = 0; i < all.Count; i++)
            {
                var item = all[i];
                Console.WriteLine($"{i + 1}.Name:{item.Name}\nDescription:{item.Description}");
            }
        }

        public async Task CreateNewCourse()
        {
            CreateCourseRequest course = new CreateCourseRequest();
            Console.WriteLine("Input Course Name");
            course.Name = Console.ReadLine();
            Console.WriteLine("Input Description");
            course.Description = Console.ReadLine();

            await _service.CreateCourse(course);
        }

        public async Task DisplayCourse()
        {
            await PrintAll();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose Course for editing");
            Console.ResetColor();
            var index = GetIntInput();
            var list = _service.GetAll().Result;
            var course = list[index - 1];
           await new CourseController(_service, _materialService, new MaterialController(_materialService), course).Process();
        }

        private int GetIntInput()
        {
            if (int.TryParse(Console.ReadLine(), out var input))
            {
                return input;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect input, try again");
                Console.WriteLine();
                return GetIntInput();
            }
        }

        public async  Task TakeACourse()
        {
            await PrintAll();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose course");
            Console.ResetColor();
            var courseIndex = GetIntInput();
            var list = await _service.GetAll();
            var course =  list[courseIndex - 1];
            var materials = course.Materials;
            for (int i = 0; i < materials.Count; i++)
            {
                var item = materials[i];
                Console.WriteLine($"{i + 1}.Name:{item.Name}\n Description:{item.Description}");
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Press Enter to ended this course");
            Console.ResetColor();
            string key = Console.ReadKey().Key.ToString();
            if (key == "")
            {
                Console.WriteLine("You did not press enter.");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("You have completed the course!");
                Console.ResetColor();
            }
                
        }
    }
}
