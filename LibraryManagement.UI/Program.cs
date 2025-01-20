using LibraryManagement.BLL;
using System;

namespace LibraryManagement.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryService BLL = new LibraryService();
            Console.Write("enter email: ");
            string email = Console.ReadLine();
            Console.Write("\nenter password: ");
            string password = Console.ReadLine();
            (int result, string message)= BLL.ProcessLogin(email, password);
            Console.WriteLine(message);
        }
    }
}
