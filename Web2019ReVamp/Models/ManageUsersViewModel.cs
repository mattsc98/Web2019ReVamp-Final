using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2019ReVamp.Data;

namespace Web2019ReVamp.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }

        public ApplicationUser[] Everyone { get; set; }
    }
}
