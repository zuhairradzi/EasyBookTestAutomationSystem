using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Xml;
using System.Windows.Forms;

namespace EBTestGUI
{
    class TripType
    {
        string trip;
        public IWebDriver driver;
        public XmlDocument xml;

        public TripType(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void ReadElement(string XMLpath, string tripType)
        {
            
            string TripTy = char.ToUpper(tripType[0]) + tripType.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/TripType");
            foreach (XmlNode xnode in xnMenu)
            {
                trip = xnode[TripTy]["Id"].InnerText.Trim();
            }
        }

        public void chooseTripType(string product)
        {
            if (product.ToLower().Contains("car"))
            {
                return;
            }
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id(trip)))).Click();
            }
            catch (Exception)
            {
                MessageBox.Show("Error #TTY01: One way button not found");
                Console.WriteLine("One way button not found");
            }
        }
    }
}
