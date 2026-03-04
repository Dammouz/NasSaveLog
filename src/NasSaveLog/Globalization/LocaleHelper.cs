using System.Globalization;
using System.Linq;

namespace NasSaveLog.Globalization
{
    internal static class LocaleHelper
    {
        /// <summary>
        /// Make language depending on string.
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static IGui MakeLocales(string locale)
        {
            if (!string.IsNullOrEmpty(locale) && IsExistingCulture(locale))
            {
                return GetLocaleGui(locale);
            }

            var installedCulture = CultureInfo.InstalledUICulture;
            return GetLocaleGui(installedCulture.Name);
        }

        /// <summary>
        /// Verify if the specified culture is existing.
        /// </summary>
        /// <param name="locale">culture name</param>
        /// <returns></returns>
        public static bool IsExistingCulture(string locale)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures).Select(c => c.Name).Contains(locale);
        }

        /// <summary>
        /// Get the corresponding Locale object from culture name.
        /// </summary>
        /// <param name="locale">culture name</param>
        /// <returns></returns>
        public static IGui GetLocaleGui(string locale)
        {
            switch (locale)
            {
                case "fr-FR":
                    return new GuiFrench();

                case "en-US":
                default:
                    return new GuiEnglish();
            }
        }
    }
}
