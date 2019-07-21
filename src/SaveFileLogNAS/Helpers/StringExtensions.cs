namespace SaveFileLogNAS.Helpers
{
   public static class StringExtensions
   {
      public static bool IsNotNullNorEmpty(this string stringToCheck)
      {
         return stringToCheck != null && stringToCheck.Length > 0;
      }
   }
}
