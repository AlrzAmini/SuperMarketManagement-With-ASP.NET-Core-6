using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SuperMarketManagement.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string InfoMessage = "InfoMessage";
        protected string ErrorMessage = "ErrorMessage";
        protected string WarningMessage = "WarningMessage";
        protected string SuccessToast = "SuccessToast";
        protected string InfoToast = "InfoToast";
        protected string ErrorToast = "ErrorToast";
        protected string WarningToast = "WarningToast";
    }
}
