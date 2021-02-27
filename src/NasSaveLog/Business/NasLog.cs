using System;
using System.Collections.Generic;
using Common;
using NasSaveLog.Common;

namespace NasSaveLog.Business
{
    public class NasLog : INasLog
    {
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
        public bool IsError { get; set; } = false;
        public string LogType => IsError ? "error" : "log";

        /// <summary>
        /// File name.
        /// </summary>
        public string LogExt { get; set; } = "log";
        public string FullLogName => $"{CommonConstants.SoftName}-{LogType}-{CommonText.FormatDate(LogDateTime, DateFormat.DateFile)}-{CommonText.MakeValidFileNameFromInvalid(LogInfo)}.{LogExt}";

        /// <summary>
        /// Paths.
        /// </summary>
        public string Path { get; set; }
        public string FullPath => System.IO.Path.Combine(Path, FullLogName);
    }
}
