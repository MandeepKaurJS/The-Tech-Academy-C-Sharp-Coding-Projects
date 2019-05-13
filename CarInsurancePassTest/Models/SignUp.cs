using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsurancePassTest.Models
{
    public class SignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> Date_of_birth { get; set; }
        public Nullable<System.DateTime> CarYear { get; set; }
        public string CarModel { get; set; }
        public string CarMake { get; set; }
    }
}