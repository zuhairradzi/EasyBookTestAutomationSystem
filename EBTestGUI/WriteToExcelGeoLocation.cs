using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBTestGUI
{
    class WriteToExcelGeoLocation
    {
        public void ExcelWrite(string site, string country, string ipAddress, string server, string URL,
            string Flag, string Currency, string Language,  string finalResult)
        {
            string file = "D:\\Easybook Test System\\Geolocation Intellisense Test Result.xlsx";
            File.SetAttributes(file, File.GetAttributes(file) & ~FileAttributes.ReadOnly);

            int i = 0;
            string[] orderDetail = { site, country, ipAddress, server, URL, Flag, Currency, Language, finalResult };

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
                xlRange = (Microsoft.Office.Interop.Excel.Range)ExcelObj.Cells[WSheet.Rows.Count, 2];
                long lastRow = (long)xlRange.get_End(Microsoft.Office.Interop.Excel.XlDirection.xlUp).Row + 1;
                Console.WriteLine("Last row = " + lastRow);
                long newRow = lastRow;
                int newRow1 = Convert.ToInt32(newRow);
                Console.WriteLine("new row = " + newRow1);
                for (int col = 1; col < 10; col++)
                {
                    for (int row = newRow1; row < newRow1 + 1; row++)
                    {
                        WSheet.Cells[row, col + 1] = orderDetail[col - 1];
                    }

                }
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
