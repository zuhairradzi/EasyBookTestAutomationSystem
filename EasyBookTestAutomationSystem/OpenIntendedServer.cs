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

namespace EasyBookTestAutomationSystem
{
    class OpenIntendedServer
    {
        string serverType;
        private string EBUrl;
        private IWebDriver driver;
        string server_1 = "G3ASPRO01";
        string server_2 = "G3ASPRO02";

        public OpenIntendedServer(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

        public OpenIntendedServer(string ChooseEBurl)
        {
            this.EBUrl = ChooseEBurl;
        }

        public OpenIntendedServer()
        {
        }
        //OpenIntendedServer server1 = new OpenIntendedServer();
        //OpenIntendedServer server2 = new OpenIntendedServer();

        public void LaunchBrowser(string EBurl)
        {
            try
            {
                driver = new ChromeDriver();
                //Console.WriteLine("4.0.1.1.a");
                driver.Navigate().GoToUrl(EBurl);
                driver.Manage().Window.Maximize();
                //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");


            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }

        public void ConnectServer2(string EBurl)
        {
            try
            {
                string EBUrl = EBurl;
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();

                // string server = footerStr.Substring(142, 10);
                //string serverName = server.Trim();
                Console.WriteLine();
                Console.WriteLine();
                if (footerStr.Contains("G3ASPRO02"))
                {
                    Console.WriteLine("Current server is : G3ASPRO02");
                    Console.WriteLine("Server S2 found 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();
                    //Console.WriteLine("ConnectServer2.1");
                    //Console.WriteLine("3.4.1");

                }
                else if (!footerStr.Contains("G3ASPRO02"))
                {
                    Console.WriteLine("Current server is : G3ASPRO01");
                    Console.WriteLine("Server S1 found at 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();
                    //Console.WriteLine("ConnectServer2.2");
                    driver.Close();
                    OpenIntendedServer server2 = new OpenIntendedServer(EBUrl);
                    //Console.WriteLine("URL = "+ EBUrl);
                    server2.Server2Test(EBUrl);
                    Thread.Sleep(2000);
                    //Console.WriteLine("ConnectServer2.3");
                    //Console.WriteLine("3.4.2");
                }
                else
                {
                    Console.WriteLine("Wrong server name");
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server not found");

            }

        }

        public void ConnectServer1(string EBurl)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                if (footerStr.Contains("G3ASPRO01"))
                {
                    Console.WriteLine("Current server is : G3ASPRO01");
                    Console.WriteLine("Server S1 found");
                    Console.WriteLine();
                    Console.WriteLine();
                    //Console.WriteLine("ConnectServer1.1");

                    //Console.WriteLine("3.4.2");
                }
                else if (!footerStr.Contains("G3ASPRO01"))
                {
                    Console.WriteLine("Current server is : G3ASPRO02");
                    Console.WriteLine("Server S2 found");
                    Console.WriteLine();
                    Console.WriteLine();
                    //Console.WriteLine("ConnectServer1.2");
                    driver.Close();
                    //Console.WriteLine("2.4.1111");
                    OpenIntendedServer server1 = new OpenIntendedServer();
                    //Console.WriteLine("URL = " + EBUrl);
                    server1.Server1Test(EBUrl);
                    Thread.Sleep(2000);
                    //Console.WriteLine("ConnectServer1.3");
                    //Console.WriteLine("3.4.1");
                }
                else
                {
                    Console.WriteLine("Wrong server name");
                }


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server not found");

            }

        }


        public void Server1Test(string EBUrl)
        {
            //Console.WriteLine("Server1Test.1 - enter");
            driver = new ChromeDriver();
            //Console.WriteLine("Server1Test.1 - chrome launch");
            //Console.WriteLine("URL = " + EBUrl);
            driver.Navigate().GoToUrl(EBUrl);
            //Console.WriteLine("Server1Test.1 - go to url");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            Thread.Sleep(2000);
            var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
            string footerStr = footer.Text.ToString();

            int i = 1;
            while (!footerStr.Contains("G3ASPRO01"))
            {
                //Console.WriteLine("Server1Test.1.1");
                driver.Close();
                // Console.WriteLine("2.1");
                i++;
                Thread.Sleep(2000);
                // Console.WriteLine("2.2");
                if (footerStr.Contains("G3ASPRO01"))
                {
                   // Console.WriteLine("Server1Test.1.1.2");
                    break;
                }
                OpenIntendedServer server1 = new OpenIntendedServer();
                server1.Server1Test(EBUrl);
                if (footerStr.Contains("G3ASPRO01"))
                {
                    //Console.WriteLine("Server1Test.1.1.3");
                    break;
                }
                // Console.WriteLine("2.3");
            }
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("Server1Test.1.2");
            Console.WriteLine("Current server is : G3ASPRO01");
            // Console.WriteLine("Current server is : " + serverName.Trim());
            Console.WriteLine("Server S1 found " + i + " attempt");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("2.4.1");
            //Console.WriteLine("2.4.11");
            return;
            //Console.WriteLine("2.4.111");
        }

        public void Server2Test(string EBUrl)
        {
            //Console.WriteLine("Server1Test.1");
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(EBUrl);
            //Console.WriteLine("Server2Test.1");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            Thread.Sleep(2000);
            var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
            string footerStr = footer.Text.ToString();
            int i = 1;
            while (!footerStr.Contains("G3ASPRO02"))
            {
                //Console.WriteLine("Server2Test.1.1");
                driver.Close();
                // Console.WriteLine("1.1");
                i++;
                Thread.Sleep(2000);
                // Console.WriteLine("1.2");
                if (footerStr.Contains("G3ASPRO02"))
                {
                    //Console.WriteLine("Server2Test.1.1.1");
                    break;
                }
                OpenIntendedServer server2 = new OpenIntendedServer();
                server2.Server1Test(EBUrl);
                if (footerStr.Contains("G3ASPRO02"))
                {
                    //Console.WriteLine("Server2Test.1.1.2");
                    break;
                }
                //Console.WriteLine("1.3");

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : G3ASPRO02");
            //Console.WriteLine("Current server is : " + serverName.Trim());
            Console.WriteLine("Server S2 found at " + i + " attempt");
            //Console.WriteLine("Server2Test.2");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(2000);
            // Console.WriteLine("1.4.1");
            return;

        }
    }
}