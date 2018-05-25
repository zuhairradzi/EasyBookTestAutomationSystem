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
using System.Data.SqlClient;

namespace EBTestGUI
{
    class LoginEBSite
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //----Login Elements--//
        string ElLogin, ElSignIn, ElemEmail, ElemPass, email, password, ElemCaptcha, ElBtnLogin, scrollToTopJS;
        //-------------------------------------------------------------------------------------//

        //---------------------METHODS-------------------------------------------//
        public IWebDriver driver;
        public XmlDocument xml;

        public LoginEBSite(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void ReadElement(string XMLpath)
        {
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/EBLogin/LoginElement");
            foreach (XmlNode xnode in xnMenu)
            {
                ElSignIn = xnode["SignIn"]["XPath"].InnerText.Trim();
                ElLogin = xnode["Login"]["Id"].InnerText.Trim();
                ElemEmail = xnode["Email"]["Id"].InnerText.Trim();
                ElemPass = xnode["Pass"]["Id"].InnerText.Trim();
                ElemCaptcha = xnode["Captcha"]["Id"].InnerText.Trim();
                ElBtnLogin = xnode["buttonLogin"]["Id"].InnerText.Trim();
                scrollToTopJS = xnode["JSactions"]["ScrolltoTop"]["Action"].InnerText.Trim();
            }
        }

        public void ReadDB(string sqlString)
        {
            using (SqlConnection connection = new SqlConnection(sqlString))
            using (SqlCommand command = new SqlCommand("select * from loginEB", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        email = reader["emailEB"].ToString();
                        password = reader["passwordEB"].ToString();
                    }
                }
            }
        }

        public void loginEB()
        {
            try
            {
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollToTopJS);
                driver.FindElement(By.XPath(ElSignIn)).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElLogin)))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemEmail)))).Clear();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemEmail)))).SendKeys(email);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemPass)))).Clear();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemPass)))).SendKeys(password);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElBtnLogin)))).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Login not found");
            }
        }
    }
}
