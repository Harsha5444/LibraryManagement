using System;
using System.Linq;
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

        public void Register()
        {
            Console.Clear();
            Console.WriteLine("User Registration:");
            string name = GetValidInput("Enter Name: ", input => !string.IsNullOrWhiteSpace(input), "Name cannot be empty.");
            string address = GetValidInput("Enter Address: ", input => !string.IsNullOrWhiteSpace(input), "Address cannot be empty.");
            string phone = GetValidInput("Enter Phone: ", input => !string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit), "Phone must be a valid number.");
            string email = GetValidInput("Enter Email: ", input => !string.IsNullOrWhiteSpace(input) && input.Contains("@"), "Invalid email format.");
            string password = GetValidInput("Enter Password: ", input => !string.IsNullOrWhiteSpace(input) && input.Length >= 6, "Password must be at least 6 characters long.");
            bool isAdmin = GetValidInput("Is Admin (yes/no): ", input => input.ToLower() == "yes" || input.ToLower() == "no", "Please enter 'yes' or 'no' for admin status.").ToLower() == "yes";

            (bool isSuccess, string message) = _BLL.RegisterUser(name, address, phone, email, password, isAdmin);
            Console.WriteLine(message);
        }

        private string GetValidInput(string prompt, Func<string, bool> validation, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (validation(input))
                {
                    return input;
                }
                Console.WriteLine(errorMessage);
            }
        }
    }
}
