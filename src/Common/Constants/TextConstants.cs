using System;

namespace Common.Constants
{
    public static class TextConstants
    {
        // Several new line
        public static readonly string NewLine = Environment.NewLine;
        public static readonly string NewLineHtml = "<br/>";

        // Replace char
        public static readonly string ReplaceChar = "_";

        // Regex pattern
        public static readonly string RegexValidPath = @"^[\w\-. ]+$";
    }
}
