using System;
using LibraryManagement.Enums;

namespace LibraryManagement.UI
{
    class LibraryManagementApp
    {
        static void Main(string[] args)
        {
            var loginManager = new MemberUI();
            var menuManager = new MenuManager(); 

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Library Management System");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Please choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
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
                        break;

                    case "2":
                        loginManager.Register(); 
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Thank you for using the Library Management System.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
