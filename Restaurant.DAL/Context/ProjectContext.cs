using Restaurant.DAL.Entities;
using Restaurant.DAL.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Context
{
   public class ProjectContext:DbContext
    {
        public ProjectContext():base ("name= dbConn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectContext>());
        }

        public DbSet<Masalar> Masalar { get; set; }
        public DbSet<Rezervasyon> Rezervsayonlar { get; set; }
        public DbSet<Yonetim> Admins { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Configurations.Add(new MasalarMapping());
            modelBuilder.Configurations.Add(new RezervasyonMapping());

            modelBuilder.Conventions.Add(new PluralizingTableNameConvention());
            
        }
    }
}
