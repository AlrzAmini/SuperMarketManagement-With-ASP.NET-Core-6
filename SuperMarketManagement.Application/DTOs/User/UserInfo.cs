using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.DTOs.User
{
    //TODO : paging and filter users
    public class UserInfo
    {
        #region properties

        public int UserId { get; set; }
        
        public string? UserName { get; set; }

        public string? Address { get; set; }

        public DateTime RegisterDate { get; set; }

        #endregion
    }
}
