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

namespace SingleTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            IWebDriver driver = new ChromeDriver();
            string url = "https://test.easybook.com/en-my/payment/paymentresult?guid=TR2b42e6071f6f41da8e&source=PaypalEC_SGD&status=completed";
            driver.Navigate().GoToUrl(url);
            var cartID = driver.FindElement(By.XPath("//*[@id='print-content']/table/tbody/tr/td/table[1]/tbody/tr[2]/td[1]/text[2]"));
            string DivOne = cartID.Text.ToString();
            Console.WriteLine();
            Console.WriteLine("Div one = " + DivOne);
            Console.WriteLine();

        }
           
    }
}

