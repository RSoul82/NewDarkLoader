using System.IO;

namespace NewDarkLoader
{
    class WriteLog
    {
        /// <summary>
        /// Calls File.AppendAllText but inserts a newline char before the text.
        /// </summary>
        /// <param name="filePath">Full path of log file.</param>
        /// <param name="content">Text to add.</param>
        public static void AddEntry(string filePath, string content)
        {
            File.AppendAllText(filePath, "\n" + content);
        }
    }
}
