using CarInsuranceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: SignUp
        public ActionResult Index(CarInsuranceTable table)
        {
            if (string.IsNullOrEmpty(table.FirstName) || string.IsNullOrEmpty(table.LastName) || string.IsNullOrEmpty(table.EmailAddress) || string.IsNullOrEmpty(table.CarMake) || (table.CarModel) == null || table.CarYear == null || table.Date_of_birth == null)
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

                return View(table);
            }
        }
    }
}