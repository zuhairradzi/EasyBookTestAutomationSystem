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
        private IWebDriver driver;

        string testID = "bustestoneway";
        string TextSelect = "Select";

        public SelectTripSandbox(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public void selectTrip()
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

                    }

                    else if (testID.ToLower().Contains("sgd"))
                    {
                        

                    }


                }

                //--CAR-LIVE--//
                else if (testID.ToLower().Contains("car") && testID.ToLower().Contains("live"))
                {

                    if (testID.ToLower().Contains("myr"))
                    {
                        
                    }

                    else if (testID.ToLower().Contains("sgd"))
                    {
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
