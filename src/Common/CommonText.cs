using System;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// Static class CommonText.
    /// Common text functions to format texts of HTML.
    /// </summary>
    public static class CommonText
    {
        #region Log

        /// <summary>
        /// Log message with formated date.
        /// </summary>
        /// <param name="messageToLog">Message to log</param>
        /// <returns>Logged message</returns>
        public static string LogMsg(string messageToLog)
        {
            Console.WriteLine($"{FormatDate(DateTime.Now, DateFormat.DateDebug)} : {messageToLog}"); // Debug

            return $"{ComonTextConstants.NewLine}{FormatDate(DateTime.Now, DateFormat.DateDebug)} : {messageToLog}";
        }

        #endregion Log

        #region Date

        /// <summary>
        /// Formate date in function of a pattern.
        /// </summary>
        /// <param name="date">Date to format</param>
        /// <param name="format">Pattern</param>
        /// <returns>Formated date</returns>
        public static string FormatDate(DateTime date, DateFormat format)
        {
            switch (format)
            {
                case DateFormat.DateDebug:
                    return $"{date:yyyy-MM-dd HH:mm:ss.fffffff}";

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

        #endregion Date

        #region AssemblyDate

        /// <summary>
        /// Format the date of assembly.
        /// </summary>
        /// <returns>Assembly date</returns>
        public static DateTime AssemblyDate()
        {
            return AssemblyDate(null);
        }

        /// <summary>
        /// Format the date of assembly.
        /// </summary>
        /// <param name="assembly">Assembly to analyze</param>
        /// <returns>Assembly date</returns>
        public static DateTime AssemblyDate(System.Reflection.Assembly assembly)
        {
            assembly = assembly ?? System.Reflection.Assembly.GetExecutingAssembly();
            // Assumes that in AssemblyInfo.cs, the version is specified as 1.0.* or the like,
            // with only 2 numbers specified; the next two are generated from the date.
            // This routine decodes them.
            var version = assembly.GetName().Version;

            // v.Build is days since Jan. 1, 2000
            // v.Revision * 2 is seconds since local midnight
            // (NEVER daylight saving time)
            return new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        .Add(new TimeSpan(TimeSpan.TicksPerDay * version.Build + TimeSpan.TicksPerSecond * 2 * version.Revision));
        }

        #endregion AssemblyDate

        #region StringFixes

        /// <summary>
        /// Trim the end of a string.
        /// </summary>
        /// <param name="input">String to trim</param>
        /// <param name="suffixToRemove">Suffix to remove</param>
        /// <returns>Trimed string</returns>
        public static string StringTrimEnd(string input, string suffixToRemove)
        {
            return (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(suffixToRemove) || !input.EndsWith(suffixToRemove))
                     ? input
                     : input.Substring(0, input.Length - suffixToRemove.Length);
        }

        /// <summary>
        /// Make a valid file name.
        /// </summary>
        /// <param name="name">Name to sanitize</param>
        /// <returns>Sanitized name</returns>
        public static string MakeValidFileName(string name)
        {
            return MakeValidFileName(name, null);
        }

        /// <summary>
        /// Make a valid file name.
        /// </summary>
        /// <param name="name">Name to sanitize</param>
        /// <param name="replacementChar">Replacement char for non valid char</param>
        /// <returns>Sanitized name</returns>
        public static string MakeValidFileName(string name, string replacementChar)
        {
            return Regex.Replace(name, ComonTextConstants.RegexValidPath, replacementChar ?? ComonTextConstants.ReplaceChar);
        }

        /// <summary>
        /// Make a valid file name from invalid chars.
        /// </summary>
        /// <param name="name">Name to sanitize</param>
        /// <returns>Sanitized name</returns>
        public static string MakeValidFileNameFromInvalid(string name)
        {
            return MakeValidFileNameFromInvalid(name, null);
        }

        /// <summary>
        /// Make a valid file name from invalid chars.
        /// </summary>
        /// <param name="name">Name to sanitize</param>
        /// <param name="replacementChar">Replacement char for non valid char</param>
        /// <returns>Sanitized name</returns>
        public static string MakeValidFileNameFromInvalid(string name, string replacementChar)
        {
            var invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, replacementChar ?? ComonTextConstants.ReplaceChar);
        }

        #endregion StringFixes
    }
}
