namespace Common.Html.Maker
{
    public static class HtmlFile
    {
        /// <summary>
        /// Add CSS file for HTML.
        /// </summary>
        /// <param name="styleFile">CSS path</param>
        /// <returns></returns>
        public static string MakeHtmlStyleFile(string styleFile)
        {
            return $"<link rel=\"stylesheet\" href=\"{styleFile}\">";
        }


        /// <summary>
        /// Create a CSS for HTML.
        /// </summary>
        /// <param name="styleContent">content of CSS</param>
        /// <returns></returns>
        public static string MakeHtmlStyle(string styleContent)
        {
            return $"<style type=\"text/css\">{styleContent}</style>";
        }


        /// <summary>
        /// Add JS file for HTML.
        /// </summary>
        /// <param name="scriptFile">JS path</param>
        /// <returns></returns>
        public static string MakeHtmlScriptFile(string scriptFile)
        {
            return $"<script type=\"text/javascript\" src=\"{scriptFile}\"></script>";
        }

        /// <summary>
        /// Create a JS for HTML.
        /// </summary>
        /// <param name="scriptContent">content of script</param>
        /// <returns></returns>
        public static string MakeHtmLscript(string scriptContent)
        {
            return $"<script type=\"text/javascript\">{scriptContent}</script>";
        }
    }
}
