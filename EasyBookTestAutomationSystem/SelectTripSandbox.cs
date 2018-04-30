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
    class SelectTripSandbox
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        private IWebDriver driver;
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


        public SelectTripSandbox(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public void selectTrip()
        {
            try
            {
                //--BUS-TEST--//
                if (testID.ToLower().Contains(bus) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelectBus)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }


                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {


                    }

                }

                //--BUS-LIVE--//
                else if (testID.ToLower().Contains(bus) && testID.ToLower().Contains(live))
                {
                    if (testID.ToLower().Contains(oneway))
                    {

                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelectBus)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {


                    }
                }


                //--TRAIN-TEST--//
                else if (testID.ToLower().Contains(train) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        try
                        {

                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelectTrain2)))).Click();

                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {

                    }
                }

                //--TRAIN-LIVE--//
                else if (testID.ToLower().Contains(train) && testID.ToLower().Contains(live))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        try
                        {

                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelectTrain2)))).Click();

                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {


                    }
                }

                //--FERRY-TEST--//
                else if (testID.ToLower().Contains(ferry) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPferryTest)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }


                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {
                    }

                }

                //--FERYY-LIVE--//
                else if (testID.ToLower().Contains(ferry) && testID.ToLower().Contains(live))
                {
                    if (testID.ToLower().Contains(oneway))
                    {

                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText("Select")))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {

                    }

                }


                //--CAR-TEST--//
                else if (testID.ToLower().Contains(car) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(myr))
                    {
                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPcarTest)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }

                    }

                    else if (testID.ToLower().Contains(sgd))
                    {
                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPcarTest)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }

                    }


                }

                //--CAR-LIVE--//
                else if (testID.ToLower().Contains(car) && testID.ToLower().Contains(live))
                {

                    if (testID.ToLower().Contains(myr))
                    {
                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPcarLive)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains(sgd))
                    {
                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPcarLive)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }
                }


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");

            }
        }

    }
}
