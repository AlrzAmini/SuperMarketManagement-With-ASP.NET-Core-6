using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Domain.Models.User;

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

        #region index

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _adminService.GetAdminsInfo();
            if (model.Any())
            {
                return View(model);
            }

            TempData[ErrorMessage] = "مدیری ثبت نشده است";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region add

        [HttpGet("create")]
        public IActionResult CreateManager()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateManager(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }

            if (await _adminService.AddAdmin(admin))
            {
                TempData[SuccessMessage] = "مدیر با موفقیت ثبت شد";
                return RedirectToAction("Index");
            }

            TempData[ErrorMessage] = "مدیر ثبت نشد";
            return RedirectToAction("Index");
        }

        #endregion

        #region edit



        #endregion

        #region delete



        #endregion

        #region details



        #endregion
    }
}
