using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.Interfaces.User;
using SuperMarketManagement.Application.Utilities.Extensions.Common;

namespace SuperMarketManagement.Web.Controllers.User_Panel
{
    [Route("account")]
    public class UserPanelController : BaseController
    {
        #region constructor

        private readonly IAdminService _adminService;

        public UserPanelController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        #endregion

        [HttpGet("home/{adminId}")]
        public async Task<IActionResult> Index(int adminId)
        {
            // if user wana to see another profiles
            if (adminId != User.GetUserId())
            {
                return BadRequest();
            }
            
            var model = await _adminService.GetAdminInfoById(adminId);
            if (model == null)
            {
                return NotFound(model);
            }
            
            return View(model);
        }
    }
}
