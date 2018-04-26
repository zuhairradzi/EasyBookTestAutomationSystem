using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBookTestAutomationSystem
{
    class Menu
    {
        string serverType;
        string site;
        string product;
        string tripType;
        string paymentMethod;

        public string ServerType()
        {
            Console.WriteLine("Choose (S1) for Server 1/S1 or (S2) for Server 2/S2 : ");
            serverType = Console.ReadLine();
            //Console.WriteLine("1.0.1");
            return serverType.ToLower().Trim() ;

        }
        public string Site()
        {
            Console.WriteLine("Choose (Test) for test.easybook.com/test site, (Live) for www.easybook.com/live site, (BQ) for backend.easybook.com/BQ site : ");
            site = Console.ReadLine();
            //Console.WriteLine("1.0.2");
            return site.ToLower().Trim();

        }
        public string Product()
        {
            Console.WriteLine("Choose (Bus) for Bus, (Ferry) for Ferry, (Car) for Car or (Train) for Train product : ");
            product = Console.ReadLine();
            //Console.WriteLine("1.0.3");
            return product.ToLower().Trim();

        }
        public string TripType()
        {
            Console.WriteLine("Choose (one way) for One Way or (return) for Return Trip : ");
            tripType = Console.ReadLine();
            //Console.WriteLine("1.0.4");
            if (product == "car")
            {
                tripType = "oneway";
                return tripType.ToLower().Trim();
            }
            return tripType.ToLower().Trim();

        }
        public string PaymentType()
        {
            //Console.WriteLine("Choose (1) Online Banking (2) for Paypal: ");
            //string PaymentType = Console.ReadLine();
            Console.WriteLine("Choose (sgd) for PayPal SGD or (myr) for PayPal MYR : ");
            string PayPalType = Console.ReadLine();
            //Console.WriteLine("1.0.5");
            return PayPalType.ToLower().Trim();

        }
    }
}
