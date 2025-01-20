using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.DAL;

namespace LibraryManagement.BLL
{
    public class LibraryService
    {
        MemberRepository mDAL = new MemberRepository();
        public (int,string) ProcessLogin(string username, string password)
        {
            int result = mDAL.UserLogin(username, password);
            switch (result)
            {
                case 1:
                    return (1,"Admin login successful.");
                case 0:
                    return (0,"Member login successful.");
                case -1:
                    return (-1,"Invalid email or password.");
                case -2:
                    return (-2,"An error occurred during login. Please try again later.");
                default:
                    return (-3,"Unexpected error occurred.");
            }
        }
    }
}
