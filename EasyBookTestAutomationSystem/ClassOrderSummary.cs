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

namespace EasyBookTestAutomationSystem
{
    class ClassOrderSummary
    {
        private IWebDriver driver;

        public ClassOrderSummary(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }
        public void LaunchBrowser3()
        {
            try
            {

                //var url = new Uri ("https://test.easybook.com/en-my");
                string url1 = "https://www.google.com";
                driver.Navigate().GoToUrl(url1);


            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }
    }
}
