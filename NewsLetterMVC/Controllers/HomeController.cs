using NewsLetterMVC.Models;
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
                using(NewsLetterEntities1 db=new NewsLetterEntities1())
                {
                    var signup = new SignUp();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;
                    
                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }

                return View("Success");
            }
        }

       
    }
}