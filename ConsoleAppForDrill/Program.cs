
using Syncfusion.XlsIO;
using System.IO;
using System.Reflection;
//using _Excel = Microsoft.Office.interop.Excel;
namespace ConsoleAppForDrill
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                //Set the default application version as Excel 2016
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2016;

                //Open existing workbook with data entered
                Assembly assembly = typeof(Program).GetTypeInfo().Assembly;
                Stream fileStream = assembly.GetManifestResourceStream("name.Sample.xls");
                IWorkbook workbook = application.Workbooks.Open(fileStream);

                //Access first worksheet from the workbook instance
                IWorksheet worksheet = workbook.Worksheets[0];

                //Insert sample text into cell “A1”
                worksheet.Range["A1"].Text = "Syncfusion Essential XlsIO";

                //Save the workbook to disk in xlsx format
                workbook.SaveAs("Output.xlsx");
            }

            //string fileName, Sampletext;
            //Console.Write("Enter File Name :");
            //fileName = Console.ReadLine();
            //Console.Write("Enter text :");
            //Sampletext = Console.ReadLine();
            //   //Create excel app object
            //Microsoft.Office.Interop.Excel.Application xlSamp = new Microsoft.Office.Interop.Excel.Application();
            //   if (xlSamp == null)
            //   {
            //       Console.WriteLine("Excel is not Insatalled");
            //       Console.ReadKey();
            //       return;
            //   }
            //   //Create a new excel book and sheet
            //   Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //   Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //   object misValue = System.Reflection.Missing.Value;
            //   //Then add a sample text into first cell
            //   xlWorkBook = xlSamp.Workbooks.Add(misValue);
            //   xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //   xlWorkSheet.Cells[1, 1] = Sampletext;
            //   string location = @"C:\Users\VrinMan Dulay\Documents\" + fileName + ".xls";
            //   xlWorkBook.SaveAs(location, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //   xlWorkBook.Close(true, misValue, misValue);
            //   xlSamp.Quit();
            //   try
            //   {
            //       System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSamp);
            //       xlSamp = null;
            //   }
            //   catch (Exception ex)
            //   {
            //       xlSamp = null;
            //       Console.Write("Error " + ex.ToString());
            //   }
            //   finally
            //   {
            //       GC.Collect();
            //   }
        }
    }

}

