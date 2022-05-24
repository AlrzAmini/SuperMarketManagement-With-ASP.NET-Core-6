using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Application.Utilities.Extensions.Date
{
    public static class DateExtensions
    {
        public static int? GetAgeByDateTime(this DateTime? birthDate)
        {
            if (birthDate == null) return null;

            var dateNow = DateTime.Now;
            var age = dateNow.Year - birthDate.Value.Year;

            if (dateNow.Month < birthDate.Value.Month || dateNow.Month == birthDate.Value.Month && dateNow.Day < birthDate.Value.Day)
                age--;

            return age;

        }

        public static string ToShamsi(this DateTime date)
        {
            var pc = new PersianCalendar();

            return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00") + "/" + pc.GetDayOfMonth(date).ToString("00");
        }

        public static string? ToShamsi(this DateTime? date)
        {
            var pc = new PersianCalendar();

            if (date == null)
            {
                return default;
            }

            return pc.GetYear((DateTime)date) + "/" + pc.GetMonth((DateTime)date).ToString("00") + "/" + pc.GetDayOfMonth((DateTime)date).ToString("00");
        }

        public static string GetHourAndMinutes(this DateTime value)
        {
            return value.ToString("HH:mm");
        }

        public static string ToIraniDate(this DateTime dt)
        {
            var pc = new PersianCalendar();
            var intYear = pc.GetYear(dt);
            var intMonth = pc.GetMonth(dt);
            var intDayOfMonth = pc.GetDayOfMonth(dt);
            var enDayOfWeek = pc.GetDayOfWeek(dt);

            var strMonthName = intMonth switch
            {
                1 => "فروردین",
                2 => "اردیبهشت",
                3 => "خرداد",
                4 => "تیر",
                5 => "مرداد",
                6 => "شهریور",
                7 => "مهر",
                8 => "آبان",
                9 => "آذر",
                10 => "دی",
                11 => "بهمن",
                12 => "اسفند",
                _ => ""
            };

            var strDayName = enDayOfWeek switch
            {
                DayOfWeek.Friday => "جمعه",
                DayOfWeek.Monday => "دوشنبه",
                DayOfWeek.Saturday => "شنبه",
                DayOfWeek.Sunday => "یکشنبه",
                DayOfWeek.Thursday => "پنجشنبه",
                DayOfWeek.Tuesday => "سه شنبه",
                DayOfWeek.Wednesday => "چهارشنبه",
                _ => ""
            };

            return ($"{strDayName} {intDayOfMonth} {strMonthName} {intYear}");
        }

        public static DateTime StringShamsiToMiladi(this string shamsi)
        {
            var splitDate = shamsi.GetEnglishNumbers().Split('/');
            if (!splitDate.Any() && splitDate.Length < 3)
            {
                return default;
            }

            var pc = new PersianCalendar();

            if (splitDate[0].Length == 4)
            {
                var year = int.Parse(splitDate[0]);
                var month = int.Parse(splitDate[1]);
                var day = int.Parse(splitDate[2]);

                var resDate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);

                return resDate;
            }

            var rDay = int.Parse(splitDate[0]);
            var rMonth = int.Parse(splitDate[1]);
            var rYear = int.Parse(splitDate[2]);

            var resultDate = pc.ToDateTime(rYear, rMonth, rDay, 0, 0, 0, 0);

            return resultDate;
        }

        public static string GetEnglishNumbers(this string s)
        {
            return s.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        }

        public static string GetPersianNumbers(this string s)
        {
            return s.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
        }
    }
}
