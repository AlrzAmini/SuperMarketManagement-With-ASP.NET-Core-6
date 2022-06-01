using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Domain.Interfaces.User;

public interface IAdminRepository
{
    Task<bool> AddAdmin(Admin admin);
    Task<bool> UpdateAdmin(Admin admin);
    Task<bool> DeleteAdmin(Admin admin);
    Task<Admin?> GetAdminById(int adminId);
    Task<List<Admin?>> GetAdmins();
}