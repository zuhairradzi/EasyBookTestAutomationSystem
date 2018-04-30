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
        private IWebDriver driver;

        //---------------------VARIABLES, XPATH,  ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        string testID = "S1-Test-Bus-oneWay-sgd";

        //conditions
        string sg = "sg";

        //page elements
        string XPFlag = "//div[@id='bs-example-navbar-collapse-1']/ul/li[2]/a/img";

        //country elements
        string Singapore = "Singapore";


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        public ChooseCountrySandbox(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }
        public void ChangeCountry()
        {
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
