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


namespace EasyBookTestAutomationSystem
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
            //string testID = product + trip + site + currency;
            PayPalProceed PaymentTest = new PayPalProceed(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/PayPalProceed");
            foreach (XmlNode xnode in xnMenu)
            {
                continue1XP = xnode["Proceed1"]["XPath"].InnerText.Trim();
                Console.WriteLine("continue1 : " + continue1XP);

                continue2XP = xnode["Proceed2"]["XPath"].InnerText.Trim();
                Console.WriteLine("continue2 : " + continue2XP);

                continue3XP = xnode["Proceed3"]["XPath"].InnerText.Trim();
                Console.WriteLine("continue3 : " + continue3XP);

                continue1ID = xnode["Proceed1"]["Id"].InnerText.Trim();
                Console.WriteLine("continue1ID : " + continue1ID);

                continue2ID = xnode["Proceed2"]["Id"].InnerText.Trim();
                Console.WriteLine("continue2ID : " + continue2ID);

                continue3ID = xnode["Proceed3"]["Id"].InnerText.Trim();
                Console.WriteLine("continue3ID : " + continue3ID);


            }

        }

        public void proceedPayPal1(string currency)
        {
            string currencyUp = currency.ToUpper();
            Thread.Sleep(15000);
            if (currencyUp.Contains("MYR"))
            {
                //Thread.Sleep(15000);
                try
                {
                    //new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(ExpectedConditions.ElementExists((By.Id(continue1ID)))).Click();
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


        public void proceedPayPal2()
        {
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id(continue2XP))).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Cannot proceed to pay 2");
                }
        }


        public void proceedPayPal3()
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(ExpectedConditions.ElementExists(By.Id(continue3XP))).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cannot proceed to pay 2");
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
