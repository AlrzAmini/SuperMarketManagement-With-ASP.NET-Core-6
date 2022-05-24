using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Application.Utilities.Extensions.Price
{
    public static class PriceExtensions
    {
        public static string ToTooman(this long price)
        {
            return price.ToString("#,0") + " تومان ";
        }

        public static string ToTooman(this float price)
        {
            return price.ToString("#,0") + " تومان ";
        }

        public static string ToTooman(this int price)
        {
            return price.ToString("#,0") + " تومان ";
        }
    }
}
