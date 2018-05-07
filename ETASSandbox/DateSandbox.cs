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

namespace ETASSandbox
{
    class DateSandbox
    {

        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        

        //Conditions product
        string bus = "bus";
        string train = "train";
        string car = "car";
        string ferry = "ferry";

        //Conditions site
        string test = "test";
        string live = "live";

        //Conditions trip type
        string oneway = "oneway";
        string returntrip = "return";

        //Conditions currency
        string myr = "myr";
        string sgd = "sgd";


        string DepElem, RetElem, DepDate, RetDate, carPickTimeElem, carRetTimeElem, carPicTime, carRetTime;

        string product = "Bus";
        string trip = "OneWay";
        string site = "TestSite";
        string currency = "SGD";
        
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        private IWebDriver driver;
        private XmlDocument xml;

        public DateSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath)
        {

            string testID = product + trip + site + currency;
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Date");
            foreach (XmlNode xnode in xnMenu)
            {

                DepElem = xnode[product]["DateElement"]["DepartElement"]["Id"].InnerText.Trim();
                Console.WriteLine("Dep Elem : " + DepElem);
                RetElem = xnode[product]["DateElement"]["ReturnElement"]["Id"].InnerText.Trim();
                Console.WriteLine("RetElem : " + RetElem);

                DepDate = xnode[product]["DateValue"]["OneWay"][site].InnerText.Trim();
                Console.WriteLine("DepDate : " + DepDate);
                RetDate = xnode[product]["DateValue"]["ReturnTrip"][site].InnerText.Trim();
                Console.WriteLine("RetDate : " + RetDate);

                if (testID.ToLower().Contains("car"))
                {
                    RetDate = xnode[product]["DateValue"]["ReturnTrip"][site][currency].InnerText.Trim();
                    Console.WriteLine("RetDate : " + RetDate);

                    carPickTimeElem = xnode[product]["TimeElement"]["PickupTimeElement"]["Id"].InnerText.Trim();
                    Console.WriteLine(" carPickTimeElem : " + carPickTimeElem);

                    carRetTimeElem = xnode[product]["TimeElement"]["ReturnTimeElement"]["Id"].InnerText.Trim();
                    Console.WriteLine("carRetTimeElem : " + carRetTimeElem);

                    carPicTime = xnode[product]["TimeValue"]["PickupTime"].InnerText.Trim();
                    Console.WriteLine("carPicTime : " + carPicTime);

                    carRetTime = xnode[product]["TimeValue"]["ReturnTime"][currency].InnerText.Trim();
                    Console.WriteLine("carRetTime : " + carRetTime);
                }

            }

        }
        public void ChooseDate()
        {
            string testID = product + trip + site + currency;
            //driver.Navigate().GoToUrl("https://test.easybook.com/en-my/car/booking/kualalumpurarea");
            try
            {
                DateSandbox keyInDate = new DateSandbox(xml, driver);
                if (testID.ToLower().Contains("car"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                    Console.WriteLine("0");
                    keyInDate.EnterTime(carPickTimeElem, carPicTime);
                    Console.WriteLine("1");
                    keyInDate.EnterDate(RetElem, RetDate);
                    Console.WriteLine("2");
                    keyInDate.EnterTime(carRetTimeElem, carRetTime);
                    Console.WriteLine("3");
                }
                else if (testID.ToLower().Contains("oneway"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                }
                else if (testID.ToLower().Contains("return"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                    keyInDate.EnterDate(RetElem, RetDate);
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");

            }

        }

        public void EnterDate(string dateElement, string dateValue)
        {
            Console.WriteLine("2.2.0");
            driver.FindElement(By.Id(dateElement)).Click();
            Console.WriteLine("2.2.1");
            driver.FindElement(By.Id(dateElement)).Clear();
            driver.FindElement(By.Id(dateElement)).SendKeys(dateValue);
            Console.WriteLine("2.2.2");

        }

        public void EnterTime(string timeElement, string timeValue)
        {
            Console.WriteLine("3.3.1");
            driver.FindElement(By.Id(timeElement)).Click();
            Console.WriteLine("3.3.2");
            driver.FindElement(By.XPath(timeValue)).Click();
            Console.WriteLine("3.3.3");
        }
    }
    
}
