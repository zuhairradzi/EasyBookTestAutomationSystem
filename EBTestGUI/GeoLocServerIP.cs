using System;
using OpenQA.Selenium;
using System.Xml;
using System.Windows.Forms;

namespace EBTestGUI
{
    class GeoLocServerIP
    {
        public IWebDriver driver;
        public XmlDocument xml;

        public GeoLocServerIP(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        string scrollDownJS, footerElem, server1, server2;
        string ipAdress, server;

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

        public string CheckServerConnection()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollDownJS);
                var footer = driver.FindElement(By.XPath(footerElem));
                string footerStr = footer.Text.ToString();
                if (footerStr.Contains(server1))
                {
                    server = server1;
                    Console.WriteLine("Current server is : " + server);
                    Console.WriteLine("Server 1 found 1 attempt");
                    Console.WriteLine();
                    return server;
                }
                else if (footerStr.Contains(server2))
                {
                    server = server2;
                    Console.WriteLine("Current server is :" + server);
                    Console.WriteLine("Server 2 found at 1 attempt");
                    Console.WriteLine();
                    return server;
                }
                return null;
            }
            catch (NoSuchElementException)

            {
                MessageBox.Show("Error #GEO01: Server element not found!");
                Console.WriteLine("Server element not found!");
                return null;
            }
        }
        public string CheckIPAddress()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollDownJS);
                var footer = driver.FindElement(By.XPath(footerElem));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                int pFrom = footerStr.IndexOf("s : ") + "s : ".Length;
                int pTo = footerStr.LastIndexOf("Ser");

                ipAdress = footerStr.Substring(pFrom, pTo - pFrom);
                return ipAdress;
            }
            catch (NoSuchElementException)

            {
                MessageBox.Show("Error #GEO02: IP address element not found!");
                Console.WriteLine("Server element not found!");
                return null;
            }
        }
    }
}
