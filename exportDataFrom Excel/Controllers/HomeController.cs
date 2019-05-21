using exportDataFrom_Excel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exportDataFrom_Excel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ImportExcel()
        {
            ImportExcel importExcel = new ImportExcel();
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("./Documents/" + importExcel.file.FileName);
                importExcel.file.SaveAs(path);

                string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                OleDbConnection excelconnection = new OleDbConnection(excelConnectionString);

                //Sheet Name
                excelconnection.Open();
                string tableName =excelconnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                excelconnection.Close();
                //End

                OleDbCommand cmd = new OleDbCommand("Select * from [" + tableName + "]", excelconnection );

                excelconnection.Open();

                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);

                //Give your Destination table name
                sqlBulk.DestinationTableName = "Students";

                //Mappings
                sqlBulk.ColumnMappings.Add("FirstName", "FirstName");
                sqlBulk.ColumnMappings.Add("LastName", "LastName");
                

                sqlBulk.WriteToServer(dReader);
                excelconnection.Close();

                ViewBag.Result = "Successfully Imported";
            }
            return View(importExcel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}