using SuperMarketManagement.Domain.Models.User;

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
}