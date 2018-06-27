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
using System.Security.Cryptography;

namespace EBTestGUI
{
    class PayPalLogin
    {
        private IWebDriver driver;
        private XmlDocument xml;
        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;

        public PayPalLogin(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        string LoginButtonFirst, emailElementID, PPemail, emailProceedElementId, emailProceedElementXp, passwordElemId, PPpass, LoginButtonCss, LoginButtonXP;
        string emailEN, passEN;
        string passKey = "eb123";
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
            XmlNodeList xnMenu1 = xml.SelectNodes("/ETAS/Login/PayPal");
            foreach (XmlNode xnode in xnMenu1)
            {
                emailEN = xnode["Email"].InnerText.Trim();
                passEN = xnode["Password"].InnerText.Trim();
            }
        }

        public void DecryptStringEmail()
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(emailEN);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passKey, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            PPemail = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public void DecryptStringPW()
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(passEN);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passKey, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            PPpass = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
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
                MessageBox.Show("Error #PPL01: Login to PayPal button not found");
                Console.WriteLine("Login to PayPal button not found");
            }
        }

        public void enterEmPP()
        {
            try
            {
                Thread.Sleep(5000);
                driver.FindElement(By.Id(emailElementID)).SendKeys(PPemail);
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #PPL02: PayPal email field not found");
                Console.WriteLine("PayPal email field not found");
            }

            try
            {
                driver.FindElement(By.XPath(emailProceedElementXp)).Click();
                Thread.Sleep(3000);
            }
            catch (NoSuchElementException)
            {

                MessageBox.Show("Error #PPL02: Cannot proceed to password");
                Console.WriteLine("Cannot proceed to password");
            }
        }

        public void enterPwPP()
        {
            try
            {
                var password = driver.FindElement(By.Id(passwordElemId));
                password.SendKeys(PPpass);
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #PPL03: Password field not found");
                Console.WriteLine("Password field not found");
            }

            try
            {
                driver.FindElement(By.CssSelector(LoginButtonCss)).Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #PPL03: Cannot login into PayPal");
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
