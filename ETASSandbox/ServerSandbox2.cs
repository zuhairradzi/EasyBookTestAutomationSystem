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
using System.Xml;
using NUnit.Framework;


namespace ETASSandbox
{
    class ServerSandbox2
    {
        private IWebDriver driver;
        private XmlDocument xml;
        string serverXPath, server1Name, server2Name, ScrollBottom, footerStr;
        string siteType = "test";
        string testURL = "https://test.easybook.com";
        string serverWanted1, serverWanted;
        public ServerSandbox2(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }

        public void ReadElement(string XMLpath)
        {
            Console.WriteLine("Enter server : ");
            serverWanted1 = Console.ReadLine();
            if (serverWanted1.Contains("1"))
            {
                serverWanted = "G3ASPRO01";
            }

            else if (serverWanted1.Contains("2"))
            {
                serverWanted = "G3ASPRO02";
            }
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Server");
            foreach (XmlNode xnode in xnMenu)
            {
                string site = char.ToUpper(siteType[0]) + siteType.Substring(1);
                serverXPath = xnode["footerElement"][site]["XPath"].InnerText.Trim();
                Console.WriteLine("serverXPath : " + serverXPath);

                server1Name = xnode["ServerName"][site]["S1"].InnerText.Trim();
                Console.WriteLine("server1Name : " + server1Name);

                server2Name = xnode["ServerName"][site]["S2"].InnerText.Trim();
                Console.WriteLine("server1Name : " + server2Name);

                ScrollBottom = xnode["JSactions"]["ScrolltoBottom"]["Action"].InnerText.Trim();
                Console.WriteLine("ScrollBottom : " + ScrollBottom);


            }
            Console.WriteLine("Server wanted : " + serverWanted);
            
        }

        public void LaunchBrowser()
        {
            try
            {
               
                driver.Navigate().GoToUrl(testURL);
                driver.Manage().Window.Maximize();
                ((IJavaScriptExecutor)driver).ExecuteScript(ScrollBottom);
                Thread.Sleep(2000);

                var footer = driver.FindElement(By.XPath(serverXPath));
                footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                // string server = footerStr.Substring(142, 10);
                //string serverName = server.Trim();
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server element not found");
            }
        }

        public void ConnectToServerWanted()
        {
            ServerSandbox2 newServer = new ServerSandbox2(xml, driver);
            try
            {
               
                while (!footerStr.Contains(serverWanted))
                {
                    driver.Close();
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl(testURL);
                    driver.Manage().Window.Maximize();
                    ((IJavaScriptExecutor)driver).ExecuteScript(ScrollBottom);
                    Thread.Sleep(2000);
                    var footer = driver.FindElement(By.XPath(serverXPath));
                    footerStr = footer.Text.ToString();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(footerStr);
                    // string server = footerStr.Substring(142, 10);
                    //string serverName = server.Trim();
                    Console.WriteLine();
                    Console.WriteLine();
                }

                if (footerStr.Contains(serverWanted))
                {
                    Console.WriteLine("Server "+serverWanted+" found");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server element not found");
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
                //driver.FindElement(By.Id("CaptchaCode")).Click();
                //Thread.Sleep(6000);

                driver.FindElement(By.Id("btnLogin")).Click();

            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Login not found");
            }
        }
    }

}
