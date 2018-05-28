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

namespace CheckBookingHistory
{
    class LaunchBrowser2
    {
        public IWebDriver driver;
        public XmlDocument xml;
        string url;
        public LaunchBrowser2(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public string GoToURL(string siteType)
        {
            if (siteType.ToLower().Contains("test"))
            {
                url = "https://test.easybook.com/en-my";
            }

            else if (siteType.ToLower().Contains("live"))
            {
                url = "https://www.easybook.com/en-my";
            }

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            return url;
        }
    }
}
