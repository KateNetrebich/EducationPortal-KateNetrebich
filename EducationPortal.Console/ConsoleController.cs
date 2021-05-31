using EducationPortal.Application.Service;
using EducationPortal.Models;
using System;

namespace EducationPortal.Presentation
{
    public class ConsoleController
    {
        private IAuthService authService;
        public ConsoleController(IAuthService service)
        {
            authService = service;
        }
        public void Process()
        {

            User currentUser = null;
            while (true)
            {
                Console.WriteLine("Select action");
                Console.WriteLine("1.New user registration");
                Console.WriteLine("2.Sign in");
                Console.WriteLine("3.Print me");
                Console.WriteLine("4.Exit");

                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        var registration = Registration();
                        authService.Register(registration);
                        break;
                    case "2":
                        var signIn = GetSignInInformation();
                        currentUser = authService.SignIn(signIn);
                        break;
                    case "3":
                        if (currentUser == null)
                        {
                            Console.WriteLine("Press 2 to Sign In");
                            break;
                        }
                        Console.WriteLine($" UserName:{currentUser.Username}\n Role:{currentUser.Role}");
                        break;
                    case "4":
                        return;
                }
            }
        }
        private RegisterRequest Registration()
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

        private SignInRequest GetSignInInformation()
        {
            Console.WriteLine("Input UserName");
            var name = Console.ReadLine();
            Console.WriteLine("Input Password");
            var password = Console.ReadLine();
            if (name == null)
            {
                throw new Exception("Username is empty");
            }
            if (password == null)
            {
                throw new Exception("Password is empty");
            }
            return new SignInRequest
            {
                Username = name,
                Password = password
            };
        }
    }
}
