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

            if (testID.ToLower().Contains("s1"))
            {
                server = "G3ASPRO01";
            }
            else if (testID.ToLower().Contains("s2"))
            {
                server = "G3ASPRO02";
            }



            if (testID.ToLower().Contains("bus"))
            {
                product = "Bus";
            }
            else if (testID.ToLower().Contains("train"))
            {
                product = "Train";
            }

            else if (testID.ToLower().Contains("ferry"))
            {
                product = "Ferry";
            }
            else if (testID.ToLower().Contains("car"))
            {
                product = "Car";
            }



            if (testID.ToLower().Contains("test"))
            {
                site = "Test Site - test.easybook.com";
            }
            else if (testID.ToLower().Contains("Live"))
            {
                product = "Live Site - www.easybook.com";
            }


            if (testID.ToLower().Contains("oneway"))
            {
                tripType = "One Way Trip";
            }
            else if (testID.ToLower().Contains("return"))
            {
                tripType = "Return Trip";
            }


            if (testID.ToLower().Contains("myr"))
            {
                paymentType = "PayPal_MYR";
            }
            else if (testID.ToLower().Contains("sgd"))
            {
                paymentType = "PayPal_SGD";
            }

            Console.WriteLine("Test Description :--- ");
            Console.WriteLine(" Server : " + server);
            Console.WriteLine("EB Site : " + site);
            Console.WriteLine("Product : " + product);
            Console.WriteLine("Trip Type : " + tripType);
            Console.WriteLine("Payment Gateway : " + paymentType);

        }
    }
    
}
