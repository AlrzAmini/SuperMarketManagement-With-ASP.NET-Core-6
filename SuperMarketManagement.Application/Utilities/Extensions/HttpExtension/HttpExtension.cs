using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SuperMarketManagement.Application.Utilities.Extensions.HttpExtension;


public static class HttpExtension
{
    public static string GetUserIp(this HttpContext httpContext)
    {
        return httpContext.Connection.RemoteIpAddress.ToString();
    }

    public static string GetCurrentUrl(this HttpContext httpContext)
    {
        return $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}";
    }
}