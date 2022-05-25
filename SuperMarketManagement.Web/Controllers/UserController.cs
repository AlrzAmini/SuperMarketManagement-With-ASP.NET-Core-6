using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Web.Controllers
{
    [Route("user")]
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

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersInfos();
            return View(users);
        }

        #endregion

        #region add

        [HttpGet("add")]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost("add")]
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



        #endregion

        #region edit



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
