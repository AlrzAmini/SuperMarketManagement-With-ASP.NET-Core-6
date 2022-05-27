
using SuperMarketManagement.Application.DTOs.Paging;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Application.Utilities.Extensions.Security;
using SuperMarketManagement.Domain.Interfaces.User;

namespace SuperMarketManagement.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            var user = new Domain.Models.User.User
            {
                UserName = createUserDto.UserName?.Sanitize(),
                Address = createUserDto.Address?.Sanitize(),
            };
            return await _userRepository.AddUser(user);
        }

        public async Task<bool> EditUser(EditUserDto editUserDto)
        {
            var user = await _userRepository.GetUserById(editUserDto.UserId);
            if (user == null)
            {
                return false;
            }

            user.UserName = editUserDto.UserName?.Sanitize();
            user.Address = editUserDto.Address?.Sanitize();

            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                return false;
            }

            return await _userRepository.DeleteUser(user);
        }

        public async Task<Domain.Models.User.User?> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<UserInfo?> GetUserInfoById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }

            return new UserInfo
            {
                UserId = user.Id,
                UserName = user.UserName,
                Address = user.Address,
                RegisterDate = user.CreatedDate
            };
        }


        public async Task<List<Domain.Models.User.User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<List<UserInfo>> GetAllUsersInfos()
        {
            var users = await _userRepository.GetAllUsersQueryable();
            return users.Select(user => new UserInfo
            {
                UserId = user.Id,
                UserName = user.UserName,
                Address = user.Address,
                RegisterDate = user.CreatedDate
            }).ToList();
        }

        public async Task<FilterUsersDto> FilterUsers(FilterUsersDto filter)
        {
            var result = await _userRepository.GetAllUsersQueryable();

            //filter by user name
            if (!string.IsNullOrEmpty(filter.UserName))
            {
                result = result.Where(r => r.UserName != null && r.UserName.Contains(filter.UserName));
            }

            //filter by address
            if (!string.IsNullOrEmpty(filter.Address))
            {
                result = result.Where(r => r.Address != null && r.Address.Contains(filter.Address));
            }

            //paging
            var pager = Pager.Build(filter.PageNum, result.Count(), filter.Take, filter.PageCountAfterAndBefore);
            var users = result.Paging(pager)
                .Select(user => new UserInfo
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Address = user.Address,
                    RegisterDate = user.CreatedDate
                }).ToList();

            return filter.SetPaging(pager).SetEntities(users);
        }

        public async Task<EditUserDto?> GetUserForEdit(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }

            return new EditUserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Address = user.Address
            };
        }
    }
}
