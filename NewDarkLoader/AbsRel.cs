using System;
using System.IO;

namespace NewDarkLoader
{
    class AbsRel
    {
        /// <summary>
        /// Converts an absolute path to a path relative to the location of NewDarkLoader.dll.
        /// </summary>
        /// <param name="absolutePath">Path to convert.</param>
        /// <returns></returns>
        public static string AbsoluteToRelative(string absolutePath)
        {
            if (absolutePath != "")
            {
                Uri pathUri = new Uri(absolutePath);
                string currentFile = Path.Combine(Environment.CurrentDirectory, "NewDarkLoader.dll"); //Dir of running program
                Uri refUri = new Uri(currentFile);
                Uri relUri = refUri.MakeRelativeUri(pathUri);
                string finalPath = relUri.ToString().Replace("%20", " ");
                return finalPath;
            }
            else
                return "";
        }

        public static string RelativeToAbsolute(string relativePath)
        {
            string fullPath = Path.GetFullPath(relativePath);

            Uri relUri = new Uri(fullPath);
            string localPath = relUri.LocalPath.Replace("%20", " ");
            return localPath;
        }
    }
}
