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
    class SelectTrip
    {
        private IWebDriver driver;

        public SelectTrip(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        string TextSelect = "Select";
        //*[@id="MY-int-21237664-8919a634-deba-429f-96a2-4411ef6ed23e"]/div[1]/div[5]/a
        string XPBusSGDlive = "//*[@id=\"MY-int-21237664-8919a634-deba-429f-96a2-4411ef6ed23e\"]/div[1]/div[5]/a";

        string TextSelectTrain = "Select Seats/Berths";
        string XpTrain = "";

        string XPferryLive = "//*[@id=\"dep-trip-tbl\"]/tbody/tr/td[9]/div/div[1]/a";
        string XPferryTest = "//*[@id=\"MY-int-382334-6fbbaf97-864f-49a1-b6ef-abdd2081dc3b\"]/div[1]/div[5]/div/a";

        string XPcarTest= "//*[@id=\"carSearchResultsTable\"]/tbody/tr[12]/td[8]/div/button";
        //*[@id="carSearchResultsTable"]/tbody/tr[1]/td[7]/div/button
        string XPcarLive = "//*[@id=\"carSearchResultsTable\"]/tbody/tr[1]/td[7]/div/button" ;
      
        


        public void selectTrip(string testID)
        {
            try
            {
                //--BUS-TEST--//
                if (testID.ToLower().Contains("bus") && testID.ToLower().Contains("test"))
                {
                    if (testID.ToLower().Contains("oneway"))
                    {
                        try
                        {
                             new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelect)))).Click();

                           
                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }


                    }

                    else if (testID.ToLower().Contains("return"))
                    {


                    }

                }

                //--BUS-LIVE--//
                else if (testID.ToLower().Contains("bus") && testID.ToLower().Contains("live"))
                {
                    if (testID.ToLower().Contains("oneway"))
                    {

                        try
                        {
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelect)))).Click();


                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains("return"))
                    {


                    }
                }


                //--TRAIN-TEST--//
                else if (testID.ToLower().Contains("train") && testID.ToLower().Contains("test"))
                {
                    if (testID.ToLower().Contains("oneway"))
                    {
                        try
                        {

                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelect)))).Click();

                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains("return"))
                    {

                    }
                }

                //--TRAIN-LIVE--//
                else if (testID.ToLower().Contains("train") && testID.ToLower().Contains("live"))
                {
                    if (testID.ToLower().Contains("oneway"))
                    {
                        try
                        {

                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText(TextSelectTrain)))).Click();

                        }
                        catch (NoSuchElementException)
                        {
                            Console.WriteLine("Select trip element not found");

                        }
                    }

                    else if (testID.ToLower().Contains("return"))
                    {


                    }
                }

                //--FERRY-TEST--//
                else if (testID.ToLower().Contains("ferry") && testID.ToLower().Contains("test"))
                {
                    if (testID.ToLower().Contains("oneway"))
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

                    else if (testID.ToLower().Contains("return"))
                    {
                    }

                }

                //--FERYY-LIVE--//
                else if (testID.ToLower().Contains("ferry") && testID.ToLower().Contains("live"))
                {
                    if (testID.ToLower().Contains("oneway"))
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

                    else if (testID.ToLower().Contains("return"))
                    {

                    }

                }


                //--CAR-TEST--//
                else if (testID.ToLower().Contains("car") && testID.ToLower().Contains("test"))
                {
                    if (testID.ToLower().Contains("myr"))
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

                    else if (testID.ToLower().Contains("sgd"))
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
                else if (testID.ToLower().Contains("car") && testID.ToLower().Contains("live"))
                {

                    if (testID.ToLower().Contains("myr"))
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

                    else if (testID.ToLower().Contains("sgd"))
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
