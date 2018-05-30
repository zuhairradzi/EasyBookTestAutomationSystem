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
using System.Windows.Forms;

namespace EBTestGUI
{
    class ChooseCountry
    {
        //---------------------VARIABLES, XPATH,  ID-------------------------------------------//

        //conditions
        string sg = "sg";

        //page elements
        string CountryMenuXP, SGLinkText, SGxp;
        //-------------------------------------------------------------------------------------//

        public IWebDriver driver;
        public XmlDocument xml;

        public ChooseCountry(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        //---------------------METHODS-------------------------------------------//
        public void ReadElement(string XMLpath)
        {
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Country");
            foreach (XmlNode xnode in xnMenu)
            {
                CountryMenuXP = xnode["CountryMenu"]["XPath"].InnerText.Trim();
                SGLinkText = xnode["CountryName"]["Singapore"]["LinkText"].InnerText.Trim();
                SGxp = xnode["CountryName"]["Singapore"]["XPath"].InnerText.Trim();
            }
        }

        public void ChangeCountry(string testID)
        {
            if (testID.ToLower().Contains(sg))
            {
                try
                {
                    driver.FindElement(By.XPath(CountryMenuXP)).Click();
                    //driver.FindElement(By.LinkText(CountryMenuXP)).Click();
                    driver.FindElement(By.XPath(SGxp)).Click();

                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not find intended country's element");
                }
            }
            else
            {
                return;
            }

        }
    }
}
