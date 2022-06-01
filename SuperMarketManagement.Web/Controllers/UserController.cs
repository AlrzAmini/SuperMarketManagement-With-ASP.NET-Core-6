using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;

namespace SuperMarketManagement.Web.Controllers
{
    [Route("users")]
    public class UserController : BaseController
    {
        #region constructor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region index
        
        public async Task<IActionResult> Index(FilterUsersDto filter)
        {
            return View(await _userService.FilterUsers(filter));
        }

        #endregion

        #region add

        [HttpGet("add")]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost("add"),ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            if (await _userService.CreateUser(userDto))
            {
                TempData[SuccessToast] = "با موفقیت ثبت شد";
                return RedirectToAction("Index");
            }
            
            TempData[ErrorToast] = "خطایی در ثبت کاربر رخ داد";
            return View();
        }

        #endregion

        #region detail

        [HttpGet("detail/{userId}")]
        public async Task<IActionResult> Detail(int userId)
        {
            var model = await _userService.GetUserInfoById(userId);
            if (model == null)
            {
                return NotFound();
            }
            
            return View(model);
        }

        #endregion

        #region edit

        [HttpGet("edit/{userId}")]
        public async Task<IActionResult> Edit(int userId)
        {
            var model = await _userService.GetUserForEdit(userId);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost("edit/{userId}"),ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserDto editUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(editUserDto);
            }
            if (await _userService.EditUser(editUserDto))
            {
                TempData[SuccessToast] = "با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }

            TempData[ErrorToast] = "ویرایش با شکست مواجه شد";
            return RedirectToAction("Index");
        }

        #endregion

        #region delete

        [HttpPost("del/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var res = await _userService.DeleteUser(userId);
            if (res)
            {
                TempData[SuccessToast] = "با موفقیت حذف شد";
                return Ok(res);
            }

            TempData[ErrorToast] = "خطایی در حذف کاربر رخ داد";
            return BadRequest(res);
        }

        #endregion
    }
}
