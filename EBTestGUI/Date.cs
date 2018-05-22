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
    class Date
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        string DepElem, RetElem, DepDate, RetDate, carPickTimeElem, carRetTimeElem, carPicTime, carRetTime;

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        public IWebDriver driver;
        public XmlDocument xml;

        public Date(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        //---------------------METHODS-------------------------------------------//
        public void ReadElement(string XMLpath, string prodName, string site, string currency)
        {
            string productType = prodName;// char.ToUpper(prodName[0]) + prodName.Substring(1);
            string siteType = site;// char.ToUpper(site[0]) + site.Substring(1);
            string currencyType = currency.ToUpper();

            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Date");

            foreach (XmlNode xnode in xnMenu)
            {
                DepElem = xnode[productType]["DateElement"]["DepartElement"]["Id"].InnerText.Trim();
                RetElem = xnode[productType]["DateElement"]["ReturnElement"]["Id"].InnerText.Trim();
                DepDate = xnode[productType]["DateValue"]["OneWay"][siteType].InnerText.Trim();
                RetDate = xnode[productType]["DateValue"]["ReturnTrip"][siteType].InnerText.Trim();

                if (productType.ToLower().Contains("car"))
                {
                    RetDate = xnode[productType]["DateValue"]["ReturnTrip"][siteType][currencyType].InnerText.Trim();
                    carPickTimeElem = xnode[productType]["TimeElement"]["PickupTimeElement"]["Id"].InnerText.Trim();
                    carRetTimeElem = xnode[productType]["TimeElement"]["ReturnTimeElement"]["Id"].InnerText.Trim();
                    carPicTime = xnode[productType]["TimeValue"]["PickupTime"].InnerText.Trim();
                    carRetTime = xnode[productType]["TimeValue"]["ReturnTime"][currencyType].InnerText.Trim();
                }
            }
        }

        public void ChooseDate(string testID)
        {
            try
            {
                Date keyInDate = new Date(xml, driver);

                if (testID.ToLower().Contains("car"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                    keyInDate.EnterTime(carPickTimeElem, carPicTime);
                    keyInDate.EnterDate(RetElem, RetDate);
                    keyInDate.EnterTime(carRetTimeElem, carRetTime);
                }
                else// if (testID.Contains("oneway"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                }/*
                else if (testID.Contains("return"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                    keyInDate.EnterDate(RetElem, RetDate);
                }*/


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");
            }


        }

        public void EnterDate(string dateElement, string dateValue)
        {
            driver.FindElement(By.Id(dateElement)).Click();
            driver.FindElement(By.Id(dateElement)).Clear();
            driver.FindElement(By.Id(dateElement)).SendKeys(dateValue);
        }

        public void EnterTime(string timeElement, string timeValue)
        {
            driver.FindElement(By.Id(timeElement)).Click();
            driver.FindElement(By.XPath(timeValue)).Click();
        }
    }
}
