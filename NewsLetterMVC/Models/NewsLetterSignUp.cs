using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsLetterMVC.Models
{
    public class NewsLetterSignUp
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}