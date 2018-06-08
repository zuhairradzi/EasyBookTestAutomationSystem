using OpenQA.Selenium;
using System.Xml;

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
