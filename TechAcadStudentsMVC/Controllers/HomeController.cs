using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechAcadStudentsMVC.Models;

namespace TechAcadStudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page-The Tech Acedemy.";

            return View();
        }
        public ActionResult Instructors()
        {
            return View();
        }
        public ActionResult Instructors(int id)
        {
            ViewBag.Id = id;
            List<Instructor> instructor = new List<Instructor> {
               new Instructor { id = 1,
                FirstName="Mandeep",
                LastName="Kaur" },
               new Instructor { id = 2,
                FirstName="Varinder",
                LastName="Singh" },
               new Instructor { id = 3,
                FirstName="Navpreet",
                LastName="Kaur" },
        };

            return View(instructor);
        }
       
    }
}