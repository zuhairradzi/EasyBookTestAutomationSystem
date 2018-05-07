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
using Microsoft.Office.Interop.Access.Dao;

namespace ETASSandbox
{
    class ProductDestSandbox
    {

        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        //Conditions product
        string product = "bus";
        string bus = "bus";
        string EBUrl = "https://test.easybook.com/en-my";


        //Product URL
        string busURL1, busURL2, busURL3, ferryURL1, prodURL;
        string busBook = "/bus/booking/";
     



        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//

        private IWebDriver driver;
        private XmlDocument xml;

        public ProductDestSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath)
        {

            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/Product/ProductName");
            //Console.WriteLine("haha");
            foreach (XmlNode xnode in xnList)
            {
                busURL1 = xnode["Bus"]["URL1"].InnerText.Trim();
                busURL2 = xnode["Bus"]["URL2"].InnerText.Trim();
                busURL3 = xnode["Bus"]["URL3"].InnerText.Trim();


            }

        }

        public void chooseProduct()
        {
           
  
            if (product==bus)
            {
                prodURL = EBUrl + busURL2;
               
            }
        }

        public void goToProductURL()
        {
            driver.Navigate().GoToUrl(prodURL);
        }
    }
}
