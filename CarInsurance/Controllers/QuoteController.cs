using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
       public int DateOfBirth { get; set; }
        public int age { get { return DateTime.Now.Year - DateOfBirth; } }
    }

}