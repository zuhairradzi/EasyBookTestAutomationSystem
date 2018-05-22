using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Xml;
using Microsoft.Office.Interop.Access.Dao;
using OpenQA.Selenium;
using System;
using System.Xml.Linq;

namespace EasyBookTestAutomationSystem
{
    class ProductAndDest
    {


        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------/

        //Product URL
        string prodURL, productURL;

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//

        public IWebDriver driver;
        public XmlDocument xml;

        public ProductAndDest(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath, string TestID, string prodName)
        {
            string productType = char.ToUpper(prodName[0]) + prodName.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/Product/ProductName");
            foreach (XmlNode xnode in xnList)
            {
                productURL = xnode[productType]["URL1"].InnerText.Trim();
            }

        }
        public void chooseProduct(string EBurl)
        {
            prodURL = EBurl + productURL;
            driver.Navigate().GoToUrl(prodURL);
        }
    
    }
}
