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
                MessageBox.Show("Login unsuccessful");
                Console.WriteLine("Login unsuccessful");
            }
        }

        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        //Encrypt
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        //Decrypt
        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
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
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
