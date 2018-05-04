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
    class PassengerDetailSandbox
    {
        private IWebDriver driver;
        private XmlDocument xml;

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


        string product = "Bus";
        string trip = "OneWay";
        string site = "TestSite";
        string currency = "SGD";
        string InsuranceClassName, nationalityElem, natiValue;

        public PassengerDetailSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void InfoDetail(string XMLpath)
        {
            string testID = product + trip + site + currency;
            PassengerDetailSandbox PassengerTest = new PassengerDetailSandbox(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/PassengerDetails");
            foreach (XmlNode xnode in xnList)
            {
                InsuranceClassName = xnode["Insurance"]["ClassName"].InnerText.Trim();
                Console.WriteLine("InsuranceClassName : " + InsuranceClassName);

                nationalityElem = xnode["Nationality"]["NationalityElement"]["Id"].InnerText.Trim();
                Console.WriteLine("nationalityElem : " + nationalityElem);

                natiValue = xnode["Nationality"]["Value"]["SelectByText"].InnerText.Trim();
                Console.WriteLine("natiValue : " + natiValue);
            }

            if (testID.ToLower().Contains(bus))
            {
                PassengerTest.untickInsurance(InsuranceClassName);
            }

            if (testID.ToLower().Contains(car))
            {
                PassengerTest.Nationality(nationalityElem, natiValue);
            }
        }
        public void untickInsurance(string insurance)
        {
            try
            {
                IWebElement element = driver.FindElement(By.ClassName(insurance));
                //Console.WriteLine("Insurance found");

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

                //------------Switch the control of 'driver' to the Alert from main window
                IAlert confirmationAlert = driver.SwitchTo().Alert();
                //Console.WriteLine("Found alert");


                //------------- Get the Text of Alert
                //String alertText = confirmationAlert.Text;

                //Console.WriteLine("Alert text is " + alertText);



                //--------'.Dismiss()' is used to cancel the alert '(click on the Cancel button)'
                confirmationAlert.Accept();
                //Console.WriteLine("Alert clicked");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Insurance not found");
                //driver.Close();

            }
        }

        public void Nationality(string natElement, string natType)
        {
            try
            {

                var Malaysia = driver.FindElement(By.Id(natElement));
                var selectElement = new SelectElement(Malaysia);
                selectElement.SelectByText(natType);
                // Console.WriteLine("Select Paypal");
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nationality not found");
                //driver.Close();

            }

        }
    }
}
