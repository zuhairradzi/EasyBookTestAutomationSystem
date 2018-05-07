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
        //-------------------------------------------------------------------------------------//


        //Conditions product
        string bus = "bus";
        string train = "train";
        string car = "car";
        string ferry = "ferry";

        //Conditions site
        string test = "test";
        string live = "live";

        //Conditions trip type
        string oneway = "oneway";
        string returntrip = "return";

        //Conditions currency
        string myr = "myr";
        string sgd = "sgd";

        //Product URL
        string URL1;
        string URL2;
        string URL3;
        string URL4;
        string busURL1, busURL2, busURL3, ferryURL1, prodURL, productURL, product;

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//

        private IWebDriver driver;
        private XmlDocument xml;

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
                Console.WriteLine("productURL : " + productURL); 
              
            }

        }
        public void chooseProduct(string EBurl)
        {
            prodURL = EBurl + productURL;
            Console.WriteLine("prodURL : " + prodURL);

            driver.Navigate().GoToUrl(prodURL);

        }
    
    }
}
