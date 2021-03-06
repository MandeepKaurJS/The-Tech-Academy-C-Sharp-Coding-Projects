﻿using CarInsurancePassTest.Models;
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
        //public ActionResult SignUp(CarInsuranceTable table)
        //{
        //    if (string.IsNullOrEmpty(table.FirstName) || string.IsNullOrEmpty(table.LastName) || string.IsNullOrEmpty(table.EmailAddress))
        //    {
        //        return View("~/Views/Shared/Error.cshtml");
        //    }
        //    else
        //    {
        //        using (CarInsuranceEntities db = new CarInsuranceEntities())
        //        {
        //            //var signup = new CarInsuranceTable();
        //            db.CarInsuranceTables.Add(table);
        //            db.SaveChanges();

        //        }

        //        return View("Success");
        //    }
   // }

    public ActionResult SignUp(string firstName, string lastName, string emailAddress, DateTime dateofbirth, DateTime carYear, string carmodel, string carmake, string DUI,string fullCoverage,string tickets)
    {
        //if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(carmodel) || string.IsNullOrEmpty(carmake))
        //{
        //    return View("~/Views/Shared/Error.cshtml");
        //}
        //else
        //{
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                CarInsuranceTable signup = new CarInsuranceTable();

                signup.FirstName = firstName;
                signup.LastName = lastName;
                signup.EmailAddress = emailAddress;
                signup.Date_of_birth = dateofbirth;
                signup.CarYear = carYear;
                signup.CarModel = carmodel;
                signup.CarMake = carmake;
                    signup.DUI = DUI;
                    signup.Tickets = tickets;
                    signup.FullCoverage = fullCoverage;
                db.CarInsuranceTables.Add(signup);
                db.SaveChanges();
            }

            return View("Success");
        //}
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