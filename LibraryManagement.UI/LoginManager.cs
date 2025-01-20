using System;
using LibraryManagement.BLL;
using LibraryManagement.Enums;

namespace LibraryManagement.UI
{
    public class LoginManager
    {
        private readonly LibraryService _BLL = new LibraryService();

        public (LoginResult result, string message, bool isAdmin) PerformLogin(string email, string password)
        {
            (LoginResult result, string message) = _BLL.ProcessLogin(email, password);

            bool isAdmin = result == LoginResult.Success; 
            return (result, message, isAdmin);
        }

        public LoginResult Login()
        {
            bool isLoginSuccessful = false;

            while (!isLoginSuccessful)
            {
                Console.Clear();
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                (LoginResult result, string message, bool isAdmin) = PerformLogin(email, password);
                Console.WriteLine(message);

                switch (result)
                {
                    case LoginResult.Success:
                    case LoginResult.MemberSuccess:
                        isLoginSuccessful = true;
                        Console.WriteLine(isAdmin ? "Admin login successful." : "Member login successful.");
                        return result;

                    case LoginResult.InvalidCredentials:
                    case LoginResult.ErrorOccurred:
                    case LoginResult.UnexpectedError:
                        Console.WriteLine("Please try again.");
                        break;
                }

                if (!isLoginSuccessful)
                {
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            }
            return LoginResult.InvalidCredentials;
        }
    }
}
