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
            string productType, orderNo, CartID, PurchaseDate, passengerName, Company, tripDetail, tripDuration;

            String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
            XmlDocument xml = new XmlDocument();
         

            //---------------------LIVE PROGRAM----------------------------//

            //-----MAIN MENU-----//
            
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
             string testScenarioUp = newCase.testCase(server, site, product, tripType, paymentType);
             string testScenario = testScenarioUp.ToLower();

             //-----TEST DESCRIPTION-----//
             TestDescription testDetail = new TestDescription();
             Console.WriteLine();
             testDetail.testInformation(testScenario);
             Console.WriteLine();

            
            //-----LAUNCH CHROME----//
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-impl-side-painting");
            IWebDriver Maindriver = new ChromeDriver();
            Console.WriteLine("Launching browser");
          

             //-----CHOOSE SITE---//
            SiteName newURL = new SiteName(xml, Maindriver);
            string ChooseEBurl = newURL.ReadElement(XMLFilePath, site);
          

            //-----GO TO SITE---//
            LaunchBrowser newSite = new LaunchBrowser(xml, Maindriver);
            newSite.GoToURL(ChooseEBurl);



            //-----SERVER CONNECTION---//
            /*ConnectToServer newServer = new ConnectToServer(xml, Maindriver);
            newServer.ReadElement(XMLFilePath, server, site);
            newServer.LaunchBrowser(ChooseEBurl);
            newServer.ConnectToServerWanted(ChooseEBurl);
            //newServer.Login();*/


            //-----LOGIN EB SITE---//
            LoginEBSite newLogin = new LoginEBSite(xml, Maindriver);
            newLogin.ReadElement(XMLFilePath);
            newLogin.loginEB();


             //--- PRODUCT AND DESTINATION ---//
            ProductAndDest newProduct = new ProductAndDest(xml, Maindriver);
            newProduct.ReadElement(XMLFilePath, testScenario, product);
            newProduct.chooseProduct(ChooseEBurl);

             //--- CHOOSE COUNTRY ---//
            ChooseCountry CountryTest = new ChooseCountry (xml, Maindriver);
            CountryTest.ReadElement(XMLFilePath);
            CountryTest.ChangeCountry(testScenario);

             //--- CHOOSE TRIP TYPE ---//
            TripType newTripType = new TripType(xml, Maindriver);
            newTripType.ReadElement(XMLFilePath, tripType);
            newTripType.chooseTripType();
             

            //--- SELECT DATE  ---//
            Date newChooseDate = new Date (xml, Maindriver);
            newChooseDate.ReadElement(XMLFilePath, product, site, paymentType);
            newChooseDate.ChooseDate(testScenario);

            //--- SUBMIT SEARCH  ---//
            SubmitSearch newSearch = new SubmitSearch(xml, Maindriver);
            newSearch.ReadElement(XMLFilePath, product);
            newSearch.confirmSearch();

            //--- SELECT TRIP  ---//
            SelectTrip newTrip = new SelectTrip(xml, Maindriver);
            newTrip.ReadElement(XMLFilePath, product, site, paymentType);
            newTrip.selectTrip(product);

            //--- SELECT SEAT  ---//
            Seat newSeat = new Seat(xml, Maindriver);
            newSeat.ReadElement(XMLFilePath, product, site, paymentType);
            newSeat.selectSeat(product);

            //--- PASSENGER DETAILS  ---//
            PassengerDetail PassengerTest = new PassengerDetail(xml, Maindriver);
            PassengerTest.ReadElement(XMLFilePath, product);

            //--- PAYMENT METHOD  ---//
            PaymentType PaymentTest = new PaymentType(xml, Maindriver);
            PaymentTest.ReadElement(XMLFilePath, paymentType);
            PaymentTest.PaymentGate();
            PaymentTest.goToCaptcha();
            PaymentTest.PayNow();

             //--- PAYPAL LOGIN  ---//
            PayPalLogin PaypalTest = new PayPalLogin(xml, Maindriver);
            PaypalTest.ReadElement(XMLFilePath);
            PaypalTest.ClickLogin();
            PaypalTest.enterEmPP();
            PaypalTest.enterPwPP();

            //--- PAYPAL PROCEED  ---//
            PayPalProceed PaypalProceedTest = new PayPalProceed(xml, Maindriver);
            PaypalProceedTest.ReadElement(XMLFilePath);
            PaypalProceedTest.proceedPayPal1(paymentType);
            //PaypalProceedTest.proceedPayPal2();
            //PaypalProceedTest.proceedPayPal3();



            //--- ORDER SUMMARY ---//
            OrderSummary OStest = new OrderSummary(xml, Maindriver);
            OStest.ReadElement(XMLFilePath, product);
            OStest.GetDiv1();
            productType = OStest.GetProductName();
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
            
            WriteToExcel OStoExcel = new WriteToExcel();
            OStoExcel.ExcelWrite(productType, orderNo, CartID,  tripDetail, PurchaseDate, tripDuration, passengerName, Company);

        }
    }

 }
