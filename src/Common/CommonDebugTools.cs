using System.Collections;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common
{
   /// <summary>
   /// Static class DebugTools.
   /// Several tools to debug.
   /// </summary>
   public static class CommonDebugTools
   {
      #region VarDump

      /// <summary>
      /// HTML format VarDump into "pre".
      /// </summary>
      /// <param name="obj">Object to display</param>
      /// <param name="recursion">Depth of the recursion</param>
      /// <returns>Returns HML formated trees of properties</returns>
      public static string VarDumpFormatHtml(object obj, int recursion)
      {
         return CommonText.HtmlFormatPre(VarDump(obj, recursion));
      }


      /// <summary>
      /// Equivalent of Var_Dump in PHP, permit to display all propertes of an object.
      /// </summary>
      /// <param name="obj">Object to display</param>
      /// <param name="recursion">Depth of the recursion</param>
      /// <returns>Returns trees of properties</returns>
      public static string VarDump(object obj, int recursion)
      {
         const int maxRecursion = 5;
         const string space = "|   ";
         const string trail = "|-- ";
         const string newLine = "\n";
         var result = new StringBuilder();

         // Protect the method against endless recursion and stop the function
         if (recursion >= maxRecursion)
         {
            return result.ToString();
         }

         // If recursion < maxRecursion, continue:
         // Determine object type
         var t = obj.GetType();
         // Get array with properties for this object
         var properties = t.GetProperties();

         foreach (var property in properties)
         {
            try
            {
               // Get the property value
               object value = property.GetValue(obj, null);

               // Create indenting string to put in front of properties of a deeper level.
               // We'll need this when we display the property name and value
               var indent = string.Empty;

               if (recursion > 0)
               {
                  indent = new StringBuilder(trail).Insert(0, space, recursion - 1).ToString();
               }

               if (value != null)
               {
                  // If the value is a string, add quotation marks
                  var displayValue = (value is string) ? $"\"{value}\"" : value.ToString();

                  // Add property name and value to return string
                  result.Append($"{indent}{property.Name} = {displayValue}{newLine}");

                  try
                  {
                     if (!(value is ICollection))
                     {
                        // Call VarDump() again to list child properties.
                        // This throws an exception if the current property value is of an unsupported type
                        // (eg. it has not properties)
                        result.Append(VarDump(value, recursion + 1));
                     }
                     else
                     {
                        // The value is a collection (eg. it's an arraylist or generic list)
                        // so loop through its elements and dump their properties
                        var elementCount = 0;
                        foreach (object element in (ICollection)value)
                        {
                           var elementName = $"{property.Name}[{elementCount}]";
                           indent = new StringBuilder(trail).Insert(0, space, recursion).ToString();

                           // Display the collection element name and type
                           result.Append($"{indent}{elementName} = {element.ToString()}{newLine}");

                           // Display the child properties
                           result.Append(VarDump(element, recursion + 2));
                           elementCount++;
                        }

                        result.Append(VarDump(value, recursion + 1));
                     }
                  }
                  catch { }
               }
               else
               {
                  // Add empty (null) property to return string
                  result.Append($"{indent}{property.Name} = null{newLine}");
               }
            }
            catch
            {
               // Some properties will throw an exception on property.GetValue()
               // I don't know exactly why this happens, so for now i will ignore them...
            }
         }
         return result.ToString();
      }


      /// <summary>
      /// Equivalent of Var_Dump in PHP, permit to display all propertes of an object, into JSON format.
      /// </summary>
      /// <param name="objectToDump">object to dump</param>
      /// <returns></returns>
      public static string VarDumpJson(object objectToDump)
      {
         return VarDumpJson(objectToDump, Formatting.Indented);
      }

      /// <summary>
      /// Equivalent of Var_Dump in PHP, permit to display all propertes of an object, into JSON without line break.
      /// </summary>
      /// <param name="objectToDump">object to dump</param>
      /// <returns></returns>
      public static string VarDumpJsonUnFormatted(object objectToDump)
      {
         return VarDumpJson(objectToDump, Formatting.None);
      }

      /// <summary>
      /// Equivalent of Var_Dump in PHP, permit to display all propertes of an object, into JSON format.
      /// </summary>
      /// <param name="objectToDump">object to dump</param>
      /// <param name="format">special format</param>
      /// <returns></returns>
      public static string VarDumpJson(object objectToDump, Formatting format)
      {
         return JsonConvert.SerializeObject(objectToDump, format);
      }

      #endregion
   }
}
