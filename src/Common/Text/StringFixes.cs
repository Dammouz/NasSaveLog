using System.Text.RegularExpressions;
using Common.Constants;

namespace Common.Text
{
    public static class StringFixes
    {
        /// <summary>
        /// Trim the end of a string.
        /// </summary>
        /// <param name="input">string to trim</param>
        /// <param name="suffixToRemove">suffix to remove</param>
        /// <returns>trimed string</returns>
        public static string StringTrimEnd(string input, string suffixToRemove)
        {
            return (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(suffixToRemove) || !input.EndsWith(suffixToRemove))
                     ? input
                     : input.Substring(0, input.Length - suffixToRemove.Length);
        }

        /// <summary>
        /// Make a valid file name.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileName(string name)
        {
            return MakeValidFileName(name, null);
        }

        /// <summary>
        /// Make a valid file name.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <param name="replacementChar">replacement char for non valid char</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileName(string name, string replacementChar)
        {
            return Regex.Replace(name, TextConstants.RegexValidPath, replacementChar ?? TextConstants.ReplaceChar);
        }

        /// <summary>
        /// Make a valid file name from invalid chars.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileNameFromInvalid(string name)
        {
            return MakeValidFileNameFromInvalid(name, null);
        }

        /// <summary>
        /// Make a valid file name from invalid chars.
        /// </summary>
        /// <param name="name">name to sanitize</param>
        /// <param name="replacementChar">replacement char for non valid char</param>
        /// <returns>sanitized name</returns>
        public static string MakeValidFileNameFromInvalid(string name, string replacementChar)
        {
            var invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, replacementChar ?? TextConstants.ReplaceChar);
        }
    }
}
