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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String XMLFilePath = "C:\\Users\\Easybook KL\\Documents\\Visual Studio 2015\\Projects\\EasyBookTestAutomationSystem\\XML files\\Test.xml";
            XmlDocument xml = new XmlDocument();

            String sqlString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Easybook KL\\Documents\\testlogin.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection();

            //ReadFromSQL read = new ReadFromSQL(conn);
            //read.getValue(sqlString);

            /*MD5Encryption hash = new MD5Encryption();
            Console.WriteLine(hash.CalculateMD5Hash("mohdzuhair"));
            Console.WriteLine();
            Console.WriteLine(hash.CalculateMD5Hash("123456"));
            
            try
            {
                string FileName = "";

                Console.WriteLine("Encrypt " + FileName);

                // Encrypt the file.
                hash.AddEncryption(FileName);

                Console.WriteLine("Decrypt " + FileName);

                // Decrypt the file.
                hash.RemoveEncryption(FileName);

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();

            Console.WriteLine(hash.SHA1Hash("mohdzuhair@easybook.com"));
             Console.WriteLine();
             Console.WriteLine(hash.SHA1Hash("123456"));*/

            EditXML edit = new EditXML(xml);
            edit.writeToXML(XMLFilePath);


        }
    }
}
