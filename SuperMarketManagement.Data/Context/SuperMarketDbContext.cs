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
    }
}
