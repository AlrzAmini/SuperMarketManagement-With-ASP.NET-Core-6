

namespace SuperMarketManagement.Application.Utilities.Utils.DateUtils
{
    public static class DateUtils
    {
        public static int GetDifferenceInMinutes(DateTime startDate, DateTime endDate)
        {
            return (int)Math.Round((endDate - startDate).TotalMinutes);
        }
    }
}
