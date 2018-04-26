using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBookTestAutomationSystem
{
    class SiteName
    {
        string site;
        public string chooseEBSite(string testCaseID)
        {
            if (testCaseID.ToLower().Contains("test")) 
            {
                Console.WriteLine("3.0.1");
                site = "https://test.easybook.com";
                return site;
            }
            if (testCaseID.ToLower().Contains("live"))
            {
                Console.WriteLine("3.0.2");
                site = "https://www.easybook.com";
                return site;
            }
            if (testCaseID.ToLower().Contains("bq"))
            {
                site = "https://backend.easybook.com";
                return site;
            }
            Console.WriteLine("Wrong site input.");
            return null;
        } 
    }
}
