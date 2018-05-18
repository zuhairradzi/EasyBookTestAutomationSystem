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
    class Seat
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//
        string seatXP1, seatXP2, seatXP3, seatXPFull, seatNo, seatContinueID, seatContinueXP, TrainTripValueXP;
        public IWebDriver driver;
        public XmlDocument xml;

        public Seat(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath, string prodName, string siteName, string currency1)
        {
            string productType = char.ToUpper(prodName[0]) + prodName.Substring(1);
            string siteType = char.ToUpper(siteName[0]) + siteName.Substring(1);
            string currency = currency1.ToUpper();
            if (prodName == ("car"))
            {
                return;
            }
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/Seat");
            foreach (XmlNode xnode in xnList)
            {
                seatXP1 = xnode[productType][siteType][currency]["SelectSeat"]["XPath"]["Part1"].InnerText.Trim();
                Console.WriteLine("seatXP1 : " + seatXP1);
                seatXP2 = xnode[productType][siteType][currency]["SelectSeat"]["XPath"]["Part2"].InnerText.Trim();
                Console.WriteLine("seatXP2 : " + seatXP2);
                seatXP3 = xnode[productType][siteType][currency]["SelectSeat"]["XPath"]["Part3"].InnerText.Trim();
                Console.WriteLine("seatXP3 : " + seatXP3);
                
                seatContinueID = xnode[productType][siteType][currency]["ContinueButton"]["Id"].InnerText.Trim();
                Console.WriteLine("seatContinueID : " + seatContinueID);


                seatContinueXP = xnode[productType][siteType][currency]["ContinueButton"]["XPath"].InnerText.Trim();
                Console.WriteLine("seatContinueXP : " + seatContinueXP);

                TrainTripValueXP = xnode["Train"][siteType][currency]["TripValue"]["XPath"].InnerText.Trim();
                Console.WriteLine("TrainTripValueXP : " + TrainTripValueXP);

                if (prodName == ("ferry"))
                {
                    seatNo = xnode[productType][siteType][currency]["NoOfSeat"]["LinkText"].InnerText.Trim();
                    Console.WriteLine("seatNo : " + seatNo);
                }
              
               
            }

        }
        public void selectSeat(string productName)
        {
           
            //--- CAR ---//
            if (productName.ToLower().Contains("car"))
            {
                return;
            }



            //--- FERRY ---//
            else if (productName.ToLower().Contains("ferry"))
            {
                seatXPFull = seatXP1 + seatXP2 + seatXP3;
                Console.WriteLine("Full seatXP = " + seatXPFull);
                Thread.Sleep(1000);
                             
                driver.FindElement(By.XPath(seatXPFull)).Click();
                new SelectElement(driver.FindElement(By.XPath(seatXPFull))).SelectByText(seatNo);
                driver.FindElement(By.XPath(seatXPFull)).Click();
                driver.FindElement(By.XPath(seatContinueXP)).Click();
                /*
                if (IsElementPresent(By.XPath(seatContinueXP)))
                {
                    driver.FindElement(By.XPath(seatContinueXP)).Click();
                }
                else if (IsElementPresent(By.Id(seatContinueID)))
                {
                    driver.FindElement(By.Id(seatContinueID)).Click();
                }*/

            }





            //--- BUS  ---//
            else if (productName.ToLower().Contains("bus"))
            {
                for (int Tr = 1; Tr < 13; Tr++)
                {
                    for (int Td = 1; Td < 8; Td++)
                    {
                        try
                        {
                            Console.WriteLine("Full seatXP = " + seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3);
                            driver.FindElement(By.XPath(seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3)).Click();//WORKING
                            driver.FindElement(By.XPath(seatContinueXP)).Click();
                            /*
                            if (IsElementPresent(By.XPath(seatContinueXP)))
                            {
                                driver.FindElement(By.XPath(seatContinueXP)).Click();
                            }
                            else if (IsElementPresent(By.Id(seatContinueID)))
                            {
                                driver.FindElement(By.Id(seatContinueID)).Click();
                            }*/

                            try
                            {
                                IAlert simpleAlert = driver.SwitchTo().Alert();
                                String alertText = simpleAlert.Text;
                                simpleAlert.Accept();
                                continue;
                            }
                            catch (NoAlertPresentException)
                            {
                                Console.WriteLine("No alert found");
                            }

                        }
                        catch (NoSuchElementException)
                        {
                            continue;
                        }
                    }
                }
            }

            //---TRAIN----//
            else if (productName.ToLower().Contains("train"))
            {
                for (int Tr = 1; Tr < 80; Tr++)
                {
                    for (int Td = 1; Td < 6; Td++)
                    {

                        if (Td == 3)
                        {
                            continue;
                        }
                        try
                        {
                           
                            Thread.Sleep(2000);
                            if (IsElementPresent(By.XPath(TrainTripValueXP)))
                            {
                                new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementExists((By.XPath(TrainTripValueXP)))).Click();
                                Console.WriteLine("Full seatXP = " + seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3);
                                new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementExists((By.XPath(seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3)))).Click();
                                //driver.FindElement(By.XPath(seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3)).Click();//WORKING
                                Console.WriteLine("Seat = " + Tr + " : " + Td);
                                // driver.FindElement(By.XPath(seatContinueXP)).Click();
                                Thread.Sleep(2000);
                                driver.FindElement(By.Id(seatContinueID)).Click();

                                try
                                {
                                    IAlert simpleAlert = driver.SwitchTo().Alert();
                                    String alertText = simpleAlert.Text;
                                    simpleAlert.Accept();
                                    continue;
                                }
                                catch (NoAlertPresentException)
                                {
                                    Console.WriteLine("No alert found");
                                    
                                }
                            }
                            else if (!IsElementPresent(By.XPath(TrainTripValueXP)))
                            {
                                 return;
                            }
                            /*
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(TrainTripValueXP)))).Click();
                            Console.WriteLine("Full seatXP = " + seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3);
                            //Thread.Sleep(7000);
                            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3)))).Click();
                            //driver.FindElement(By.XPath(seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3)).Click();//WORKING
                            Console.WriteLine("Seat = " + Tr + " : " + Td);
                            // driver.FindElement(By.XPath(seatContinueXP)).Click();
                            driver.FindElement(By.Id(seatContinueID)).Click();

                            try
                            {
                                IAlert simpleAlert = driver.SwitchTo().Alert();
                                String alertText = simpleAlert.Text;
                                simpleAlert.Accept();
                                continue;
                            }
                            catch (NoAlertPresentException)
                            {
                                Console.WriteLine("No alert found");
                                break;
                            }*/

                        }
                        catch (NoSuchElementException)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
