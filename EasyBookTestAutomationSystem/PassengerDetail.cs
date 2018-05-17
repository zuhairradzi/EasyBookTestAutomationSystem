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
    class PassengerDetail
    {
        public IWebDriver driver;
        public XmlDocument xml;

        public PassengerDetail(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        string insuranceElem, nationalityValue, nationElem; 

        public void ReadElement(string XMLpath, string product)
        {
            PassengerDetail PassengerTest = new PassengerDetail(xml, driver);
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/PassengerDetails");
            foreach (XmlNode xnode in xnList)
            {
                insuranceElem = xnode["Insurance"]["ClassName"].InnerText.Trim();
                Console.WriteLine("InsuranceClassName : " + insuranceElem);

                nationElem = xnode["Nationality"]["NationalityElement"]["Id"].InnerText.Trim();
                Console.WriteLine("nationalityElem : " + nationElem);

                nationalityValue = xnode["Nationality"]["Value"]["SelectByText"].InnerText.Trim();
                Console.WriteLine("natiValue : " + nationalityValue);
            }

            if (product.ToLower().Contains("bus"))
            {
                PassengerTest.untickInsurance(insuranceElem);
            }

            if (product.ToLower().Contains("car"))
            {
                PassengerTest.Nationality(nationElem, nationalityValue);
            }

            if (product.ToLower().Contains("train"))
            {
                PassengerTest.Nationality(nationElem, nationalityValue);
            }
        }

        public void untickInsurance(string insurance)
        {
            try
            {
                IWebElement element = driver.FindElement(By.ClassName(insurance));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
                IAlert confirmationAlert = driver.SwitchTo().Alert();
                confirmationAlert.Accept();

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Insurance not found");
                //driver.Close();

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
                //driver.Close();

            }

        }
    }
}
