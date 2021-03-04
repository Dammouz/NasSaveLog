using System;
using Common.Enums;

namespace Common.Text
{
    public static class Date
    {
        /// <summary>
        /// Formate date in function of a pattern.
        /// </summary>
        /// <param name="date">date to format</param>
        /// <param name="format">pattern</param>
        /// <returns>formated date</returns>
        public static string FormatDate(DateTime date, DateFormat format)
        {
            switch (format)
            {
                case DateFormat.DateDebug:
                    return $"{date:yyyy-MM-dd HH:mm:ss.fffffff}";

                case DateFormat.DateLog:
                    return $"{date:yyyy-MM-dd HH:mm:ss.fff}";

                case DateFormat.DateHuman:
                    return $"{date:dd/MM/yyyy HH:mm:ss}";

                case DateFormat.DateFile:
                    return $"{date:yyyyMMddHHmm}";

                case DateFormat.DateLong:
                    return $"{date:yyyyMMddHHmmss}";

                case DateFormat.Date:
                    return $"{date:yyyyMMdd}";

                case DateFormat.Undefined:
                default:
                    return date.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}
