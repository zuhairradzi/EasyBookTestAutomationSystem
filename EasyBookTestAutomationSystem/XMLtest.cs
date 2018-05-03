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
using Microsoft.Office.Interop.Access.Dao;

namespace EasyBookTestAutomationSystem
{
    class XMLtest
    {

        private XmlDocument xml;
        private IWebDriver driver;
        string xpath, xpath2, xpath3;
        public XMLtest(XmlDocument xml, IWebDriver driver)
        {
            this.xml = xml;
            this.driver = driver;
        }
        public void testReadXML(string myXmlString)
        {
            string urlTest = "https://test.easybook.com";
            
            //String myXmlString = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ProductURL.xml";
            //String myXmlString = "<?xml version='1.0' encoding='utf-8'?><Bus><Test><Url1>test.easybook.com1</Url1><Url2>test.easybook.com2</Url2></Test><Live><Url1>www.easybook.com1</Url1><Url2>www.easybook.com2</Url2></Live></Bus>";
            //XmlDocument xml = new XmlDocument();
            xml.Load(myXmlString); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("/ETAS/Server");
            Console.WriteLine("haha");
            foreach (XmlNode xn in xnList)
            {
                xpath3 = xn["footerElement"]["Id"].InnerText;
                Console.WriteLine("xpath: " + xpath3);
                xpath = xn["footerElement"].InnerXml;
                Console.WriteLine("xpath: " + xpath);
                xpath2 = xn["footerElement"].InnerText;
                Console.WriteLine("xpath2: "+ xpath2);
            }

            /*driver.Navigate().GoToUrl(urlTest);
            driver.Manage().Window.Maximize();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            Thread.Sleep(2000);

            var footer = driver.FindElement(By.XPath(xpath));
            string footerStr = footer.Text.ToString();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(footerStr);
            Console.WriteLine();
            Console.WriteLine();*/
            /*
            XmlTextReader readfile = new XmlTextReader("C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\LoginEB.xml");
            while (readfile.Read())
            {
                if ((readfile.NodeType == XmlNodeType.Element) && readfile.Name == "email")
                {
                    try
                    {
                        string email = readfile.GetAttribute("email");
                        Console.WriteLine(email);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("email not found");
                        Console.WriteLine(e.Message);

                    }

                  
                }
                if ((readfile.NodeType == XmlNodeType.Element) && readfile.Name == "password")
                {
                    string pass = readfile.GetAttribute("pass");
                    Console.WriteLine(pass);
                }

            }




            XmlTextReader readfile2 = new XmlTextReader("C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ChooseCountry.xml");
            while (readfile2.Read())
            {
                if ((readfile2.NodeType == XmlNodeType.Element) && readfile2.Name == "menuElement")
                {
                    string xpath = readfile2.GetAttribute("xpath");
                    Console.WriteLine(xpath);
                }
            

            
                if ((readfile2.NodeType == XmlNodeType.Element) && readfile2.Name == "country")
                {
                    string country = readfile2.GetAttribute("singapore");
                    Console.WriteLine(country);
                }
            }*/






        }
        

    }
}
