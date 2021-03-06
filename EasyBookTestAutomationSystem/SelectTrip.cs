﻿using OpenQA.Selenium;
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
    class SelectTrip
    {
        //---------------------METHODS-------------------------------------------//

        public IWebDriver driver;
        public XmlDocument xml;

        public SelectTrip(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        string tripValue;
        public void ReadElement(string XMLpath, string prodName, string siteName, string currency1)
        {
            string productType = char.ToUpper(prodName[0]) + prodName.Substring(1);
            string siteType = char.ToUpper(siteName[0]) + siteName.Substring(1);
            string currency = currency1.ToUpper();
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/SelectTrip");
            foreach (XmlNode xnode in xnList)
            {
                tripValue = xnode[productType][siteType][currency]["XPath"].InnerText.Trim();
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
                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(tripValue)))).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Select trip element not found");

                }
            }
           
        }
    }
}
