using EducationPortal.Application.Service;
using EducationPortal.Presentation;
using EducationPortal.Repositories.FileRepository;

namespace EducationPortal.ConsoleApp
{
    public class Program
    {
        private const string SavingDir = "D:\\";

        static void Main(string[] args)
        {
            UserJsonRepository _repository = new UserJsonRepository(SavingDir + "\\users.json");
            _repository.Import();

            IAuthService authService = new AuthService(_repository);
            ConsoleController controller = new ConsoleController(authService);
            controller.Process();
        }

    }
}
