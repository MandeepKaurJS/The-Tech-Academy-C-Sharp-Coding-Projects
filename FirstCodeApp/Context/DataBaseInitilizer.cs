using FirstCodeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstCodeApp.Context
{
    public class DataBaseInitilizer:DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            var Students = new List<Student>()
            {
                new Student {Name="Mandeep",DoB=DateTime.Parse("1992-06-21"),Gender=Gender.Female,Flag=1},
                new Student {Name="Varinder",DoB=DateTime.Parse("1992-02-06"),Gender=Gender.Male,Flag=0},
                new Student {Name="JAskaran",DoB=DateTime.Parse("1993-09-05"),Gender=Gender.Male,Flag=1},
                new Student {Name="Navpreet",DoB=DateTime.Parse("1992-10-22"),Gender=Gender.Female,Flag=1},
            };
            Students.ForEach(x => context.Students.Add(x));
            context.SaveChanges();
        }
       
    }
}