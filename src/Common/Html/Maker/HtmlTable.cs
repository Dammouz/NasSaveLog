using System.Collections.Generic;
using System.Text;
using Common.Html.Style;

namespace Common.Html.Maker
{
    public static class HtmlTable
    {
        /// <summary>
        /// Make the table.
        /// </summary>
        /// <param name="tableId">ID of the table</param>
        /// <param name="tableCaption">remarks of the table</param>
        /// <param name="tableHeader">name of the columns</param>
        /// <param name="tableContent">list of the content cells</param>
        /// <returns></returns>
        public static string MakeHtmlTable(string tableId, string tableCaption, string[] tableHeader, IEnumerable<string[]> tableContent)
        {
            tableId += "Table";
            var table = new StringBuilder(MakeHtmlTableStyle(tableId));
            table.Append(MakeHtmlTableBegin(tableId));
            table.Append(MakeHtmlTableCaption(tableCaption));
            table.Append(MakeHtmlTableHeader(tableHeader));
            table.Append(MakeHtmlTableBody(tableContent));
            table.Append(MakeHtmlTableEnd);

            return table.ToString();
        }

        /// <summary>
        /// Make the style of the table.
        /// </summary>
        /// <param name="tableId">ID of the table</param>
        /// <returns></returns>
        public static string MakeHtmlTableStyle(string tableId)
        {
            return HtmlFile.MakeHtmlStyle($"#{tableId} {{{HtmlTableStyle.TableCssStyle}}}"
                                 + $" #{tableId} caption {{{HtmlTableStyle.TableCssCaption}}}"
                                 + $" #{tableId} td, #{tableId} th {{{HtmlTableStyle.TableCssCells}}}"
                                 + $" #{tableId} th {{{HtmlTableStyle.TableCssCellHeader}}}"
                                 + $" #{tableId} tr td {{{HtmlTableStyle.TableCssCell}}}"
                                 + $" #{tableId} tr.alt td {{{HtmlTableStyle.TableCssCellAlt}}}");
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

            return sbResultHeader.Append("</tr></thead>").ToString();
        }

        /// <summary>
        /// Make the content of the table.
        /// </summary>
        /// <param name="tableContent">List of the content cells</param>
        /// <returns></returns>
        public static string MakeHtmlTableBody(IEnumerable<string[]> tableContent)
        {
            var isRowAlt = false;
            var tableBodyContent = new StringBuilder("<tbody>");

            foreach (var rowOfCells in tableContent)
            {
                tableBodyContent.Append($"<tr{(isRowAlt ? " class=\"alt\"" : string.Empty)}>");

                foreach (var cell in rowOfCells)
                {
                    tableBodyContent.Append($"<td>{cell}</td>");
                }

                tableBodyContent.Append("</tr>");
                isRowAlt = !isRowAlt;
            }

            return tableBodyContent.Append("</tbody>").ToString();
        }

        /// <summary>
        /// Close the table.
        /// </summary>
        public static readonly string MakeHtmlTableEnd = "</table>";
    }
}
