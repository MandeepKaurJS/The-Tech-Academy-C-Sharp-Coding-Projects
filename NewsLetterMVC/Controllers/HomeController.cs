using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string firstName,string lastName,string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                string _connectionString = @"Data Source=DESKTOP-LDP0GC0\SQLEXPRESS;
                                            Initial Catalog=NewsLetter;Integrated Security=True;Connect Timeout=30;
                                            Encrypt=False;TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                string queryString = @"Insert into SignUps (FirstName,LastName,EmailAddress)values
                                    (@FirstName,@LastName,@EmailAddress)";
                using(SqlConnection connection=new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    command.Parameters.Add("@LastName", SqlDbType.VarChar);
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    command.Parameters["@FirstName"].Value = firstName;
                    command.Parameters["@LastName"].Value = lastName;
                    command.Parameters["@EmailAddress"].Value = emailAddress;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return View("Success");
            }
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