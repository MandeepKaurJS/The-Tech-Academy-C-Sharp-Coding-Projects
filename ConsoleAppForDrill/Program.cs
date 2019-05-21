using System;
using System.IO;
using Microsoft.Office.Interop.Excel;
namespace ConsoleAppForDrill
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Create an instance of ExcelEngine
            //using (ExcelEngine excelEngine = new ExcelEngine())
            //{
            //    IApplication application = excelEngine.Excel;
            //    //Set the default application version as Excel 2016
            //    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2016;

            //    //Open existing workbook with data entered
            //    Assembly assembly = typeof(Program).GetTypeInfo().Assembly;
            //    Stream fileStream = assembly.GetManifestResourceStream("name.xlsx");
            //    IWorkbook workbook = application.Workbooks.Open(fileStream);

            //    //Access first worksheet from the workbook instance
            //    IWorksheet worksheet = workbook.Worksheets[0];

            //    //Insert sample text into cell “A1”
            //    worksheet.Range["A1"].Text = "Syncfusion Essential XlsIO";

            //    //Save the workbook to disk in xlsx format
            //    workbook.SaveAs("Output.xlsx");
            //}

            string filename, sampletext;
            Console.Write("enter file name :");
            filename = Console.ReadLine();
            Console.Write("enter text :");
            sampletext =Console.ReadLine();
            //create excel app object
            Microsoft.Office.Interop.Excel.Application xlsamp = new Microsoft.Office.Interop.Excel.Application();
            if(xlsamp == null)
               {
                Console.WriteLine("excel is not insatalled");
                Console.ReadKey();
                return;
            }
            //create a new excel book and sheet
            Microsoft.Office.Interop.Excel.Workbook xlworkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlworksheet;
            object misvalue = System.Reflection.Missing.Value;
            //then add a sample text into first cell
            xlworkbook = xlsamp.Workbooks.Add(misvalue);
            xlworksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlworkbook.Worksheets.get_Item(1);
            xlworksheet.Cells[1, 1] = sampletext;
            string location = @"c:\users\vrinman dulay\documents\" + filename + ".xls";
            xlworkbook.SaveAs(location, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misvalue, misvalue, misvalue, misvalue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misvalue, misvalue, misvalue, misvalue, misvalue);
            xlworkbook.Close(true, misvalue, misvalue);
            xlsamp.Quit();
            try
               {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsamp);
                xlsamp = null;
            }
            catch(Exception ex)
               {
                xlsamp = null;
                Console.Write("error " + ex.ToString());
            }
            finally
               {
                GC.Collect();
            }
        }
    }

}

