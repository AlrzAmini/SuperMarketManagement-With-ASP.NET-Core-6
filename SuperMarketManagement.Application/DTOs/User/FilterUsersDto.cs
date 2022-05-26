using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Application.DTOs.Paging;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Application.DTOs.User
{
    public class FilterUsersDto : BasePaging
    {
        #region constructor

        public FilterUsersDto()
        {
            Users = new List<UserInfo>();
        }

        #endregion

        #region properties

        public string? UserName { get; set; }

        public string? Address { get; set; }

        public UserRole? UserRole { get; set; }

        public List<UserInfo> Users { get; set; }

        #endregion

        #region methods

        public FilterUsersDto SetEntities(List<UserInfo> users)
        {
            Users = users;
            return this;
        }

        public FilterUsersDto SetPaging(BasePaging paging)
        {
            PageNum = paging.PageNum;
            TotalEntitiesCount = paging.TotalEntitiesCount;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            PageCountAfterAndBefore = paging.PageCountAfterAndBefore;
            Take = paging.Take;
            Skip = paging.Skip;
            TotalPages = paging.TotalPages;

            return this;
        }

        #endregion
    }
}
