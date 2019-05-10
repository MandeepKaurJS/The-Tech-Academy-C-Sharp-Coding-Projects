using CarInsurancePassTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurancePassTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    var signup = new CarInsuranceTable();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.CarInsuranceTables.Add(signup);
                    db.SaveChanges();
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