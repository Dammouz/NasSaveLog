namespace Common
{
    /// <summary>
    /// Static class CommonHtmlStyle.
    /// Common HTML CSS style.
    /// </summary>
    public static class CommonHtmlStyle
    {
        #region HTML color string

        public static readonly string HtmlColorOk = "green";
        public static readonly string HtmlColorNok = "red";

        #endregion HTML color string

        #region HTML table style

        public static readonly string TableCssStyle = " font-family: Arial, Helvetica, sans-serif;"
                                                  + " width: 100%;"
                                                  + " border-collapse: collapse;"
                                                  + " border: 1px solid #98BF21;"
                                                  + " margin-bottom: 10px;";
        public static readonly string TableCssCaption = " color: black;"
                                                      + " font-size: 1.5em;"
                                                      + " font-weight: bold;"
                                                      + " margin-bottom: 5px;";
        public static readonly string TableCssCells = " font-size: 1.0em;"
                                                    + " border: 1px solid #98BF21;"
                                                    + " padding: 3px 7px 2px 7px;";
        public static readonly string TableCssCellHeader = " background-color: #87B300;"
                                                         + " color: #FFF;"
                                                         + " font-size: 1.4em;"
                                                         + " text-align: left;"
                                                         + " padding-top: 5px;"
                                                         + " padding-bottom: 4px;";
        public static readonly string TableCssCell = " background-color: #FFF;"
                                                   + " color: #000;";
        public static readonly string TableCssCellAlt = " background-color: #EAF2D3;";

        #endregion HTML table style
    }
}
