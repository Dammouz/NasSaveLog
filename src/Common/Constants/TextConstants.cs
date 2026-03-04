using System;

namespace Common.Constants
{
    public static class TextConstants
    {
        // Several new line
        public static readonly string NewLine = Environment.NewLine;
        public const string NewLineHtml = "<br/>";

        // Replace char
        public const string ReplaceChar = "_";

        // Regex pattern
        public const string RegexValidPath = @"^[\w\-. ]+$";
    }
}
