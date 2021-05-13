using EducationPortal.Models;
using EducationPortal.Repositories.FileRepository;
using System;

namespace EducationPortal.ConsoleApp
{
    public class AuthController
    {
        private const string SavingDir = "D:\\NIX Education\\EducationPortal\\OutputResults";
        static UserJsonRepository _repository = new UserJsonRepository(SavingDir + "\\users.json");
        static void Main(string[] args)
        {
            _repository.Import();
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
                        _repository.Register(registration);
                        _repository.Export();
                        break;
                    case "2":
                        var signIn = GetSignInInformation();
                         currentUser = _repository.SignIn(signIn);
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

        

        public static RegisterRequest Registration()
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

        public static SignInRequest GetSignInInformation()
        { 
            Console.WriteLine("Input UserName");
            var name = Console.ReadLine();
            Console.WriteLine("Input Password");
            var password = Console.ReadLine();
            if(name == null)
            {
                throw new Exception("Username is empty");
            }
            if(password == null)
            {
                throw new Exception("Password is empty");
            }
            return new SignInRequest {
                Username = name,    
                Password = password
            };
        }

    }
}
    