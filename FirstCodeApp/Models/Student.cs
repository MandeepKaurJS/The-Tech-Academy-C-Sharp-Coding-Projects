using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstCodeApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public Gender Gender { get; set; }
        public int Flag { get; set; }
    }
    public enum Gender
    {
        Male, Female, Other
    }
}