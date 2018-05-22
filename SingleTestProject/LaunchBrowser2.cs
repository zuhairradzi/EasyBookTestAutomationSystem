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

namespace SingleTestProject
{
    class LaunchBrowser2
    {
        public IWebDriver driver;
        public XmlDocument xml;
        string urlOS;
        public LaunchBrowser2(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void GoToURL(string siteType, string cartID)
        {
            if (siteType.ToLower().Contains("test"))
            {
                urlOS = "https://test.easybook.com/en-my/payment/paymentresult?guid=" + cartID + "&source=PaypalEC_SGD&status=completed";
            }

            else if (siteType.ToLower().Contains("live"))
            {
                urlOS = "https://www.easybook.com/en-my/payment/paymentresult?guid=" + cartID + "&source=PaypalEC_SGD&status=completed";

            }
            driver.Navigate().GoToUrl(urlOS);
            driver.Manage().Window.Maximize();
        }
    }
}
