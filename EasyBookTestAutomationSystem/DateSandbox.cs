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
    class DateSandbox
    {

        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        string testID = "bustestoneway";

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

        //Element
        string busDepElem, busRetElem, traDepElem, traRetElem, 
            ferDepElem, ferRetElem, 
            carPickElem, carRetElem, carPickTimeElem, carRetTimeElem;
        //Value
        string busDepDate, busRetDate,
            ferryLiveDepDate, ferryTestRetDate, ferryTestDepDate, ferryLiveRetDate,
            trainDepDate, trainRetDate,
            carTestPicDate, carLivePicDate, carPicTime,
            carTestRet, carTestRetSG, carLiveRet, carLiveRetSG, carRetTime, carRetTimeSG;



        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        private IWebDriver driver;
        private XmlDocument xml;

        public DateSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        //---------------------METHODS-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        public void EnterDate(string dateElement, string dateValue)
        {
            driver.FindElement(By.Id(dateElement)).Click();
            driver.FindElement(By.Id(dateElement)).Clear();
            driver.FindElement(By.Id(dateElement)).SendKeys(dateValue);

        }

        public void EnterTime(string timeElement, string timeValue)
        {
            driver.FindElement(By.Id(timeElement)).Click();
            driver.FindElement(By.XPath(timeValue)).Click();
        }


        public void ChooseDate(string XMLpath)
        {
            xml.Load(XMLpath);

            XmlNodeList xnDateElem = xml.SelectNodes("/ETAS/DateElement");
            foreach (XmlNode xnode in xnDateElem)
            {
                busDepElem = xnode["BusDepature"].InnerText.Trim();
                busRetElem = xnode["BusReturn"].InnerText.Trim();
                traDepElem = xnode["TrainDepature"].InnerText.Trim();
                traRetElem = xnode["TrainReturn"].InnerText.Trim();
                ferDepElem = xnode["FerryDepature"].InnerText.Trim();
                ferRetElem = xnode["FerryReturn"].InnerText.Trim();
                carPickElem = xnode["CarPickup"].InnerText.Trim();
                carRetElem = xnode["CarReturn"].InnerText.Trim();
                carPickTimeElem = xnode["CarPickupTime"].InnerText.Trim();
                carRetTimeElem = xnode["CarPickupTime"].InnerText.Trim();


            }

            XmlNodeList xnDateBus = xml.SelectNodes("/ETAS/DateValue/Bus");
            foreach (XmlNode xnode in xnDateBus)
            {
                busDepDate = xnode["OneWayDate"].InnerText.Trim();
                busRetDate = xnode["ReturnDate"].InnerText.Trim();
              

            }

            XmlNodeList xnDateFerryDepart = xml.SelectNodes("/ETAS/DateValue/Ferry");
            foreach (XmlNode xnode in xnDateFerryDepart)
            {
                ferryTestDepDate = xnode["TestDate"].InnerText.Trim();
                ferryLiveDepDate = xnode["LiveDate"].InnerText.Trim();


            }
            XmlNodeList xnDateFerryReturn = xml.SelectNodes("/ETAS/DateValue/Ferry/Return");
            foreach (XmlNode xnode in xnDateFerryReturn)
            {
                ferryTestRetDate = xnode["TestDate"].InnerText.Trim();
                ferryLiveRetDate = xnode["LiveDate"].InnerText.Trim();


            }

            XmlNodeList xnTrain = xml.SelectNodes("/ETAS/DateValue/Train");
            foreach (XmlNode xnode in xnTrain)
            {
                trainDepDate = xnode["OneWayDate"].InnerText.Trim();
                trainRetDate = xnode["ReturnDate"].InnerText.Trim();


            }

            XmlNodeList xnCarPick = xml.SelectNodes("/ETAS/DateValue/Car/Pickup");
            foreach (XmlNode xnode in xnCarPick)
            {
                carTestPicDate = xnode["TestDate"].InnerText.Trim();
                carLivePicDate = xnode["LiveDate"].InnerText.Trim();
                carPicTime = xnode["Time"].InnerText.Trim();


            }

            XmlNodeList xnCarRet = xml.SelectNodes("/ETAS/DateValue/Car/Return");
            foreach (XmlNode xnode in xnCarRet)
            {
                carTestRet = xnode["TestDate"].InnerText.Trim();
                carTestRetSG = xnode["TestSGDDate"].InnerText.Trim();
                carLiveRet = xnode["LiveDate"].InnerText.Trim();
                carLiveRetSG = xnode["LiveSGDDate"].InnerText.Trim();
                carRetTime = xnode["MYRTime"].InnerText.Trim();
                carRetTimeSG = xnode["SGDTime"].InnerText.Trim();


            }

            try
            {
                DateSandbox keyInDate = new DateSandbox(xml, driver);

                switch (testID)
                {
                    case "busoneway":
                        keyInDate.EnterDate(busDepElem, busDepDate);
                        break;
                    case "busreturn":
                        keyInDate.EnterDate(busDepElem, busDepDate);
                        keyInDate.EnterDate(busRetElem, busRetDate);
                        break;
                    case "trainoneway":
                        keyInDate.EnterDate(traDepElem, trainDepDate);
                        break;
                    case "trainreturn":
                        keyInDate.EnterDate(traDepElem, trainDepDate);
                        keyInDate.EnterDate(traRetElem, trainRetDate);
                        break;
                    case "ferrytest":
                        keyInDate.EnterDate(ferDepElem, ferryTestDepDate);
                        break;
                    case "ferrylive":
                        keyInDate.EnterDate(ferDepElem, ferryLiveDepDate);
                        break;

                    case "cartestsgd":
                        keyInDate.EnterDate(carPickElem, carTestPicDate);
                        keyInDate.EnterTime(carPickTimeElem, carPicTime);
                        keyInDate.EnterDate(carRetElem, carTestRetSG);
                        keyInDate.EnterTime(carRetTimeElem, carRetTimeSG);
                        break;

                    case "cartestmyr":
                        keyInDate.EnterDate(carPickElem, carTestPicDate);
                        keyInDate.EnterTime(carPickTimeElem, carPicTime);
                        keyInDate.EnterDate(carRetElem, carTestRet);
                        keyInDate.EnterTime(carRetTimeElem, carRetTime);
                        break;

                    case "carlivesgd":
                        keyInDate.EnterDate(carPickElem, carLivePicDate);
                        keyInDate.EnterTime(carPickTimeElem, carPicTime);
                        keyInDate.EnterDate(carRetElem, carLiveRetSG);
                        keyInDate.EnterTime(carRetTimeElem, carRetTimeSG);
                        break;

                    case "carlivemyr":
                        keyInDate.EnterDate(carPickElem, carLivePicDate);
                        keyInDate.EnterTime(carPickTimeElem, carPicTime);
                        keyInDate.EnterDate(carRetElem, carLiveRet);
                        keyInDate.EnterTime(carRetTimeElem, carRetTime);
                        break;



                }
                
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");

            }


        }
    }
    
}
