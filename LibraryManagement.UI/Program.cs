using System;
using LibraryManagement.BLL;
using LibraryManagement.Enums;

namespace LibraryManagement.UI
{
    internal class Program
    {
        private readonly LibraryService _BLL = new LibraryService();

        static void Main(string[] args)
        {
            Program ui = new Program();
            ui.Login();
            Console.ReadKey();
        }
        public void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            (LoginResult result, string message) = _BLL.ProcessLogin(email, password);
            Console.WriteLine(message);
        }
        public void Register()
        {

        }
    }
}
