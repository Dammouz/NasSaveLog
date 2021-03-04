using System;
using System.IO;
using Common.Enums;
using Common.Text;

namespace Common.WriteStream
{
    /// <summary>
    /// Common functions to write into stream.
    /// </summary>
    public static class WriteIntoStream
    {
        /// <summary>
        /// Write stream into file.
        /// </summary>
        /// <param name="message">messageto write into log</param>
        /// <param name="path">path to log file</param>
        /// <param name="mode">opening file mode</param>
        /// <param name="access">access file mode</param>
        /// <returns>writing is OK or NOK</returns>
        public static bool SendToStream(string message, string path, FileMode mode, FileAccess access)
        {
            try
            {
                using (var fileStream = File.Open(path, mode, access))
                {
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine(Date.FormatDate(DateTime.UtcNow, DateFormat.DateDebug));
                        streamWriter.WriteLine(message);
                        streamWriter.WriteLine();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
