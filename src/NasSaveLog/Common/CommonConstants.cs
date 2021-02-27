using System;
using Common;

namespace NasSaveLog.Common
{
    public static class CommonConstants
    {
        #region Soft informations

        public static readonly string SoftCompanyName = "Dammouz";
        public static readonly string SoftAuthor = "Dammouz";
        public static readonly string SoftVersion = "0.1.0.0";
        public static readonly string SoftName = "NasSaveLog";
        public static readonly DateTime SoftDateTime = CommonText.AssemblyDate(System.Reflection.Assembly.GetExecutingAssembly());
        public static readonly string SoftDate = SoftDateTime.ToString();

        #endregion Soft informations
    }
}
