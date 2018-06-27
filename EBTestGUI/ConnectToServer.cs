using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Xml;
using System.Windows.Forms;

namespace EBTestGUI
{
    class ConnectToServer
    {
        public IWebDriver driver;
        public XmlDocument xml;
        string serverXPath, server1Name, server2Name, ScrollBottom, footerStr, serverNeeded;

        public ConnectToServer(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void ReadElement(string XMLpath, string serverInput, string siteType)
        {
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Server");
            foreach (XmlNode xnode in xnMenu)
            {
                string site = char.ToUpper(siteType[0]) + siteType.Substring(1);
                string serverName = char.ToUpper(serverInput[0]) + serverInput.Substring(1);

                serverXPath = xnode["footerElement"][site]["XPath"].InnerText.Trim();
                serverNeeded = xnode["ServerName"][site][serverName].InnerText.Trim();
                server1Name = xnode["ServerName"][site]["S1"].InnerText.Trim();
                server2Name = xnode["ServerName"][site]["S2"].InnerText.Trim();
                ScrollBottom = xnode["JSactions"]["ScrolltoBottom"]["Action"].InnerText.Trim();
            }
        }

        public void LaunchBrowser(string EBUrl)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(ScrollBottom);
                Thread.Sleep(2000);
                var footer = driver.FindElement(By.XPath(serverXPath));
                footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                Console.WriteLine();
                Console.WriteLine();

            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #COSE01 : Server element not found");
                Console.WriteLine("Server element not found");
            }
        }

        public IWebDriver ConnectToServerWanted(string EBUrl)
        {
            ConnectToServer newServer = new ConnectToServer(xml, driver);
            try
            {
                while (!footerStr.Contains(serverNeeded))
                {
                    driver.Close();
                    driver = new ChromeDriver("D:\\Easybook Test System\\");
                    driver.Navigate().GoToUrl(EBUrl);
                    driver.Manage().Window.Maximize();
                    ((IJavaScriptExecutor)driver).ExecuteScript(ScrollBottom);
                    Thread.Sleep(2000);
                    var footer = driver.FindElement(By.XPath(serverXPath));
                    footerStr = footer.Text.ToString();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(footerStr);
                    Console.WriteLine();
                    Console.WriteLine();
                }

                if (footerStr.Contains(serverNeeded))
                {
                    Console.WriteLine("Server " + serverNeeded + " found");
                    return driver;
                }
                return null;
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #COSE02 : Server element not found");
                Console.WriteLine("Server element not found");
                return null;
            }
        }

        private void Close()
        {
            this.Close();
        }
    }
}
