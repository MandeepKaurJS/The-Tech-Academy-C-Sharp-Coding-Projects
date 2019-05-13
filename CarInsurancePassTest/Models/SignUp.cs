using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date_of_birth { get; set; }
        public Nullable<System.DateTime> CarYear { get; set; }
        public string CarModel { get; set; }
        public string CarMake { get; set; }
    }
}