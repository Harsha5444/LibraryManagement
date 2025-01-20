using LibraryManagement.DAL;
using LibraryManagement.Enums;

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
    }
}
