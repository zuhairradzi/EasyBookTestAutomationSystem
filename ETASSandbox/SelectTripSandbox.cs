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
    class SelectTripSandbox
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        private IWebDriver driver;
        private XmlDocument xml;

        public SelectTripSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }
        string testID = "busonewaymyr";

        //Conditions product
        string bus = "bus";
        string train = "train";
        string car = "car";
        string ferry = "ferry";

        //Conditions site
        string test = "test";
        string live = "live";

        //Conditions trip type
        string oneway = "oneway";
        string returntrip = "return";

        //Conditions currency
        string myr = "myr";
        string sgd = "sgd";


        //Bus Element
        string TextSelectBus = "Select";
        string XPBusTest = "";
        string XPBusLive = "";
        //*[@id="MY-int-21237664-8919a634-deba-429f-96a2-4411ef6ed23e"]/div[1]/div[5]/a
        string XPBusSGDlive = "//*[@id=\"MY-int-21237664-8919a634-deba-429f-96a2-4411ef6ed23e\"]/div[1]/div[5]/a";


        //Train Element
        string TextSelectTrain = "Select Seats/Berths";
        string TextSelectTrain2 = "Select";
        string XpTrainLive = "";
        string XpTrainTest = "";

        //Ferry Element
        string XPferryLive = "//*[@id=\"dep-trip-tbl\"]/tbody/tr/td[9]/div/div[1]/a";
        string XPferryTest = "//*[@id=\"MY-int-382334-6fbbaf97-864f-49a1-b6ef-abdd2081dc3b\"]/div[1]/div[5]/div/a";


        //Car Element
        string XPcarTest = "//*[@id=\"carSearchResultsTable\"]/tbody/tr[12]/td[8]/div/button";
        //*[@id="carSearchResultsTable"]/tbody/tr[1]/td[7]/div/button
        string XPcarLive = "//*[@id=\"carSearchResultsTable\"]/tbody/tr[1]/td[7]/div/button";



        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//


        string tripValue;
        string product = "Bus";
        string trip = "OneWay";
        string site = "TestSite";
        string currency = "SGD";
        string method = "LinkText";

        public void ReadElement(string XMLpath)
        {
            string testID = product + trip + site + currency;
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/SelectTrip");
            foreach (XmlNode xnode in xnList)
            {
                tripValue = xnode[product][site][method].InnerText.Trim();
                Console.WriteLine("tripValue : " + tripValue);
            }

        }

        public void selectTrip()
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelectBus)))).Click();

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");

            }
        }

    }
}
