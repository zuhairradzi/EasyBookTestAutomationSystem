using System.Xml;
using OpenQA.Selenium;

namespace EBTestGUI
{
    class LaunchBrowser
    {
        public IWebDriver driver;
        public XmlDocument xml;

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