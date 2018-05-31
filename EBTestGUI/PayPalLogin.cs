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
using System.Windows.Forms;

namespace EBTestGUI
{
    class PayPalLogin
    {
        private IWebDriver driver;
        private XmlDocument xml;

        public PayPalLogin(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        string LoginButtonFirst, emailElementID, emailVal, emailProceedElementId, emailProceedElementXp, passwordElemId, pwVal, LoginButtonCss, LoginButtonXP;
        public void ReadElement(string XMLpath)
        {
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/PayPalLogin");
            foreach (XmlNode xnode in xnMenu)
            {
                LoginButtonFirst = xnode["LoginButton"]["XPath"].InnerText.Trim();
                emailElementID = xnode["Email"]["Id"].InnerText.Trim();
                emailProceedElementXp = xnode["Email"]["ContinueButton"]["XPath"].InnerText.Trim();
                emailProceedElementId = xnode["Email"]["ContinueButton"]["Id"].InnerText.Trim();
                passwordElemId = xnode["Password"]["Id"].InnerText.Trim();
                LoginButtonCss = xnode["Password"]["ContinueButton"]["CssSelector"].InnerText.Trim();
                LoginButtonXP = xnode["Password"]["ContinueButton"]["XPath"].InnerText.Trim();
            }
        }


        public void ReadDB(string sqlString)
        {
            using (SqlConnection connection = new SqlConnection(sqlString))
            using (SqlCommand command = new SqlCommand("select * from loginPayPal", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        emailVal = reader["emailPP"].ToString();
                        pwVal = reader["passwordPP"].ToString();
                    }
                }
            }
        }

        public void ClickLogin()
        {
            try
            {
                new WebDriverWait(driver,
                    TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists(By.XPath(LoginButtonFirst))).Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Login to PayPal button not found");
                Console.WriteLine("Login to PayPal button not found");
            }
        }

        public void enterEmPP()
        {
            try
            {
                Thread.Sleep(5000);
                driver.FindElement(By.Id(emailElementID)).SendKeys(emailVal);
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("PayPal email field not found");
                Console.WriteLine("PayPal email field not found");
            }

            try
            {
                driver.FindElement(By.XPath(emailProceedElementXp)).Click();
                Thread.Sleep(3000);
            }
            catch (NoSuchElementException)
            {

                MessageBox.Show("Cannot proceed to password");
                Console.WriteLine("Cannot proceed to password");
            }
        }

        public void enterPwPP()
        {
            try
            {
                var password = driver.FindElement(By.Id(passwordElemId));
                password.SendKeys(pwVal);
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Password field not found");
                Console.WriteLine("Password field not found");
            }

            try
            {
                driver.FindElement(By.CssSelector(LoginButtonCss)).Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Cannot login into PayPal");
                Console.WriteLine("Cannot login into PayPal");
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
