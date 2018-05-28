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
using System.Reflection;

namespace CheckBookingHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            string url, product, date, orderNo;

            Console.WriteLine("Enter site : ");
            string site = Console.ReadLine();

            Console.WriteLine("Enter server : ");
            string server = Console.ReadLine();

            Console.WriteLine("Enter product : ");
            product = Console.ReadLine();

            Console.WriteLine("Enter date : ");
            date = Console.ReadLine();

            Console.WriteLine("Enter orderNo : ");
            orderNo = Console.ReadLine();

            Console.WriteLine();

            String sqlString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Easybook KL\\Documents\\testlogin.mdf\";Integrated Security=True;Connect Timeout=30";
            String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\ETAS.xml";
            XmlDocument xml = new XmlDocument();
            IWebDriver Maindriver;

            Maindriver = new ChromeDriver();

            //-----GO TO SITE---//
            LaunchBrowser2 newSite = new LaunchBrowser2(xml, Maindriver);
            url = newSite.GoToURL(site);

            //-----CHECK SERVER---//
            CheckServer2 NewServer = new CheckServer2(xml, Maindriver);
            NewServer.ReadElement(XMLFilePath, site);
            NewServer.CheckServerConnection();


            
            if (server.ToLower().Contains("s1") || server.ToLower().Contains("s2"))
            {
                //-----SERVER CONNECTION---//
                ConnectToServer2 newServer = new ConnectToServer2(xml, Maindriver);
                newServer.ReadElement(XMLFilePath, server, site);
                newServer.LaunchBrowser(url);
                Maindriver = newServer.ConnectToServerWanted(url);
            }

            //-----LOGIN EB SITE---//
            LoginEB2 newLogin = new LoginEB2(xml, Maindriver);
            newLogin.ReadElement(XMLFilePath);
            newLogin.ReadDB(sqlString);
            newLogin.loginEB();

            //--CHECK BOOKING HISTORY--//
            ManageBooking newHistory = new ManageBooking(xml, Maindriver);
            newHistory.ReadElement(XMLFilePath, site, product);
            newHistory.searchBooking(date, orderNo);

        }
    }
}
