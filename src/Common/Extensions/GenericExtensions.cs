using Common.DebugTools;

namespace Common.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Extension do dump any object, only public properties.
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="objectToDump">object to dump</param>
        /// <returns></returns>
        public static string Dump<T>(this T objectToDump)
        {
            return VarDump.VarDumpJson(objectToDump);
        }

        /// <summary>
        /// Extension do dump any object, only public properties, unforamtted.
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="objectToDump">object to dump</param>
        /// <returns></returns>
        public static string DumpUnFormatted<T>(this T objectToDump)
        {
            return VarDump.VarDumpJsonUnformatted(objectToDump);
        }
    }
}
