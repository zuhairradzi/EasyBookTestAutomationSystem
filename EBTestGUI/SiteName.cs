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

namespace EBTestGUI
{
    class SiteName
    {
        string site;
        public IWebDriver driver;
        public XmlDocument xml;

        public SiteName(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public string ReadElement(string XMLpath, string siteType)
        {
            string siteName = siteType;// char.ToUpper(siteType[0]) + siteType.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Site");
            foreach (XmlNode xnode in xnMenu)
            {
                site = xnode["URL"][siteName].InnerText.Trim();
                return site;
            }
            return null;
        }
    }
}
