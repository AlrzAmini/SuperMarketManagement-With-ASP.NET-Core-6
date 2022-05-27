

namespace SuperMarketManagement.Application.Utilities.Extensions.Text
{
    public static class TextExtensions
    {
        public static string TruncateLongString(this string str, int maxLength)
        {
            var res = str[..Math.Min(str.Length, maxLength)];
            return res + " ... ";
        }

        public static string FixForUrl(this string str)
        {
            return str.Replace(" ", "-");
        }

        public static string FixForAddress(this string address)
        {
            return string.IsNullOrEmpty(address) ? "" : address.Replace(" ", " - ");
        }

        public static bool IsAllCharEnglish(this string input)
        {
            return input.ToCharArray()
                .All(item => char.IsLower(item) ||
                             char.IsUpper(item) ||
                             char.IsDigit(item) ||
                             char.IsWhiteSpace(item));
        }

        public static string ToMegaByteForm(this float value)
        {
            return value + " مگابایت ";
        }
    }
}
