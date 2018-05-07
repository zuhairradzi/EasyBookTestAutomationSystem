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

namespace EasyBookTestAutomationSystem
{
    class TripType
    {
        string trip;
        private IWebDriver driver;
        private XmlDocument xml;

        public TripType(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void ReadElement(string XMLpath, string tripType)
        {
            string TripTy = char.ToUpper(tripType[0]) + tripType.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/TripType");
            foreach (XmlNode xnode in xnMenu)
            {
                trip = xnode[TripTy]["Id"].InnerText.Trim();
            }
        }

        public void chooseTripType()
        {
           try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(trip)))).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("One Way trip not found");
            }
    }
}
}
