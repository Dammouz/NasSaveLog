using System.Globalization;
using System.Linq;

namespace SaveFileLogNAS.Globalization
{
   public class Locale
   {
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
         switch(locale)
         {
            case "fr-FR":
               return new GuiFrench();

            case "en-us":
            default:
               return new GuiEnglish();
         }
      }
   }
}
