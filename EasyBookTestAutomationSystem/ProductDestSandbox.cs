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
    class ProductDestSandbox
    {
        string product = "bus";
     
        string busURL1;
        string busURL2;
        string busURL3;
        string ferryURL1;
        private IWebDriver driver;

        public ProductDestSandbox(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public void chooseProduct()
        {
            if (product=="bus")
            {
                busURL1 = "https://test.easybook.com/en-my/bus/booking/sungainibong-to-melakasentral";
                busURL2 = "https://test.easybook.com/en-my/bus/booking/melakasentral-to-sungainibong"; ;
                busURL3 = "https://test.easybook.com/en-my/bus/booking/kovanhub206-to-melakasentral";
                ferryURL1 = "https://test.easybook.com/en-my/ferry/booking/batamcenter-to-harbourfront";
            }
        }

        public void goToProductURL()
        {
            driver.Navigate().GoToUrl(busURL1);
        }
    }
}
