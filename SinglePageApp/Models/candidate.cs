using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinglePageApp.Models
{
    public class candidate
    {


        public class Candidate
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public int Experience { get; set; }
            public string[] Technologies { get; set; }
        }



    }
}