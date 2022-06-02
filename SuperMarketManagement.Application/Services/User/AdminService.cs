
using SuperMarketManagement.Application.DTOs.Account;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Application.Utilities.Extensions.Security;
using SuperMarketManagement.Application.Utilities.Security.Hashers;
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

        public async Task<AddAdminResult> AddAdmin(Admin admin)
        {
            admin.Password = PasswordHasher.HashWithAragon2(admin.Password);
            admin.UserName = admin.UserName.Sanitize();

            if (await IsUserNameExist(admin.UserName))
            {
                return AddAdminResult.UserNameExist;
            }

            if (await _adminRepository.AddAdmin(admin))
            {
                return AddAdminResult.Success;
            }

            return AddAdminResult.Error;
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

        public async Task<List<Admin>> GetAdmins()
        {
            return await _adminRepository.GetAdmins();
        }

        public async Task<List<AdminInfoDto>> GetAdminsInfo()
        {
            var admins = await _adminRepository.GetAdmins();

            return admins
                .Select(a => new AdminInfoDto
                {
                    Password = a.Password,
                    UserName = a.UserName,
                    ManagerId = a.Id ,
                    CreateDate = a.CreatedDate 
                }).ToList();
        }

        public async Task<bool> IsUserNameExist(string? userName)
        {
            if (userName == null)
            {
                return false;
            }

            return await _adminRepository.IsUserNameExist(userName);
        }

        public async Task<LoginResult> CheckLogin(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.UserName) || string.IsNullOrEmpty(loginDto.Password))
                return LoginResult.Error;

            // get admin
            var admin = await _adminRepository.GetAdminByUserName(loginDto.UserName);
            
            // check admin for null exp
            if (admin == null) return LoginResult.UserNameNotFound;
            
            // verify password
            var verifyResult = PasswordHasher.VerifyAragon2(loginDto.Password, admin.Password);
            return verifyResult ? LoginResult.Success : LoginResult.PasswordNotMatch;
        }

        public async Task<AdminInfoDto?> GetAdminInfoByUserName(string userName)
        {
            var admin = await _adminRepository.GetAdminByUserName(userName);
            if (admin == null)
            {
                return null;
            }

            return new AdminInfoDto
            {
                UserName = admin.UserName,
                Password = admin.Password,
                ManagerId = admin.Id,
                CreateDate = admin.CreatedDate
            };
        }
    }
}
