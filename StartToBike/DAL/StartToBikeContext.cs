using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StartToBike.Models;

namespace StartToBike.DAL
{
    public class StartToBikeContext : DbContext
    {
        public StartToBikeContext() : base("StartToBike") { }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Injury> Injuries { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}