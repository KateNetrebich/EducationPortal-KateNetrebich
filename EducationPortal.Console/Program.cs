using EducationPortal.Application.Service;
using EducationPortal.Persistence.FileRepository;
using EducationPortal.Presentation;
using EducationPortal.Repositories.FileRepository;

namespace EducationPortal.ConsoleApp
{
    public class Program
    {
        private const string SavingDir = "D:\\";

        static void Main(string[] args)
        {
            UserJsonRepository _userRepository = new UserJsonRepository(SavingDir + "\\users.json");
            _userRepository.Import();

            CourceJsonRepository _courseRepository = new CourceJsonRepository(SavingDir + "\\courses.json");
            _courseRepository.Import();

            MaterialJsonRepository _materialRepository = new MaterialJsonRepository(SavingDir + "\\material.json");
            _materialRepository.Import();

            IAuthService authService = new AuthService(_userRepository);
            ICourseService courseService = new CourseService(_courseRepository);
            IMaterialService materialService = new MaterialService(_materialRepository);
            CoursesListController coursesController = new CoursesListController(courseService, materialService);
            ConsoleController controller = new ConsoleController(authService, coursesController);
            controller.Process();
        }
    }
}
