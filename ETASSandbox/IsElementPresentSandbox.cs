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
using System.Reflection;

namespace ETASSandbox
{
    class IsElementPresentSandbox
    {
        private IWebDriver driver;
        private XmlDocument xml;

        public IsElementPresentSandbox(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        //IWebDriver driver = new ChromeDriver();
        public void LaunchBrowser()
        {
            string urlLive = "https://www.easybook.com/en-my";
            string urlTest = "https://test.easybook.com/en-my";
            try
            {
                //Console.WriteLine("Live (1) or test (2) site?");
                string site = "2";//Console.ReadLine();
                if (site == "1")
                {
                    driver.Navigate().GoToUrl(urlLive);
                }
                else if (site == "2")
                {
                    driver.Navigate().GoToUrl(urlTest);
                }


                driver.Manage().Window.Maximize();


            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }

        public void Login()
        {
            try
            {
                if (IsElementPresent(By.LinkText("Sign in")))
                {
                    Console.WriteLine("By link text");
                    driver.FindElement(By.LinkText("Sign in")).Click();
                    driver.FindElement(By.Id("loginLink")).Click();
                    driver.FindElement(By.Id("Email")).Clear();
                    driver.FindElement(By.Id("Email")).SendKeys("mohdzuhair@easybook.com");
                    driver.FindElement(By.Id("Password")).Clear();
                    driver.FindElement(By.Id("Password")).SendKeys("123456");
                    driver.FindElement(By.Id("btnLogin")).Click();
                }
                else if (IsElementPresent(By.XPath("//*[@id=\"bs-example-navbar-collapse-1\"]/ul/li[1]/a")))
                {
                    Console.WriteLine("By Xpath");
                    driver.FindElement(By.XPath("//*[@id=\"bs-example-navbar-collapse-1\"]/ul/li[1]/a")).Click();
                    driver.FindElement(By.Id("loginLink")).Click();
                    driver.FindElement(By.Id("Email")).Clear();
                    driver.FindElement(By.Id("Email")).SendKeys("mohdzuhair@easybook.com");
                    driver.FindElement(By.Id("Password")).Clear();
                    driver.FindElement(By.Id("Password")).SendKeys("123456");
                    driver.FindElement(By.Id("btnLogin")).Click();
                }
                /*
                //*[@id="bs-example-navbar-collapse-1"]/ul/li[1]/a
                //driver.FindElement(By.LinkText("Sign in")).Click();
                driver.FindElement(By.XPath("//*[@id=\"bs-example-navbar-collapse-1\"]/ul/li[1]/a")).Click();
                driver.FindElement(By.Id("loginLink")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys("mohdzuhair@easybook.com");
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys("123456");
                //driver.FindElement(By.Id("CaptchaCode")).Click();
                //Thread.Sleep(6000);

                driver.FindElement(By.Id("btnLogin")).Click();
                */
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Login not found");
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
