using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Xml;
using System.IO;
using System.Reflection;

namespace SingleTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://test.easybook.com/en-my/payment/paymentresult?guid=TRa77f991416864df3b1&source=PaypalEC_MYR&status=completed";
           // FerryOrderSummary newOS = new FerryOrderSummary();
            TrainOrderSummary newOS = new TrainOrderSummary();
            newOS.LaunchBrowser(url);
            newOS.ProductName();
             newOS.OrderNo();
            newOS.CartID();
             newOS.PurchaseDate();
            newOS.DepartPlace();
            newOS.ArrivePlace();
            newOS.Journey();
            newOS.DepartTime();
            newOS.Company();
            newOS.PassengerName();
            newOS.Server();
            newOS.Platform();

            /*
            for(int i = 0; i<10; i++)
            {
                for (int j = 0; j<10; j++)
                {
                    if (j == 3)
                    {
                        continue;
                    }
                    Console.WriteLine("i = " + i + " - j = " + j);
                }
            }*/

        }
    }
}
