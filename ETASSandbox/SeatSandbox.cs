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
    class SeatSandbox
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
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

        string product = "Bus";
        string trip = "OneWay";
        string site = "TestSite";
        string currency = "SGD";
        string seatChoose, seatNo, continueButtonId;
        string busPart1, busPart2, busPart3;


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//
        private IWebDriver driver;
        private XmlDocument xml;

        public SeatSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void BusSeat(string Seat, string Proceed, string Front, string Mid, string End)
        {
            Thread.Sleep(2000);
            //driver.FindElement(By.ClassName(Seat)).Click();//WORKING
            //driver.FindElement(By.Id(Proceed)).Click();
           // Console.WriteLine("front : "+Front);
           // Console.WriteLine("Mid : " + Mid);
           // Console.WriteLine("End :" + End);
            //Console.WriteLine("seat function entered");
            for (int Tr = 1; Tr < 15; Tr++)
            {
                //Console.WriteLine("first loop");
                for (int Td = 1; Td < 10; Td++)
                {
                    //Console.WriteLine("second loop");
                    try
                    {
                        //Console.WriteLine("looping");
                        //Thread.Sleep(1000);
                        //*[@id="coach-lower"]/table/tbody/tr[3]/td/table/tbody/tr[4]/td[4]/a/div
                        //driver.FindElement(By.XPath("//*[@id=\"coach-lower\"]/table/tbody/tr[3]/td/table/tbody/tr[" + (Tr) + "]/td[" + (Td) + "]/a/div")).Click();//WORKING
                        //Console.WriteLine("seat clicked : " + Tr + " : " + Td);
                        //Console.WriteLine("xpath clicked : "+Front + (Tr) + Mid + (Td) + End);
                        driver.FindElement(By.XPath(Front + (Tr) + Mid + (Td) + End)).Click();//WORKING
                        //Console.WriteLine("seat clicked2 : "+Tr+" : "+Td);
                        // driver.FindElement(By.XPath(Seat)).Click();//WORKING
                        driver.FindElement(By.Id(Proceed)).Click();
                        //Console.WriteLine("Continue Pax detail clicked");
                        //Console.WriteLine("Seat Td: {0} - Tr: {1} tested", Td,Tr);

                        try
                        {
                            IAlert simpleAlert = driver.SwitchTo().Alert();
                            //Console.WriteLine("Popup found");

                            String alertText = simpleAlert.Text;
                            //Console.WriteLine("Alert text is " + alertText);

                            simpleAlert.Accept();
                            //Console.WriteLine("Popup clicked");

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

        public void FerrySeat(string Seat, string SeatNo, string Proceed)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(Seat)))).Click();
            new SelectElement(driver.FindElement(By.XPath(Seat))).SelectByText(SeatNo);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(Seat)))).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(Proceed)))).Click();
        }

        public void TrainSeat(string Seat, string Proceed)
        {

        }

        public void selectSeat(string XMLpath)
        {
            string testID = product + trip + site + currency;


            if (testID.ToLower().Contains(car))
            {
                return;
            }


            SeatSandbox Seating = new SeatSandbox(xml, driver);

            xml.Load(XMLpath);
            XmlNodeList xnDateElem1 = xml.SelectNodes("/ETAS/Seat");
            foreach (XmlNode xnode in xnDateElem1)
            {
                seatChoose = xnode[product]["SelectSeat"]["XPathFull"].InnerText.Trim();
                Console.WriteLine("seatChoose : " + seatChoose);

                busPart1 = xnode[product]["SelectSeat"]["XPath"]["Part1"].InnerText.Trim();
                Console.WriteLine("busPart1 : " + busPart1);
                busPart2 = xnode[product]["SelectSeat"]["XPath"]["Part2"].InnerText.Trim();
                Console.WriteLine("busPart2 : " + busPart2);
                busPart3 = xnode[product]["SelectSeat"]["XPath"]["Part3"].InnerText.Trim();
                Console.WriteLine("busPart3 : " + busPart3);

                continueButtonId = xnode[product]["ContinueButton"]["Id"].InnerText.Trim();
                Console.WriteLine("continueButton : " + continueButtonId);
                if (testID.ToLower().Contains(ferry))
                {
                    seatNo = xnode[product]["NoOfSeat"]["LinkText"].InnerText.Trim();
                    Console.WriteLine("seatNo : " + seatNo);
                    continueButtonId = xnode[product]["ContinueButton"]["XPath"].InnerText.Trim();
                    Console.WriteLine("continueButton : " + continueButtonId);
                }

            }
            try
            {

                if (testID.ToLower().Contains(bus))
                {

                    Seating.BusSeat(seatChoose, continueButtonId, busPart1, busPart2, busPart3);
                }
                else if (testID.ToLower().Contains(ferry))
                {

                    Seating.FerrySeat(seatChoose, seatNo, continueButtonId);
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No seat found");
            }
           
        }

      
        /*
        public void selectSeat(string XMLpath)
        {
            string testID = product + trip + site + currency;
            string seatChoose, seatNo, continueButtonId;

            if (testID.ToLower().Contains(car))
            {
                return;
            }


            xml.Load(XMLpath);
            XmlNodeList xnDateElem1 = xml.SelectNodes("/ETAS/Seat");
            foreach (XmlNode xnode in xnDateElem1)
            {
                seatChoose = xnode[product]["SelectSeat"]["XPath"].InnerText.Trim();
                Console.WriteLine("seatChoose: " + seatChoose);
                continueButtonId = xnode[product]["SelectSeat"]["Id"].InnerText.Trim();
                Console.WriteLine("continueButton: " + continueButtonId);
                if (testID.ToLower().Contains(ferry))
                {
                    seatNo = xnode[product]["NoOfSeat"]["LinkText"].InnerText.Trim();
                    Console.WriteLine("seatNo : " + seatNo);
                }
                   
            }

            if(testID.ToLower().Contains(bus))
            {
                return;
            }
            //--- CAR ---//




            /*
            //--- TRAIN TEST ---//
            else if (testID.ToLower().Contains(train) && testID.ToLower().Contains(test))
            {

            }

            //--- TRAIN LIVE ---//
            else if (testID.ToLower().Contains(train) && testID.ToLower().Contains(live))
            {

            }



            //--- FERRY TEST ---//
            else if (testID.ToLower().Contains(ferry) && testID.ToLower().Contains(test))
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPFerryTestSeat)))).Click();
                new SelectElement(driver.FindElement(By.XPath(XPFerryTestSeat))).SelectByText(XPFerryTestSeatNo);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPFerryTestSeat)))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPFerryTestSeatContinue)))).Click();
            }

            //--- FERRY LIVE ---//
            else if (testID.ToLower().Contains(ferry) && testID.ToLower().Contains(live))
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPFerryLiveSeat)))).Click();
                new SelectElement(driver.FindElement(By.XPath(XPFerryLiveSeat))).SelectByText(XPFerryLiveSeatNo);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPFerryLiveSeat)))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(XPFerryLiveSeatContinue)))).Click();
            }




            //--- BUS TEST ---//
            else if (testID.ToLower().Contains(bus) && testID.ToLower().Contains(test))
            {
                for (int Tr = 1; Tr < 11; Tr++)
                {
                    for (int Td = 1; Td < 5; Td++)
                    {
                        try
                        {
                            //Thread.Sleep(1000);
                            driver.FindElement(By.XPath("//div[@id='coach-lower']/table/tbody/tr[3]/td/table/tbody/tr[" + (Tr) + "]/td[" + (Td) + "]/a/div")).Click();//WORKING
                            driver.FindElement(By.Id(IDContinueBus)).Click();
                            //Console.WriteLine("Continue Pax detail clicked");
                            //Console.WriteLine("Seat Td: {0} - Tr: {1} tested", Td,Tr);

                            try
                            {
                                IAlert simpleAlert = driver.SwitchTo().Alert();
                                //Console.WriteLine("Popup found");

                                String alertText = simpleAlert.Text;
                                //Console.WriteLine("Alert text is " + alertText);

                                simpleAlert.Accept();
                                //Console.WriteLine("Popup clicked");

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

            //--- BUS LIVE ---//
            else if (testID.ToLower().Contains(bus) && testID.ToLower().Contains(live))
            {
                for (int Tr = 1; Tr < 11; Tr++)
                {
                    for (int Td = 1; Td < 5; Td++)
                    {
                        try
                        {
                            //Thread.Sleep(1000);
                            driver.FindElement(By.XPath("//div[@id='coach-lower']/table/tbody/tr[3]/td/table/tbody/tr[" + (Tr) + "]/td[" + (Td) + "]/a/div")).Click();//WORKING
                            driver.FindElement(By.Id(IDContinueBus)).Click();
                            //Console.WriteLine("Continue Pax detail clicked");
                            //Console.WriteLine("Seat Td: {0} - Tr: {1} tested", Td,Tr);

                            try
                            {
                                IAlert simpleAlert = driver.SwitchTo().Alert();
                                //Console.WriteLine("Popup found");

                                String alertText = simpleAlert.Text;
                                //Console.WriteLine("Alert text is " + alertText);

                                simpleAlert.Accept();
                                //Console.WriteLine("Popup clicked");

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
        }*/
    }
}
