using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBookTestAutomationSystem
{
    class LoginETAS
    {
        public string[] Login()
        {
            Console.WriteLine("Enter email : ");
            string email1 = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password1 = Console.ReadLine();
            string[] loginID = { email1, password1 };
            return loginID; 
        }

        public void LogOut()
        {

        }
        public void ForgotPassword()
        {

        }
    }
}
