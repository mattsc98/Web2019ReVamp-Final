using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web2019ReVamp.Models;

namespace Web2019ReVamp.Models
{
    public class Web2019ReVampContext : DbContext
    {
        public Web2019ReVampContext (DbContextOptions<Web2019ReVampContext> options)
            : base(options)
        {
        }
        //public DbSet<Catagories> Catagoies { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Web2019ReVamp.Models.Upvotes> Upvotes { get; set; }
        
    }
}
