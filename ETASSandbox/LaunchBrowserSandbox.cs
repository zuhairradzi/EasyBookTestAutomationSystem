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
    class LaunchBrowserSandbox
    {
        private IWebDriver driver;
        private XmlDocument xml;



        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //----Login Elements--//

        string ElLogin, ElSignIn, ElemEmail, ElemPass, email, password, ElemCaptcha, ElBtnLogin;
        
        //---links---//
        string urlTest = "https://test.easybook.com";
        string urlLive = "https://www.easybook.com";

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//



        public LaunchBrowserSandbox(XmlDocument xml, IWebDriver driver)
        {
            this.xml = xml;
            this.driver = driver;
            
        }
        public void LaunchBrowser()
        {
            driver.Navigate().GoToUrl(urlTest);
            driver.Manage().Window.Maximize();
        }


        public void loginEB(string XMLpath)
        {

            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/EBLogin/LoginElement");
            //Console.WriteLine("haha");
            foreach (XmlNode xnode in xnList)
            {
                ElSignIn = xnode["SignIn"]["XPath"].InnerText.Trim();
                Console.WriteLine("ElSignIn : " +ElSignIn.Trim());

                ElLogin = xnode["Login"]["Id"].InnerText.Trim();
                //Console.WriteLine("ElLogin : " + ElLogin.Trim());

                ElemEmail = xnode["Email"]["Id"].InnerText.Trim();
                //Console.WriteLine("ElemEmail : " + ElemEmail.Trim());

                ElemPass = xnode["Pass"]["Id"].InnerText.Trim();
                //Console.WriteLine("ElemPass : " + ElemPass.Trim());

                email = xnode["Email"]["Value"].InnerText.Trim();
                //Console.WriteLine("email : " + email.Trim());

                password = xnode["Pass"]["Value"].InnerText.Trim();
               // Console.WriteLine("password : " + password.Trim());

                ElemCaptcha = xnode["Captcha"]["Id"].InnerText.Trim();
                //Console.WriteLine("ElemCaptcha : " + ElemCaptcha.Trim());

                ElBtnLogin = xnode["buttonLogin"]["Id"].InnerText.Trim();
                //Console.WriteLine("ElBtnLogin :" + ElBtnLogin.Trim());
            }

            try
            {

                driver.FindElement(By.XPath(ElSignIn)).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElLogin)))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemEmail)))).Clear();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemEmail)))).SendKeys(email);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemPass)))).Clear();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemPass)))).SendKeys(password);
               // new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemCaptcha)))).Click();
               // Thread.Sleep(6000);

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElBtnLogin)))).Click();

            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Login not found");
            }
        }
    }
}
