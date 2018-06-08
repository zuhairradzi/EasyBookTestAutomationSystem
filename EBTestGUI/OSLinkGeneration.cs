using OpenQA.Selenium;
using System.Xml;

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
