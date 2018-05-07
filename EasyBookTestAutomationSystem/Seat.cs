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
        string seatXP1, seatXP2, seatXP3, seatXPFull, seatNo, seatContinue; 
        private IWebDriver driver;
        private XmlDocument xml;

        public Seat(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath, string prodName, string siteName)
        {
            string productType = char.ToUpper(prodName[0]) + prodName.Substring(1);
            string siteType = char.ToUpper(siteName[0]) + siteName.Substring(1);

            if (prodName == ("car"))
            {
                return;
            }
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/Seat");
            foreach (XmlNode xnode in xnList)
            {
                seatXP1 = xnode[productType]["SelectSeat"][siteType]["XPath"]["Part1"].InnerText.Trim();
                Console.WriteLine("seatXP1 : " + seatXP1);
                seatXP2 = xnode[productType]["SelectSeat"][siteType]["XPath"]["Part2"].InnerText.Trim();
                Console.WriteLine("seatXP2 : " + seatXP2);
                seatXP3 = xnode[productType]["SelectSeat"][siteType]["XPath"]["Part3"].InnerText.Trim();
                Console.WriteLine("seatXP3 : " + seatXP3);
                seatContinue = xnode[productType]["ContinueButton"]["XPath"].InnerText.Trim();
                Console.WriteLine("seatContinue : " + seatContinue);

                if (prodName == ("ferry"))
                {
                    seatNo = xnode[productType]["NoOfSeat"]["LinkText"].InnerText.Trim();
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
                seatXPFull = seatXP1 + seatXP2 + seatXP2;
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(seatXPFull)))).Click();
                new SelectElement(driver.FindElement(By.XPath(seatXPFull))).SelectByText(seatNo);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(seatXPFull)))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(seatContinue)))).Click();
            }





            //--- BUS  ---//
            else if (productName.ToLower().Contains("ferry"))
            {
                for (int Tr = 1; Tr < 11; Tr++)
                {
                    for (int Td = 1; Td < 5; Td++)
                    {
                        try
                        {
                            driver.FindElement(By.XPath(seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3)).Click();//WORKING
                            driver.FindElement(By.XPath(seatContinue)).Click();
                        
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
        }
    }
}
