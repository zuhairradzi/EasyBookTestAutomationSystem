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

namespace ETASSandbox
{
    class SubmitSearch
    {
       
        string LinkTextSearch;
        string XPSearch ;
        string ClNameSearch;
        string CssSearch;
       

        private IWebDriver driver;
        private XmlDocument xml;

        public SubmitSearch(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }
        public void confirmSearch(string XMLpath)
        {
            try
            {

                xml.Load(XMLpath);
                XmlNodeList xnMenu = xml.SelectNodes("/ETAS/SubmitSearch");
                foreach (XmlNode xnode in xnMenu)
                {
                    XPSearch = xnode["SearchButton"]["XPath"]["Bus"].InnerText.Trim();
                    LinkTextSearch = xnode["SearchButton"]["LinkText"].InnerText.Trim();
                    ClNameSearch = xnode["SearchButton"]["ClassName"].InnerText.Trim();
                    CssSearch = xnode["SearchButton"]["CssSelector"].InnerText.Trim();
                    //Console.WriteLine("xpath : " + XPFlag);

                }
                //Thread.Sleep(2000);
                //driver.FindElement(By.LinkText("Search")).Click();
                //driver.FindElement(By.Name("submit")).Click();
                //*[@id="modify-search"]/div[8]/div/div/button
                driver.FindElement(By.XPath(XPSearch)).Click();
                //driver.FindElement(By.CssSelector(CssSearch)).Click();
                //driver.FindElement(By.ClassName(ClNameSearch)).Click();
                //driver.FindElement(By.LinkText(LinkTextSearch)).Click();
                //Thread.Sleep(2000);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Submit button not found");
                //driver.Close();

            }

        }
    }
}
