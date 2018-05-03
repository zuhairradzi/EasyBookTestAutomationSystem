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
using System.Xml.Linq;

namespace EasyBookTestAutomationSystem
{
    class ProductAndDest
    {

        //-------------------------------XML FILE-------------------------------------------------------------------///
        string XMLfilePath =
"C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ProductURL.xml";
        //---------------------------------------------------------------------------------------------------------///


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
            //XmlTextReader reader = new XmlTextReader(XMLfilePath);
            XmlDocument xml = new XmlDocument();
            xml.Load(XMLfilePath);
            //XElement booksFromFile = XElement.Load(@"books.xml");
            XmlNodeList xnList = xml.SelectNodes("product/bus/test");
            Console.WriteLine("1");
            if (TestID.ToLower().Contains(bus))
            {
                if (TestID.ToLower().Contains(test))
                {
                    Console.WriteLine("2");
                    foreach (XmlNode xn in xnList)
                    {
                        Console.WriteLine("3");
                        URL1 = xn["url1"].InnerText;
                        URL2 = xn["url2"].InnerText;
                        Console.WriteLine("url: {0},{1}", URL1, URL2);
                        Console.WriteLine("4");
                    }/*
                     while (reader.Read())
                     {
                         if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "url1")
                         {
                             reader.Read();
                            URL1 = reader.Value;
                             URL2 = reader.GetAttribute("url2");
                             URL3 = reader.GetAttribute("url3");
                             URL4 = reader.GetAttribute("url4");

                         }


                     }*/

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
                {/*
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "live")
                        {
                            URL1 = reader.GetAttribute("url1");
                            URL2 = reader.GetAttribute("url2");
                            URL3 = reader.GetAttribute("url3");
                         
                        }

                    }
                
                    try
                    {
                        driver.Navigate().GoToUrl(URL1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Product URL not found");
                    }

                    */
                }
            }

            else if (TestID.ToLower().Contains(car))
            {
                if (TestID.ToLower().Contains(test))
                {
                    URL1 = "";
                    URL2 = "";

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
                    URL1 = "";

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
                    URL1 = "";
                    URL2 = "";

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
                    URL1 = "";
                    URL2 = "";

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
                    URL1 = "";
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
