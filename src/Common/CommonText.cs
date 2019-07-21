using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
   /// <summary>
   /// Static class CommonText.
   /// Common text functions to format texts of HTML.
   /// </summary>
   public static class CommonText
   {
      #region ConstString

      // Several new line
      public static readonly string NewLine = Environment.NewLine;
      public static readonly string NewLineHtml = "<br/>";

      // Replace char
      public static readonly string ReplaceChar = "_";

      // Regex pattern
      public static readonly string RegexValidPath = @"^[\w\-. ]+$";

      #endregion


      #region Log

      /// <summary>
      /// Log message with formated date.
      /// </summary>
      /// <param name="messageToLog">Message to log</param>
      /// <returns>Logged message</returns>
      public static string LogMsg(string messageToLog)
      {
         Console.WriteLine($"{FormatDate(DateTime.Now, DateFormat.DateDebug)} : {messageToLog}");   // Debug
         return $"{NewLine}{FormatDate(DateTime.Now, DateFormat.DateDebug)} : {messageToLog}";
      }

      #endregion


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

      #endregion


      #region AssemblyDate

      /// <summary>
      /// Format the date of assembly.
      /// </summary>
      /// <returns>Assembly date</returns>
      public static DateTime AssemblyDate(System.Reflection.Assembly assembly = null)
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

      #endregion


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
      public static string MakeValidFileName(string name, string replacementChar =  null)
      {
         return Regex.Replace(name, RegexValidPath, replacementChar ?? ReplaceChar);
      }

      /// <summary>
      /// Make a valid file name from invalid chars.
      /// </summary>
      /// <param name="name">Name to sanitize</param>
      /// <returns>Sanitized name</returns>
      public static string MakeValidFileNameFromInvalid(string name, string replacementChar = null)
      {
         var invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
         var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

         return Regex.Replace(name, invalidRegStr, ReplaceChar);
      }

      #endregion


      #region HTMLInfoText

      /// <summary>
      /// Format to "pre" HTML.
      /// </summary>
      /// <param name="toFormat"></param>
      /// <returns>REturn "pre" string</returns>
      public static string HtmlFormatPre(string toFormat)
      {
         return $"<pre>{toFormat}</pre>{NewLineHtml}";
      }

      /// <summary>
      /// Make OK message.
      /// </summary>
      /// <param name="msgOk">Message OK</param>
      /// <returns></returns>
      public static string MakeHtmlCheckOk(string msgOk)
      {
         return $"<span style=\"font-weight:bold; color:{CommonHtmlStyle.HtmlColorOk};\">{msgOk}</span>";
      }

      /// <summary>
      /// Make NOK message.
      /// </summary>
      /// <param name="msgNok">Message NOK</param>
      /// <returns></returns>
      public static string MakeHtmlCheckNok(string msgNok)
      {
         return $"<span style=\"font-weight:bold; color:{CommonHtmlStyle.HtmlColorNok};\">{msgNok}</span>";
      }

      #endregion


      #region HTMLFile

      /// <summary>
      /// Add CSS file for HTML.
      /// </summary>
      /// <param name="styleFile">CSS path</param>
      /// <returns></returns>
      public static string MakeHtmlStyleFile(string styleFile)
      {
         return $"<link rel=\"stylesheet\" href=\"{styleFile}\">";
      }


      /// <summary>
      /// Create a CSS for HTML.
      /// </summary>
      /// <param name="styleContent">Content of CSS</param>
      /// <returns></returns>
      public static string MakeHtmlStyle(string styleContent)
      {
         return $"<style type=\"text/css\">{styleContent}</style>";
      }


      /// <summary>
      /// Add JS file for HTML.
      /// </summary>
      /// <param name="scriptFile">JS path</param>
      /// <returns></returns>
      public static string MakeHtmlScriptFile(string scriptFile)
      {
         return $"<script type=\"text/javascript\" src=\"{scriptFile}\"></script>";
      }

      /// <summary>
      /// Create a JS for HTML.
      /// </summary>
      /// <param name="scriptContent">Content of script</param>
      /// <returns></returns>
      public static string MakeHtmLscript(string scriptContent)
      {
         return $"<script type=\"text/javascript\">{scriptContent}</script>";
      }

      #endregion


      #region HTMLTable

      /// <summary>
      /// Make the table.
      /// </summary>
      /// <param name="tableId">ID of the table</param>
      /// <param name="tableCaption">Remarks of the table</param>
      /// <param name="tableHeader">Name of the columns</param>
      /// <param name="tableContent">List of the content cells</param>
      /// <returns></returns>
      public static StringBuilder MakeHtmlTable(string tableId, string tableCaption, string[] tableHeader, IEnumerable<string[]> tableContent)
      {
         var sbTable = new StringBuilder();
         tableId += "Table";
         sbTable.Append(MakeHtmlTableStyle(tableId));
         sbTable.Append(MakeHtmlTableBegin(tableId));
         sbTable.Append(MakeHtmlTableCaption(tableCaption));
         sbTable.Append(MakeHtmlTableHeader(tableHeader));
         sbTable.Append(MakeHtmlTableBody(tableContent));
         sbTable.Append(MakeHtmlTableEnd());

         return sbTable;
      }

      /// <summary>
      /// Make the style of the table.
      /// </summary>
      /// <param name="tableId">ID of the table</param>
      /// <returns></returns>
      public static string MakeHtmlTableStyle(string tableId)
      {
         return MakeHtmlStyle($"#{tableId} {{{CommonHtmlStyle.TableCssStyle}}}"
                              + $" #{tableId} caption {{{CommonHtmlStyle.TableCssCaption}}}"
                              + $" #{tableId} td, #{tableId} th {{{CommonHtmlStyle.TableCssCells}}}"
                              + $" #{tableId} th {{{CommonHtmlStyle.TableCssCellHeader}}}"
                              + $" #{tableId} tr td {{{CommonHtmlStyle.TableCssCell}}}"
                              + $" #{tableId} tr.alt td {{{CommonHtmlStyle.TableCssCellAlt}}}");
      }

      /// <summary>
      /// Open the table.
      /// </summary>
      /// <param name="tableId">ID of the table</param>
      /// <returns></returns>
      public static string MakeHtmlTableBegin(string tableId)
      {
         return $"<table id=\"{tableId}\" class=\"{tableId} tableWithFloatingHeader\">";
      }

      /// <summary>
      /// Make the caption of the table.
      /// </summary>
      /// <param name="tableCaption">Title of the table</param>
      /// <returns></returns>
      public static string MakeHtmlTableCaption(string tableCaption)
      {
         return $"<caption>{tableCaption}</caption>";
      }

      /// <summary>
      /// Make the header of the table.
      /// </summary>
      /// <param name="tableHeader">Name of the columns</param>
      /// <returns></returns>
      public static string MakeHtmlTableHeader(string[] tableHeader)
      {
         var sbResultHeader = new StringBuilder("<thead><tr>");

         foreach (var headerTitle in tableHeader)
         {
            sbResultHeader.Append($"<th>{headerTitle}</th>");
         }
         sbResultHeader.Append("</tr></thead>");

         return sbResultHeader.ToString();
      }

      /// <summary>
      /// Make the content of the table.
      /// </summary>
      /// <param name="tableContent">List of the content cells</param>
      /// <returns></returns>
      public static string MakeHtmlTableBody(IEnumerable<string[]> tableContent)
      {
         var resultContent = new StringBuilder();
         var isRowAlt = false;

         resultContent.Append("<tbody>");
         foreach (var rowOfCells in tableContent)
         {
            var rowAltClass = isRowAlt ? " class=\"alt\"" : "";
            resultContent.Append($"<tr{rowAltClass}>");
            foreach (var cell in rowOfCells)
            {
               resultContent.Append($"<td>{cell}</td>");
            }
            resultContent.Append("</tr>");
            isRowAlt = !isRowAlt;
         }
         resultContent.Append("</tbody>");

         return resultContent.ToString();
      }

      /// <summary>
      /// Close the table.
      /// </summary>
      /// <returns></returns>
      public static string MakeHtmlTableEnd()
      {
         return "</table>";
      }

      #endregion
   }
}
