using SuperMarketManagement.Domain.Models.User;
using SuperMarketManagement.Domain.Models.User.Attendance;

namespace SuperMarketManagement.Domain.Interfaces.User;

public interface IAdminRepository
{
    Task<bool> AddAdmin(Admin admin);
    
    Task<bool> UpdateAdmin(Admin admin);
    
    Task<bool> DeleteAdmin(Admin admin);
    
    Task<Admin?> GetAdminById(int adminId);
    
    Task<List<Admin>> GetAdmins();
    
    Task<bool> IsUserNameExist(string userName);
    
    string? GetAdminHashedPasswordByUserName(string userName);
    
    Task<Admin?> GetAdminByUserName(string userName);

    #region AdminAttendance

    Task<bool> AddAttendance(AdminAttendance attendance);
    Task<bool> UpdateAttendance(AdminAttendance attendance);    
    Task<bool> CloseAttendance(AdminAttendance attendance);    
    Task<AdminAttendance?> GetAttendanceById(int attendanceId);
    Task<bool> IsAdminHaveUnClosedAttendance(int adminId);
    DateTime? GetAdminUnClosedAttendanceDate(int adminId);
    Task<AdminAttendance?> GetAdminUnClosedAttendance(int adminId);
    int CalculateAdminAllWorkDays(int adminId);
    IQueryable<AdminAttendance> GetAdminAttendancesQueryable(int adminId);

    #endregion
}