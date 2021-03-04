namespace Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Verify if the string is not null and not empty.
        /// </summary>
        /// <param name="stringToCheck">string to check</param>
        /// <returns></returns>
        public static bool IsNotNullNorEmpty(this string stringToCheck)
        {
            return stringToCheck != null && stringToCheck.Length > 0;
        }

        /// <summary>
        /// Trim the end of a string.
        /// </summary>
        /// <param name="input">string to trim</param>
        /// <param name="suffixToRemove">suffix to remove</param>
        /// <returns>trimed string</returns>
        public static string StringTrimEnd(this string input, string suffixToRemove)
        {
            return (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(suffixToRemove) || !input.EndsWith(suffixToRemove))
                     ? input
                     : input.Substring(0, input.Length - suffixToRemove.Length);
        }
    }
}
