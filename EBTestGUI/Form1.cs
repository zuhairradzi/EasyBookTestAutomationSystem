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
using System.Windows.Forms;

namespace EBTestGUI
{
    public partial class Form1 : Form
    {
        string product, site, paypal;
        string productName, orderNo, CartID, PurchaseDate, passengerName, Company, tripDetail, tripDuration;

        String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
        XmlDocument xml = new XmlDocument();
       
        public Form1()
        {
            InitializeComponent();
            return;
        }

        private void productType(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            product = button.Text;
        }

        private void paypalType(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            paypal = button.Text;
        }

        private void siteType(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            site = button.Text;           
        }
       
        private void Run_Click(object sender, EventArgs e)
        {
            //-----LAUNCH CHROME----//
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-impl-side-painting");
            IWebDriver Maindriver = new ChromeDriver();

            //-----CHOOSE SITE---//
            SiteName newURL = new SiteName(xml, Maindriver);
            string ChooseEBurl = newURL.ReadElement(XMLFilePath, site);


            //-----GO TO SITE---//
            LaunchBrowser newSite = new LaunchBrowser(xml, Maindriver);
            newSite.GoToURL(ChooseEBurl);

            //-----CHECK SERVER---//
            CheckServer NewServer = new CheckServer(xml, Maindriver);
            NewServer.ReadElement(XMLFilePath, site);
            NewServer.CheckServerConnection();

            //-----LOGIN EB SITE---//
            LoginEBSite newLogin = new LoginEBSite(xml, Maindriver);
            newLogin.ReadElement(XMLFilePath);
            newLogin.loginEB();


            //--- PRODUCT AND DESTINATION ---//
            ProductAndDest newProduct = new ProductAndDest(xml, Maindriver);
            newProduct.ReadElement(XMLFilePath, product);
            newProduct.chooseProduct(ChooseEBurl);

            //--- CHOOSE COUNTRY ---//
            ChooseCountry CountryTest = new ChooseCountry(xml, Maindriver);
            CountryTest.ReadElement(XMLFilePath);
            CountryTest.ChangeCountry(paypal);

            //--- CHOOSE TRIP TYPE ---//
            TripType newTripType = new TripType(xml, Maindriver);
            newTripType.ReadElement(XMLFilePath, "oneway");
            newTripType.chooseTripType();


            //--- SELECT DATE  ---//
            Date newChooseDate = new Date(xml, Maindriver);
            newChooseDate.ReadElement(XMLFilePath, product, site, paypal);
            newChooseDate.ChooseDate(product);

            //--- SUBMIT SEARCH  ---//
            SubmitSearch newSearch = new SubmitSearch(xml, Maindriver);
            newSearch.ReadElement(XMLFilePath, product);
            newSearch.confirmSearch();

            //--- SELECT TRIP  ---//
            SelectTrip newTrip = new SelectTrip(xml, Maindriver);
            newTrip.ReadElement(XMLFilePath, product, site, paypal);
            newTrip.selectTrip(product);

            //--- SELECT SEAT  ---//
            Seat newSeat = new Seat(xml, Maindriver);
            newSeat.ReadElement(XMLFilePath, product, site, paypal);
            newSeat.selectSeat(product);

            //--- PASSENGER DETAILS  ---//
            PassengerDetail PassengerTest = new PassengerDetail(xml, Maindriver);
            PassengerTest.ReadElement(XMLFilePath, product);


            //--- PAYMENT METHOD  ---//
            PaymentType PaymentTest = new PaymentType(xml, Maindriver);
            PaymentTest.ReadElement(XMLFilePath, paypal);
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
            PaypalProceedTest.proceedPayPal1(paypal);

            //--- ORDER SUMMARY ---//
            OrderSummary OStest = new OrderSummary(xml, Maindriver);
            OStest.ReadElement(XMLFilePath, product);
            OStest.GetDiv1();
            productName = OStest.GetProductName();
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
            OStoExcel.ExcelWrite(productName, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company);

        }

    }
}
