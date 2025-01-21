using LibraryManagement.DAL;
using LibraryManagement.Enums;
using System.Text.RegularExpressions;

namespace LibraryManagement.BLL
{
    public class LibraryService
    {
        private readonly MemberRepository _mDAL = new MemberRepository();

        public (LoginResult result, string message) ProcessLogin(string username, string password)
        {
            LoginResult result = _mDAL.UserLogin(username, password);

            switch (result)
            {
                case LoginResult.Success:
                    return (LoginResult.Success, "Admin login successful.");
                case LoginResult.MemberSuccess:
                    return (LoginResult.MemberSuccess, "Member login successful.");
                case LoginResult.InvalidCredentials:
                    return (LoginResult.InvalidCredentials, "Invalid email or password.");
                case LoginResult.ErrorOccurred:
                    return (LoginResult.ErrorOccurred, "An error occurred during login. Please try again later.");
                default:
                    return (LoginResult.UnexpectedError, "Unexpected error occurred.");
            }
        }
        public (bool isSuccess, string message) RegisterUser(string name, string address, string phone, string email, string password, bool isAdmin)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                return (false, "All fields are required.");
            }

            if (!Regex.IsMatch(phone, @"^\d+$"))
            {
                return (false, "Phone must be a valid number.");
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return (false, "Invalid email format.");
            }

            if (password.Length < 6)
            {
                return (false, "Password must be at least 6 characters long.");
            }

            var (isRegistered, message) = _mDAL.AddUser(name, address, phone, email, password, isAdmin);

            return (isRegistered, message);
        }
    }
}
