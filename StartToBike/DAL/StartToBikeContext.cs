using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StartToBike.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StartToBike.DAL
{
    public class StartToBikeContext : DbContext
    {
        public StartToBikeContext() : base("StartToBike") { }

        public virtual DbSet<ApplicationUser> User { get; set; }
        public virtual DbSet<Injury> Injury { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Training> Training { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Injury).WithMany(i => i.ApplicationUser)
                .Map(m => {
                    m.ToTable("AspNetUserInjuries");
                    m.MapLeftKey("AspUserID");
                    m.MapRightKey("InjuryID");
                });
           
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);
            

        }
    }
}