using Common.Constants;
using Common.Html.Style;

namespace Common.Html.Maker
{
    public static class HtmlFormatter
    {
        /// <summary>
        /// Format to "pre" HTML.
        /// </summary>
        /// <param name="toFormat">object to display</param>
        /// <returns>"pre" string of input</returns>
        public static string HtmlFormatPre(string toFormat)
        {
            return $"<pre>{toFormat}</pre>{TextConstants.NewLineHtml}";
        }

        /// <summary>
        /// Make OK message.
        /// </summary>
        /// <param name="msgOk">message OK</param>
        /// <returns></returns>
        public static string MakeHtmlCheckOk(string messageOk)
        {
            return MakeHtmlCheckWithColor(HtmlColor.HtmlColorOk, messageOk);
        }

        /// <summary>
        /// Make NOK message.
        /// </summary>
        /// <param name="msgNok">message NOK</param>
        /// <returns></returns>
        public static string MakeHtmlCheckNok(string messageNok)
        {
            return MakeHtmlCheckWithColor(HtmlColor.HtmlColorNok, messageNok);
        }

        /// <summary>
        /// Make a bold message with color.
        /// </summary>
        /// <param name="msgNok">message</param>
        /// <returns>boled colored message</returns>
        public static string MakeHtmlCheckWithColor(string color, string message)
        {
            return $"<span style=\"font-weight:bold; color:{color};\">{message}</span>";
        }
    }
}
