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
    class SubmitSearch
    {
        private IWebDriver driver;
        string LinkTextSearch = "Search";
        string XPSearch = "//button[@value='Submit']";
        string NameSearch = "";


        public SubmitSearch(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public void confirmSearch()
        {
            try
            {
                //Thread.Sleep(2000);
                //driver.FindElement(By.LinkText("Search")).Click();
                //driver.FindElement(By.Name("submit")).Click();
                //*[@id="modify-search"]/div[8]/div/div/button
                driver.FindElement(By.XPath(XPSearch)).Click();
                //Thread.Sleep(2000);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Submit button not found");
                //driver.Close();

            }

        }
    }
}
