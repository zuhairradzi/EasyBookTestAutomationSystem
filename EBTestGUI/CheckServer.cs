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
using System.Windows.Forms;

namespace EBTestGUI
{
    class CheckServer
    {

        public IWebDriver driver;
        public XmlDocument xml;

        public CheckServer(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        string scrollDownJS, footerElem, server1, server2;

        public void ReadElement(string XMLpath, string site)
        {
            string siteType = char.ToUpper(site[0]) + site.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Server");
            foreach (XmlNode xnode in xnMenu)
            {
                scrollDownJS = xnode["JSactions"]["ScrolltoBottom"]["Action"].InnerText.Trim();
                footerElem = xnode["footerElement"][siteType]["XPath"].InnerText.Trim();
                server1 = xnode["ServerName"][siteType]["S1"].InnerText.Trim();
                server2 = xnode["ServerName"][siteType]["S2"].InnerText.Trim();
            }
        }

        public void CheckServerConnection()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollDownJS);
                //Thread.Sleep(1000);
                var footer = driver.FindElement(By.XPath(footerElem));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                Console.WriteLine();
                Console.WriteLine();
                if (footerStr.Contains(server1))
                {
                    Console.WriteLine("Current server is : " + server1);
                    Console.WriteLine("Server 1 found 1 attempt");
                    Console.WriteLine();
                }
                else if (footerStr.Contains(server2))
                {
                    Console.WriteLine("Current server is :" + server2);
                    Console.WriteLine("Server 2 found at 1 attempt");
                    Console.WriteLine();
                }
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Server element not found!");
                Console.WriteLine("Server element not found!");
            }
        }
    }
}
