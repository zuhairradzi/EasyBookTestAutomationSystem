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
    class LoginEBSite
    {

        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //----Login Elements--//

        private IWebDriver driver;
        string ElLogin = "loginLink";
        string ElSignIn;
        string ElUserName = "Email";
        string ElPassword = "Password";
        string username;
        string password;
        string ElCaptcha = "CaptchaCode";
        string ElBtnLogin = "btnLogin";
        string XPathSignIn = "//*[@id=\"bs-example-navbar-collapse-1\"]/ul/li[1]/a";

        //---Login details---//
        string usernameFile = "user.txt";
        string passwordFile = "pass.txt";


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//

        public LoginEBSite(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

       
        public void loginEB(string EBUrl)
        {
            
            try
            {  
                using (StreamReader sr = new StreamReader(usernameFile))
                {
                    username = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            try
            { 
                using (StreamReader sr = new StreamReader(passwordFile))
                {
                    password = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


            try
            {;
                Thread.Sleep(2000);
                driver.FindElement(By.XPath(XPathSignIn)).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElLogin)))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElUserName)))).Clear();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElUserName)))).SendKeys(username);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElPassword)))).Clear();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElPassword)))).SendKeys(password);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElCaptcha)))).Click();
                Thread.Sleep(6000);


                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElBtnLogin)))).Click();
                
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Login not found");
            }
        }
    }
}
