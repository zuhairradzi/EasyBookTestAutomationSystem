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
    class PayPalProceedSandbox
    {
        private IWebDriver driver;
        private XmlDocument xml;

        public PayPalProceedSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        string continue1XP, continue2XP, continue3XP;

        public void ReadElement(string XMLpath)
        {
            //string testID = product + trip + site + currency;
            PaymentTypeSandbox PaymentTest = new PaymentTypeSandbox(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/PayPalProceed");
            foreach (XmlNode xnode in xnMenu)
            {
                continue1XP = xnode["Proceed1"]["XPath"].InnerText.Trim();
                Console.WriteLine("continue1 : " + continue1XP);
                
                continue2XP = xnode["Proceed2"]["Id"].InnerText.Trim();
                Console.WriteLine("continue2 : " + continue2XP);

                continue3XP = xnode["Proceed3"]["Id"].InnerText.Trim();
                Console.WriteLine("continue3 : " + continue3XP);


            }
           
        }

        public void proceedPayPal()
        {
            try
            {
                Thread.Sleep(8000);
                driver.FindElement(By.XPath(continue1XP)).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id(continue2XP))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(ExpectedConditions.ElementExists(By.Id(continue3XP))).Click();
           


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cannot proceed to pay");
            }

            try
            {
                Thread.Sleep(8000);
                //driver.FindElement(By.XPath(continue1XP)).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id(continue2XP))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(ExpectedConditions.ElementExists(By.Id(continue3XP))).Click();



            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cannot proceed to pay");
            }
        }
    }
}
