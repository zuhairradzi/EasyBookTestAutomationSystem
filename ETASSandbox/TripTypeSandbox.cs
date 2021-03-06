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
using Microsoft.Office.Interop.Access.Dao;

namespace ETASSandbox
{
    class TripTypeSandbox
    {
        string TestID = "oneway";
        string oneway, returnTrip;
        private IWebDriver driver;
        private XmlDocument xml;

        public TripTypeSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath)
        {

            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/TripType");
            foreach (XmlNode xnode in xnMenu)
            {

                oneway = xnode["OneWay"]["Id"].InnerText.Trim();
                returnTrip = xnode["Return"]["Id"].InnerText.Trim();

            }

        }
        
        public void chooseTripType()
        {
                 
            if (TestID.ToLower().Contains("oneway"))
            {

                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(oneway)))).Click();
                }
                catch (Exception)
                {
                    Console.WriteLine("One Way trip not found");
                }

            }
            else if (TestID.ToLower().Contains("return"))
            {
                
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(returnTrip)))).Click();
                }
                catch (Exception)
                {
                    Console.WriteLine("Product URL not found");
                }


            }
        }
    }
}
