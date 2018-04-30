using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Xml;
using Microsoft.Office.Interop.Access.Dao;
using OpenQA.Selenium;
using System;

namespace EasyBookTestAutomationSystem
{
    class ProductAndDest
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        private IWebDriver driver;

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

        //Product URL
        string URL1;
        string URL2;
        string URL3;
        string URL4;

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//


        public ProductAndDest(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public void chooseProduct(string TestID, string EBurl)
        {
            if (TestID.ToLower().Contains(bus))
            {
                if (TestID.ToLower().Contains(test))
                {
                    
                    URL1 = "https://test.easybook.com/en-my/bus/booking/melakasentral-to-sungainibong";
                    URL2 = "https://test.easybook.com/en-my/bus/booking/sungainibong-to-melakasentral";
                    URL3 = "https://test.easybook.com/en-my/bus/booking/kovanhub206-to-melakasentral";
                    URL4 = "https://test.easybook.com/en-my/bus/booking/melakasentral-to-kovanhub206";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }

                }
                else if (TestID.ToLower().Contains(live))
                {
                    URL1 = "https://www.easybook.com/en-my/bus/booking/sungainibong-to-melakasentral";
                    URL2 = "https://www.easybook.com/en-my/bus/booking/melakasentral-to-sungainibong"; 
                    URL3 = "https://www.easybook.com/en-my/bus/booking/kovanhub206-to-melakasentral";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }


                }


            }

            else if (TestID.ToLower().Contains(car))
            {
                if (TestID.ToLower().Contains(test))
                {
                    URL1 = "https://test.easybook.com/en-my/car/booking/bukitbintangarea";
                    URL2 = "https://test.easybook.com/en-my/car/booking/kualalumpurarea";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }


                }
                else if (TestID.ToLower().Contains(live))
                {
                    URL1 = "https://www.easybook.com/en-my/car/booking/kualalumpurarea";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }

                }

            }


            else if (TestID.ToLower().Contains(train))
            {
                if (TestID.ToLower().Contains(test))
                {
                    URL1 = "https://test.easybook.com/en-my/train/booking/jbsentral-to-woodland";
                    URL2 = "https://test.easybook.com/en-my/train/booking/kepong-to-terminalktm";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }

                }
                else if (TestID.ToLower().Contains(live))
                {
                    URL1 = "https://www.easybook.com/en-my/train/booking/jbsentral-to-woodland";
                    URL2 = "https://www.easybook.com/en-my/train/booking/kepong-to-terminalktm";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }

                }

            }
            else if (TestID.ToLower().Contains(ferry))
            {
                if (TestID.ToLower().Contains(test))
                {
                    URL1 = "https://test.easybook.com/en-my/ferry/booking/batamcenter-to-harbourfront";
                    URL2 = "https://test.easybook.com/en-my/ferry/booking/harbourfront-to-batamcenter";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }


                }
                else if (TestID.ToLower().Contains(live))
                {
                    URL1 = "https://www.easybook.com/en-my/ferry/booking/batamcenter-to-harbourfront";
                    URL2 = "https://www.easybook.com/en-my/ferry/booking/harbourfront-to-batamcenter";

                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }


                }

            }
        }
    
    }
}
