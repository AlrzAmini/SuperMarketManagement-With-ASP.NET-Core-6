using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Data.Context
{
    public class SuperMarketDbContext : DbContext
    {
        #region constructor

        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> option) : base(option)
        {
        }

        #endregion

        #region add entities

        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                rel.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region query filters

            modelBuilder.Entity<User>()
                .HasQueryFilter(e => !e.IsDelete);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
