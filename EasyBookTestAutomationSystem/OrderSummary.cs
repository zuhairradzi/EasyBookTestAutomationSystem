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

namespace EasyBookTestAutomationSystem
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

        string testID = "";

        string OrderNo, Div1, DivOne, DepartPlace, productName,
           ArrivePlace, DepartTime, Company, PassengerName,
           ServerPlatform, ReturnLocation, RentDuration, CarDetail, product;

        public void ReadElement(string XMLpath, string prodName)
        {
            product = char.ToUpper(prodName[0]) + prodName.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/OrderSummary");
            foreach (XmlNode xnode in xnMenu)
            {
                OrderNo = xnode[product]["OrderNo"]["XPath"].InnerText.Trim();
                //Console.WriteLine("OrderNo : " + OrderNo);

                Div1 = xnode[product]["Div1"]["XPath"].InnerText.Trim();
                Console.WriteLine("Div1 : " + Div1);

                DepartPlace = xnode[product]["DepartPlace"]["XPath"].InnerText.Trim();
                //Console.WriteLine("DepartPlace : " + DepartPlace);

                if (product.ToLower().Contains("ferry") || product.ToLower().Contains("bus"))
                {
                    ArrivePlace = xnode[product]["ArrivePlace"]["XPath"].InnerText.Trim();
                    //Console.WriteLine("ArrivePlace : " + ArrivePlace);

                    ReturnLocation = "";
                    CarDetail = "";
                    RentDuration = "";
                }

                DepartTime = xnode[product]["DepartTime"]["XPath"].InnerText.Trim();
                //Console.WriteLine("DepartTime : " + DepartTime);

                Company = xnode[product]["Company"]["XPath"].InnerText.Trim();
                //Console.WriteLine("Company : " + Company);

                PassengerName = xnode[product]["PassengerName"]["XPath"].InnerText.Trim();
                //Console.WriteLine("PassengerName : " + PassengerName);

                ServerPlatform = xnode[product]["ServerPlatform"]["XPath"].InnerText.Trim();
                //Console.WriteLine("ServerPlatform : " + ServerPlatform);

                if (product.ToLower().Contains("car"))
                {
                    ReturnLocation = xnode[product]["ReturnLocation"]["XPath"].InnerText.Trim();
                    //Console.WriteLine("ReturnLocation : " + ReturnLocation);

                    RentDuration = xnode[product]["RentDuration"]["XPath"].InnerText.Trim();
                    //Console.WriteLine("RentDuration : " + RentDuration);

                    CarDetail = xnode[product]["CarDetail"]["XPath"].InnerText.Trim();
                    //Console.WriteLine("CarDetail : " + CarDetail);

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
                //Console.WriteLine("SS OS done");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("OS not found");

            }
        }
        public void GetDiv1()
        {
            try
            {
                var DivEl = driver.FindElement(By.XPath(Div1));
                DivOne = DivEl.Text.ToString().Trim();
                Console.WriteLine();
                Console.WriteLine("Div one = "+DivOne);
                Console.WriteLine();
                //Console.WriteLine("Order no : "+ OrderNo.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Order No not found");

            }

        }

        public string GetProductName()
        {
            try
            {

                if (product == "Bus")
                {
                    productName = "Bus";
                    //return productName;
                }
                else if (product == "Car")
                {
                    productName = "Car";
                    //return productName;
                }
                else if (product == "Ferry")
                {
                    productName = "Ferry";
                    //return productName;
                }
                else if (product == "Train")
                {
                    productName = "Train";
                    //return productName;
                }
                Console.WriteLine("productName : " + productName);
                return productName;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("productName not found");
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
                Console.WriteLine("Purchase date : " + PurchaseDate);
                return PurchaseDate;


            }
            catch (NoSuchElementException)
            {
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
                    Console.WriteLine("Front trim = "+ FrontTrim);
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
                    Console.WriteLine(FrontTrim);
                    string BackTrim = FrontTrim.Remove(21, 23);
                    Console.WriteLine(BackTrim);
                    cartID = BackTrim.Trim();
                    Console.WriteLine("Cart ID : " + cartID);
                }
                return cartID;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("CartID not found");
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
                //Console.WriteLine("Order no : "+ OrderNo.Text);
                return orderNo;

            }
            catch (NoSuchElementException)
            {
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
                Console.WriteLine("Arrive Place not found");

            }

        }

        public string Journey()
        {
            if (product == "Bus"||product == "Ferry")
            {
                try
                {
                    var DepartPlaceElem = driver.FindElement(By.XPath(DepartPlace));
                    var ArrivePlaceElem = driver.FindElement(By.XPath(ArrivePlace));
                    string depPlace = DepartPlaceElem.Text.ToString().Trim();
                    //Console.WriteLine("Arrive Place : " + depPlace);
                    string arrPlace = ArrivePlaceElem.Text.ToString().Trim();
                    // Console.WriteLine("Arrive Place : " + arrPlace);
                    Console.WriteLine("Journey is : " + depPlace + " to " + arrPlace);
                    tripInfo = depPlace + " to " + arrPlace;
                    Console.WriteLine("trip info : " + tripInfo);
                    return tripInfo;

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Journey not found");
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
                    // Console.WriteLine("Company: " + Company.Text);
                    return tripInfo;
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("CarInfo not found");
                    return null;

                }
            }
            Console.WriteLine("Trip Info not found");
            return null;
        }
   

        public string GetTripInfo()
        {
            if (product == "Bus" || product == "Ferry")
            {
                try
                {
                    var DepartTimeElem = driver.FindElement(By.XPath(DepartTime));
                    depTime = DepartTimeElem.Text.ToString().Trim();
                    Console.WriteLine("Depart Time : " + depTime);
                    //Console.WriteLine("Depart Time: " + DepartTime.Text);
                    return depTime;
                }
                catch (NoSuchElementException)
                {
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
                    // Console.WriteLine("Company: " + Company.Text);
                    return RentTime;

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("CarInfo not found");
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
                // Console.WriteLine("Company: " + Company.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Return Location not found");

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
                Console.WriteLine("Passenger Name not found");
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
                // Console.WriteLine("Company: " + Company.Text);
                return CompanyName;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Company not found");
                return null;

            }

        }

        public void Server()
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
                }
                else if (serverTrim.Contains("G3ASPRO02"))
                {
                    string serverName = "Server 2";
                    string serverName2 = "G3ASPRO02";
                    Console.WriteLine("Server : " + serverName + " - " + serverName2);
                }
                else
                {
                    Console.WriteLine("Server name not found");
                }


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server Name not found");

            }

        }

        public void Platform()
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
                }
                else if (platTrim.Contains("desktop"))
                {
                    string platName = "Desktop Browser";
                    Console.WriteLine("Platform : " + platName);
                }
                else
                {
                    Console.WriteLine("Platform name not found");
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Platform Name not found");

            }

        }
      

    }
}
