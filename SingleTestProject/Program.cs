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
            string urlOS;
            Console.WriteLine("Enter CartID : ");
            string cartID = Console.ReadLine();
            Console.WriteLine("Enter Site type : ");
            string siteType = Console.ReadLine();
           
            string productType, orderNo, CartID, PurchaseDate, passengerName, Company, tripDetail, tripDuration;

            String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
            XmlDocument xml = new XmlDocument();
            IWebDriver Maindriver = new ChromeDriver();
            Console.WriteLine("Launching browser");

            LaunchBrowser2 newURL = new LaunchBrowser2(xml, Maindriver);
            newURL.GoToURL(siteType, cartID);

            OrderSummary2 OStest = new OrderSummary2(xml, Maindriver);
            
            productType = OStest.GetProductName(cartID);
            OStest.ReadElement(XMLFilePath, siteType);
            OStest.GetDiv1();
           
            CartID = OStest.GetCartID();
            orderNo = OStest.GetOrderNo();

            OStest.GetDepartPlace();
            OStest.GetArrivePlace();

            tripDetail = OStest.Journey();
            PurchaseDate = OStest.GetPurchaseDate();
            tripDuration = OStest.GetTripInfo();
            passengerName = OStest.GetPassengerName();
            Company = OStest.GetCompany();

            OStest.GetReturnLocation();
            OStest.Journey();
            OStest.GetCartID();
            OStest.Platform();
            OStest.Server();

            WriteToExcelTest2 OStoExcelTest = new WriteToExcelTest2();
            WriteToExcelLive2 OStoExcelLive = new WriteToExcelLive2();

            if (passengerName.ToLower().Contains("live"))
            {
                OStoExcelLive.ExcelWrite(productType, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company);
            }
            else
            {
                OStoExcelTest.ExcelWrite(productType, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company);
            }
        }
    }
}
