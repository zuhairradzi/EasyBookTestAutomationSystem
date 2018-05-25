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
    class EditXML
    {
        public XmlDocument xml;

        public EditXML(XmlDocument xml)
        {
            this.xml = xml;
        }
        public void writeToXML(string XMLFilePath)
        {
            Console.WriteLine("Enter new value");
            string input = Console.ReadLine();
            string h1, h11, h12;
            xml.Load(XMLFilePath);
            XmlNodeList xnMenu = xml.SelectNodes("/Header");
            foreach (XmlNode xnode in xnMenu)
            {
                xnode["H2"].InnerText = input;
            }
            foreach (XmlNode xnode in xnMenu)
            {
                h12 = xnode["H2"].InnerText.Trim();
                Console.WriteLine("h12: " + h12);
            }
            xml.Save(XMLFilePath);
        }
    }
}
