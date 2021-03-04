using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Common.Constants;

namespace Common.WriteStream
{
    public static class WriteIntoFile
    {
        /// <summary>
        /// Write text in a file with secure path.
        /// </summary>
        /// <param name="filePath">path to fhe file</param>
        /// <param name="fileName">file name</param>
        /// <param name="fileContent">content to write</param>
        /// <param name="appendToFile">append content to file</param>
        /// <returns>writing is OK or NOK</returns>
        public static bool WriteFilePath(string filePath, string fileName, string fileContent, bool appendToFile)
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
        /// <param name="filePath">path to fhe file</param>
        /// <param name="fileName">file name</param>
        /// <param name="fileContent">content to write</param>
        /// <returns>writing is OK or NOK</returns>
        public static bool WriteFilePath(string filePath, string fileName, string fileContent)
        {
            return WriteFilePath(filePath, fileName, fileContent, true);
        }

        /// <summary>
        /// Write text in a file with secure path.
        /// </summary>
        /// <param name="filePath">path to fhe file</param>
        /// <param name="fileName">file name</param>
        /// <param name="fileContents">enumerable of content to write</param>
        /// <param name="appendToFile">append content to file</param>
        /// <returns>writing is OK or NOK</returns>
        public static bool WriteFilePath(string filePath, string fileName, IEnumerable<string> fileContents, bool appendToFile)
        {
            var fileContent = string.Join(TextConstants.NewLine, fileContents);

            return WriteFilePath(filePath, fileName, fileContent, appendToFile);
        }

        /// <summary>
        /// Write text in a file with secure path.
        /// </summary>
        /// <param name="filePath">path to fhe file</param>
        /// <param name="fileName">file name</param>
        /// <param name="fileContents">enumerable of content to write</param>
        /// <returns>writing is OK or NOK</returns>
        /// <returns></returns>
        public static bool WriteFilePath(string filePath, string fileName, IEnumerable<string> fileContents)
        {
            return WriteFilePath(filePath, fileName, fileContents, true);
        }
    }
}
