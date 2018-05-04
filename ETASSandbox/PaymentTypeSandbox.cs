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
    class PaymentTypeSandbox
    {
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
        string currency = "MYR";

        private IWebDriver driver;
        private XmlDocument xml;
        string paymentGateID, payNowElement, ElemCaptcha;
        public PaymentTypeSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath)
        {
            string testID = product + trip + site + currency;
            PaymentTypeSandbox PaymentTest = new PaymentTypeSandbox(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS");
            foreach (XmlNode xnode in xnMenu)
            {
                paymentGateID = xnode["PaymentType"]["PayPal"][currency]["Id"].InnerText.Trim();
                Console.WriteLine("paymentGateID : " + paymentGateID);

                payNowElement = xnode["PaymentType"]["PayNowButton"]["Id"].InnerText.Trim();
                Console.WriteLine("payNowElement : " + payNowElement);

                ElemCaptcha = xnode["Captcha"]["Id"].InnerText.Trim();
                Console.WriteLine("ElemCaptcha : " + ElemCaptcha.Trim());


            }
            PaymentTest.PaymentGate(paymentGateID);
            PaymentTest.goToCaptcha(ElemCaptcha);
            PaymentTest.PayNow(payNowElement);
        }

        public void PaymentGate(string paymentID)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentID)))).Click();
                Thread.Sleep(1000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentID)))).Click();
                Thread.Sleep(1000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentID)))).Click();
                Thread.Sleep(1000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentID)))).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Paypal element not found");
                //driver.Close();

            }

        }
        public void goToCaptcha(string CaptchaID)
        {
            try
            {

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(CaptchaID)))).Click();
              
                //Console.WriteLine("Captcha found");
                Thread.Sleep(8000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Captcha not found");
                //driver.Close();

            }

        }

        public void PayNow(string payNowID)
        {
            try
            {

                var payNow = driver.FindElement(By.Id(payNowID));
                Actions actionsPay = new Actions(driver);
                actionsPay.MoveToElement(payNow);
                actionsPay.Perform();
                //Thread.Sleep(8000);
                IWebElement element = driver.FindElement(By.Id(payNowID));


                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
                IAlert confirmationAlert = driver.SwitchTo().Alert();
                String alertText = confirmationAlert.Text;
                confirmationAlert.Accept();
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Pay now proceed not found");
                //driver.Close();

            }


        }
    }
}
