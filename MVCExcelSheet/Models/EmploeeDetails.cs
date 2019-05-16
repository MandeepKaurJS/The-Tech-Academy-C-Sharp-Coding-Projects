using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCExcelSheet.Models
{
    public class EmploeeDetails
    {
        [Key]
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
     
    }
}