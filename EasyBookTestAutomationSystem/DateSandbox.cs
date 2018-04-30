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

        private IWebDriver driver;
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

        //Date Element
        string dateDepart;
        string dateReturn;
        string dateElementDep;
        string dateElementRet;
        string pickupTimeElem;
        string returnTimeElem;
        string pickupTimeList;
        string returnTimeList;


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        public DateSandbox(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        //---------------------METHODS-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        public void ChooseDate(string testID)
        {
            try
            {
                //--BUS-TEST--//
                if (testID.ToLower().Contains(bus) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        dateElementDep = "dpDepartureDate_Bus";
                        dateDepart = "2020-03-08";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);


                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {
                        dateElementDep = "dpDepartureDate_Bus";
                        dateDepart = "2020-03-08";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        dateElementRet = "dpReturnDate_Bus";
                        dateReturn = "2020-03-09";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);


                    }

                }

                //--BUS-LIVE--//
                else if (testID.ToLower().Contains(bus) && testID.ToLower().Contains(live))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        dateElementDep = "dpDepartureDate_Bus";
                        dateDepart = "2020-03-08";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {
                        dateElementDep = "dpDepartureDate_Bus";
                        dateDepart = "2020-03-08";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        dateElementRet = "dpReturnDate_Bus";
                        dateReturn = "2020-03-09";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);


                    }
                }


                //--TRAIN-TEST--//
                else if (testID.ToLower().Contains(train) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        dateElementDep = "dpDepartureDate_Train";
                        dateDepart = "2018-05-31";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {
                        dateElementDep = "dpDepartureDate_Train";
                        dateDepart = "2018-05-30";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        dateElementRet = "dpReturnDate_Train";
                        dateReturn = "2018-05-31";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);

                    }
                }

                //--TRAIN-LIVE--//
                else if (testID.ToLower().Contains(train) && testID.ToLower().Contains(live))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        dateElementDep = "dpDepartureDate_Train";
                        dateDepart = "2018-05-31";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {
                        dateElementDep = "dpDepartureDate_Train";
                        dateDepart = "2018-05-30";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        dateElementRet = "dpReturnDate_Train";
                        dateReturn = "2018-05-31";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);

                    }
                }

                //--FERRY-TEST--//
                else if (testID.ToLower().Contains(ferry) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        dateElementDep = "dpDepartureDate_Ferry";
                        dateDepart = "2019-03-21";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);


                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {
                        dateElementDep = "dpDepartureDate_Ferry";
                        dateDepart = "2019-03-21";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        dateElementRet = "dpReturnDate_Ferry";
                        dateReturn = "2019-03-22";


                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);
                    }

                }

                //--FERYY-LIVE--//
                else if (testID.ToLower().Contains(ferry) && testID.ToLower().Contains(live))
                {
                    if (testID.ToLower().Contains(oneway))
                    {
                        dateElementDep = "dpDepartureDate_Ferry";
                        dateDepart = "2020-03-01";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);
                    }

                    else if (testID.ToLower().Contains(returntrip))
                    {
                        dateElementDep = "dpDepartureDate_Ferry";
                        dateDepart = "2020-03-01";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        dateElementRet = "dpReturnDate_Ferry";
                        dateReturn = "2020-03-02";


                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);
                    }

                }


                //--CAR-TEST--//
                else if (testID.ToLower().Contains(car) && testID.ToLower().Contains(test))
                {
                    if (testID.ToLower().Contains(myr))
                    {
                        dateElementDep = "ddPickUpDateCar";
                        dateDepart = "2019-03-08";
                        pickupTimeElem = "ddlPickUpTimeCar";
                        pickupTimeList = "//*[@id=\"ddlPickUpTimeCar\"]/option[1]";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        driver.FindElement(By.Id(pickupTimeElem)).Click();
                        driver.FindElement(By.XPath(pickupTimeList)).Click();

                        dateElementRet = "ddReturnDateCar";
                        dateReturn = "2019-03-08";
                        returnTimeElem = "ddlReturnTimeCar";
                        returnTimeList = "//*[@id=\"ddlReturnTimeCar\"]/option[3]";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.XPath(returnTimeList)).Click();

                    }

                    else if (testID.ToLower().Contains(sgd))
                    {
                        dateElementDep = "ddPickUpDateCar";
                        dateDepart = "2019-03-08";
                        pickupTimeElem = "ddlPickUpTimeCar";
                        pickupTimeList = "//*[@id=\"ddlPickUpTimeCar\"]/option[1]";


                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        driver.FindElement(By.Id(pickupTimeElem)).Click();
                        driver.FindElement(By.XPath(pickupTimeList)).Click();

                        dateElementRet = "ddReturnDateCar";
                        dateReturn = "2019-03-09";
                        returnTimeElem = "ddlReturnTimeCar";
                        returnTimeList = "//*[@id=\"ddlReturnTimeCar\"]/option[2]";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);

                        driver.FindElement(By.Id(returnTimeElem)).Click();
                        driver.FindElement(By.XPath(returnTimeList)).Click();

                    }


                }

                //--CAR-LIVE--//
                else if (testID.ToLower().Contains(car) && testID.ToLower().Contains(live))
                {

                    if (testID.ToLower().Contains(myr))
                    {
                        dateElementDep = "ddPickUpDateCar";
                        dateDepart = "2046-03-08";
                        pickupTimeElem = "ddlPickUpTimeCar";
                        pickupTimeList = "//*[@id=\"ddlPickUpTimeCar\"]/option[1]";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        driver.FindElement(By.Id(pickupTimeElem)).Click();
                        driver.FindElement(By.XPath(pickupTimeList)).Click();

                        dateElementRet = "ddReturnDateCar";
                        dateReturn = "2046-03-08";
                        returnTimeElem = "ddlReturnTimeCar";
                        returnTimeList = "//*[@id=\"ddlReturnTimeCar\"]/option[3]";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);

                        driver.FindElement(By.Id(returnTimeElem)).Click();
                        driver.FindElement(By.XPath(returnTimeList)).Click();
                    }

                    else if (testID.ToLower().Contains(sgd))
                    {
                        dateElementDep = "ddPickUpDateCar";
                        dateDepart = "2046-03-08";
                        pickupTimeElem = "ddlPickUpTimeCar";
                        pickupTimeList = "//*[@id=\"ddlPickUpTimeCar\"]/option[1]";

                        driver.FindElement(By.Id(dateElementDep)).Click();
                        driver.FindElement(By.Id(dateElementDep)).Clear();
                        driver.FindElement(By.Id(dateElementDep)).SendKeys(dateDepart);

                        driver.FindElement(By.Id(pickupTimeElem)).Click();
                        driver.FindElement(By.XPath(pickupTimeList)).Click();

                        dateElementRet = "ddReturnDateCar";
                        dateReturn = "2046-03-09";
                        returnTimeElem = "ddlReturnTimeCar";
                        returnTimeList = "//*[@id=\"ddlReturnTimeCar\"]/option[2]";

                        driver.FindElement(By.Id(dateElementRet)).Click();
                        driver.FindElement(By.Id(dateElementRet)).Clear();
                        driver.FindElement(By.Id(dateElementRet)).SendKeys(dateReturn);


                        driver.FindElement(By.Id(returnTimeElem)).Click();
                        driver.FindElement(By.XPath(returnTimeList)).Click();

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
