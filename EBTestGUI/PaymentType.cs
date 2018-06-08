using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Xml;
using System.Windows.Forms;

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
                MessageBox.Show("PayPal option not found");
                Console.WriteLine("PayPal option not found");
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
                MessageBox.Show("Captcha field not found");
                Console.WriteLine("Captcha field not found");
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
                MessageBox.Show("Proceed to payment button not found");
                Console.WriteLine("Proceed to payment button not found");
            }
        }
    }
}
