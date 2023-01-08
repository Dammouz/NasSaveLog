using System.Text.RegularExpressions;
using Common.Constants;

namespace Common.Extensions
{
    public static class FileNameExtensions
    {
        /// <summary>
        /// Make a valid file name.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileName(this string name)
        {
            return name.MakeValidFileName(null);
        }

        /// <summary>
        /// Make a valid file name.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <param name="replacementChar">replacement char for non valid char</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileName(this string name, string replacementChar)
        {
            return Regex.Replace(name, TextConstants.RegexValidPath, replacementChar ?? TextConstants.ReplaceChar);
        }

        /// <summary>
        /// Make a valid file name from invalid chars.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileNameFromInvalid(this string name)
        {
            return name.MakeValidFileNameFromInvalid(null);
        }

        /// <summary>
        /// Make a valid file name from invalid chars.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <param name="replacementChar">replacement char for non valid char</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileNameFromInvalid(this string name, string replacementChar)
        {
            var invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, replacementChar ?? TextConstants.ReplaceChar);
        }
    }
}
