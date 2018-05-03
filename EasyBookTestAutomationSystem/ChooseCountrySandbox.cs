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

namespace EasyBookTestAutomationSystem
{
    class ChooseCountrySandbox
    {
       
        //---------------------VARIABLES, XPATH,  ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        string testID = "S1-Test-Bus-oneWay-sgd";

        //conditions
        string sg = "sg";

        //page elements
        string XPFlag, Singapore;


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        private IWebDriver driver;
        private XmlDocument xml;

        public ChooseCountrySandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }
        public void ChangeCountry(string XMLpath)
        {
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Country/CountryMenu");
            foreach (XmlNode xnode in xnMenu)
            {
                XPFlag = xnode["XPath"].InnerText.Trim();
                //Console.WriteLine("xpath : " + XPFlag);

            }

            XmlNodeList xnList = xml.SelectNodes("/ETAS/Country/CountryName");
            foreach (XmlNode xnode in xnList)
            {
                Singapore = xnode["Singapore"]["LinkText"].InnerText.Trim();
                //Console.WriteLine("country : " + Singapore);

            }
            if (testID.Contains(sg))
            {
                try
                {

                    driver.FindElement(By.XPath(XPFlag)).Click();
                    driver.FindElement(By.LinkText(Singapore)).Click();
                    //Thread.Sleep(2000);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Country not found");

                }


            }
            else
            {
                return;
            }

        }


    }
}
