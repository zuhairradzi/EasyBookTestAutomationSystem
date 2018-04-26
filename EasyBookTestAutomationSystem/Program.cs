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
using Microsoft.Office.Interop.Access.Dao;

namespace EasyBookTestAutomationSystem
{


    class Program
    {   
        static void Main(string[] args)
        {
            
            XmlTextReader reader = new XmlTextReader("EBlogin.xml");
            XmlNodeList xmlnode;
            XmlNode node = Document.SelectSingleNode("/Employees");
            
            
            




            /*
            Menu mainMenu = new Menu();
           // Console.WriteLine("1.0");
            string server = mainMenu.ServerType();
            string site = mainMenu.Site();
            string product = mainMenu.Product();
            string tripType = mainMenu.TripType();
            string paymentType = mainMenu.PaymentType();
            //Console.WriteLine("1.1");




            IWebDriver Maindriver = new ChromeDriver();
            
            TestCases newCase = new TestCases();
            //Console.WriteLine("2.0");
            string testScenario = newCase.testCase(server, site, product, tripType, paymentType);
            //Console.WriteLine("2.1");

            SiteName newURL = new SiteName();
            //Console.WriteLine("3.0");
            string ChooseEBurl = newURL.chooseEBSite(testScenario);
            //Console.WriteLine("3.1");

            ServerConnection newServer = new ServerConnection(Maindriver);
            //Console.WriteLine("4.0");
            newServer.LaunchBrowser(testScenario, ChooseEBurl);
            //Console.WriteLine("4.1");


            LoginEBSite newLogin = new LoginEBSite(Maindriver);
            newLogin.loginEB();



            //newServer.ServerChoosen(testScenario, ChooseEBurl);
            //Console.WriteLine("4.2");*/

            /*
            ClassTestBuy test1 = new ClassTestBuy(Maindriver);

            test1.LaunchBrowser();
            test1.LaunchBrowser2();
           
            ClassOrderSummary test2 = new ClassOrderSummary(Maindriver);

            test2.LaunchBrowser3();
            




            /*for (int i = 0; i <info.Length; i++)
            {
                Console.WriteLine(info[i]);
                Console.WriteLine();
            }*/
        }
    }
    
}
