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
    class ChooseCountry
    {
        private IWebDriver driver;

        //-------------------------------XML FILE-------------------------------------------------------------------///
        string XMLfilePath =
"C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ChooseCountry.xml";
        //---------------------------------------------------------------------------------------------------------///


       

        //---------------------VARIABLES, XPATH,  ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        //conditions
        string sg = "sg";

        //page elements
        string XPsg;
        
        //country elements
        string sg1;

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//



        public ChooseCountry (IWebDriver maindriver)
        {
            this.driver = maindriver;

        }

     


        //---------------------METHODS-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

       
        public void ChangeCountry(string testID)
        {
            XmlTextReader reader = new XmlTextReader(XMLfilePath);
            if (testID.Contains(sg))
            {
                try
                {

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "menuElement")
                        {
                            XPsg = reader.GetAttribute("XPath");
                            Console.WriteLine(XPsg);
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "country")
                        {
                            sg1 = reader.GetAttribute("singapore");
                            Console.WriteLine(sg1);
                        }
                    }

                    driver.FindElement(By.XPath(XPsg)).Click();
                    driver.FindElement(By.LinkText(sg1)).Click();


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
