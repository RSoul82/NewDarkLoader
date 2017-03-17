using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SevenZip;

namespace NewDarkLoader
{
    class DateFromSavegames
    {
        /// <summary>
        /// True if there are saves in the installation folder or the backup zip file.
        /// </summary>
        /// <param name="fmInstalledPath">C:\...FMs\[fm name]</param>
        /// <param name="savegameFilePath">C:\...\[fm name].FMSelBack.zip</param>
        /// <returns></returns>
        public static bool FMHasSaves(string fmInstalledPath, string savegameFilePath, bool gameIsT3)
        {
            StringValues sV = getStrings(gameIsT3);
            string saveSearchPattern = sV.searchPattern;
            string fmSavesPath = fmInstalledPath + "\\" + sV.savesFolderName;
            
            bool hasSaves = false;
            //Check the archive and FM folder to make sure there's at least one savegame file.
            bool folderSaves = false;
            if (Directory.Exists(fmSavesPath))
            {
                string[] allFiles = Directory.GetFiles(fmSavesPath, saveSearchPattern, SearchOption.AllDirectories);
                if (allFiles.Length != 0)
                {
                    hasSaves = true;
                    folderSaves = true;
                }
            }

            if (!folderSaves) //Only necessary if there are no folder saves.
            {
                if (File.Exists(savegameFilePath))
                {
                    SevenZipExtractor ext = new SevenZipExtractor(savegameFilePath);
                    if (!gameIsT3)
                    {
                        foreach (ArchiveFileInfo afi in ext.ArchiveFileData)
                        {
                            if (afi.FileName.ToLower().EndsWith(".sav")) //screenshots don't count.
                            {
                                hasSaves = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (ArchiveFileInfo afi in ext.ArchiveFileData)
                        {
                            if (afi.FileName.ToLower().StartsWith("savegames")) //screenshots don't count.
                            {
                                hasSaves = true;
                                break;
                            }
                        }
                    }
                }
            }
            return hasSaves;
        }

        public static DateTime MostRecentSavegame(string fmInstalledPath, string savegameFilePath, bool gameIsT3)
        {
            StringValues sV = getStrings(gameIsT3);
            string saveSearchPattern = sV.searchPattern;
            string fmSavesPath = fmInstalledPath + "\\" + sV.savesFolderName;

            List<DateTime> modifiedDates = new List<DateTime>();

            //Get dates from save files in the folder
            if (Directory.Exists(fmSavesPath))
            {
                DirectoryInfo dI = new DirectoryInfo(fmSavesPath);
                FileInfo[] allFiles = dI.GetFiles(saveSearchPattern);
                foreach (FileInfo fI in allFiles)
                {
                    modifiedDates.Add(fI.LastWriteTime);
                }
            }

            if (File.Exists(savegameFilePath))
            {
                SevenZipExtractor ext = new SevenZipExtractor(savegameFilePath);
                if (!gameIsT3)
                {
                    foreach (ArchiveFileInfo afi in ext.ArchiveFileData)
                    {
                        if (afi.FileName.ToLower().EndsWith(".sav"))
                        {
                            modifiedDates.Add(afi.LastWriteTime);
                        }
                    }
                }
                else
                {
                    foreach (ArchiveFileInfo afi in ext.ArchiveFileData)
                    {
                        if (afi.FileName.ToLower().StartsWith("savegames"))
                            modifiedDates.Add(afi.LastWriteTime);
                    }
                }
            }

            return modifiedDates.Max<DateTime>();
        }

        private static StringValues getStrings(bool gameIsT3)
        {
            string saveSearchPattern = "*.sav";
            string savesFolder = "saves";
            if (gameIsT3)
            {
                saveSearchPattern = "*.*";
                savesFolder = "savegames";
            }

            StringValues sV = new StringValues();
            sV.searchPattern = saveSearchPattern;
            sV.savesFolderName = savesFolder;

            return sV;
        }

        private struct StringValues
        {
            public string searchPattern;
            public string savesFolderName;
        }
    }
}
