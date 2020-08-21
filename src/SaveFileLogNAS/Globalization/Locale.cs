using System.Globalization;
using System.Linq;
using Common.Extensions;

namespace SaveFileLogNAS.Globalization
{
    public static class Locale
    {
        /// <summary>
        /// Make language depending on string.
        /// </summary>
        /// <returns></returns>
        public static IGui MakeLocales(string locale)
        {
            if (locale.IsNotNullNorEmpty() && IsExistingCulture(locale))
            {
                return GetLocaleGui(locale);
            }

            CultureInfo ci = CultureInfo.InstalledUICulture;
            return GetLocaleGui(ci.Name);
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
