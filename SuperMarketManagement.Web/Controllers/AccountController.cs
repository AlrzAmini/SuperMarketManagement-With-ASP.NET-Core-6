using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SuperMarketManagement.Application.DTOs.Account;
using SuperMarketManagement.Application.Interfaces.User;

namespace SuperMarketManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private const string ErrorMessage = "ErrorMessage";
        private const string WarningMessage = "WarningMessage";
        private const string SuccessToast = "SuccessToast";

        #region MyRegion

        private readonly IAdminService _adminService;

        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        #endregion

        #region login

        [HttpGet("login")]
        public IActionResult Login(string? returnUrl)
        {
            // if the user is already logged in,
            // check if the user is trying to access the login page,
            // if so, redirect to the home page

            // pattern : user identity is not null + user is authenticated
            if (User.Identity is { IsAuthenticated: true })
            {
                TempData[WarningMessage] = "شما هم اکنون وارد شده اید";
                return RedirectToAction("Index", "Home");
            }

            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewData["returnUrl"] = returnUrl;
                return View(loginDto);
            }

            var checkLoginInfoResult = await _adminService.CheckLogin(loginDto);

            switch (checkLoginInfoResult)
            {
                case LoginResult.Success:
                    {
                        var adminInfo = await _adminService.GetAdminInfoByUserName(loginDto.UserName);
                        if (adminInfo == null) return BadRequest();

                        var claims = new List<Claim>
                        {
                        new(ClaimTypes.NameIdentifier,adminInfo.ManagerId.ToString()),
                        new(ClaimTypes.Name,adminInfo.UserName)
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            AllowRefresh = true
                        };

                        // command for login user
                        await HttpContext.SignInAsync(principal, properties);

                        TempData[SuccessToast] = "خوش آمدید";
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");

                    }
                case LoginResult.UserNameNotFound:
                    TempData[ErrorMessage] = "کاربری با این نام کاربری یافت نشد";
                    return RedirectToAction("Login");
                case LoginResult.PasswordNotMatch:
                    TempData[ErrorMessage] = "رمز عبور اشتباه است";
                    return RedirectToAction("Login");
                case LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داد";
                    return RedirectToAction("Login");
                default:
                    TempData[ErrorMessage] = "خطایی رخ داد";
                    return RedirectToAction("Login");
            }
        }

        #endregion

        #region logout

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity is { IsAuthenticated: false })
                return RedirectToAction("Login");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");

        }

        #endregion

        #region attendance

        

        #endregion
    }
}
