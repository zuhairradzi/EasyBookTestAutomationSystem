using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Threading;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace EBTestGUI
{
    class LoginEBSite
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //----Login Elements--//
        string ElLogin, ElSignIn, ElemEmail, ElemPass, emailEN, passEN, ElemCaptcha, ElBtnLogin, scrollToTopJS;
        string passKey = "eb123";
        string EBemail, EBpass;
        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        //Encrypt
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
            XmlNodeList xnMenu1 = xml.SelectNodes("/ETAS/Login/EB");
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
            EBemail = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
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
            EBpass = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemEmail)))).SendKeys(EBemail);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemPass)))).Clear();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElemPass)))).SendKeys(EBpass);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(ElBtnLogin)))).Click();
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Login unsuccessful");
                Console.WriteLine("Login unsuccessful");
            }
        }

    }
}
