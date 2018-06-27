using OpenQA.Selenium;
using System;
using System.Xml;
using System.Windows.Forms;

namespace EBTestGUI
{
    class ChooseCountry
    {
        //---------------------VARIABLES, XPATH,  ID-------------------------------------------//
        
        string sg = "sg";
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
                    driver.FindElement(By.XPath(SGxp)).Click();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error #COU01: Country not found");
                    Console.WriteLine("Country not found!");
                }
            }
            else
            {
                return;
            }
        }
    }
}
