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
using System.Diagnostics;


namespace EBTestGUI
{
    public partial class Form1 : Form
    {
        String sqlString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Easybook KL\\Documents\\testlogin.mdf\";Integrated Security=True;Connect Timeout=30";
        String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
        XmlDocument xml = new XmlDocument();
        IWebDriver Maindriver;
        Stopwatch sw = new Stopwatch();
        TimeSpan ts;

        string product, site, siteBH, paypal, server;
        string productName, orderNo, CartID, PurchaseDate, passengerName, Company, tripDetail, tripDuration, serverTestBuy, platformTestBuy;
        string orderNumber, dateHistory;
        string textFieldOS, radioGenOS;
        string timeStart, timeEnd, duration, elapsedTime;

        string busHisXP, ferHisXP, traHisXP, carHisXP;


        List<Panel> newList = new List<Panel>();

        private void SelTest_Click(object sender, EventArgs e)
        {
            ChromeDriver driver = new ChromeDriver("D:\\");
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();


        }

        public Form1()
        {
            InitializeComponent();
            return;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            newList.Add(panelTestBuy);//0
            newList.Add(panelCheckBH);//1
            newList.Add(panelInstruction);//2
            newList.Add(panelGenOS); //3
            labelMenuTitle.Text = "Instruction";
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login logOut = new Login();
            logOut.Show();
        }

      

        private void GenOSAction(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            radioGenOS = button.Text;
        }

        private void GenerateOSTab_Click(object sender, EventArgs e)
        {
            newList[3].BringToFront();
            labelMenuTitle.Text = "Generate Order Summary";
        }
        
        private void CheckBHButton_Click(object sender, EventArgs e)
        {
            newList[1].BringToFront();
            labelMenuTitle.Text = "Check Booking History";
            //panelCheckBH.BringToFront();
        }

        private void TestBuyButton_Click(object sender, EventArgs e)
        {
            newList[0].BringToFront();
            labelMenuTitle.Text = "Test Buy Automation";
        }

        private void InstructionButton_Click(object sender, EventArgs e)
        {
            newList[2].BringToFront();
            labelMenuTitle.Text = "Instruction";
        }

        private void XMLDocButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage form2 = new HomePage();
            form2.Show();
            form2.xmlPath(XMLFilePath);
        }
        private void siteName(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            siteBH = button.Text;
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

        private void serverType(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            server = button.Text;
        }

        private void siteType(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            site = button.Text;           
        }


        private void OrderNo_Click(object sender, EventArgs e)
        {
            OrderNo_textBox.Text = "";
            //orderNumber = OrderNo_textBox.Text;
        }

        private void OSTextField_Click(object sender, EventArgs e)
        {
            OS_textField.Text = "";
        }



        private void RunGenOS_Click(object sender, EventArgs e)
        {
            if (OS_textField.Text == "" || OS_textField.Text == "Cart ID")
            {
                MessageBox.Show("Please enter the Cart ID!");
                return;
            }

            if (radioButtonLiveOS.Checked == false && radioButtonTestOS.Checked == false)
            {
                MessageBox.Show("Please choose a site type!");
                return;
            }

            if (GenOS.Checked == false && GenOSWriteExcel.Checked == false)
            {
                MessageBox.Show("Please choose an action!");
                return;
            }

         
            IWebDriver Maindriver = new ChromeDriver("D:\\");
            Console.WriteLine("Launching browser");

            OSLinkGeneration newURL = new OSLinkGeneration(xml, Maindriver);
            newURL.GoToURL(site, OS_textField.Text);

            OrderSummaryGen OStest = new OrderSummaryGen(xml, Maindriver);

            productName = OStest.GetProductName(OS_textField.Text);
            OStest.ReadElement(XMLFilePath, site);
            OStest.GetDiv1();

            CartID = OStest.GetCartID();
            orderNo = OStest.GetOrderNo();

           // OStest.GetDepartPlace();
            //OStest.GetArrivePlace();

            tripDetail = OStest.Journey();
            PurchaseDate = OStest.GetPurchaseDate();
            tripDuration = OStest.GetTripInfo();
            passengerName = OStest.GetPassengerName();
            Company = OStest.GetCompany();

           // OStest.GetReturnLocation();
            platformTestBuy = OStest.Platform();
            serverTestBuy = OStest.Server();

            elapsedTime = "OS generation only";

            if (radioGenOS.ToLower().Contains("excel"))
            {
                WriteToExcelTest OStoExcelTest = new WriteToExcelTest();
                WriteToExcelLive OStoExcelLive = new WriteToExcelLive();

                if (passengerName.ToLower().Contains("live"))
                {
                    OStoExcelLive.ExcelWrite(productName, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company, serverTestBuy, platformTestBuy, elapsedTime);
                }
                else
                {
                    OStoExcelTest.ExcelWrite(productName, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company, serverTestBuy, platformTestBuy, elapsedTime);
                }
            }
           
        }

        private void CheckHistoryClick(object sender, EventArgs e)
        {
            if (OrderNo_textBox.Text == "" || OrderNo_textBox.Text == "Order No")
            {
                MessageBox.Show("Please enter the Order No!");
                return;
            }

            if (radioButtonBusBH.Checked == false && radioButtonFerryBH.Checked == false && radioButtonTrainBH.Checked == false && radioButtonCarBH.Checked == false)
            {
                MessageBox.Show("Please choose a product!");
                return;
            }

            if (radioButtonBHLive.Checked == false && radioButtonBHTest.Checked == false)
            {
                MessageBox.Show("Please choose a site type!");
                return;
            }
            
            if (radioButtonS1BH.Checked == false && radioButtonS2BH.Checked == false && radioButtonNoServerBH.Checked == false)
            {
                MessageBox.Show("Please choose a server type!");
                return;
            }
            Maindriver = new ChromeDriver("D:\\");
            string date = dateTimePickerBH.Value.ToString("MM/dd/yyyy");
            //-----CHOOSE SITE---//
            SiteName newURL = new SiteName(xml, Maindriver);
            string ChooseEBurl = newURL.ReadElement(XMLFilePath, siteBH);

            //-----GO TO SITE---//
            LaunchBrowser newSite = new LaunchBrowser(xml, Maindriver);
            newSite.GoToURL(ChooseEBurl);

            //-----CHECK SERVER---//
            CheckServer NewServer = new CheckServer(xml, Maindriver);
            NewServer.ReadElement(XMLFilePath, siteBH);
            NewServer.CheckServerConnection();


            if (server.ToLower().Contains("s1") || server.ToLower().Contains("s2"))
            {
                //-----SERVER CONNECTION---//
                ConnectToServer newServer = new ConnectToServer(xml, Maindriver);
                newServer.ReadElement(XMLFilePath, server, siteBH);
                newServer.LaunchBrowser(ChooseEBurl);
                Maindriver = newServer.ConnectToServerWanted(ChooseEBurl);
            }

            //-----LOGIN EB SITE---//
            LoginEBSite newLogin = new LoginEBSite(xml, Maindriver);
            newLogin.ReadElement(XMLFilePath);
            newLogin.ReadDB(sqlString);
            newLogin.loginEB();

            //--CHECK BOOKING HISTORY--//
            ManageBooking newHistory = new ManageBooking(xml, Maindriver);
            newHistory.ReadElement(XMLFilePath, siteBH, product);
            newHistory.searchBooking(date, OrderNo_textBox.Text);
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (radioButtonBus.Checked == false && radioButtonFerry.Checked == false && radioButtonTrain.Checked == false && radioButtonCar.Checked == false)
            {
                MessageBox.Show("Please choose a product!");
                return;
            }

            if (radioButtonLive.Checked == false && radioButtonTest.Checked == false)
            {
                MessageBox.Show("Please choose a site type!");
                return;
            }

            if (radioButtonMYR.Checked == false && radioButtonSGD.Checked == false)
            {
                MessageBox.Show("Please choose a currency!");
                return;
            }

            if (radioButtonS1.Checked == false && radioButtonS2.Checked == false && radioButtonNoServer.Checked == false)
            {
                MessageBox.Show("Please choose a server type!");
                return;
            }
            //-----LAUNCH CHROME----//
            
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-impl-side-painting");
            Maindriver = new ChromeDriver("D:\\");

            //--TIMER START--//
            sw.Start();

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

            if(server.ToLower().Contains("s1")|| server.ToLower().Contains("s2"))
            {
                //-----SERVER CONNECTION---//
                ConnectToServer newServer = new ConnectToServer(xml, Maindriver);
                newServer.ReadElement(XMLFilePath, server, site);
                newServer.LaunchBrowser(ChooseEBurl);
                Maindriver = newServer.ConnectToServerWanted(ChooseEBurl);
            }
         
            //-----LOGIN EB SITE---//
            LoginEBSite newLogin = new LoginEBSite(xml, Maindriver);
            newLogin.ReadElement(XMLFilePath);
            newLogin.ReadDB(sqlString);
            newLogin.loginEB();


            //--- PRODUCT AND DESTINATION ---//
            ProductAndDest newProduct = new ProductAndDest(xml, Maindriver);
            newProduct.ReadElement(XMLFilePath, product, site, paypal);
            newProduct.chooseProduct(product, ChooseEBurl);

            //--- CHOOSE COUNTRY ---//
            ChooseCountry CountryTest = new ChooseCountry(xml, Maindriver);
            CountryTest.ReadElement(XMLFilePath);
            CountryTest.ChangeCountry(paypal);

            //--- CHOOSE TRIP TYPE ---//
            TripType newTripType = new TripType(xml, Maindriver);
            newTripType.ReadElement(XMLFilePath, "oneway");
            newTripType.chooseTripType(product);


            //--- SELECT DATE  ---//
            Date newChooseDate = new Date(xml, Maindriver);
            newChooseDate.ReadElement(XMLFilePath, product, site, paypal);
            newChooseDate.ChooseDate(product);

            //--- SUBMIT SEARCH  ---//
            SubmitSearch newSearch = new SubmitSearch(xml, Maindriver);
            newSearch.ReadElement(XMLFilePath, product);
            newSearch.confirmSearch();

            //--- SORT FARE  ---//
            SortFare low = new SortFare(xml, Maindriver);
            low.ReadElement(XMLFilePath, product, site, paypal);
            low.lowFare(product);

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

           // OStest.GetDepartPlace();
            //OStest.GetArrivePlace();

            tripDetail = OStest.Journey();
            PurchaseDate = OStest.GetPurchaseDate();
            tripDuration = OStest.GetTripInfo();
            passengerName = OStest.GetPassengerName();
            Company = OStest.GetCompany();

           // OStest.GetReturnLocation();
             platformTestBuy = OStest.Platform();
             serverTestBuy =  OStest.Server();

            //--STOP TIMER--//
            sw.Stop();
            ts = sw.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            //MessageBox.Show("Time recorded : " + elapsedTime);
            sw.Reset();


            //--WRITE TO EXCEL--//
            WriteToExcelTest OStoExcelTest = new WriteToExcelTest();
            WriteToExcelLive OStoExcelLive = new WriteToExcelLive();

            if (passengerName.ToLower().Contains("live"))
            {
                OStoExcelLive.ExcelWrite(productName, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company, serverTestBuy, platformTestBuy, elapsedTime);
            }
            else
            {
                OStoExcelTest.ExcelWrite(productName, orderNo, CartID, tripDetail, PurchaseDate, tripDuration, passengerName, Company, serverTestBuy, platformTestBuy, elapsedTime);
            }
        }
    }
}
