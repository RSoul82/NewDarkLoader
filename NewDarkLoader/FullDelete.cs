using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewDarkLoader
{
    class FullDelete
    {
        /// <summary>
        /// This sets the attribs to normal before deleting the file. Does not check if the file exists.
        /// </summary>
        /// <param name="fullPath">Full path of the file to be deleted.</param>
        public static void DeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                FileInfo fInfo = new FileInfo(fullPath);
                fInfo.Attributes = FileAttributes.Normal;
                File.Delete(fullPath);
            }
        }

        /// <summary>
        /// This sets the attribs to normal before deleting the directory. Does not check if the directory exists.
        /// </summary>
        /// <param name="fullDirPath">Full path of the directory to be deleted.</param>
        /// <param name="recursive">Delete all files/dirs within the dir.</param>
        public static void DeleteDir(string fullDirPath, bool recursive = false)
        {
            if (Directory.Exists(fullDirPath))
            {
                DirectoryInfo dInfo = new DirectoryInfo(fullDirPath);
                if (recursive)
                {
                    foreach (FileInfo fInfo in dInfo.GetFiles())
                    {
                        fInfo.Attributes = FileAttributes.Normal;
                    }
                }
                dInfo.Attributes = FileAttributes.Normal;
                Directory.Delete(fullDirPath, recursive);
            }
        }
    }
}
