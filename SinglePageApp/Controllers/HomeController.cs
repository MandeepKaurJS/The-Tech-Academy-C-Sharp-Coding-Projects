using SinglePageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static SinglePageApp.Models.candidate;

namespace SinglePageApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentMvcWithKnockout()
        {
            Student student = new Student();
            student.Number = "B123456";
            student.Name = "Mandeep";
            student.Surname = "Kaur";
            return View(student);
        }
        public JsonResult GetStudents()
        {
            List<Student> StudentList = new List<Student>(){
                new Student() { Number = "A123456", Name = "Yusuf", Surname = "Karatoprak" },
                                      new Student() { Number = "B123456", Name = "Mahesh", Surname = "Chand" },
                                                                   new Student() { Number = "C123456", Name = "Ä°brahim", Surname = "Ersoy" },
                                                                        new Student() { Number = "D123456", Name = "Mike", Surname = "Gold" }};
            return Json(StudentList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Candidate()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Create(Candidate candidate)
        {
            //do the persistence logic here
            var message = "Candidate: " + candidate.FirstName + " Saved";
            return Json(message);
        }


    }
}
