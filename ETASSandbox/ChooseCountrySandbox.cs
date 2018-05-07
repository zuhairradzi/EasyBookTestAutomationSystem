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
    class ChooseCountrySandbox
    {
       
        //---------------------VARIABLES, XPATH,  ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        string testID = "S1-Test-Bus-oneWay-sgd";

        //conditions
        string sg = "sg";

        //page elements
        string CountryMenuXP, SGLinkText;


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        private IWebDriver driver;
        private XmlDocument xml;

        public ChooseCountrySandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath)
        {

            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Country");
            foreach (XmlNode xnode in xnMenu)
            {
                CountryMenuXP = xnode["CountryMenu"]["XPath"].InnerText.Trim();
                Console.WriteLine("CountryMenuXP : " + CountryMenuXP);

                SGLinkText = xnode["CountryName"]["LiveSite"]["LinkText"].InnerText.Trim();
                Console.WriteLine("SGLinkText : " + SGLinkText);

            }

        }
        public void ChangeCountry()
        {
           
            if (testID.Contains(sg))
            {
                try
                {

                    driver.FindElement(By.XPath(CountryMenuXP)).Click();
                    driver.FindElement(By.LinkText(SGLinkText)).Click();
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
