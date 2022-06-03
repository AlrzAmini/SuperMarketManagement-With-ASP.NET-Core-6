using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarketManagement.Domain.Models.Product;
using SuperMarketManagement.Domain.Models.User;
using SuperMarketManagement.Domain.Models.User.Attendance;

namespace SuperMarketManagement.Data.Context
{
    public class SuperMarketDbContext : DbContext
    {
        #region constructor

        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> option)
            : base(option)
        {
        }

        #endregion

        #region add entities

        #region user

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminAttendance> AdminAttendances { get; set; }

        #endregion

        #region product

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                rel.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region query filters

            modelBuilder.Entity<User>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<Admin>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<ProductGroup>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<ProductSize>()
                .HasQueryFilter(e => !e.IsDeleted);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
