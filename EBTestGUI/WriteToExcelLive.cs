using System;
using System.IO;
using System.Reflection;

namespace EBTestGUI
{
    class WriteToExcelLive
    {
        public void ExcelWrite(string productType, string orderNo, string CartID, string tripDetail, string PurchaseDate,
           string tripDuration, string passengerName, string Company, string serverUsed, string platformUsed, string timeTaken)
        {
            string file = "D:\\Easybook Test System\\Product Purchase Log Live.xlsx";
            File.SetAttributes(file, File.GetAttributes(file) & ~FileAttributes.ReadOnly);

            int i = 0;
            string[] orderDetail = { productType, orderNo, CartID, "", tripDetail, PurchaseDate, tripDuration, passengerName, Company, "", "", "", "", serverUsed, platformUsed, timeTaken };

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
                for (int col = 1; col < 17; col++)
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
