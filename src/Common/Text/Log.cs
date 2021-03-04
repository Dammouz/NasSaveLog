using System;
using Common.Constants;
using Common.Enums;

namespace Common.Text
{
    public static class Log
    {
        /// <summary>
        /// Log message with formated date.
        /// </summary>
        /// <param name="messageToLog">message to log</param>
        /// <returns>logged message</returns>
        public static string LogMessage(string messageToLog)
        {
            Console.WriteLine($"{Date.FormatDate(DateTime.UtcNow, DateFormat.DateLog)} : {messageToLog}"); // Debug
            return $"{TextConstants.NewLine}{Date.FormatDate(DateTime.UtcNow, DateFormat.DateLog)} : {messageToLog}";
        }
    }
}
