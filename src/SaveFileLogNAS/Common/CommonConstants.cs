using System;

namespace Common
{
    public static class CommonConsts
    {
        #region Soft informations

        public static readonly string SoftCompanyName = "Damm's";
        public static readonly string SoftAuthor = "Damm's";
        public static readonly string SoftVersion = "0.1.0.0";
        public static readonly string SoftName = "SaveFileLogNAS";
        public static readonly DateTime SoftDateTime = CommonText.AssemblyDate(System.Reflection.Assembly.GetExecutingAssembly());
        public static readonly string SoftDate = SoftDateTime.ToString();

        #endregion Soft informations
    }
}
