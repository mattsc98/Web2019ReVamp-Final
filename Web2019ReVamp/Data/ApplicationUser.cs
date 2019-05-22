using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2019ReVamp.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        public int totalReports { get; set; }
    }
}
