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

        //Bus Seat Elements
        string XPSeatBus = "";
        string IDContinueBus = "btnProceedToPassengerDetail";

        //Ferry seat elements
        string XPFerryTestSeat = "//div[@id='ferry-seat-chart']/div/div[2]/div/div/select";
        string XPFerryTestSeatNo = "1 Seats";
        string XPFerryTestSeatContinue = "//*[@id=\"MY-int-219568-9ac8d73c-07cd-4f47-bedb-245f1510c2c5\"]";


        string XPFerryLiveSeat = "";
        string XPFerryLiveSeatNo = "";
        string XPFerryLiveSeatContinue = "";

        //Train seat elements
        string XPTrainSeat = "";


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//


        public Seat(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public void selectSeat(string testID)
        {
            //--- CAR ---//
            if (testID.ToLower().Contains(car))
            {
                return;
            }




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
        }
    }
}
