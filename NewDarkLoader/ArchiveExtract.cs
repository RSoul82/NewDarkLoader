using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDarkLoader
{
    class ArchiveExtract
    {
        /// <summary>
        /// NewDark cann't have . + or ~ in the folder name. This method replaces them with _
        /// </summary>
        /// <param name="archiveSimpleName">Simple filename without extension.</param>
        /// <returns></returns>
        public static string ArchiveExtracedFolderName(string archiveSimpleName)
        {
            string checkLength = "";

            if (archiveSimpleName.Length > 30)
            {
                StringBuilder limited = new StringBuilder();
                for (int i = 0; i < 30; i++)
                {
                    limited.Append(archiveSimpleName[i]);
                }
                checkLength = limited.ToString();
            }
            else
                checkLength = archiveSimpleName;

            StringBuilder replaceChars = new StringBuilder(checkLength);

            replaceChars.Replace(' ', '_');
            replaceChars.Replace('+', '_');
            replaceChars.Replace('.', '_');
            replaceChars.Replace('~', '_');

            return replaceChars.ToString();
        }
    }
}
