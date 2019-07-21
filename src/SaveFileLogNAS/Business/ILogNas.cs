using System;
using System.Collections.Generic;

namespace SaveFileLogNAS.Business
{
   public interface ILogNas
   {
      /// <summary>
      /// Content.
      /// </summary>
      string Content { get; set; }
      IEnumerable<string> Contents { get; set; }

      /// <summary>
      /// Dates.
      /// </summary>
      DateTime LogDateTime { get; set; }

      /// <summary>
      /// Log info.
      /// </summary>
      string LogInfo { get; set; }

      /// <summary>
      /// Errors.
      /// </summary>
      bool IsError { get; set; }
      string LogType { get; }

      /// <summary>
      /// File name.
      /// </summary>
      string LogExt { get; set; }
      string FullLogName { get; }

      /// <summary>
      /// Paths.
      /// </summary>
      string Path { get; set; }
      string FullPath { get; }
   }
}
