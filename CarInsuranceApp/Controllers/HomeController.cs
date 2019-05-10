using CarInsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(CarInsuranceTable table)
        {
            if (string.IsNullOrEmpty(table.FirstName) || string.IsNullOrEmpty(table.LastName) || string.IsNullOrEmpty(table.EmailAddress) || string.IsNullOrEmpty(table.CarMake)||(table.CarModel)==null||table.CarYear==null||table.Date_of_birth==null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    var signup = new CarInsuranceTable();
                    
                    db.CarInsuranceTable.Add(table);
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