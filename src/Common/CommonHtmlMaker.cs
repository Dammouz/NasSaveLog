using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class CommonHtmlMaker
    {
        #region HTMLInfoText

        /// <summary>
        /// Format to "pre" HTML.
        /// </summary>
        /// <param name="toFormat"></param>
        /// <returns>REturn "pre" string</returns>
        public static string HtmlFormatPre(string toFormat)
        {
            return $"<pre>{toFormat}</pre>{ComonTextConstants.NewLineHtml}";
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

        #endregion HTMLInfoText

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

        #endregion HTMLFile

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
                var rowAltClass = isRowAlt ? " class=\"alt\"" : string.Empty;
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

        #endregion HTMLTable
    }
}
