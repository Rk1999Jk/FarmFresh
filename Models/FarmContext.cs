using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class FarmContext:DbContext
    {
        public FarmContext() : base("Name=FarmFreshConnectionString")
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<FarmerDetails> FarmerDetails { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<FarmerLogin> FarmerLogins { get; set; }
        public DbSet<UserCart> UserCarts { get; set; }
        public DbSet<UserCategoryViewModel> UserCategoryViewModels { get; set; }
        public DbSet<CategoryTable> CategoryTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<WebApplication4.Models.ProductDetails> ProductDetails { get; set; }
    }
}