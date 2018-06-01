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
using System.Windows.Forms;

namespace EBTestGUI
{
    class OrderSummary
    {
        private IWebDriver driver;
        private XmlDocument xml;

        public OrderSummary(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }


        string PurchaseDate, cartID, orderNo, Passenger, CompanyName, tripInfo, tripDuration, depTime, arriveTime, RentTime;
        string OrderNo, Div1, DivOne, DepartPlace, productName,
           ArrivePlace, DepartTime, Company, PassengerName,
           ServerPlatform, ReturnLocation, RentDuration, CarDetail, product, siteType;

        public void ReadElement(string XMLpath, string prodName, string site)
        {
            siteType = char.ToUpper(site[0]) + site.Substring(1);
            product = char.ToUpper(prodName[0]) + prodName.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/OrderSummary");
            foreach (XmlNode xnode in xnMenu)
            {
                OrderNo = xnode[product][siteType]["OrderNo"]["XPath"].InnerText.Trim();
                Div1 = xnode[product][siteType]["Div1"]["XPath"].InnerText.Trim();
                DepartPlace = xnode[product][siteType]["DepartPlace"]["XPath"].InnerText.Trim();

                if (product.ToLower().Contains("ferry") || product.ToLower().Contains("bus") || product.ToLower().Contains("train"))
                {
                    ArrivePlace = xnode[product][siteType]["ArrivePlace"]["XPath"].InnerText.Trim();
                    ReturnLocation = "";
                    CarDetail = "";
                    RentDuration = "";
                }

                DepartTime = xnode[product][siteType]["DepartTime"]["XPath"].InnerText.Trim();
                Company = xnode[product][siteType]["Company"]["XPath"].InnerText.Trim();
                PassengerName = xnode[product][siteType]["PassengerName"]["XPath"].InnerText.Trim();
                ServerPlatform = xnode[product][siteType]["ServerPlatform"]["XPath"].InnerText.Trim();

                if (product.ToLower().Contains("car"))
                {
                    ReturnLocation = xnode[product][siteType]["ReturnLocation"]["XPath"].InnerText.Trim();
                    RentDuration = xnode[product][siteType]["RentDuration"]["XPath"].InnerText.Trim();
                    CarDetail = xnode[product][siteType]["CarDetail"]["XPath"].InnerText.Trim();
                    ArrivePlace = "";
                }
            }

            string url = driver.Url;
            Console.WriteLine();
            Console.WriteLine("OS URL is : ");
            Console.WriteLine();
            Console.WriteLine(url);
            Console.WriteLine();

        }

        public void ScreenShotsOS()
        {
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString("h:mm:ss:tt  d/MMMM/y"));
            TimeAndDate.Replace("/", " ");
            TimeAndDate.Replace(":", ".");
            string currentDate = Convert.ToString(TimeAndDate);

            try
            {
                //Thread.Sleep(3000);
                string url = driver.Url;
                Console.WriteLine();
                Console.WriteLine("OS URL is : ");
                Console.WriteLine();
                Console.WriteLine(url);
                Console.WriteLine();
                Console.WriteLine();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.Id("print-content")));
                var OS = driver.FindElement(By.Id("print-content"));
                Actions actionsPay = new Actions(driver);
                actionsPay.MoveToElement(OS);
                actionsPay.Perform();
                Screenshot ss1 = ((ITakesScreenshot)driver).GetScreenshot();
                ss1.SaveAsFile("D:/Screenshots\\" + currentDate + " (OS).png", OpenQA.Selenium.ScreenshotImageFormat.Png);
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Order summary not found");
                Console.WriteLine("Order summary not found");
            }
        }
        public void GetDiv1()
        {
            Thread.Sleep(2000);
            try
            {
                var DivEl = driver.FindElement(By.XPath(Div1));
                DivOne = DivEl.Text.ToString().Trim();
                Console.WriteLine();
                Console.WriteLine("Div one = " + DivOne);
                Console.WriteLine();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Div one not found");
                Console.WriteLine("Div one not found");
            }

        }

        public string GetProductName()
        {
            try
            {

                if (product == "Bus")
                {
                    productName = "Bus";
                }
                else if (product == "Car")
                {
                    productName = "Car";
                }
                else if (product == "Ferry")
                {
                    productName = "Ferry";
                }
                else if (product == "Train")
                {
                    productName = "Train";
                }
                Console.WriteLine("productName : " + productName);
                return productName;

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Product name not found");
                Console.WriteLine("Product name not found");
                return null;
            }

        }

        public string GetPurchaseDate()
        {
            try
            {
                if (product == "Bus")
                {
                    string FrontTrim = DivOne.Remove(0, 40);
                    //Console.WriteLine(FrontTrim);
                    string BackTrim = FrontTrim.Remove(21, 69);
                    //Console.WriteLine(BackTrim);
                    PurchaseDate = BackTrim.Trim();
                    //Console.WriteLine(PurchaseDate);
                    Console.WriteLine("Purchase date : " + PurchaseDate);
                    //return PurchaseDate;
                }

                else if (product == "Car")
                {
                    string FrontTrim = DivOne.Remove(0, 42);
                    //Console.WriteLine(FrontTrim);
                    string BackTrim = FrontTrim.Remove(21, 69);
                    //Console.WriteLine(BackTrim);
                    PurchaseDate = BackTrim.Trim();
                    //Console.WriteLine(PurchaseDate);
                    Console.WriteLine("Purchase date : " + PurchaseDate);
                    //return PurchaseDate;
                }
                else if (product == "Ferry")
                {
                    string FrontTrim = DivOne.Remove(0, 61);
                    string BackTrim = FrontTrim.Remove(20, 54);
                    PurchaseDate = BackTrim.Trim();
                    Console.WriteLine("Purchase date : " + PurchaseDate);
                    //return PurchaseDate;

                }

                else if (product == "Train")
                {
                    string FrontTrim = DivOne.Remove(0, 40);
                    string BackTrim = FrontTrim.Remove(22, 68);
                    PurchaseDate = BackTrim.Trim();
                    Console.WriteLine("Purchase date : " + PurchaseDate);
                    //return PurchaseDate;

                }
                Console.WriteLine("Purchase date : " + PurchaseDate);
                return PurchaseDate;


            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Purchase date not found");
                Console.WriteLine("Purchase date not found");
                return null;

            }

        }

        public string GetCartID()
        {
            try
            {

                if (product == "Bus")
                {
                    string FrontTrim = DivOne.Remove(0, 71);
                    //Console.WriteLine("Front trim = "+ FrontTrim);
                    string BackTrim = FrontTrim.Remove(21, 38);
                    //Console.WriteLine(BackTrim);
                    cartID = BackTrim.Trim();
                    //Console.WriteLine(CartID);
                    Console.WriteLine("Cart ID : " + cartID);
                }

                else if (product == "Car")
                {
                    string FrontTrim = DivOne.Remove(0, 73);
                    //Console.WriteLine(FrontTrim);
                    string BackTrim = FrontTrim.Remove(23, 36);
                    //Console.WriteLine(BackTrim);
                    cartID = BackTrim.Trim();
                    //Console.WriteLine(PurchaseDate);
                    Console.WriteLine("Cart ID : " + cartID);
                }
                else if (product == "Ferry")
                {
                    string FrontTrim = DivOne.Remove(0, 91);
                    //Console.WriteLine(FrontTrim);
                    string BackTrim = FrontTrim.Remove(21, 23);
                    //Console.WriteLine(BackTrim);
                    cartID = BackTrim.Trim();
                    Console.WriteLine("Cart ID : " + cartID);
                }
                else if (product == "Train")
                {
                    string FrontTrim = DivOne.Remove(0, 71);
                    //Console.WriteLine(FrontTrim);
                    string BackTrim = FrontTrim.Remove(21, 38);
                    // Console.WriteLine(BackTrim);
                    cartID = BackTrim.Trim();
                    Console.WriteLine("Cart ID : " + cartID);
                }
                return cartID;

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Cart ID not found");
                Console.WriteLine("Cart ID not found");
                return null;
            }

        }
        public string GetOrderNo()
        {
            try
            {
                var OrderNoEl = driver.FindElement(By.XPath(OrderNo));
                orderNo = OrderNoEl.Text.ToString().Trim();
                Console.WriteLine("Order no : " + orderNo);
                return orderNo;

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Order No not found");
                Console.WriteLine("Order No not found");
                return null;
            }

        }



        public void GetDepartPlace()
        {
            try
            {
                var DepartPlaceElem = driver.FindElement(By.XPath(DepartPlace));
                string depPlace = DepartPlaceElem.Text.ToString().Trim();
                Console.WriteLine("Depart Place: " + depPlace);

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Depart Place not found");
                Console.WriteLine("Depart Place not found");
            }

        }

        public void GetArrivePlace()
        {
            try
            {
                var ArrivePlaceElem = driver.FindElement(By.XPath(ArrivePlace));
                string arrPlace = ArrivePlaceElem.Text.ToString().Trim();
                Console.WriteLine("Arrive Place : " + arrPlace);

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Arrive Place not found");
                Console.WriteLine("Arrive Place not found");
            }

        }

        public string Journey()
        {
            if (product == "Bus" || product == "Ferry" || product == "Train")
            {
                try
                {
                    var DepartPlaceElem = driver.FindElement(By.XPath(DepartPlace));
                    var ArrivePlaceElem = driver.FindElement(By.XPath(ArrivePlace));
                    string depPlace = DepartPlaceElem.Text.ToString().Trim();
                    string arrPlace = ArrivePlaceElem.Text.ToString().Trim();
                    Console.WriteLine("Journey is : " + depPlace + " to " + arrPlace);
                    tripInfo = depPlace + " to " + arrPlace;
                    Console.WriteLine("trip info : " + tripInfo);
                    return tripInfo;

                }
                catch (NoSuchElementException)
                {
                    MessageBox.Show("Trip Info not found");
                    Console.WriteLine("Trip Info not found");
                    return null;
                }
            }

            else if (product == "Car")
            {
                try
                {
                    var CarDetailElem = driver.FindElement(By.XPath(CarDetail));
                    tripInfo = CarDetailElem.Text.ToString().Trim();
                    Console.WriteLine("CarInfo : " + tripInfo);
                    return tripInfo;
                }
                catch (NoSuchElementException)
                {
                    MessageBox.Show("Car Info not found");
                    Console.WriteLine("Car Info not found");
                    return null;

                }
            }
            Console.WriteLine("Trip Info not found");
            return null;
        }


        public string GetTripInfo()
        {
            if (product == "Bus" || product == "Ferry" || product == "Train")
            {
                try
                {
                    var DepartTimeElem = driver.FindElement(By.XPath(DepartTime));
                    depTime = DepartTimeElem.Text.ToString().Trim();
                    Console.WriteLine("Depart Time : " + depTime);
                    return depTime;
                }
                catch (NoSuchElementException)
                {
                    MessageBox.Show("Depart Time not found");
                    Console.WriteLine("Depart Time not found");
                    return null;
                }
            }

            else if (product == "Car")
            {
                try
                {
                    var RentDurationElem = driver.FindElement(By.XPath(RentDuration));
                    RentTime = RentDurationElem.Text.ToString().Trim();
                    Console.WriteLine("RentTime : " + RentTime);
                    return RentTime;

                }
                catch (NoSuchElementException)
                {
                    MessageBox.Show("Rent Period not found");
                    Console.WriteLine("Rent Period not found");
                    return null;
                }
            }

            Console.WriteLine("Trip Info not found");
            return null;
        }

        public void GetReturnLocation()
        {
            try
            {
                var ReturnLocationElem = driver.FindElement(By.XPath(ReturnLocation));
                string ReturnLoc = ReturnLocationElem.Text.ToString().Trim();
                Console.WriteLine("ReturnLoc : " + ReturnLoc);

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Return Location not found");
            }

        }

        public string GetPassengerName()
        {
            try
            {
                var PassengerNameElem = driver.FindElement(By.XPath(PassengerName));
                Passenger = PassengerNameElem.Text.ToString().Trim();
                Console.WriteLine("Passenger Name : " + Passenger);
                return Passenger;


            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Passenger Name not found");
                Console.WriteLine("Pasengger Name not found");
                return null;

            }

        }

        public string GetCompany()
        {
            try
            {
                var CompanyElem = driver.FindElement(By.XPath(Company));
                CompanyName = CompanyElem.Text.ToString().Trim();
                Console.WriteLine("Company : " + CompanyName);
                return CompanyName;

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Company not found");
                Console.WriteLine("Company not found");
                return null;

            }

        }

        public string Server()
        {
            try
            {
                var ServPlat = driver.FindElement(By.XPath(ServerPlatform));
                string strServPlat = ServPlat.Text.ToString();
                string serverTrim = strServPlat.Trim();
                if (serverTrim.Contains("G3ASPRO01"))
                {
                    string serverName = "Server 1";
                    string serverName2 = "G3ASPRO01";
                    Console.WriteLine("Server : " + serverName + " - " + serverName2);
                    return serverName2;
                }
                else if (serverTrim.Contains("G3ASPRO02"))
                {
                    string serverName = "Server 2";
                    string serverName2 = "G3ASPRO02";
                    Console.WriteLine("Server : " + serverName + " - " + serverName2);
                    return serverName2;
                }
                else
                {
                    MessageBox.Show("Server name not found");
                    Console.WriteLine("Server name not found");
                    return null;
                }


            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Server not found");
                Console.WriteLine("Server not found");
                return null;
            }

        }

        public string Platform()
        {
            try
            {
                var ServPlat = driver.FindElement(By.XPath(ServerPlatform));
                string strServPlat = ServPlat.Text.ToString();
                string platTrim = strServPlat.Trim().ToLower();

                if (platTrim.Contains("mobile"))
                {
                    string platName = "Mobile Browser";
                    Console.WriteLine("Platform : " + platName);
                    return platName;
                }
                else if (platTrim.Contains("desktop"))
                {
                    string platName = "Desktop Browser";
                    Console.WriteLine("Platform : " + platName);
                    return platName;
                }
                else
                {
                    MessageBox.Show("Platform not found");
                    Console.WriteLine("Platform name not found");
                    return null; 
                }

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Platform not found");
                Console.WriteLine("Platform not found");
                return null;
            }

        }
    }
}
