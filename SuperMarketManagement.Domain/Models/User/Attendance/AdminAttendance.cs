using System.ComponentModel.DataAnnotations;
using SuperMarketManagement.Domain.Models.Base;

namespace SuperMarketManagement.Domain.Models.User.Attendance
{
    public class AdminAttendance : BaseEntity
    {
        #region properties

        public int AdminId { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        public int? WorkTimeMinutes { get; set; }

        public bool IsClosed { get; set; }

        #endregion

        #region relations

        public Admin? Admin { get; set; }

        #endregion
    }
}
