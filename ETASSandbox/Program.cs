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

namespace ETASSandbox
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


           // IWebDriver Maindriver = new ChromeDriver();
            String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
            XmlDocument xml = new XmlDocument();
            //XMLtest test1 = new XMLtest(xml, Maindriver);
            //test1.testReadXML(XMLFilePath);


            //----------------------SANDBOX CLASSES-------------------------//

           // IsElementPresentSandbox newElementFind = new IsElementPresentSandbox(xml, Maindriver);
           // newElementFind.LaunchBrowser();
          //  newElementFind.Login();

            //---CHECK SERVER--//

            //IWebDriver Maindriver = new ChromeDriver();
           //  ServerSandbox testConnectServer = new ServerSandbox(xml, Maindriver);
           // testConnectServer.LaunchBrowser(XMLFilePath);

           // ServerSandbox2 newServer = new ServerSandbox2(xml, Maindriver);
           // newServer.ReadElement(XMLFilePath);
           // newServer.LaunchBrowser();
           // newServer.ConnectToServerWanted();
            //newServer.Login();

           IPServerLaunch testServer = new IPServerLaunch();
            testServer.LaunchBrowser();
            testServer.CheckServerConnection();
           testServer.Login();

            //---LAUNCH & LOGIN EB SITE ---//
           /* LaunchBrowserSandbox LaunchTest = new LaunchBrowserSandbox(xml, Maindriver);
            LaunchTest.LaunchBrowser();
            LaunchTest.loginEB(XMLFilePath);


            //--- PRODUCT AND DESTINATION ---//
            ProductDestSandbox productTest = new ProductDestSandbox(xml, Maindriver);
            productTest.ReadElement(XMLFilePath);
            productTest.chooseProduct();
            productTest.goToProductURL();


            //--- CHOOSE COUNTRY ---//
            ChooseCountrySandbox CountryTest = new ChooseCountrySandbox(xml, Maindriver);
            CountryTest.ReadElement(XMLFilePath);
            CountryTest.ChangeCountry();


            //--- CHOOSE TRIP TYPE ---//
            TripTypeSandbox TripTypeTest = new TripTypeSandbox(xml, Maindriver);
            TripTypeTest.ReadElement(XMLFilePath);
            TripTypeTest.chooseTripType();

            //--- SELECT DATE  ---//
            DateSandbox SelectDateTest = new DateSandbox(xml, Maindriver);
            SelectDateTest.ReadElement(XMLFilePath);
            SelectDateTest.ChooseDate();

            //--- SUBMIT SEARCH  ---//
            SubmitSearch newSearch = new SubmitSearch(xml, Maindriver);
            newSearch.ReadElement(XMLFilePath);
            newSearch.confirmSearch();

            //--- SELECT TRIP  ---//
            SelectTripSandbox TripTest = new SelectTripSandbox(xml, Maindriver);
            TripTest.ReadElement(XMLFilePath);
            TripTest.selectTrip();

            //--- SELECT SEAT  ---//
            SeatSandbox SeatTest = new SeatSandbox(xml, Maindriver);
            SeatTest.selectSeat(XMLFilePath);

            //--- PASSENGER DETAIL PAGE  ---//
            PassengerDetailSandbox PassengerTest = new PassengerDetailSandbox(xml, Maindriver);
            PassengerTest.ReadElement(XMLFilePath);


            //--- PAYMENT METHOD  ---//
            PaymentTypeSandbox PaymentTest = new PaymentTypeSandbox(xml, Maindriver);
            PaymentTest.ReadElement(XMLFilePath);*/

            //--- PAYPAL LOGIN  ---//
            /*PayPalLoginSandbox PaypalTest = new PayPalLoginSandbox(xml, Maindriver);
            PaypalTest.ReadElement(XMLFilePath);

            //--- PAYPAL PROCEED  ---//
            PayPalProceedSandbox PaypalProceedTest = new PayPalProceedSandbox(xml, Maindriver);
            PaypalProceedTest.ReadElement(XMLFilePath);
            PaypalProceedTest.proceedPayPal();*/

            //--- ORDER SUMMARY ---//
            // OrderSummarySandbox OStest = new OrderSummarySandbox(xml, Maindriver);
             //OStest.ReadElement(XMLFilePath);
             /*OStest.GetDiv1();
             OStest.GetPurchaseDate();
             OStest.GetCartID();
             OStest.GetOrderNo();
             OStest.GetDepartPlace();
             OStest.GetArrivePlace();
             OStest.GetReturnLocation();
             OStest.GetDepartTime();
             OStest.GetRentPeriod();
             OStest.Journey();
             OStest.GetCarDetail();
             OStest.GetCartID();
             OStest.GetCompany();
             OStest.GetPassengerName();
             OStest.Platform();
             OStest.Server();*/

            /*

            OStest.GetDiv1();

            string productType = OStest.getProductName();
            string CartID = OStest.GetCartID();
            string orderNo = OStest.GetOrderNo();
            OStest.GetDepartPlace();
            OStest.GetArrivePlace();
            string tripDetail = OStest.Journey();
            string PurchaseDate = OStest.GetPurchaseDate();
            string tripDuration = OStest.GetDepartTime();
            string passengerName = OStest.GetPassengerName();
            string Company = OStest.GetCompany();


            OStest.GetDepartPlace();
            OStest.GetArrivePlace();
            OStest.GetReturnLocation();
            // OStest.GetDepartTime();
            // OStest.GetRentPeriod();
            OStest.Journey();
            OStest.GetCartID();

            OStest.Platform();
            OStest.Server();

            //NewEmptyCellExcelSandbox cellTest = new NewEmptyCellExcelSandbox();
            //cellTest.ExcelWrite();

            WriteToExcelSandbox logFill = new WriteToExcelSandbox();
            logFill.ExcelWrite(productType, CartID, orderNo, tripDetail, PurchaseDate, tripDuration, passengerName, Company);*/




        }
    }
}
