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
        //---------------------VARIABLES, XPATH, ID-------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        private IWebDriver driver;

        //----Server Elements--//
        string ElFooter = "//*[@id=\"footer\"]/div/div[5]/div/p";

        //---Server Variables--//
        string ServerWanted;
        string ServerNameWanted;
        string ServerBQwanted;
        string server_1 = "G3ASPRO01";
        string server_2 = "G3ASPRO02";
        string s1 = "s1";
        string s2 = "s2";


        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//


        //---------------------METHODS-------------------------------------------//
       
        
        public ServerConnection(IWebDriver maindriver)
        {
            this.driver = maindriver;
        }

      

        public void LaunchBrowser(string TestID, string EBurl)
        {
            try
            {
                OpenIntendedServer test1 = new OpenIntendedServer(driver);
                driver.Navigate().GoToUrl(EBurl);
                driver.Manage().Window.Maximize();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);

                var footer = driver.FindElement(By.XPath(ElFooter));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                Console.WriteLine();
                Console.WriteLine();

                if (TestID.ToLower().Contains(s1))
                {
                    ServerWanted = "S1";
                    ServerNameWanted = "G3ASPRO01";
                    ServerBQwanted = "01";

                    if (footerStr.Contains(ServerNameWanted))
                    {
                        Console.WriteLine("Current server is : "+ ServerNameWanted);
                        Console.WriteLine("Server "+ServerWanted+" found");
                        Console.WriteLine();
                        Console.WriteLine();


                    }

                    else if (!footerStr.Contains(ServerNameWanted))
                    {
                        Console.WriteLine("Current server is : G3ASPRO02");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();

                        test1.LaunchBrowser(EBurl);
                        test1.ConnectServer1(EBurl);
             
                    }

                }
                else if (TestID.ToLower().Contains(s2))
                {
                    ServerWanted = "S2";
                    ServerNameWanted = "G3ASPRO02";
                    ServerBQwanted = "02";

                    if (footerStr.Contains(ServerNameWanted))
                    {
 
                        Console.WriteLine("Current server is : " + ServerNameWanted);
                        Console.WriteLine("Server " + ServerWanted + " found");
                        Console.WriteLine();
                        Console.WriteLine();
 

                    }
                    else if (!footerStr.Contains(ServerNameWanted))
                    {
                   
                        Console.WriteLine("Current server is : G3ASPRO01");
                        Console.WriteLine("Server " + ServerWanted + " not found");
                        Console.WriteLine();
                        Console.WriteLine();
                        driver.Close();


                       
                        test1.LaunchBrowser(EBurl);
                        test1.ConnectServer2(EBurl);
                        Thread.Sleep(2000);
                  
                    }

                }

             
            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not foun111", e);

            }

        }

       

    }
   

   
}
