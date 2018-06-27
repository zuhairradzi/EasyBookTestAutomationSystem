using System;
using OpenQA.Selenium;
using System.Xml;
using System.Threading;
using System.Windows.Forms;

namespace EBTestGUI
{
    class GeoLocContent
    {
        public IWebDriver driver;
        public XmlDocument xml;

        public GeoLocContent(XmlDocument mainxml, IWebDriver maindriver)
        {
            this.xml = mainxml;
            this.driver = maindriver;
        }

        string currency, curSel, CurID, flag, url, originPlace, OrPlaceId, firstPlace, language, langID, languageSel, scrollUp, scrollToTopJS;
        string bannerXPath;
        string urlWanted, currencyWanted, flagWanted, languageWanted;
        string urlResult, currencyResult, flagResult, flagName, languageResult;
        string country;

        public void ReadElement(string XMLpath, string site, string countryWanted)
        {
            string siteType = char.ToUpper(site[0]) + site.Substring(1);
            country = countryWanted;
            xml.Load(XMLpath);
            XmlNodeList xnMenu = xml.SelectNodes("/ETAS/GeoIntel");
            foreach (XmlNode xnode in xnMenu)
            {
                language = xnode["Geolocation"]["Language"]["XPath"].InnerText.Trim();
                langID = xnode["Geolocation"]["Language"]["Id"].InnerText.Trim();
                languageSel = xnode["Geolocation"]["Language"]["Selected"].InnerText.Trim();
                currency = xnode["Geolocation"]["Currency"]["XPath"].InnerText.Trim();
                CurID = xnode["Geolocation"]["Currency"]["Id"].InnerText.Trim();
                curSel = xnode["Geolocation"]["Currency"]["Text"].InnerText.Trim();
                flag = xnode["Geolocation"]["Flag"]["XPath"].InnerText.Trim();
                originPlace = xnode["Intellisense"]["Origin"]["XPath"].InnerText.Trim();
                OrPlaceId = xnode["Intellisense"]["Origin"]["Id"].InnerText.Trim();
                firstPlace = xnode["Intellisense"]["FirstPlace"]["XPath"].InnerText.Trim();
                scrollUp = xnode["TopPage"].InnerText.Trim();
                bannerXPath = xnode["Banner"].InnerText.Trim();

                urlWanted = xnode["CheckList"][country][siteType]["Content"]["URL"].InnerText.Trim();
                currencyWanted = xnode["CheckList"][country][siteType]["Content"]["Currency"].InnerText.Trim();
                flagWanted = xnode["CheckList"][country][siteType]["Content"]["Flag"].InnerText.Trim();
                languageWanted = xnode["CheckList"][country][siteType]["Content"]["Language"].InnerText.Trim();
            }
            XmlNodeList xnMenu1 = xml.SelectNodes("/ETAS/EBLogin/LoginElement");
            foreach (XmlNode xnode in xnMenu1)
            {
                scrollToTopJS = xnode["JSactions"]["ScrolltoTop"]["Action"].InnerText.Trim();
            }
        }
        public string findFlag()
        {
            try
            {
                driver.FindElement(By.XPath(flag)).Click();
                var element = driver.FindElement(By.XPath(flag));
                string imageSrc = element.GetAttribute("src");
                Console.WriteLine("Flag : " + imageSrc);
                Console.WriteLine();
                
                if (imageSrc.Trim().ToLower() == flagWanted.ToLower())
                {
                    flagResult = "Passed";
                    flagName = country;
                    return flagName;
                }
                else
                {
                    flagResult = "Failed";
                    return flagResult;
                }
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #GLC01 : Flag element not found!");
                Console.WriteLine("Flag not found");
                return null;
            }
          
        }

        public string findURL()
        {
            try
            {
                url = driver.Url;
                Console.WriteLine();
                Console.WriteLine("URL is : "+url);
                if (url.Trim().ToLower() == urlWanted.ToLower())
                {
                    urlResult = "Passed";
                    return url;
                }
                else
                {
                    urlResult = "Failed";
                    return urlResult;
                }
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #GLC02 : URL element not found!");
                Console.WriteLine("URL not found");
                return null;
            }

        }
        public string findCurrency()
        {
            try
            {
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollToTopJS);
                var banner = driver.FindElement(By.XPath(bannerXPath));
                string bannerStr = banner.Text.ToString();

                if (bannerStr.Trim().ToLower().Contains(currencyWanted.ToLower()))
                {
                    currencyResult = "Passed";
                    Console.WriteLine("Currency : " + currencyWanted);
                    return currencyWanted;
                }
                else
                {
                    currencyResult = "Failed";
                    return currencyResult;
                }
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #GLC03 : Currency element not found!");
                Console.WriteLine("Currency not found");
                return null;
            }
        
        }
        public string findLanguage()
        {
            try
            {

                driver.FindElement(By.XPath(language)).Click();
                var langDef = driver.FindElement(By.XPath(languageSel));
                string langStr = langDef.Text.ToString();
                if (langStr.Trim().ToLower()==languageWanted.Trim().ToLower())
                {
                    languageResult = "Passed";
                    Console.WriteLine("Language : " + langStr);
                    return langStr;
                }
                else
                {
                    languageResult = "Failed";
                    return languageResult;
                }
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #GLC04 : Language element not found!");
                Console.WriteLine("Language not found");
                return null;
            }
        }

        public string CheckResult()
        {
            if (urlResult== "Passed" && currencyResult == "Passed" && flagResult == "Passed" && languageResult == "Passed")
            {
                return "Passed";
            }
            else
            {
                return "Failed";
            }
        }

        public void findLocation()
        {
            try
            {
                
                /* IWebElement elem = driver.FindElement(By.Id(OrPlaceId));

                 SelectElement selectList = new SelectElement(elem);
                 IList<IWebElement> options = selectList.Options;
                 IWebElement firstOption = options[0];
                 string defPlace = firstOption.ToString();
                 Console.WriteLine("defPlace : "+ defPlace);*/

                driver.FindElement(By.Id("txtSearchOrigin_Bus")).Click();
                Console.WriteLine("1");
                Thread.Sleep(2000);
               // driver.FindElement(By.XPath("//*[@id='originBasicMode_Bus']/div/span/div/div/div[1]/div")).Click();
                driver.FindElement(By.XPath("//div[@id='originBasicMode_Bus']/div/span/div/div/div/div/span")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("txtSearchOrigin_Bus")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='originBasicMode_Bus']/div/span/div/div/div[1]/div/span[1]/strong")).Click();
                var place = driver.FindElement(By.XPath("//*[@id='originBasicMode_Bus']/div/span/div/div/div[1]/div/span[1]"));
                Thread.Sleep(1000);
                //*[@id="originBasicMode_Bus"]/div/span/div/div/div[1]/div/span[1]/strong
                //*[@id="originBasicMode_Bus"]/div/span/div/div/div[1]/div/span[1]
                //*[@id="txtSearchOrigin_Bus"]
                string firstPlaceStr = place.Text.ToString();
                Console.WriteLine("firstPlaceStr : " + firstPlaceStr);
                Thread.Sleep(2000);
                Console.WriteLine("2");
                //driver.FindElement(By.Id("txtSearchOrigin_Bus")).Click();
                Console.WriteLine("3");
                //var place = driver.FindElement(By.XPath("//div[@id='originBasicMode_Bus']/div/span/div/div/div/div/span"));
                //string firstPlaceStr = place.Text.ToString();
                
                Console.WriteLine();
                /* SelectElement oSelect = new SelectElement(driver.FindElement(By.Id(OrPlaceId)));
                 IList<IWebElement> elementCount = oSelect.Options;

                 int iSize = elementCount.Count;

                 for (int i = 0; i > iSize; i++)
                 {
                     String sValue = elementCount.ElementAt(i).Text;
                     Console.WriteLine(sValue);
                 }

              /*    driver.FindElement(By.XPath(originPlace)).Click();
                 driver.FindElement(By.XPath(firstPlace)).Click();
                 var firstPlaceDef = driver.FindElement(By.XPath(firstPlace));
                 string firstPlaceStr = firstPlaceDef.Text.ToString();
                 Console.WriteLine("firstPlaceStr : " + firstPlaceStr);
                 Console.WriteLine();
                 //MessageBox.Show("firstPlaceStr : " + firstPlaceStr);*/
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error #GLC05 : Location element not found!");
                Console.WriteLine("location not found");
            }
        }
    }
}
