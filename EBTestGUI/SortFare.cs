using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Xml;
using System.Windows.Forms;

namespace EBTestGUI
{
    class SortFare
    {
        public IWebDriver driver;
        public XmlDocument xml;
        string sortPriceElemXP, sortPriceElemLinkText;
        public SortFare(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void ReadElement(string XMLpath, string prodName, string site, string currency)
        {
            string productType = prodName;// char.ToUpper(prodName[0]) + prodName.Substring(1);
            string siteType = site;// char.ToUpper(site[0]) + site.Substring(1);
            string currencyType = currency.ToUpper();

            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Sort");

            foreach (XmlNode xnode in xnMenu)
            {
                sortPriceElemXP = xnode[productType]["Fare"]["XPath"].InnerText.Trim();
                sortPriceElemLinkText = xnode[productType]["Fare"]["LinkText"].InnerText.Trim();
            }
        }

        public void lowFare(string product)
        {
            if (product.ToLower().Contains("car"))
            {
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(sortPriceElemXP)))).Click();
                }
                catch (NoSuchElementException)
                {
                    MessageBox.Show("Error #SOR01: Sort fare not found");
                }
            }
            else if (product.ToLower().Contains("ferry") || product.ToLower().Contains("train") || product.ToLower().Contains("bus"))
            {
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(sortPriceElemLinkText)))).Click();
                }
                catch (NoSuchElementException)
                {
                    MessageBox.Show("Error #SOR02: Sort fare not found");
                }
            }
        }
           
    }
}
