using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Data.Context;
using SuperMarketManagement.Domain.Interfaces.User;

namespace SuperMarketManagement.Data.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly SuperMarketDbContext _context;

        public UserRepository(SuperMarketDbContext context)
        {
            _context = context;
        }
    }
}
