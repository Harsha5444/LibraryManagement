using System;

namespace LibraryManagement.UI
{
    public class MenuManager
    {
        public void ShowAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome, Admin! Please select an option:");
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. View Reports");
            Console.WriteLine("3. Logout");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Managing users...");
                    break;

                case "2":
                    Console.WriteLine("Viewing reports...");
                    break;

                case "3":
                    Console.WriteLine("Logging out...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    ShowAdminMenu();
                    break;
            }
        }

        public void ShowMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome, Member! Please select an option:");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. Borrow Books");
            Console.WriteLine("3. Logout");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Viewing books...");
                    break;

                case "2":
                    Console.WriteLine("Borrowing books...");
                    break;

                case "3":
                    Console.WriteLine("Logging out...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    ShowMemberMenu();
                    break;
            }
        }
    }
}
