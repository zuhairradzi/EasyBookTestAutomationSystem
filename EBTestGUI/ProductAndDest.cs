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
    class ProductAndDest
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        string prodURL, productURL;

        //---------------------METHODS-------------------------------------------//

        public IWebDriver driver;
        public XmlDocument xml;

        public ProductAndDest(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void ReadElement(string XMLpath, string prodName, string site)
        {
            string siteName = char.ToUpper(site[0]) + site.Substring(1);
            string productType = char.ToUpper(prodName[0]) + prodName.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/Product/ProductName");
            foreach (XmlNode xnode in xnList)
            {
                productURL = xnode[productType][siteName]["URL1"].InnerText.Trim();
            }

        }
        public void chooseProduct(string product, string EBurl)
        {
            string prod = product.ToLower();
            prodURL = EBurl +"/"+ prod+ "/booking/"+ productURL;
            driver.Navigate().GoToUrl(prodURL);
        }

    }
}
