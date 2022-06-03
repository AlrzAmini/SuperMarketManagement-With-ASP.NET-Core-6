using SuperMarketManagement.Application.DTOs.Account;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Domain.Models.User;
using SuperMarketManagement.Domain.Models.User.Attendance;

namespace SuperMarketManagement.Application.Interfaces.User;

public interface IAdminService
{
    Task<AddAdminResult> AddAdmin(Admin admin);

    Task<bool> EditAdmin(Admin admin);

    Task<bool> DeleteAdmin(int adminId);
    
    Task<Admin?> GetAdminById(int adminId);
    
    Task<List<Admin>> GetAdmins();
    
    Task<List<AdminInfoDto>> GetAdminsInfo();
    
    Task<AdminInfoDto?> GetAdminInfoById(int adminId);
    
    Task<bool> IsUserNameExist(string? userName);
    
    Task<LoginResult> CheckLogin(LoginDto loginDto);
    
    Task<AdminInfoDto?> GetAdminInfoByUserName(string userName);

    #region AdminAttendance

    Task<bool> AddAttendance(AdminAttendance attendance);
    Task<bool> UpdateAttendance(AdminAttendance attendance);
    Task<bool> CloseAttendance(int attendanceId);
    Task<int> CalculateAdminTodayWorkTime(int adminId);

    #endregion
}