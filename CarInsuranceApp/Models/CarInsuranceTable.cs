//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarInsuranceApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarInsuranceTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> Date_of_birth { get; set; }
        public Nullable<System.DateTime> CarYear { get; set; }
        public Nullable<System.DateTime> CarModel { get; set; }
        public Nullable<System.DateTime> CarMake { get; set; }
    }
}
