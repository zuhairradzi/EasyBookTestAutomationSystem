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
    class SiteName
    {
        string site;
        string test = "test";
        string live = "live";
        string bq = "bq";


        //-------------------------------XML FILE-------------------------------------------------------------------///
        string XMLfilePath =
"C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\siteName.xml";
        //---------------------------------------------------------------------------------------------------------///


        public string chooseEBSite(string testCaseID)
        {
            XmlTextReader reader = new XmlTextReader(XMLfilePath);
            if (testCaseID.ToLower().Contains(test)) 
            {
                
                while (reader.Read())
                {
                    
                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "test")
                    {
                       
                        //site = reader.GetAttribute("test");
                        reader.Read();
                        string value = reader.Value;
                        string site = value.Trim();
                        //Console.WriteLine("site : "+site);
                        return site;
                    }
                }
               
            }
            if (testCaseID.ToLower().Contains(live))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "live")
                    {
                        //site = reader.GetAttribute("test");
                        reader.Read();
                        string value = reader.Value;
                        string site = value.Trim();
                        //Console.WriteLine("site : "+site);
                        return site;
                    }
                }
            }
            if (testCaseID.ToLower().Contains(bq))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "backend")
                    {
                        //site = reader.GetAttribute("test");
                        reader.Read();
                        string value = reader.Value;
                        string site = value.Trim();
                        //Console.WriteLine("site : "+site);
                        return site;
                    }
                }
            }
            Console.WriteLine("Wrong site input.");
            return null;
        } 
    }
}
