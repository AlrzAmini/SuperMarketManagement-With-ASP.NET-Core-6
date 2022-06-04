using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Application.Utilities.Extensions.Common;
using SuperMarketManagement.Domain.Interfaces.User;
using SuperMarketManagement.Domain.Models.User.Attendance;

namespace SuperMarketManagement.Web.Controllers.User_Panel;

[Route("attend")]
public class AttendanceController : BaseController
{
    #region constructor

    private readonly IAdminService _adminService;

    public AttendanceController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    #endregion

    #region add

    [HttpPost("add")]
    public async Task<IActionResult> AddAttendance(string returnUrl)
    {
        var attendance = new AdminAttendance
        {
            AdminId = User.GetUserId()
        };

        if (await _adminService.AddAttendance(attendance))
        {
            TempData[SuccessMessage] = "شروع ساعت کاری جدید";
            return Redirect(returnUrl);
        }

        TempData[ErrorMessage] = "خطا در ثبت ساعت کاری";
        return Redirect(returnUrl);
    }

    #endregion

    #region close

    [HttpPost("close")]
    public async Task<IActionResult> CloseAttendance(string returnUrl)
    {
        var attendanceId = await _adminService.GetAdminUnClosedAttendanceId(User.GetUserId());
        if (await _adminService.CloseAttendance(attendanceId))
        {
            TempData[SuccessMessage] = "بستن ساعت کاری با موفقیت انجام شد";
            return Redirect(returnUrl);
        }

        TempData[ErrorMessage] = "خطا در بستن ساعت کاری";
        return Redirect(returnUrl);
    }

    #endregion
}