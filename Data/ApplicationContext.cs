using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    // public class ApplicationContext : DbContext
       public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public ApplicationContext(DbContextOptions dbContextOptions):  base(dbContextOptions)
        {
           
        }

         public DbSet<Stock> Stock { get; set; }
         public DbSet<Comment> Comments  { get; set; }
         public DbSet<Trade> Trade { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);

             List<IdentityRole> roleList = new List<IdentityRole>(){
                 new IdentityRole {Name = "Admin", NormalizedName = "ADMIN"},
                 new IdentityRole {Name = "User", NormalizedName = "USER"},
                 new IdentityRole {Name = "VIP", NormalizedName = "VIP"},
                 new IdentityRole {Name = "VIP+", NormalizedName = "VIP+"},
                 new IdentityRole {Name = "VIP++", NormalizedName = "VIP++"}
             };
             
             modelBuilder.Entity<IdentityRole>().HasData(roleList);
             
         }
    }
}