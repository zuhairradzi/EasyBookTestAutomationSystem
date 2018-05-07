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
    class LaunchBrowser
    {
        private IWebDriver driver;
        private XmlDocument xml;

        public LaunchBrowser(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void GoToURL(string EBUrl)
        {
            driver.Navigate().GoToUrl(EBUrl);
            driver.Manage().Window.Maximize();
        }
    }
}
