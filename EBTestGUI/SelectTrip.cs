using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Xml;
using System.Windows.Forms;

namespace EBTestGUI
{
    class SelectTrip
    {

        //---------------------METHODS-------------------------------------------//

        public IWebDriver driver;
        public XmlDocument xml;
        string frontXP, backXP;
        string tripKey, tripXP;
        public SelectTrip(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }
        
        public void ReadElement(string XMLpath, string prodName, string siteName, string currency1)
        {
            string productType = char.ToUpper(prodName[0]) + prodName.Substring(1);
            string siteType = char.ToUpper(siteName[0]) + siteName.Substring(1);
            string currency = currency1.ToUpper();
            xml.Load(XMLpath);
            XmlNodeList xnList2 = xml.SelectNodes("/ETAS/TripXPath");
            foreach (XmlNode xnode in xnList2)
            {
                frontXP = xnode[productType][siteType][currency]["Front"].InnerText.Trim();
                tripKey = xnode[productType][siteType][currency]["Key"].InnerText.Trim();
                backXP = xnode[productType][siteType][currency]["Back"].InnerText.Trim();

                if (productType.ToLower().Contains("car"))
                {
                    tripXP = xnode[productType][siteType][currency]["XPathFull"].InnerText.Trim();
                }
                else
                {
                    tripXP = frontXP + tripKey + backXP;
                }
            }
        }

        public void selectTrip(string product)
        {
            string productUp = product.ToUpper();
            if (productUp == "TRAIN")
            {
                return;
            }
            else
            {
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.XPath(tripXP)))).Click();
                }
                catch (NoSuchElementException)
                {
                    MessageBox.Show("Select trip not found");
                    Console.WriteLine("Select trip not found");
                }
            }

        }
    }
}
