using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Xml;

namespace EBTestGUI
{
    class IndexInputCallXML
    {
        string strkey;
        int key;
        public int ReadElement(string XMLpath, string prodID, string siteID, string currencyID)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/Index");
            foreach (XmlNode xnode in xnMenu)
            {
                strkey = xnode[prodID][siteID][currencyID].InnerText.Trim();
                key = Convert.ToInt32(strkey);
            }
            return key;
        }
        
    }
}
