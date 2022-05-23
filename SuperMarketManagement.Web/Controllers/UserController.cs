using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.DTOs.User;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Domain.Models.User;

namespace SuperMarketManagement.Web.Controllers
{
    public class UserController : Controller
    {
        #region constructor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion
        
        //TODO  : Create View
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersInfos();
            return View(users);
        }
    }
}
