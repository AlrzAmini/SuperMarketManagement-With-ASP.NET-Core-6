using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Domain.Interfaces.User;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.Services.User
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> AddAdmin(Admin admin)
        {
            return await _adminRepository.AddAdmin(admin);
        }

        public async Task<bool> EditAdmin(Admin admin)
        {
            return await _adminRepository.UpdateAdmin(admin);
        }

        public async Task<bool> DeleteAdmin(int adminId)
        {
            var admin = await _adminRepository.GetAdminById(adminId);
            if (admin == null)
            {
                return false;
            }

            return await _adminRepository.DeleteAdmin(admin);
        }

        public async Task<Admin?> GetAdminById(int adminId)
        {
            return await _adminRepository.GetAdminById(adminId);
        }

        public async Task<List<Admin?>> GetAdmins()
        {
            return await _adminRepository.GetAdmins();
        }

        public async Task<List<AdminInfoDto>> GetAdminsInfo()
        {
            var admins = await _adminRepository.GetAdmins();

            return admins
                .Select(a => new AdminInfoDto
                {
                    Password = a?.Password,
                    UserName = a?.UserName,
                    ManagerId = a?.Id ?? default,
                    CreateDate = a?.CreatedDate ?? default
                }).ToList();
        }
    }
}
