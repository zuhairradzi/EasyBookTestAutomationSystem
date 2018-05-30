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
using System.Windows.Forms;

namespace Menu
{
    public partial class Form1 : Form
    {
        string testXP, xpathNew;
        List<Panel> newList = new List<Panel>();


        String sqlString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Easybook KL\\Documents\\testlogin.mdf\";Integrated Security=True;Connect Timeout=30";
        String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\Test.xml";
        XmlDocument xml = new XmlDocument();


        public Form1()
        {
            InitializeComponent();
            //XpathTextBox.Text = testXP.ToString();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            newList.Add(panelDisplayXML);
            newList.Add(panelEditXML);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            newList[1].BringToFront();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            xpathNew = XMLEditTextbox.Text;
            XpathLabel.Text = xpathNew;
            newList[0].BringToFront();
            xml.Load(XMLFilePath);
            XmlNodeList xnMenu = xml.SelectNodes("/Header");
            foreach (XmlNode xnode in xnMenu)
            {
                xnode["H2"].InnerText = XpathLabel.Text;
            }
            xml.Save(XMLFilePath);
            // XpathLabel.Text = xpathNew;
        }

       

        private void XMLDocTab_Click(object sender, EventArgs e)
        {
            xml.Load(XMLFilePath);
            XmlNodeList xnMenu = xml.SelectNodes("/Header");
            foreach (XmlNode xnode in xnMenu)
            {
                testXP = xnode["H2"].InnerText.Trim();
            }
            XpathLabel.Text = testXP.ToString();
        }

       
       
    }
}
