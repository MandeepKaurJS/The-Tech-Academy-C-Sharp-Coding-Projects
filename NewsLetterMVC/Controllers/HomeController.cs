using NewsLetterMVC.Models;
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
        private readonly string _connectionString = @"Data Source=DESKTOP-LDP0GC0\SQLEXPRESS;
                                            Initial Catalog=NewsLetter;Integrated Security=True;Connect Timeout=30;
                                            Encrypt=False;TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


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

        public ActionResult Admin()
        {
            string querystrin = "Select Id,FirstName,LastName,EmailAddress from SignUps";
            List<NewsLetterSignUp> signups = new List<NewsLetterSignUp>();
            using(SqlConnection connection=new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(querystrin, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var signup = new NewsLetterSignUp();
                    signup.id = Convert.ToInt32(reader["Id"]);
                    signup.FirstName = reader["FirstName"].ToString();
                    signup.LastName = reader["LastName"].ToString();
                    signup.EmailAddress = reader["EmailAddress"].ToString();
                    signups.Add(signup);
                }
            }
            return View(signups);
        }
    }
}