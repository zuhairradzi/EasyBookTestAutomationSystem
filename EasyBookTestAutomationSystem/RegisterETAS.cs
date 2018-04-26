using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBookTestAutomationSystem
{
    class RegisterETAS
    {
        public string[] RegisterAccount()
        {
            Console.WriteLine("Enter name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter position : ");
            string position = Console.ReadLine();
            Console.WriteLine("Enter email : ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();
            string[] personalInfo = { name, position, email, password };
            return personalInfo;
        }
        public void DeleteAccount()
        {

        }
       
    }
}
