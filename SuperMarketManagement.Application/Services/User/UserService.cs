using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Application.Utilities.Extensions.Security;
using SuperMarketManagement.Application.Utilities.Security.Hashers;
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
                Address = createUserDto.Address.Sanitize(),
                Password = PasswordHasher.HashWithMd5(createUserDto.Password)
                UserRole = createUserDto.UserRole,
            };
        }

        public async Task<bool> EditUser(EditUserDto editUserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Models.User.User> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
