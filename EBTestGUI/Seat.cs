using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Xml;

namespace EBTestGUI
{
    class Seat
    {
        //---------------------METHODS-------------------------------------------//
        string seatXP1, seatXP2, seatXP3, seatXPFull, seatNo, seatContinueID, seatContinueXP, TrainTripValueXP, tripKey, buttonContinue;
        string frontButtonXP, backButtonXP, tripXP, frontXP, backXP; 
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
            if (prodName.ToLower().Contains("car"))
            {
                return;
            }
            xml.Load(XMLpath);
            XmlNodeList xnList1 = xml.SelectNodes("/ETAS/Seat");
            foreach (XmlNode xnode in xnList1)
            {
                seatXP1 = xnode[productType][siteType][currency]["SelectSeat"]["XPath"]["Part1"].InnerText.Trim();
                seatXP2 = xnode[productType][siteType][currency]["SelectSeat"]["XPath"]["Part2"].InnerText.Trim();
                seatXP3 = xnode[productType][siteType][currency]["SelectSeat"]["XPath"]["Part3"].InnerText.Trim();
            }
          
            if (prodName.ToLower().Contains("train"))
            {
                XmlNodeList xnList2 = xml.SelectNodes("/ETAS/TripXPath");
                foreach (XmlNode xnode in xnList2)
                {
                    frontXP = xnode[productType][siteType][currency]["Front"].InnerText.Trim();
                    tripKey = xnode[productType][siteType][currency]["Key"].InnerText.Trim();
                    backXP = xnode[productType][siteType][currency]["Back"].InnerText.Trim();
                    TrainTripValueXP = frontXP + tripKey + backXP;
                }

                XmlNodeList xnList3 = xml.SelectNodes("/ETAS/Seat");
                foreach (XmlNode xnode in xnList3)
                {
                    seatContinueID = xnode[productType][siteType][currency]["ContinueButton"]["Id"].InnerText.Trim();
                    seatContinueXP = xnode[productType][siteType][currency]["ContinueButton"]["XPath"].InnerText.Trim();
                }
            }

            else if (prodName.ToLower().Contains("bus"))
            {
               
                XmlNodeList xnList3 = xml.SelectNodes("/ETAS/Seat");
                foreach (XmlNode xnode in xnList3)
                {
                    seatContinueXP = xnode[productType][siteType][currency]["ContinueButton"]["XPath"].InnerText.Trim();
                }
            }
            else if (prodName.ToLower().Contains("ferry"))
            {
               
                XmlNodeList xnList3 = xml.SelectNodes("/ETAS/Seat");
                foreach (XmlNode xnode in xnList3)
                {
                    seatNo = xnode[productType][siteType][currency]["NoOfSeat"]["LinkText"].InnerText.Trim();
                }

                XmlNodeList xnList4 = xml.SelectNodes("/ETAS/TripXPath");
                foreach (XmlNode xnode in xnList4)
                {
                    tripKey = xnode[productType][siteType][currency]["Key"].InnerText.Trim();
                }
                XmlNodeList xnList5 = xml.SelectNodes("/ETAS/ContinueButton");
                foreach (XmlNode xnode in xnList5)
                {
                    frontButtonXP = xnode["Front"].InnerText.Trim();
                    backButtonXP = xnode["Back"].InnerText.Trim();
                }

                buttonContinue = frontButtonXP + tripKey + backButtonXP;
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
                driver.FindElement(By.XPath(buttonContinue)).Click();
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
                            if (IsElementPresent(By.XPath(seatContinueXP)))
                            {
                                Thread.Sleep(2000);
                                Console.WriteLine("Full seatXP = " + seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3);
                                driver.FindElement(By.XPath(seatXP1 + (Tr) + seatXP2 + (Td) + seatXP3)).Click();//WORKING
                                driver.FindElement(By.XPath(seatContinueXP)).Click();
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
                            else if (!IsElementPresent(By.XPath(seatContinueXP)))
                            {
                                return;
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
                                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists((By.XPath(TrainTripValueXP)))).Click();
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
