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

namespace EBTestGUI
{
    class PaymentType
    {
        public IWebDriver driver;
        public XmlDocument xml;
        string paymentGateID, payNowElement, ElemCaptcha;
        public PaymentType(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath, string currency)
        {
            string currencyUpper = currency.ToUpper();
            PaymentType PaymentTest = new PaymentType(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS");
            foreach (XmlNode xnode in xnMenu)
            {
                paymentGateID = xnode["PaymentType"]["PayPal"][currencyUpper]["Id"].InnerText.Trim();
                payNowElement = xnode["PaymentType"]["PayNowButton"]["Id"].InnerText.Trim();
                ElemCaptcha = xnode["Captcha"]["Id"].InnerText.Trim();
            }

        }

        public void PaymentGate()
        {
            try
            {
                Thread.Sleep(1000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentGateID)))).Click();
                Thread.Sleep(1000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentGateID)))).Click();
                Thread.Sleep(1000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentGateID)))).Click();
                Thread.Sleep(1000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(paymentGateID)))).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Paypal element not found");
            }

        }
        public void goToCaptcha()
        {
            try
            {

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemCaptcha)))).Click();
                Thread.Sleep(8000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Captcha not found");
            }

        }

        public void PayNow()
        {
            try
            {

                var payNow = driver.FindElement(By.Id(payNowElement));
                Actions actionsPay = new Actions(driver);
                actionsPay.MoveToElement(payNow);
                actionsPay.Perform();
                IWebElement element = driver.FindElement(By.Id(payNowElement));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
                IAlert confirmationAlert = driver.SwitchTo().Alert();
                String alertText = confirmationAlert.Text;
                confirmationAlert.Accept();
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Pay now proceed not found");
            }
        }
    }
}
