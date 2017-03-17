using System.Diagnostics;
using System.IO;

namespace NewDarkLoader
{
    /// <summary>
    /// Methods for using the external 7zG program - good performance.
    /// </summary>
    class SevenZipGExtract
    {
        /// <summary>
        /// Extract single file from archive.
        /// </summary>
        /// <param name="sevenZipGPath">Path to 7zG.exe.</param>
        /// <param name="fmArchivePath">Where the archives are kept.</param>
        /// <param name="archiveFilename">Simple filename, no path.</param>
        /// <param name="extractionPath">Where to extract the file.</param>
        /// <param name="filename">Filename to extract.</param>
        /// <param name="useDirStructure">Default true if it shoud be preserved.</param>
        public static int ExtractFile(string sevenZipGPath, string fmArchivePath, string subFolder, string archiveFilename, 
            string extractionPath, string filename, bool useDirStructure = true)
        {
            bool noWindows = false;

            if (sevenZipGPath.ToLower().EndsWith("7z.exe"))
                noWindows = true;

            string extractCommand = "x "; //preserve dir structure
            if (!useDirStructure) extractCommand = "e "; //extract file only

            Process p = new Process();
            p.StartInfo.FileName = "\"" + sevenZipGPath + "\"";
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(sevenZipGPath);
            p.StartInfo.Arguments = extractCommand
                + "\"" + fmArchivePath + subFolder + "\\" + archiveFilename + "\""
                + " -o\"" + extractionPath + "\" "
                + "\"" + filename + "\" -y";

            if (noWindows)
            {
                //p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
            }

            p.Start();
            p.WaitForExit();

            int exitCode = p.ExitCode;
            //if (!noWindows && exitCode != 0)
            //    ignoreError();
            
            p.Close();

            return exitCode;
        }

        /// <summary>
        /// Extract entire archive.
        /// </summary>
        /// <param name="sevenZipGPath">Where the archives are kept.</param>
        /// <param name="fmArchivePath">Where the archives are kept.</param>
        /// <param name="archiveFilename">Simple filename, no path.</param>
        /// <param name="extractionPath">Where to extract the file(s). Include the "Extraction name" in the path.</param>
        public static int ExtractArchive(string sevenZipGPath, string fmArchivePath, string archiveFilename,
            string extractionPath)
        {
            bool noWindows = false;
            if(sevenZipGPath.ToLower().EndsWith("7z.exe"))
                 noWindows = true;
            
            Process p = new Process();
            p.StartInfo.FileName = "\"" + sevenZipGPath + "\"";
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(sevenZipGPath);
            p.StartInfo.Arguments = "x " + "\"" + fmArchivePath + "\\" + archiveFilename + "\""
                + " -o\"" + extractionPath + "\" -y";

            if (noWindows)
            {
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
            }

            p.Start();
            p.WaitForExit();

            int exitCode = p.ExitCode;
            //if (!noWindows && p.ExitCode != 0)
            //    ignoreError();
            
            p.Close();

            return exitCode;
        }

        public static void ignoreError()
        {
            System.Windows.Forms.MessageBox.Show("The error message you got can probably be ignored.");
        }
    }
}