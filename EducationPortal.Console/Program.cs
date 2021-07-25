using EducationPortal.Application.Service;
using EducationPortal.Persistence.Contexts;
using EducationPortal.Persistence.DbRepository;
using EducationPortal.Presentation;

namespace EducationPortal.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            EducationPortalDbContext _dbContext = new EducationPortalDbContextConnection().CreateDbContext(args);

            UserDbRepository _userRepository = new UserDbRepository(_dbContext);

            CourseDbRepository _courseRepository = new CourseDbRepository(_dbContext);

            MaterialDbRepository _materialRepository = new MaterialDbRepository(_dbContext);

            IAuthService authService = new AuthService(_userRepository);
            ICourseService courseService = new CourseService(_courseRepository);
            IMaterialService materialService = new MaterialService(_materialRepository);
            CoursesListController coursesController = new CoursesListController(courseService, materialService);
            ConsoleController controller = new ConsoleController(authService, coursesController);
            controller.Process().Wait();
        }
    }
}
