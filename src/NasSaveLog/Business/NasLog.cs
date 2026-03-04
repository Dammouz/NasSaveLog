using System;
using System.Collections.Generic;
using Common.Enums;
using Common.Extensions;
using Common.Text;

namespace NasSaveLog.Business
{
    internal class NasLog : INasLog
    {
        internal NasLog(string appName)
        {
            FullLogName = appName;
        }

        /// <summary>
        /// Content.
        /// </summary>
        public string Content { get; set; }
        public IEnumerable<string> Contents { get; set; }

        /// <summary>
        /// Dates.
        /// </summary>
        public DateTime LogDateTime { get; set; }

        /// <summary>
        /// Log info.
        /// </summary>
        public string LogInfo { get; set; }

        /// <summary>
        /// Errors.
        /// </summary>
        public bool IsError { get; set; }
        public string LogType => IsError ? "error" : "log";

        /// <summary>
        /// File name.
        /// </summary>
        public string LogExt { get; set; } = "log";
        public string FullLogName => $"{field}-{LogType}-{DateHelper.FormatDate(LogDateTime, DateFormat.DateFile)}-{LogInfo.MakeValidFileNameFromInvalid()}.{LogExt}";

        /// <summary>
        /// Paths.
        /// </summary>
        public string Path { get; set; }
        public string FullPath => System.IO.Path.Combine(Path, FullLogName);
    }
}
