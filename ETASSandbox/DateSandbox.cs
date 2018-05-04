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
    class DateSandbox
    {

        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        

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

        string DepElem, RetElem, DepDate, RetDate;



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
            Console.WriteLine("2.2.0");
            driver.FindElement(By.Id(dateElement)).Click();
            Console.WriteLine("2.2.1");
            driver.FindElement(By.Id(dateElement)).Clear();
            driver.FindElement(By.Id(dateElement)).SendKeys(dateValue);
            Console.WriteLine("2.2.2");

        }

        public void EnterTime(string timeElement, string timeValue)
        {
            Console.WriteLine("3.3.1");
            driver.FindElement(By.Id(timeElement)).Click();
            Console.WriteLine("3.3.2");
            driver.FindElement(By.XPath(timeValue)).Click();
            Console.WriteLine("3.3.3");
        }


        public void ChooseDate(string XMLpath)
        {
            //driver.Navigate().GoToUrl("https://test.easybook.com/en-my/car/booking/kualalumpurarea");
            xml.Load(XMLpath);
            string product = "Bus";
            string trip = "OneWay";
            string site = "TestSite";
            string currency = "SGD";
            string testID = product+trip+site+currency;


            XmlNodeList xnDateElem1 = xml.SelectNodes("/ETAS/Date");
            foreach (XmlNode xnode in xnDateElem1)
            {
                DepElem = xnode[product]["DateElement"]["DepartElement"]["Id"].InnerText.Trim();
                Console.WriteLine("Dep Elem : " + DepElem);
                RetElem = xnode[product]["DateElement"]["ReturnElement"]["Id"].InnerText.Trim();
                Console.WriteLine("RetElem : " + RetElem);

                DepDate = xnode[product]["DateValue"]["OneWay"][site].InnerText.Trim();
                Console.WriteLine("DepDate : " + DepDate);
                RetDate = xnode[product]["DateValue"]["ReturnTrip"][site].InnerText.Trim();
                Console.WriteLine("RetDate : " + RetDate);

                if (testID.ToLower().Contains("car"))
                {
                    RetDate = xnode[product]["DateValue"]["ReturnTrip"][site][currency].InnerText.Trim();
                    Console.WriteLine("RetDate : " + RetDate);

                    carPickTimeElem = xnode[product]["TimeElement"]["PickupTimeElement"]["Id"].InnerText.Trim();
                    Console.WriteLine(" carPickTimeElem : " + carPickTimeElem);

                    carRetTimeElem = xnode[product]["TimeElement"]["ReturnTimeElement"]["Id"].InnerText.Trim();
                    Console.WriteLine("carRetTimeElem : " + carRetTimeElem);

                    carPicTime = xnode[product]["TimeValue"]["PickupTime"].InnerText.Trim();
                    Console.WriteLine("carPicTime : " + carPicTime);


                   // carTestRet = xnode[product]["DateValue"]["ReturnTrip"][site][currency].InnerText.Trim();
                    //Console.WriteLine("carTestRet : " + carTestRet);


                    carRetTime = xnode[product]["TimeValue"]["ReturnTime"][currency].InnerText.Trim();
                    Console.WriteLine("carRetTime : " + carRetTime);
                }
              
            }

            /*    
            XmlNodeList xnDateElem = xml.SelectNodes("/ETAS/Date");
            foreach (XmlNode xnode in xnDateElem)
            {
                busDepElem = xnode["Bus"]["DateElement"]["DepartElement"]["Id"].InnerText.Trim();
                Console.WriteLine("Bus Dep Elem : " + busDepElem);

                busRetElem = xnode["Bus"]["DateElement"]["ReturnElement"]["Id"].InnerText.Trim();
                Console.WriteLine("busRetElem: " + busRetElem);

                busDepDate = xnode["Bus"]["DateValue"]["OneWay"]["TestSite"].InnerText.Trim();
                Console.WriteLine("busDepDate: " + busDepDate);

                busRetDate = xnode["Bus"]["DateValue"]["ReturnTrip"]["TestSite"].InnerText.Trim();
                Console.WriteLine("busRetDate : " + busRetDate);


                ferDepElem = xnode["Ferry"]["DateElement"]["DepartElement"]["Id"].InnerText.Trim();
                Console.WriteLine("ferDepElem : " + ferDepElem);

                ferRetElem = xnode["Ferry"]["DateElement"]["ReturnElement"]["Id"].InnerText.Trim();
                Console.WriteLine("ferRetElem: " + ferRetElem);

                ferryTestDepDate = xnode["Ferry"]["DateValue"]["OneWay"]["TestSite"].InnerText.Trim();
                Console.WriteLine("ferryTestDepDate: " + ferryTestDepDate);

                ferryLiveDepDate = xnode["Ferry"]["DateValue"]["OneWay"]["LiveSite"].InnerText.Trim();
                Console.WriteLine("ferryLiveDepDate : " + ferryLiveDepDate);

                ferryTestRetDate = xnode["Ferry"]["DateValue"]["ReturnTrip"]["TestSite"].InnerText.Trim();
                Console.WriteLine("ferryTestRetDate : " + ferryTestRetDate);

                ferryLiveRetDate = xnode["Ferry"]["DateValue"]["ReturnTrip"]["LiveSite"].InnerText.Trim();
                Console.WriteLine("ferryLiveRetDate : " + ferryLiveRetDate);



                traDepElem = xnode["Train"]["DateElement"]["DepartElement"]["Id"].InnerText.Trim();
                Console.WriteLine("traDepElem: " + traDepElem);

                traRetElem = xnode["Train"]["DateElement"]["ReturnElement"]["Id"].InnerText.Trim();
                Console.WriteLine("traRetElem: " + traRetElem);

                trainDepDate = xnode["Train"]["DateValue"]["OneWay"].InnerText.Trim();
                Console.WriteLine("trainDepDate: " + trainDepDate);

                trainRetDate = xnode["Train"]["DateValue"]["ReturnTrip"].InnerText.Trim();
                Console.WriteLine("trainRetDate : " + trainRetDate);



                carPickElem = xnode["Car"]["DateElement"]["DepartElement"]["Id"].InnerText.Trim();
                Console.WriteLine("carPickElem : " + carPickElem);

                carRetElem = xnode["Car"]["DateElement"]["ReturnElement"]["Id"].InnerText.Trim();
                Console.WriteLine("carRetElem : " + carRetElem);

                carPickTimeElem = xnode["Car"]["TimeElement"]["PickupTimeElement"]["Id"].InnerText.Trim();
                Console.WriteLine(" carPickTimeElem : " + carPickTimeElem);

                carRetTimeElem = xnode["Car"]["TimeElement"]["ReturnTimeElement"]["Id"].InnerText.Trim();
                Console.WriteLine("carRetTimeElem : " + carRetTimeElem);     

                carTestPicDate = xnode["Car"]["DateValue"]["OneWay"]["TestSite"].InnerText.Trim();
                Console.WriteLine("carTestPicDate : " + carTestPicDate);

                carLivePicDate = xnode["Car"]["DateValue"]["OneWay"]["LiveSite"].InnerText.Trim();
                Console.WriteLine("carLivePicDate : " + carLivePicDate);

                carPicTime = xnode["Car"]["TimeValue"]["PickupTime"].InnerText.Trim();
                Console.WriteLine("carPicTime : " + carPicTime);

                carTestRet = xnode["Car"]["DateValue"]["ReturnTrip"]["TestSite"]["MYR"].InnerText.Trim();
                Console.WriteLine("carTestRetSG : " + carTestRet);

                carTestRetSG = xnode["Car"]["DateValue"]["ReturnTrip"]["TestSite"]["SGD"].InnerText.Trim();
                Console.WriteLine("carTestRetSG : " + carTestRetSG);

                carLiveRet = xnode["Car"]["DateValue"]["ReturnTrip"]["LiveSite"]["MYR"].InnerText.Trim();
                Console.WriteLine("carLiveRet : " + carLiveRet);

                carLiveRetSG = xnode["Car"]["DateValue"]["ReturnTrip"]["LiveSite"]["SGD"].InnerText.Trim();
                Console.WriteLine("carLiveRetSG: " + carLiveRetSG);

                carRetTime = xnode["Car"]["TimeValue"]["ReturnTime"]["MYR"].InnerText.Trim();
                Console.WriteLine("carRetTime : " + carRetTime);

                carRetTimeSG = xnode["Car"]["TimeValue"]["ReturnTime"]["SGD"].InnerText.Trim();
                Console.WriteLine("carRetTimeSG: " + carRetTimeSG);

            }
            */

            try
            {
                DateSandbox keyInDate = new DateSandbox(xml, driver);
                if (testID.ToLower().Contains("car"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                    Console.WriteLine("0");
                    keyInDate.EnterTime(carPickTimeElem, carPicTime);
                    Console.WriteLine("1");
                    keyInDate.EnterDate(RetElem, RetDate);
                    Console.WriteLine("2");
                    keyInDate.EnterTime(carRetTimeElem, carRetTime);
                    Console.WriteLine("3");
                }
                else if (testID.ToLower().Contains("oneway"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                }
                else if (testID.ToLower().Contains("return"))
                {
                    keyInDate.EnterDate(DepElem, DepDate);
                    keyInDate.EnterDate(RetElem, RetDate);
                }/*
                switch (testID)
                {
                    case "bustestoneway":
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
                */
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");

            }


        }
    }
    
}
