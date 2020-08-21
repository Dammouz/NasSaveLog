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
    }
}
