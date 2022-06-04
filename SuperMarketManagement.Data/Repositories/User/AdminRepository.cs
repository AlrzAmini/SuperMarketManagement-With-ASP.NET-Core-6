
using Microsoft.EntityFrameworkCore;
using SuperMarketManagement.Data.Context;
using SuperMarketManagement.Domain.Interfaces.User;
using SuperMarketManagement.Domain.Models.User;
using SuperMarketManagement.Domain.Models.User.Attendance;

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

        public async Task<List<Admin>> GetAdmins()
        {
            return (await _context.Admins
                .OrderByDescending(a => a!.CreatedDate)
                .ToListAsync())!;
        }

        public async Task<bool> IsUserNameExist(string userName)
        {
            return await _context.Admins.AnyAsync(x => x.UserName == userName);
        }

        public string? GetAdminHashedPasswordByUserName(string userName)
        {
            return _context.Admins.FirstOrDefault(a => a.UserName == userName)?.Password;
        }

        public async Task<Admin?> GetAdminByUserName(string userName)
        {
            return await _context.Admins.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<bool> AddAttendance(AdminAttendance attendance)
        {
            try
            {
                await _context.AdminAttendances.AddAsync(attendance);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAttendance(AdminAttendance attendance)
        {
            try
            {
                _context.AdminAttendances.Update(attendance);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CloseAttendance(AdminAttendance attendance)
        {
            attendance.IsClosed = true;
            return await UpdateAttendance(attendance);
        }

        public async Task<AdminAttendance?> GetAttendanceById(int attendanceId)
        {
            return await _context.AdminAttendances.FindAsync(attendanceId);
        }

        public IQueryable<AdminAttendance> GetAdminAttendances(int adminId)
        {
            return _context.AdminAttendances
                .Where(a => a.AdminId == adminId);
        }

        public async Task<bool> IsAdminHaveUnClosedAttendance(int adminId)
        {
            return await _context.AdminAttendances.AnyAsync(a => a.AdminId == adminId && !a.IsClosed);
        }

        public DateTime? GetAdminUnClosedAttendanceDate(int adminId)
        {
            return _context.AdminAttendances.FirstOrDefault(a => a.AdminId == adminId && !a.IsClosed)?.StartDate;
        }

        public async Task<AdminAttendance?> GetAdminUnClosedAttendance(int adminId)
        {
            return await _context.AdminAttendances.FirstOrDefaultAsync(a => a.AdminId == adminId && !a.IsClosed);
        }
    }
}
