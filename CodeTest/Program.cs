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

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\Test.xml";
            XmlDocument xml = new XmlDocument();

            EditXML edit = new EditXML(xml);
            edit.writeToXML(XMLFilePath);

          
        }
    }
}
