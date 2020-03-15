using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    /// <summary>
    /// Static class CommonWriteStream.
    /// Common functions to write into stream.
    /// </summary>
    public static class CommonWriteStream
    {
        #region WriteIntoFile

        /// <summary>
        /// Write text in a file with secure path.
        /// </summary>
        /// <param name="filePath">Path to fhe file</param>
        /// <param name="fileName">File name</param>
        /// <param name="fileContent">Content to write</param>
        /// <param name="appendToFile">Append content to file</param>
        /// <returns>Writing is OK or NOK</returns>
        public static bool WriteFilePath(string filePath, string fileName, string fileContent, bool appendToFile = true)
        {
            Console.WriteLine(fileContent);
            bool isOk;
            try
            {
                using (var swFile = new StreamWriter(Path.Combine(filePath, fileName), appendToFile, Encoding.UTF8))
                {
                    swFile.WriteLine(fileContent);
                }
                isOk = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isOk = WriteFilePath(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), fileName, fileContent, appendToFile);
            }

            return isOk;
        }

        /// <summary>
        /// Write text in a file with secure path.
        /// </summary>
        /// <param name="filePath">Path to fhe file</param>
        /// <param name="fileName">File name</param>
        /// <param name="fileContents">Enumerable of content to write</param>
        /// <param name="appendToFile">Append content to file</param>
        /// <returns>Writing is OK or NOK</returns>
        /// <returns></returns>
        public static bool WriteFilePath(string filePath, string fileName, IEnumerable<string> fileContents, bool appendToFile = true)
        {
            var fileContent = string.Join(ComonTextConstants.NewLine, fileContents);

            return WriteFilePath(filePath, fileName, fileContent, appendToFile);
        }

        #endregion WriteIntoFile

        #region WriteIntoStream

        /// <summary>
        /// Write stream into file.
        /// </summary>
        /// <param name="msg">Messageto write into log</param>
        /// <param name="path">Path to log file</param>
        /// <param name="mode">Opening file mode</param>
        /// <param name="access">Access file mode</param>
        /// <returns>Wrinting is OK or NOK</returns>
        public static bool SendToStream(string msg, string path, FileMode mode, FileAccess access)
        {
            try
            {
                using (var fs = File.Open(path, mode, access))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(CommonText.FormatDate(DateTime.Now, DateFormat.DateDebug));
                        sw.WriteLine(msg);
                        sw.WriteLine();
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

        #endregion WriteIntoStream
    }
}
