using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Windows.Forms;

namespace EBTestGUI
{
    class IPServerLaunch
    {
        IWebDriver driver = new ChromeDriver();
        public void LaunchBrowser(string site)
        {
            string urlLive = "https://www.easybook.com/en-my";
            string urlTest = "https://test.easybook.com/en-my";
            try
            {
                if (site.ToLower().Contains("live"))
                {
                    driver.Navigate().GoToUrl(urlLive);
                }
                else if (site.ToLower().Contains("test"))
                {
                    driver.Navigate().GoToUrl(urlTest);
                }
                driver.Manage().Window.Maximize();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Homepage not found");
                Console.WriteLine("Homepage not found");
            }
        }

        public void Login()
        {
            try
            {
                driver.FindElement(By.LinkText("Sign in")).Click();
                driver.FindElement(By.Id("loginLink")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys("mohdzuhair@easybook.com");
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys("123456");
                driver.FindElement(By.Id("btnLogin")).Click();

            }

            catch (NoSuchElementException)
            {
                MessageBox.Show("Login element not found");
                Console.WriteLine("Login element not found");
            }
        }


        public void CheckServerConnection()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(1000);
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                Console.WriteLine();
                Console.WriteLine();
                if (footerStr.Contains("G3ASPRO01"))
                {
                    Console.WriteLine("Current server is : G3ASPRO01");
                    Console.WriteLine("Server 1 found 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();

                }
                else if (footerStr.Contains("G3ASPRO02"))
                {
                    Console.WriteLine("Current server is : G3ASPRO02");
                    Console.WriteLine("Server 2 found at 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();

                }



            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Could not find server element");
            }


        }

    }
}
