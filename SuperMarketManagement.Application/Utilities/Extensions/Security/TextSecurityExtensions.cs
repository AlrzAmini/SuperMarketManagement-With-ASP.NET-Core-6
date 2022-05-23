using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.XSS;

namespace SuperMarketManagement.Application.Utilities.Extensions.Security
{
    public static class TextSecurityExtensions
    {
        public static string Sanitize(this string input)
        {
            var htmlSanitizer = new HtmlSanitizer();
            return htmlSanitizer.Sanitize(input);
        }
        public static string? SanitizeNullable(this string? input)
        {
            if (input == null)
            {
                return null;
            }
            
            var htmlSanitizer = new HtmlSanitizer();
            return htmlSanitizer.Sanitize(input);
        }
    }
}
