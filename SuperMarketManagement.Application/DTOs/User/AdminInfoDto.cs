using System.ComponentModel;

namespace SuperMarketManagement.Application.DTOs.User
{
    public class AdminInfoDto
    {
        public AdminInfoDto()
        {
            UserName = "";
            Password = "";
            TodayWorkTimeMinutes = default;
        }

        #region properties

        public int ManagerId { get; set; }

        [DisplayName("نام کاربری")]
        public string UserName { get; set; }

        [DisplayName("رمز عبور")]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public int AllWorkDays { get; set; }

        public int TodayWorkTimeMinutes { get; set; }

        public DateTime? UnClosedAttendanceDate { get; set; }

        #endregion
    }
}
