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

namespace EasyBookTestAutomationSystem
{
    class ServerConnection
    {

        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        private IWebDriver driver;
        private XmlDocument xml;

        public ServerConnection(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;

        }


        //---Server Variables--//
        string ServerWanted, FooterXP, XMLfile, scrollDownJS, footerElem, server1, server2;
        string server_1 = "G3ASPRO01";
        string server_2 = "G3ASPRO02";
        string s1 = "s1";
        string s2 = "s2";


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//
        public void ReadElement(string XMLpath, string site, string server)
        {
            string siteType = char.ToUpper(site[0]) + site.Substring(1);
            string serverType = char.ToUpper(server[0]) + server.Substring(1);
            this.XMLfile = XMLpath;
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Server");
            foreach (XmlNode xnode in xnMenu)
            {
                scrollDownJS = xnode["JSactions"]["ScrolltoBottom"]["Action"].InnerText.Trim();
                FooterXP = xnode["footerElement"][siteType]["XPath"].InnerText.Trim();
                ServerWanted = xnode["ServerName"][siteType][serverType].InnerText.Trim();
                server1 = xnode["ServerName"][siteType]["S1"].InnerText.Trim();
                server2 = xnode["ServerName"][siteType]["S2"].InnerText.Trim();
            }

        }



        public void LaunchBrowser(string TestID, string EBurl)
        {
            
            try
            {
                OpenIntendedServer test1 = new OpenIntendedServer(xml, driver);
                driver.Navigate().GoToUrl(EBurl);
                driver.Manage().Window.Maximize();
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollDownJS);
                Thread.Sleep(2000);

                var footer = driver.FindElement(By.XPath(FooterXP));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                Console.WriteLine();
                Console.WriteLine();

                if (TestID.Contains(s1))
                {
                    if (footerStr.Contains(ServerWanted))
                    {
                        Console.WriteLine("Current server is : "+ ServerWanted);
                        Console.WriteLine("Server "+ ServerWanted + " found");
                        Console.WriteLine();
                        Console.WriteLine();


                    }

                    else if (!footerStr.Contains(ServerWanted))
                    {
                        Console.WriteLine("Current server is : S2");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();

                        test1.ReadElement(XMLfile);
                        test1.LaunchBrowser(EBurl);
                        test1.ConnectServer1(EBurl);
             
                    }

                }
                else if (TestID.Contains(s2))
                {

                    if (footerStr.Contains(ServerWanted))
                    {
 
                        Console.WriteLine("Current server is : " + ServerWanted);
                        Console.WriteLine("Server " + ServerWanted + " found");
                        Console.WriteLine();
                        Console.WriteLine();
 

                    }
                    else if (!footerStr.Contains(ServerWanted))
                    {
                   
                        Console.WriteLine("Current server is : S1");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();


                       
                        test1.LaunchBrowser(EBurl);
                        test1.ConnectServer2(EBurl);
                        Thread.Sleep(2000);
                  
                    }

                }

             
            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }

       

    }
   

   
}
