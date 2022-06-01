using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Application.DTOs.User
{
    public class AdminInfoDto
    {
        #region properties

        public int ManagerId { get; set; }

        [DisplayName("نام کاربری")]
        public string? UserName { get; set; }

        [DisplayName("رمز عبور")]
        public string? Password { get; set; }

        public DateTime CreateDate { get; set; }

        #endregion
    }
}
