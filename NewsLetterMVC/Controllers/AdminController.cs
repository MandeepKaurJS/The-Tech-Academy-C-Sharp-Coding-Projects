using NewsLetterMVC.Models;
using NewsLetterMVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewsLetterMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (NewsLetterEntities1 db = new NewsLetterEntities1())
            {
                var signups = db.SignUps;
                var signupvm = new List<SignUpVm>();
                foreach (var signup in signups)
                {
                    var signupVm = new SignUpVm();
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                }
                return View(signupvm);

            }
           
        }
    }
}