using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private string _connectionString = @"Data Source=DESKTOP-LDP0GC0\SQLEXPRESS;
                                            Initial Catalog=School;Integrated Security=True;
                                            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False";
        // GET: Student
        public ActionResult Index()
        {
            string queryString = "Select * From Students";
            List<Students> students = new List<Students>();
            using (SqlConnection connection = new SqlConnection( _connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Students student = new Students();
                    student.id = Convert.ToInt32(reader["id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    students.Add(student);
                }
                connection.Close();
            }
                return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Students students)
        {
            string queryString=@"Insert into Students(FirstName,LastName)values
                                (@FirstName,@LastName)";
            using (SqlConnection connection=new SqlConnection( _connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters["@FirstName"].Value = students.FirstName;
                command.Parameters["@LastName"].Value = students.LastName;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}