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
using System.Reflection;

namespace CheckBookingHistory
{
    class ManageBooking
    {
        string dateElemXP, dateElemID, SelElemXP, SelElemID, productElemXP, productElemLinkText, searchButXP,
            searchButId, site, productName;
        public IWebDriver driver;
        public XmlDocument xml;
        public ManageBooking(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath, string siteType, string product)
        {
            xml.Load(XMLpath);
            site = char.ToUpper(siteType[0]) + siteType.Substring(1);
            Console.WriteLine("site : " + site);
            productName = char.ToUpper(product[0]) + product.Substring(1);
            Console.WriteLine("productName : " + productName);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/BookingHistory");
            foreach (XmlNode xnode in xnMenu)
            {
                

                dateElemXP = xnode[site]["Date"]["Element"]["XPath"].InnerText.Trim();
                Console.WriteLine("dateElemXP : " + dateElemXP);
                
                dateElemID = xnode[site]["Date"]["Element"]["Id"].InnerText.Trim();
                Console.WriteLine("dateElemID : " + dateElemID);

                SelElemXP = xnode[site]["SelectProduct"]["Element"]["XPath"].InnerText.Trim();
                Console.WriteLine("SelElemXP : " + SelElemXP);
                SelElemID = xnode[site]["SelectProduct"]["Element"]["Id"].InnerText.Trim();
                Console.WriteLine("SelElemID : " + SelElemID);

                productElemXP = xnode[site]["SelectProduct"]["Product"][productName]["XPath"].InnerText.Trim();
                Console.WriteLine("SelElemXP : " + SelElemXP);
                productElemLinkText = xnode[site]["SelectProduct"]["Product"][productName]["LinkText"].InnerText.Trim();
                Console.WriteLine("SelElemID : " + SelElemID);

                searchButXP = xnode[site]["SearchButton"]["XPath"].InnerText.Trim();
                Console.WriteLine("searchButXP : " + searchButXP);

                searchButId = xnode[site]["SearchButton"]["Id"].InnerText.Trim();
                Console.WriteLine("searchButId : " + searchButId);


            }

        }

        public void searchBooking(string date, string orderNo)
        {
            driver.FindElement(By.Id(dateElemID)).Click();
            driver.FindElement(By.Id(dateElemID)).SendKeys(date);
            driver.FindElement(By.Id(SelElemID)).Click();
            driver.FindElement(By.XPath(productElemXP)).Click();
            driver.FindElement(By.Id(searchButId)).Click();
            //driver.FindElement(By.LinkText(orderNo)).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(orderNo)))).Click();

        } 
    }
}
