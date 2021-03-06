﻿using OpenQA.Selenium;
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
    class PassengerDetail
    {
        public IWebDriver driver;
        public XmlDocument xml;

        public PassengerDetail(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        string insuranceElemClass, insuranceElemID, insuranceElemXP, nationalityValue, nationElem, genderElemXP, genderElemID, genderTypeXP, genderTypeText, ICPassElem, ICPassValue; 

        public void ReadElement(string XMLpath, string product)
        {
            PassengerDetail PassengerTest = new PassengerDetail(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/PassengerDetails");
            foreach (XmlNode xnode in xnList)
            {
                insuranceElemClass = xnode["Insurance"]["ClassName"].InnerText.Trim();
                insuranceElemID = xnode["Insurance"]["Id"].InnerText.Trim();
                insuranceElemXP = xnode["Insurance"]["XPath"].InnerText.Trim();
                nationElem = xnode["Nationality"]["NationalityElement"]["Id"].InnerText.Trim();
                nationalityValue = xnode["Nationality"]["Value"]["SelectByText"].InnerText.Trim();
                genderElemXP = xnode["Gender"]["GenElement"]["XPath"].InnerText.Trim();
                genderElemID = xnode["Gender"]["GenElement"]["Id"].InnerText.Trim();
                genderTypeXP = xnode["Gender"]["GenValue"]["Male"]["XPath"].InnerText.Trim();
                genderTypeText = xnode["Gender"]["GenValue"]["Male"]["Text"].InnerText.Trim();
                ICPassElem = xnode["ICPassport"]["FieldElement"]["XPath"].InnerText.Trim();
                ICPassValue = xnode["ICPassport"]["Value"].InnerText.Trim();
            }

            if (product.ToLower().Contains("bus"))
            {
                PassengerTest.untickInsurance(insuranceElemID);
            }

            if (product.ToLower().Contains("car"))
            {
                PassengerTest.Nationality(nationElem, nationalityValue);
            }

            if (product.ToLower().Contains("train"))
            {
                PassengerTest.Gender(genderElemXP, genderTypeText);
                PassengerTest.ICPassPort(ICPassElem, ICPassValue);
            }
        }

        public void untickInsurance(string insurance)
        {
            try
            {
                driver.FindElement(By.Id(insurance)).Click();
               // IWebElement element = driver.FindElement(By.Id(insurance));
               // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
               // IAlert confirmationAlert = driver.SwitchTo().Alert();
               // confirmationAlert.Accept();

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Insurance not found");
            }
        }

        public void Nationality(string natElement, string natType)
        {
            try
            {
                var NatElem = driver.FindElement(By.Id(natElement));
                var selectElement = new SelectElement(NatElem);
                selectElement.SelectByText(natType);
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nationality not found");
            }

        }

        public void Gender(string genElem, string genType)
        {
            try
            {

                driver.FindElement(By.XPath(genElem)).Click();
                new SelectElement(driver.FindElement(By.XPath(genElem))).SelectByText(genType);
                driver.FindElement(By.XPath(genElem)).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Gender not found");
            }

        }

        public void ICPassPort(string ICElem, string ICno)
        {
            try
            {
                driver.FindElement(By.XPath(ICElem)).SendKeys(ICno);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("ICPassport not found");
            }
        }
    }
}
