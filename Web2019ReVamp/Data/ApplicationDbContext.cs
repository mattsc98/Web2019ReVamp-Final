using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web2019ReVamp.Models;
using Web2019ReVamp.ViewModels;

namespace Web2019ReVamp.Data
{

   

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Web2019ReVamp.Models.Reports> Reports { get; set; }
        public DbSet<Web2019ReVamp.ViewModels.UsersViewer> UsersViewer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasIndex(x => x.UserName).IsUnique();

            base.OnModelCreating(builder);

            //seed admin
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Administrator", NormalizedName = "Administrator".ToUpper() });

        }
    }

}