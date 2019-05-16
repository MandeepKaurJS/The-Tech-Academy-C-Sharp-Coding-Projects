using MVCExcelSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using System.Web;

namespace MVCExcelSheet.Context
{
    public class DbAccessContext : DbContext
    {
        public DbAccessContext() : base("DefaultConnection") { }
        public DbSet<EmploeeDetails> Employees
        {
            get;
            set;
        }
        public DbSet<Department> Departments
        {
            get;
            set;
        }
    }