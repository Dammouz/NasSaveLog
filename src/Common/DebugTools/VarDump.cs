using Common.Html.Maker;
using Newtonsoft.Json;

namespace Common.DebugTools
{
    public static class VarDump
    {
        /// <summary>
        /// HTML format VarDumpJson into "pre".
        /// </summary>
        /// <param name="objectToDump">object to display</param>
        /// <returns>HTML formated trees of properties</returns>
        public static string VarDumpFormatHtml(object objectToDump)
        {
            return HtmlFormatter.HtmlFormatPre(VarDumpJson(objectToDump));
        }

        /// <summary>
        /// Equivalent of var_dump in PHP, permit to display all propertes of an object, into JSON format.
        /// </summary>
        /// <param name="objectToDump">object to dump</param>
        /// <returns></returns>
        public static string VarDumpJson(object objectToDump)
        {
            return VarDumpJson(objectToDump, Formatting.Indented);
        }

        /// <summary>
        /// Equivalent of var_dump in PHP, permit to display all propertes of an object, into JSON format.
        /// </summary>
        /// <param name="objectToDump">object to dump</param>
        /// <param name="format">special format</param>
        /// <returns></returns>
        public static string VarDumpJson(object objectToDump, Formatting format)
        {
            return JsonConvert.SerializeObject(objectToDump, format);
        }

        /// <summary>
        /// Equivalent of var_dump in PHP, permit to display all propertes of an object, into JSON without line break.
        /// </summary>
        /// <param name="objectToDump">object to dump</param>
        /// <returns></returns>
        public static string VarDumpJsonUnformatted(object objectToDump)
        {
            return VarDumpJson(objectToDump, Formatting.None);
        }
    }
}
