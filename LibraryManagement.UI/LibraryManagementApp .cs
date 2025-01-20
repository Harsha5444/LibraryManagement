using System;
using LibraryManagement.Enums;

namespace LibraryManagement.UI
{
    class LibraryManagementApp
    {
        static void Main(string[] args)
        {
            var loginManager = new LoginManager();
            var menuManager = new MenuManager();

            LoginResult loginResult = loginManager.Login();

            if (loginResult == LoginResult.Success) 
            {
                menuManager.ShowAdminMenu();
            }
            else if (loginResult == LoginResult.MemberSuccess) 
            {
                menuManager.ShowMemberMenu();
            }
            else
            {
                Console.WriteLine("Login failed. Please try again.");
            }

            Console.ReadKey();
        }
    }
}
