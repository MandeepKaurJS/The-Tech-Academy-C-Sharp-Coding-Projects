using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

using ExportExcelFileInASP.NET.Models;

namespace ExportExcelFileInASP.NET.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile==null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please select Excel file<br>";
                return View("Index");
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                    //Read data from excel file
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range rang = worksheet.UsedRange;
                    List<Product> listproduct = new List<Product>();
                    for (int row = 3; row < rang.Rows.Count; row++)
                    {
                        Product p = new Product();
                        p.id = ((Excel.Range)rang.Cells[row, 1]).Text;
                        p.FirstName = ((Excel.Range)rang.Cells[row, 2]).Text;
                        p.LastName = ((Excel.Range)rang.Cells[row, 3]).Text;
                        listproduct.Add(p);
                    }
                    ViewBag.ListProducts = listproduct;
                    return View("Success");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect<br>";
                    return View("Index");
                }
                return View();
            }
            
        }
    }
}