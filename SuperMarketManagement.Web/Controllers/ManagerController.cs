using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.Interfaces.User;

namespace SuperMarketManagement.Web.Controllers
{
    [Route("managers")]
    public class ManagerController : BaseController
    {
        private readonly IAdminService _adminService;

        public ManagerController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _adminService.GetAdminsInfo();
            if (model.Any())
            {
                return View(model);
            }

            TempData[ErrorMessage] = "مدیری ثبت نشده است";
            return RedirectToAction("Index","Home");
        }
    }
}
