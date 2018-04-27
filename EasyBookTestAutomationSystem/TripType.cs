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
using Microsoft.Office.Interop.Access.Dao;

namespace EasyBookTestAutomationSystem
{
    class TripType
    {
        private IWebDriver driver;
        public TripType(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public void chooseTripType(string TestID)
        {
            if (TestID.ToLower().Contains("oneway"))
            {

                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("radioOneWay")))).Click();
                }
                catch (Exception)
                {
                    Console.WriteLine("One Way trip not found");
                }

            }
            else if (TestID.ToLower().Contains("return"))
            {

                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("radioRoundTrip")))).Click();
                }
                catch (Exception)
                {
                    Console.WriteLine("Product URL not found");
                }


            }
        }
    }
}
