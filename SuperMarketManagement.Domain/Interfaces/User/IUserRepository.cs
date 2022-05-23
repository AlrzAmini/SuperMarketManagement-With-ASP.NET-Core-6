using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Domain.Interfaces.User
{
    public interface IUserRepository
    {
        Task<bool> AddUser(Models.User.User user);

        Task<bool> UpdateUser(Models.User.User user);

        Task<bool> DeleteUser(Models.User.User user);

        Task<Models.User.User> GetUserById(int userId);
    }
}
