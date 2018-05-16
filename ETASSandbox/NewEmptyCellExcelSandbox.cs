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
using Microsoft.Office.Interop.Excel;

namespace ETASSandbox
{
    class NewEmptyCellExcelSandbox
    {
        public void ExcelWrite()
        {
            Console.WriteLine("Hello");
            string file = "D:\\Product Purchase Log Sandbox2.xlsx";
            File.SetAttributes(file, File.GetAttributes(file) & ~FileAttributes.ReadOnly);

            int i = 0;
            string[] orderDetail = {"1", "2", "3", "4", "5", "6", "7", "8", };

            Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet WSheet;
            Microsoft.Office.Interop.Excel.Range xlRange;


            try
            {
                //Start Excel and get Application object.

                object oMissing = Missing.Value;
                ExcelObj.Visible = true;
                Console.WriteLine(i);
                i++;
                if (!File.Exists(file))
                {
                    Console.WriteLine("File do not exist");
                }
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
                xlWorkbook = ExcelObj.Workbooks.Open(file);

                // open the existing sheet

                WSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelObj.Sheets.get_Item(1);



                xlRange = (Microsoft.Office.Interop.Excel.Range)ExcelObj.Cells[WSheet.Rows.Count, 1];
                long lastRow = (long)xlRange.get_End(Microsoft.Office.Interop.Excel.XlDirection.xlUp).Row + 1;
                Console.WriteLine("Last row = " + lastRow);
                long newRow = lastRow;
                int newRow1 = Convert.ToInt32(newRow);
                Console.WriteLine("new row = " +  newRow1);
                /*var _with1 = WSheet;
                _with1.get_Range("A" + lastRow).Value = orderDetail[0];
                _with1.get_Range("B" + lastRow).Value = orderDetail[1];
                _with1.get_Range("C" + lastRow).Value = orderDetail[2];
                _with1.get_Range("D" + lastRow).Value = orderDetail[3];
                _with1.get_Range("E" + lastRow).Value = orderDetail[4];
                _with1.get_Range("F" + lastRow).Value = orderDetail[5];
                _with1.get_Range("G" + lastRow).Value = orderDetail[6];*/
                //string test = WSheet.Cells[1, 3].Value.ToString();
                // Console.WriteLine("No : " + test);


                var cell = (Microsoft.Office.Interop.Excel.Range)WSheet.Cells[1, 3];
                string cell2 = cell.ToString();
                Console.WriteLine("cell value = "+cell.Value2);

                int count = 1;
                for (int col = 1; col < 12; col++)
                {
                    for (int row = newRow1; row < newRow1 + 1; row++)
                    {
                        Console.WriteLine("row = " + row + " -- col = "+col);
                        Console.WriteLine(orderDetail[col-1]);
                        //WSheet.Cells[row, 1] = "count = "+count;
                        WSheet.Cells[row, col+1] = orderDetail[col - 1];
                     
                    }
                    
                }
                count++;
                xlWorkbook.Save();
                //xlWorkbook.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Excel cannot open", e);

            }
            
        }
    }
}
