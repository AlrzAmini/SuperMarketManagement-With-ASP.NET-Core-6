using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Domain.Models.User.User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> AddUser(Domain.Models.User.User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(Domain.Models.User.User user)
        {
            user.IsDelete = true;
            return await UpdateUser(user);
        }

        public async Task<Domain.Models.User.User?> GetUserById(int userId)
        {
            //not matter if method returns null because we control it in service layer
            return await _context.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUser(Domain.Models.User.User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IQueryable<Domain.Models.User.User>> GetAllUsersQueryable()
        {
            // in the service we do select in this queryable
            // so we need lazy loading
            // in this way we just have to call .ToList() just once
            return await Task.FromResult(_context.Users.AsQueryable().OrderByDescending(u=>u.UserId));
        }
    }
}
