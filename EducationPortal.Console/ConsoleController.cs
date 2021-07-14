using EducationPortal.Application.Service;
using EducationPortal.Models;
using System;
using System.Threading.Tasks;

namespace EducationPortal.Presentation
{
    public class ConsoleController
    {
        private IAuthService _authService;
        private CoursesListController _courses;
        private CourseResultService _resultService;
        public ConsoleController(IAuthService service, CoursesListController courses)
        {
            _authService = service;
            _courses = courses;
        }
        public async Task Process()
        {

            User currentUser = null;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Main menu");
                Console.ResetColor();
                Console.WriteLine("1.New user registration");
                Console.WriteLine("2.Sign in");
                Console.WriteLine("3.Print information about my profile");
                Console.WriteLine("4.Manage cources");
                Console.WriteLine("5.Exit");

                var action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                        var registration = Registration();
                        await _authService.Register(registration);
                        Console.Clear();
                        break;
                    case "2":
                        var signIn = GetSignInInformation();
                        currentUser = await _authService.SignIn(signIn);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"WELCOME {currentUser.Username}");
                        Console.ResetColor();
                        break;
                    case "3":
                        if (currentUser == null)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Press 2 to Sign In!!!");
                            Console.ResetColor();
                            break;
                        }
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("User info");
                        Console.ResetColor();
                        await PrintMyInfo(currentUser);
                        Console.WriteLine();
                        break;
                    case "4":
                        if (currentUser == null)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Press 2 to Sign In!!!");
                            Console.ResetColor();
                            break;
                        }
                        Console.Clear();
                        await _courses.Process();
                        break;
                    case "5":
                        return;
                }
            }
        }
        private RegisterRequest Registration()
        {
            try
            {
                RegisterRequest user = new RegisterRequest();
                Console.WriteLine("Input Username");
                user.Username = Console.ReadLine();
                Console.WriteLine("Input password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Input role");
                user.Role = Console.ReadLine();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception occured:{ex.Message}");
            }

        }

        private SignInRequest GetSignInInformation()
        {
            Console.WriteLine("Input UserName");
            string name = Console.ReadLine();
            Console.WriteLine("Input Password");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Username is empty");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is empty");
            }
            return new SignInRequest
            {
                Username = name,
                Password = password
            };
        }

        private async Task PrintMyInfo(User currentUser)
        {
            Console.WriteLine($" UserName:{currentUser.Username}\n Role:{currentUser.Role}");
            //var results = await _resultService.GetByUser(currentUser);
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"Courses:{item.Course}\nCourses Result{item.Result}");
            //}
        }
    }
}
