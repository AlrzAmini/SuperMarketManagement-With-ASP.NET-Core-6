using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarketManagement.Data.Context;
using SuperMarketManagement.Domain.Interfaces.User;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Data.Repositories.User
{
    public class AdminRepository : IAdminRepository
    {
        private readonly SuperMarketDbContext _context;

        public AdminRepository(SuperMarketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAdmin(Admin admin)
        {
            try
            {
                await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAdmin(Admin admin)
        {
            try
            {
                _context.Admins.Update(admin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAdmin(Admin admin)
        {
            admin.IsDeleted = true;
            return await UpdateAdmin(admin);
        }

        public async Task<Admin?> GetAdminById(int adminId)
        {
            return await _context.Admins.FindAsync(adminId);
        }

        public async Task<List<Admin?>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }
    }
}
