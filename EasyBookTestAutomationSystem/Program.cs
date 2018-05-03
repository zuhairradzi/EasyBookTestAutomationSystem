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
            string server;
            string site;
            string product;
            string tripType;
            string paymentType;

         
            //IWebDriver Maindriver = new ChromeDriver();
            String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
            XmlDocument xml = new XmlDocument();
            //XMLtest test1 = new XMLtest(xml, Maindriver);
            //test1.testReadXML(XMLFilePath);


            //----------------------SANDBOX CLASSES-------------------------//

            //---CHECK SERVER--//
            
            IWebDriver Maindriver = new ChromeDriver();
            //ServerSandbox testConnectServer = new ServerSandbox(xml, Maindriver);
            //testConnectServer.LaunchBrowser(XMLFilePath);



            //---LAUNCH & LOGIN EB SITE ---//
            LaunchBrowserSandbox LaunchTest = new LaunchBrowserSandbox(xml, Maindriver);
             LaunchTest.LaunchBrowser();
             LaunchTest.loginEB(XMLFilePath);


             //--- PRODUCT AND DESTINATION ---//
            ProductDestSandbox productTest = new ProductDestSandbox(xml, Maindriver);
             productTest.chooseProduct(XMLFilePath);
             productTest.goToProductURL();


            //--- CHOOSE COUNTRY ---//
            ChooseCountrySandbox CountryTest = new ChooseCountrySandbox(xml, Maindriver);
            CountryTest.ChangeCountry(XMLFilePath);


            //--- CHOOSE TRIP TYPE ---//
            TripTypeSandbox TripTypeTest = new TripTypeSandbox(xml, Maindriver);
            TripTypeTest.chooseTripType(XMLFilePath);

            //--- SELECT DATE  ---//
            /*DateSandbox SelectDateTest = new DateSandbox(xml, Maindriver);
            SelectDateTest.ChooseDate(XMLFilePath);

            //--- SUBMIT SEARCH  ---//
            /*SubmitSearch newSearch = new SubmitSearch(Maindriver);
            newSearch.confirmSearch();

            //--- SELECT TRIP  ---//
            SelectTripSandbox TripTest = new SelectTripSandbox(Maindriver);
            TripTest.selectTrip();*/



            //---------------------LIVE PROGRAM----------------------------//

            //-----MAIN MENU-----//
            /*
            Menu mainMenu = new Menu();
             Console.WriteLine("EB TEST AUTOMATION SYSTEM");
             Console.WriteLine();
             Console.WriteLine();


             //----------------------------------Enter server--------------------//
             server = mainMenu.ServerType();
             while ((server != "s1") && (server !="s2"))
             {
                 Console.WriteLine("Wrong server input");
                 server = mainMenu.ServerType();
             }
             Console.WriteLine();


             //----------------------------------Enter site--------------------//
             site = mainMenu.Site();
             while ((site != "test") && (site != "live"))
             {
                 Console.WriteLine("Wrong site input");
                 site = mainMenu.Site();
             }
             Console.WriteLine();


             //----------------------------------Enter product--------------------//
             product = mainMenu.Product();
             while ((product != "bus") && (product != "car")&&(product != "train") && (product != "ferry"))
             {
                 Console.WriteLine("Wrong product input");
                 product = mainMenu.Product();
             }
             Console.WriteLine();


             //----------------------------------Enter trip type and payment type--------------------//
             if (product == "car")
             {
                 tripType = "oneway";
                 paymentType = mainMenu.PaymentType();
                 while ((paymentType != "myr") && (paymentType != "sgd"))
                 {
                     Console.WriteLine("Wrong payment type input");
                     paymentType = mainMenu.PaymentType();
                 }
                 Console.WriteLine();
             }
             else
             {
                 tripType = mainMenu.TripType();
                 while ((tripType != "oneway") && (tripType != "return"))
                 {
                     Console.WriteLine("Wrong trip type input");
                     tripType = mainMenu.TripType();
                 }
                 Console.WriteLine();

                 paymentType = mainMenu.PaymentType();
                 while ((paymentType != "myr") && (paymentType != "sgd"))
                 {
                     Console.WriteLine("Wrong payment type input");
                     paymentType = mainMenu.PaymentType();
                 }
                 Console.WriteLine();
             }




             //-----TEST CASE----//

             TestCases newCase = new TestCases();
             //nsole.WriteLine("2.0");
             string testScenario = newCase.testCase(server, site, product, tripType, paymentType);
             //Console.WriteLine("2.1");



             //-----TEST DESCRIPTION-----//
             TestDescription testDetail = new TestDescription();
             Console.WriteLine();
             Console.WriteLine();
             testDetail.testInformation(testScenario);
             Console.WriteLine();
             Console.WriteLine();



            //-----LAUNCH CHROME----//
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-impl-side-painting");

            IWebDriver Maindriver = new ChromeDriver();
            Console.WriteLine("Launching browser");
          

             //-----CHOOSE SITE---//

             SiteName newURL = new SiteName();
            //Console.WriteLine("3.0");
            string ChooseEBurl = newURL.chooseEBSite(testScenario);
            //Console.WriteLine("3.1");


             //-----SERVER CONNECTION---//

             ServerConnection newServer = new ServerConnection(Maindriver);
              //Console.WriteLine("4.0");
              newServer.LaunchBrowser(testScenario, ChooseEBurl);
              //Console.WriteLine("4.1");


             //-----LOGIN EB SITE---//
             LoginEBSite newLogin = new LoginEBSite(Maindriver);
             newLogin.loginEB(ChooseEBurl);


             //--- PRODUCT AND DESTINATION ---//
             ProductAndDest newProduct = new ProductAndDest(Maindriver);
             newProduct.chooseProduct(testScenario, ChooseEBurl);

             //--- CHOOSE COUNTRY ---//
             ChooseCountry CountryTest = new ChooseCountry (Maindriver);
             CountryTest.ChangeCountry(testScenario);

             //--- CHOOSE TRIP TYPE ---//
             TripType newTripType = new TripType(Maindriver);
             newTripType.chooseTripType(testScenario);
             

            //--- SELECT DATE  ---//
            Date newChooseDate = new Date (Maindriver);
            newChooseDate.ChooseDate(testScenario);

            //--- SUBMIT SEARCH  ---//
            SubmitSearch newSearch = new SubmitSearch(Maindriver);
            newSearch.confirmSearch();

            //--- SELECT TRIP  ---//
            SelectTrip newTrip = new SelectTrip(Maindriver);
            newTrip.selectTrip(testScenario);*/

        }
    }
    
}
