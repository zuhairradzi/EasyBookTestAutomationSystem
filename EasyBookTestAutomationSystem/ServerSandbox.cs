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
    class ServerSandbox
    {
        string ServerWanted;
        string ServerNameWanted;
        string ServerBQwanted;
        string s1 = "G3ASPRO01";
        string s2 = "G3ASPRO02";
        string testURL = "https://test.easybook.com";
        string liveURL = "https://www.easybook.com";
        string serverTest = "G3ASPRO01";

        private IWebDriver driver;

        public ServerSandbox(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }
        public ServerSandbox()
        {
        }

        public void LaunchBrowser2()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl(testURL);
                driver.Manage().Window.Maximize();
            }
            catch (Exception)
            {
                Console.WriteLine("Browser cannot restart");
            }
        }


        public void LaunchBrowser()
        {
            try
            {
                ServerSandbox test1 = new ServerSandbox(driver);
                //Console.WriteLine("4.0.1");
                driver.Navigate().GoToUrl(testURL);
                driver.Manage().Window.Maximize();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);

                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                // string server = footerStr.Substring(142, 10);
                //string serverName = server.Trim();
                Console.WriteLine();
                Console.WriteLine();
                if (serverTest.Contains(s1))
                {
                    //Console.WriteLine("4.0.1.a");
                    ServerWanted = "S1";
                    ServerNameWanted = "G3ASPRO01";
                    ServerBQwanted = "01";

                    if (footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.a.1");
                        Console.WriteLine("Current server is : " + ServerNameWanted);
                        Console.WriteLine("Server " + ServerWanted + " found");
                        Console.WriteLine();
                        Console.WriteLine();
                        //Console.WriteLine("3.4.1");


                    }

                    else if (!footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.a.2");
                        Console.WriteLine("Current server is : G3ASPRO02");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();

                        test1.LaunchBrowser2();
                        test1.ConnectServer1();
                        //Console.WriteLine("3.4.2");
                    }

                }
                else if (serverTest.Contains(s2))
                {
                    //Console.WriteLine("4.0.1.b");
                    ServerWanted = "S2";
                    ServerNameWanted = "G3ASPRO02";
                    ServerBQwanted = "02";

                    if (footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.b.1");
                        Console.WriteLine("Current server is : " + ServerNameWanted);
                        Console.WriteLine("Server " + ServerWanted + " found");
                        Console.WriteLine();
                        Console.WriteLine();
                        // Console.WriteLine("3.4.3");
                    }
                    else if (!footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.b.2");
                        Console.WriteLine("Current server is : G3ASPRO01");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();



                        test1.LaunchBrowser2();
                        test1.ConnectServer2();
                        Thread.Sleep(2000);
                        //Console.WriteLine("3.4.4");
                    }

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not foundddd", e);

            }

        }


        public void ConnectServer2()
        {
            try
            {
               
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
                    ServerSandbox server2 = new ServerSandbox();
                    //Console.WriteLine("URL = "+ EBUrl);
                    server2.Server1Test();
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

        public void ConnectServer1()
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
                    ServerSandbox server1 = new ServerSandbox();
                    //Console.WriteLine("URL = " + EBUrl);
                    server1.Server1Test();
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


        public void Server1Test()
        {
            //Console.WriteLine("Server1Test.1 - enter");
            driver = new ChromeDriver();
            //Console.WriteLine("Server1Test.1 - chrome launch");
            //Console.WriteLine("URL = " + EBUrl);
            driver.Navigate().GoToUrl(testURL);
            driver.Manage().Window.Maximize();
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
                ServerSandbox server1 = new ServerSandbox();
                server1.Server1Test();
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

        public void Server2Test()
        {
            //Console.WriteLine("Server1Test.1");
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testURL);
            driver.Manage().Window.Maximize();
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
                ServerSandbox server2 = new ServerSandbox();
                server2.Server1Test();
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
