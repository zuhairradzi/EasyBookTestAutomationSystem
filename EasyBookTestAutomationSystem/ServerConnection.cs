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

namespace EasyBookTestAutomationSystem
{
    class ServerConnection
    {
        string ServerWanted;
        string ServerNameWanted;
        string server_1 = "G3ASPRO01";
        string server_2 = "G3ASPRO02";
        private IWebDriver driver;
        
        public ServerConnection(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

      

        public void LaunchBrowser(string TestID, string EBurl)
        {
            try
            {
                OpenIntendedServer test1 = new OpenIntendedServer(driver);
                //Console.WriteLine("4.0.1");
                driver.Navigate().GoToUrl(EBurl);
                driver.Manage().Window.Maximize();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);

                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                // string server = footerStr.Substring(142, 10);
                //string serverName = server.Trim();
                Console.WriteLine();
                Console.WriteLine();
                if (TestID.ToLower().Contains("s1"))
                {
                    //Console.WriteLine("4.0.1.a");
                    ServerWanted = "S1";
                    ServerNameWanted = "G3ASPRO01";

                    if (footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.a.1");
                        Console.WriteLine("Current server is : "+ ServerNameWanted);
                        Console.WriteLine("Server "+ServerWanted+" found");
                        Console.WriteLine();
                        Console.WriteLine();
                        //Console.WriteLine("3.4.1");


                    }

                    else if (!footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.a.2");
                        Console.WriteLine("Current server is : G3ASPRO02");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();

                        test1.LaunchBrowser(EBurl);
                        test1.ConnectServer1(EBurl);
                        //Console.WriteLine("3.4.2");
                    }

                }
                else if (TestID.ToLower().Contains("s2"))
                {
                    //Console.WriteLine("4.0.1.b");
                    ServerWanted = "S2";
                    ServerNameWanted = "G3ASPRO02";

                    if (footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.b.1");
                        Console.WriteLine("Current server is : " + ServerNameWanted);
                        Console.WriteLine("Server " + ServerWanted + " found");
                        Console.WriteLine();
                        Console.WriteLine();
                       // Console.WriteLine("3.4.3");
                    }
                    else if (!footerStr.Contains(ServerNameWanted))
                    {
                        //Console.WriteLine("4.0.1.b.2");
                        Console.WriteLine("Current server is : G3ASPRO01");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();


                       
                        test1.LaunchBrowser(EBurl);
                        test1.ConnectServer2(EBurl);
                        Thread.Sleep(2000);
                        //Console.WriteLine("3.4.4");
                    }

                }

             
            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not foundddd", e);

            }

        }

       

    }
   

   
}
