using SuperMarketManagement.Application.DTOs.Account;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.Interfaces.User;

public interface IAdminService
{
    Task<AddAdminResult> AddAdmin(Admin admin);
    Task<bool> EditAdmin(Admin admin);
    Task<bool> DeleteAdmin(int adminId);
    Task<Admin?> GetAdminById(int adminId);
    Task<List<Admin>> GetAdmins();
    Task<List<AdminInfoDto>> GetAdminsInfo();
    Task<bool> IsUserNameExist(string? userName);
    Task<LoginResult> CheckLogin(LoginDto loginDto);
    Task<AdminInfoDto?> GetAdminInfoByUserName(string userName);
}