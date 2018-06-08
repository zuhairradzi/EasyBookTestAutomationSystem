using OpenQA.Selenium;
using System.Xml;

namespace EBTestGUI
{
    class ProductAndDest
    {
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        string prodURL, productURL1, productURL2;

        //---------------------METHODS-------------------------------------------//

        public IWebDriver driver;
        public XmlDocument xml;

        public ProductAndDest(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        public void ReadElement(string XMLpath, string prodName, string site, string currency)
        {
            string currenUpper = currency.ToUpper();
            string siteName = char.ToUpper(site[0]) + site.Substring(1);
            string productType = char.ToUpper(prodName[0]) + prodName.Substring(1);
            xml.Load(XMLpath);
            XmlNodeList xnList = xml.SelectNodes("/ETAS/Product/ProductName");
            foreach (XmlNode xnode in xnList)
            {
                productURL1 = xnode[productType][siteName][currenUpper]["URL1"].InnerText.Trim();
                productURL2 = xnode[productType][siteName][currenUpper]["URL2"].InnerText.Trim();
            }

        }
        public void chooseProduct(string product, string EBurl)
        {
            
            string prod = product.ToLower();
            if (prod == "car")
            {
                prodURL = EBurl + "/" + prod + "/booking/" + productURL1 + "area";
                driver.Navigate().GoToUrl(prodURL);
            }
            else if (prod == "bus"|| prod == "ferry" || prod == "train")
            {
                prodURL = EBurl + "/" + prod + "/booking/" + productURL1 + "-to-" + productURL2;
                driver.Navigate().GoToUrl(prodURL);
            }
            //prodURL = EBurl +"/"+ prod+ "/booking/"+ productURL1;
            //driver.Navigate().GoToUrl(prodURL);
        }

    }
}
