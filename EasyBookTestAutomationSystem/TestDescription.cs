using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBookTestAutomationSystem
{
    class TestDescription
    {
        string server;
        string site;
        string product;
        string tripType;
        string paymentType;

        public void testInformation(string testID)
        {
            Console.WriteLine("Test ID : " + testID);

            if (testID.Contains("s1"))
            {
                server = "G3ASPRO01";
            }
            else if (testID.Contains("s2"))
            {
                server = "G3ASPRO02";
            }



            if (testID.Contains("bus"))
            {
                product = "Bus";
            }
            else if (testID.Contains("train"))
            {
                product = "Train";
            }

            else if (testID.Contains("ferry"))
            {
                product = "Ferry";
            }
            else if (testID.Contains("car"))
            {
                product = "Car";
            }



            if (testID.Contains("test"))
            {
                site = "Test Site - test.easybook.com";
            }
            else if (testID.Contains("live"))
            {
                site = "Live Site - www.easybook.com";
            }


            if (testID.Contains("oneway"))
            {
                tripType = "One Way Trip";
            }
            else if (testID.Contains("return"))
            {
                tripType = "Return Trip";
            }


            if (testID.Contains("myr"))
            {
                paymentType = "PayPal_MYR";
            }
            else if (testID.Contains("sgd"))
            {
                paymentType = "PayPal_SGD";
            }

            Console.WriteLine();
            Console.WriteLine("----- Test Description --- ");
            Console.WriteLine(" Server : " + server);
            Console.WriteLine("EB Site : " + site);
            Console.WriteLine("Product : " + product);
            Console.WriteLine("Trip Type : " + tripType);
            Console.WriteLine("Payment Gateway : " + paymentType);
            Console.WriteLine("----- --------------- --- ");
            Console.WriteLine();

        }
    }
    
}
