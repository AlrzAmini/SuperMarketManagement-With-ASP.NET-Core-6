using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Application.Utilities.Extensions.Common
{
    public static class CommonExtensions
    {
        public static string GetEnumName(this Enum value)
        {
            var enumInfo = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            if (enumInfo == null)
            {
                return "";
            }

            var name = enumInfo.GetCustomAttribute<DisplayAttribute>()?.GetName();
            return name ?? "";
        }

        public static int GetUserId(this ClaimsPrincipal claim)
        {
            var data = claim.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
            return data != null ? Convert.ToInt32(data.Value) : default;
        }

        public static string GetUserName(this ClaimsPrincipal claim)
        {
            var data = claim.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Name);
            return data != null ? data.Value : "";
        }        

    }
}
