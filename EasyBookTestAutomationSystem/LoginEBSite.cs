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

namespace EasyBookTestAutomationSystem
{
    class LoginEBSite
    {
        private IWebDriver driver;

        public LoginEBSite(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        XmlTextReader reader = new XmlTextReader("EBlogin.xml");
        public void loginEB()
        {
            try
            {
                Console.WriteLine(reader.Value);
                driver.FindElement(By.LinkText("Sign in")).Click();
                driver.FindElement(By.Id("loginLink")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys("mohdzuhair@easybook.com");
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys("123456");
                driver.FindElement(By.Id("CaptchaCode")).Click();
                Thread.Sleep(6000);

                driver.FindElement(By.Id("btnLogin")).Click();

            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Login not found");
            }
        }
    }
}
