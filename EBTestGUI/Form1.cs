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
        String sqlString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Easybook KL\\Documents\\testlogin.mdf\";Integrated Security=True;Connect Timeout=30";
        String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
        XmlDocument xml = new XmlDocument();

        string product, site, siteBH, paypal;
        string productName, orderNo, CartID, PurchaseDate, passengerName, Company, tripDetail, tripDuration;
        
        List<Panel> newList = new List<Panel>();

      

        public Form1()
        {
            InitializeComponent();
            return;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            newList.Add(panelTestBuy);
            newList.Add(panelCheckBH);
            newList.Add(panelInstruction);
            newList.Add(panelXMLDoc);
        }


        private void CheckBHButton_Click(object sender, EventArgs e)
        {
            newList[1].BringToFront();
        }

        private void TestBuyButton_Click(object sender, EventArgs e)
        {
            newList[0].BringToFront();
        }

        private void InstructionButton_Click(object sender, EventArgs e)
        {
            newList[2].BringToFront();
        }

        private void XMLDocButton_Click(object sender, EventArgs e)
        {
            newList[3].BringToFront();
        }
        private void siteName(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            siteBH = button.Text;
        }
        
        private void IPServer_Click(object sender, EventArgs e)
        {
            //-----LAUNCH CHROME----//
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-impl-side-painting");
            IPServerLaunch testServer = new IPServerLaunch();
            testServer.LaunchBrowser(siteBH);
            testServer.CheckServerConnection();
            testServer.Login();
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
            newLogin.ReadDB(sqlString);
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
            PaypalTest.ReadDB(sqlString);
            PaypalTest.ClickLogin();
            PaypalTest.enterEmPP();
            PaypalTest.enterPwPP();

            //--- PAYPAL PROCEED  ---//
            PayPalProceed PaypalProceedTest = new PayPalProceed(xml, Maindriver);
            PaypalProceedTest.ReadElement(XMLFilePath);
            PaypalProceedTest.proceedPayPal1(paypal);

            //--- ORDER SUMMARY ---//
            OrderSummary OStest = new OrderSummary(xml, Maindriver);
            OStest.ReadElement(XMLFilePath, product, site);
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


            WriteToExcelTest OStoExcelTest = new WriteToExcelTest();
            WriteToExcelLive OStoExcelLive = new WriteToExcelLive();

            if (passengerName.ToLower().Contains("live"))
            {
                OStoExcelLive.ExcelWrite(productName, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company);
            }
            else
            {
                OStoExcelTest.ExcelWrite(productName, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company);
            }
        }

    }
}
