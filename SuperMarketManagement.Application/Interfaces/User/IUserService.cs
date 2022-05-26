using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Application.DTOs.User;

namespace SuperMarketManagement.Application.Interfaces.User
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDto createUserDto);

        Task<bool> EditUser(EditUserDto editUserDto);

        Task<bool> DeleteUser(int userId);

        Task<Domain.Models.User.User?> GetUserById(int userId);

        Task<List<Domain.Models.User.User>> GetAllUsers();
        
        Task<List<UserInfo>> GetAllUsersInfos();

        Task<FilterUsersDto> FilterUsers(FilterUsersDto filter);
    }
}
