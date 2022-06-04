using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.DTOs.User;
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
            return View(model);
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

            var res = await _adminService.AddAdmin(admin);
            switch (res)
            {
                case AddAdminResult.Success:
                    TempData[SuccessMessage] = "مدیر با موفقیت ثبت شد";
                    return RedirectToAction("Index");
                case AddAdminResult.UserNameExist:
                    TempData[ErrorMessage] = "نام مدیر نمیتواند تکراری باشد";
                    return RedirectToAction("CreateManager");
                case AddAdminResult.Error:
                    TempData[ErrorMessage] = "مدیر ثبت نشد";
                    return RedirectToAction("Index");
                default:
                    TempData[ErrorMessage] = "خطایی رخ داد";
                    return RedirectToAction("Index");
            }
        }

        #endregion

        #region edit

        [HttpGet("edit/{adminId}")]
        public async Task<IActionResult> Edit(int adminId)
        {
            var model = await _adminService.GetAdminInfoForEdit(adminId);
            if (model == null)
            {
                return NotFound(model);
            }

            return View(model);
        }

        [HttpPost("edit/{adminId}"),ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminInfoForEdit infoForEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(infoForEdit);
            }
            var result = await _adminService.EditManager(infoForEdit);
            if (result)
            {
                TempData[SuccessMessage] = "با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }

            TempData[ErrorMessage] = "مشکلی در ویرایش رخ داد";
            return RedirectToAction("Edit", new { adminId = infoForEdit.Id });
        }

        #endregion

        #region delete

        [HttpPost("del/{managerId}")]
        public async Task<IActionResult> DeleteManager(int managerId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var res = await _adminService.DeleteAdmin(managerId);
            if (res)
            {
                TempData[SuccessMessage] = "مدیر با موفقیت حذف شد";
                return Ok(res);
            }

            TempData[ErrorMessage] = "مدیر حذف نشد";
            return BadRequest(res);
        }

        #endregion

        #region details



        #endregion
    }
}
