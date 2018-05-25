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
    class PayPalProceed
    {
        private IWebDriver driver;
        private XmlDocument xml;

        public PayPalProceed(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        string continue1XP, continue2XP, continue3XP, continue1ID, continue2ID, continue3ID;

        public void ReadElement(string XMLpath)
        {
            PayPalProceed PaymentTest = new PayPalProceed(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/PayPalProceed");
            foreach (XmlNode xnode in xnMenu)
            {
                continue1XP = xnode["Proceed1"]["XPath"].InnerText.Trim();
                continue2XP = xnode["Proceed2"]["XPath"].InnerText.Trim();
                continue3XP = xnode["Proceed3"]["XPath"].InnerText.Trim();
                continue1ID = xnode["Proceed1"]["Id"].InnerText.Trim();
                continue2ID = xnode["Proceed2"]["Id"].InnerText.Trim();
                continue3ID = xnode["Proceed3"]["Id"].InnerText.Trim();
            }
        }

        public void proceedPayPal1(string currency)
        {
            string currencyUp = currency.ToUpper();
            Thread.Sleep(10000);
            if (currencyUp.Contains("MYR"))
            {
                try
                {
                    driver.FindElement(By.Id(continue1ID)).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Cannot proceed to pay 2");
                }
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.Id(continue2ID))).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Cannot proceed to pay 3");
                }

                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(35)).Until(ExpectedConditions.ElementExists(By.Id(continue3ID))).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Cannot proceed to OS");
                }
            }
            else if (currencyUp.Contains("SGD"))
            {
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(ExpectedConditions.ElementExists(By.Id(continue2ID))).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Cannot proceed to pay 3");
                }
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(35)).Until(ExpectedConditions.ElementExists(By.Id(continue3ID))).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Cannot proceed to OS");
                }
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
