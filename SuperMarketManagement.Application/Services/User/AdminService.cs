
using SuperMarketManagement.Application.DTOs.Account;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Application.Utilities.Extensions.Security;
using SuperMarketManagement.Application.Utilities.Security.Hashers;
using SuperMarketManagement.Application.Utilities.Utils.DateUtils;
using SuperMarketManagement.Domain.Interfaces.User;
using SuperMarketManagement.Domain.Models.User;
using SuperMarketManagement.Domain.Models.User.Attendance;

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
                    ManagerId = a.Id,
                    CreateDate = a.CreatedDate,
                    TodayWorkTimeMinutes = CalculateAdminTodayWorkTime(a.Id),
                    AllWorkDays = _adminRepository.CalculateAdminAllWorkDays(a.Id)
                }).ToList();
        }

        public async Task<AdminInfoDto?> GetAdminInfoById(int adminId)
        {
            var admin = await _adminRepository.GetAdminById(adminId);
            if (admin == null)
            {
                return null;
            }

            return new AdminInfoDto
            {
                UserName = admin.UserName,
                Password = admin.Password,
                CreateDate = admin.CreatedDate,
                ManagerId = admin.Id,
                TodayWorkTimeMinutes = CalculateAdminTodayWorkTime(adminId),
                AllWorkDays = _adminRepository.CalculateAdminAllWorkDays(adminId),
                UnClosedAttendanceDate = _adminRepository.GetAdminUnClosedAttendanceDate(admin.Id)
            };
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

        public async Task<AdminInfoForEdit?> GetAdminInfoForEdit(int adminId)
        {
            var admin = await _adminRepository.GetAdminById(adminId);
            if (admin == null)
            {
                return null;
            }

            return new AdminInfoForEdit
            {
                Id = admin.Id,
                UserName = admin.UserName
            };
        }

        public async Task<bool> EditManager(AdminInfoForEdit infoForEdit)
        {
            var admin = await _adminRepository.GetAdminById(infoForEdit.Id);
            if (admin == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(infoForEdit.UserName))
            {
                admin.UserName = infoForEdit.UserName;
            }
            if (!string.IsNullOrEmpty(infoForEdit.Password))
            {
                admin.Password = PasswordHasher.HashWithAragon2(infoForEdit.Password);
            }

            return await _adminRepository.UpdateAdmin(admin);
        }

        public async Task<bool> AddAttendance(AdminAttendance attendance)
        {
            return await _adminRepository.AddAttendance(attendance);
        }

        public async Task<bool> UpdateAttendance(AdminAttendance attendance)
        {
            return await _adminRepository.UpdateAttendance(attendance);
        }

        public async Task<bool> CloseAttendance(int attendanceId)
        {
            var attendance = await _adminRepository.GetAttendanceById(attendanceId);
            if (attendance == null)
            {
                return false;
            }

            if (attendance.IsClosed)
            {
                return false;
            }

            var now = DateTime.Now;

            // work time is ended : attendance end date = datetime.now and status = closed
            attendance.EndDate = now;
            attendance.WorkTimeMinutes = DateUtils.GetDifferenceInMinutes(attendance.StartDate, now);

            return await _adminRepository.CloseAttendance(attendance);
        }

        public async Task<bool> IsAdminHaveUnClosedAttendance(int adminId)
        {
            return await _adminRepository.IsAdminHaveUnClosedAttendance(adminId);
        }

        public async Task<int> GetAdminUnClosedAttendanceId(int adminId)
        {
            var res = await _adminRepository.GetAdminUnClosedAttendance(adminId);
            return res?.Id ?? default;
        }

        private int CalculateAdminTodayWorkTime(int adminId)
        {
            try
            {
                var query = _adminRepository.GetAdminAttendancesQueryable(adminId);

                // filter admin today attendances
                query = query.Where(q => q.StartDate.Date == DateTime.Now.Date);

                var todayWorkTime = query.Sum(a => a.WorkTimeMinutes);

                // pattern :
                // if todayWorkTime is not null, return todayWorkTime
                // else return 0
                return todayWorkTime ?? default;
            }
            // if query is null, come into catch and return 0
            catch (ArgumentOutOfRangeException)
            {
                return default;
            }
        }
    }
}
