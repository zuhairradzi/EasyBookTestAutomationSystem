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
    class OSLinkGeneration
    {
        public IWebDriver driver;
        public XmlDocument xml;
        string url, urlOS;
        public OSLinkGeneration(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void GoToURL(string siteType, string cartID)
        {
            if (siteType.ToLower().Contains("test"))
            {
                urlOS = "https://test.easybook.com/en-my/payment/paymentresult?guid=" + cartID + "&source=PaypalEC_SGD&status=completed";
                url = "https://test.easybook.com/en-my";
            }

            else if (siteType.ToLower().Contains("live"))
            {
                urlOS = "https://www.easybook.com/en-my/payment/paymentresult?guid=" + cartID + "&source=PaypalEC_SGD&status=completed";
                url = "https://www.easybook.com/en-my";
            }
            driver.Navigate().GoToUrl(urlOS);
            driver.Manage().Window.Maximize();
        }
    }
}
