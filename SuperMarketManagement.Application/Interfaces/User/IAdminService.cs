using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.Interfaces.User;

public interface IAdminService
{
    Task<bool> AddAdmin(Admin admin);
    Task<bool> EditAdmin(Admin admin);
    Task<bool> DeleteAdmin(int adminId);
    Task<Admin?> GetAdminById(int adminId);
    Task<List<Admin?>> GetAdmins();
    Task<List<AdminInfoDto>> GetAdminsInfo();
}