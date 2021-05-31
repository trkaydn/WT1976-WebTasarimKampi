using MuseumProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MuseumProject.Models
{
    public class Context : DbContext
    {
        public Context() : base("Context")
        {

        }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Message> Message { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Collection> Collection { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}