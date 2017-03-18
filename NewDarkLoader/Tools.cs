﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SevenZip;

namespace NewDarkLoader
{
    public partial class Tools : Form
    {
        /// <summary>
        /// Import Darkloader saves and ini settings.
        /// </summary>
        /// <param name="gameFullPath">Location of .exe file's folder (not file itself).</param>
        /// <param name="fmArchiveFullPath">Location of FM zip files.</param>
        /// <param name="sevenZipGExePath">7zG.exe location (the file itself).</param>
        /// <param name="tempPath">User's temp path. Ends with \\</param>
        /// <param name="archiveNames">Filenames of FM archives, extension, no path.</param>
        /// <param name="archiveExts">List of valid FM archive extensions, initially read from the .ini file.</param>
        public Tools(string gameFullPath, string fmArchiveFullPath, string sevenZipGExePath, string tempPath, List<DarkLoaderFMData> dataList, newKeyNames keyNames, INIFile ndlINI, List<string> archiveExts, string windowTitle, string gamePathText, string saveImportText, string dataImportText, string closeText,
            string ovTitle, string ovWarn1, string ovWarn2, string ovWarn3, string ovWarn4, string ovWarn5, string ovWarn6, string yesBtn, string yesToAllBtn, string noBtn, string noToAllBtn, bool gameIsShock2)
        {
            InitializeComponent();
            gamePath = gameFullPath;
            fmArchivePath = fmArchiveFullPath;
            sevenZipGPath = sevenZipGExePath;
            userTempPath = tempPath;
            foreach (DarkLoaderFMData datum in dataList)
            {
                dlFMData.Add(datum);
            }

            nKeys = keyNames;

            Text = windowTitle;
            label1.Text = gamePathText;
            lblGamePath.Text = gamePath;
            btnImportSaves.Text = saveImportText;
            btnImportINI.Text = dataImportText;
            btnClose.Text = closeText;

            overWarnTitle = ovTitle;
            overMsg1 = ovWarn1;
            overMsg2 = ovWarn2;
            overMsg3 = ovWarn3;
            overMsg4 = ovWarn4;
            overMsg5 = ovWarn5;
            overMsg6 = ovWarn6;
            yBtn = yesBtn;
            yToAllBtn = yesToAllBtn;
            nBtn = noBtn;
            nToAllBtn = noToAllBtn;
            shock2 = gameIsShock2;

            newINI = ndlINI;
        }

        /// <summary>
        /// Does not end with \\
        /// </summary>
        private string gamePath;
        /// <summary>
        /// Does not end with \\
        /// </summary>
        private string fmArchivePath;
        /// <summary>
        /// Full path to exe file.
        /// </summary>
        private string sevenZipGPath;
        /// <summary>
        /// Ends with \\
        /// </summary>
        private string userTempPath;

        private List<DarkLoaderFMData> dlFMData = new List<DarkLoaderFMData>();

        private newKeyNames nKeys;

        private INIFile newINI;

        private bool iniImported = false;

        private bool yesToAll = false;
        private bool noToAll = false;

        private string overWarnTitle = "";
        private string overMsg1 = "";
        private string overMsg2 = "";
        private string overMsg3 = "";
        private string overMsg4 = "";
        private string overMsg5 = "";
        private string overMsg6 = "";
        private string yBtn = "";
        private string yToAllBtn = "";
        private string nBtn = "";
        private string nToAllBtn = "";
        private bool shock2 = false; //different saves file structure if true.

        private void btnImportSaves_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            yesToAll = false;
            noToAll = false;
            string allsavesPath = gamePath + "\\allsaves";

            DirectoryInfo dInfo = new DirectoryInfo(allsavesPath);
            FileInfo[] darkLoaderSaveFiles = dInfo.GetFiles();

            string[] fullFMPaths = Directory.GetFiles(fmArchivePath, "*.*", SearchOption.AllDirectories);

            int currentFile = 0;
            foreach (FileInfo fInfo in darkLoaderSaveFiles) 
            {
                double prog = currentFile / (double)darkLoaderSaveFiles.Length * 100;
                double rounded = Math.Round(prog, 0);
                progressBar1.Value = Convert.ToInt32(rounded);

                string dlName = fInfo.Name;
                if (dlName.ToLower() != "original_saves.zip")
                {
                    addSavesDirToZip(fInfo, fullFMPaths);
                }
                currentFile++;
            }
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void addSavesDirToZip(FileInfo zFile, string[] fullFMPaths)
        {
            //NDL saves backup filename.
            string ndlFileName = zFile.Name.Replace("_saves", ".FMSelBak");

            string ndlFilePath = userTempPath + ndlFileName;
            string tempSaves = userTempPath + "saves";

            if (Directory.Exists(tempSaves)) //possible leftover from aborted run or massive coincidence
            {
                deleteTempSaves(tempSaves);
            }

            Directory.CreateDirectory(tempSaves);

            //Store DL saves in temp\saves
            SevenZipExtractor sz = new SevenZipExtractor(zFile.FullName);
            sz.ExtractArchive(tempSaves);

            string source = ndlFilePath;

            //Work out dest file location, with possible subfolder
            string fmBasicFilename = ndlFileName.Replace(".FMSelBak.zip", "");
            string fmDir = fmArchivePath;
            
            foreach (string file in fullFMPaths)
            {
                if (file.Contains(fmBasicFilename) && !file.Contains(".FMSelBak"))
                {
                    FileInfo fI = new FileInfo(file);
                    fmDir = fI.DirectoryName;
                    break;
                }
            }

            string dest = fmDir + "\\" + ndlFileName;

            if (File.Exists(dest))
            {
                if (yesToAll)
                    copySaveBackup(source, dest, ndlFilePath, tempSaves);
                else if (!noToAll)
                {
                    FileInfo destInfo = new FileInfo(dest);
                    DateTime destModDate = destInfo.LastWriteTime;

                    DateTime oldModDate = zFile.LastWriteTime;

                    StringBuilder warning = new StringBuilder();
                    warning.AppendLine(overMsg1 + " " + destInfo.Name); warning.AppendLine(overMsg2); warning.AppendLine(overMsg3 + " " + destModDate.ToString());
                    warning.AppendLine(""); warning.AppendLine(overMsg4 + " " + oldModDate.ToString()); warning.AppendLine(overMsg5); warning.AppendLine(overMsg6);

                    string showWarning = warning.ToString();

                    OverwriteSave ovSave = new OverwriteSave(showWarning, overWarnTitle, yBtn, yToAllBtn, nBtn, nToAllBtn);
                    ovSave.ShowDialog();

                    if (ovSave.OverwriteType == saveOverwriteType.Yes)
                    {
                        copySaveBackup(source, dest, ndlFilePath, tempSaves);
                    }
                    else if (ovSave.OverwriteType == saveOverwriteType.YesToAll)
                    {
                        copySaveBackup(source, dest, ndlFilePath, tempSaves);
                        yesToAll = true;
                    }
                    else if (ovSave.OverwriteType == saveOverwriteType.NoToAll)
                    {
                        noToAll = true;
                    }
                }
                else if (noToAll)
                {
                    return;
                }
            }
            else
                copySaveBackup(source, dest, ndlFilePath, tempSaves);

            deleteTempSaves(tempSaves);
        }

        /// <summary>
        /// Creates a saves backup and copies it to FM's folder. Overwrites existing file.
        /// </summary>
        /// <param name="source">FMSelBak in temp.</param>
        /// <param name="dest">FMSelBak's desination (FM's folder).</param>
        /// <param name="ndlFilePath">NDL saves backup filename.</param>
        /// <param name="tempSaves">temp\saves location.</param>
        private void copySaveBackup(string source, string dest, string ndlFilePath, string tempSaves)
        {
            createBackupFile(ndlFilePath, tempSaves);
            File.Copy(source, dest, true);
        }

        /// <summary>
        /// Adds the files in temp\saves to a zip file.
        /// </summary>
        /// <param name="ndlFilePath">NDL saves backup filename.</param>
        /// <param name="tempSaves">temp\saves location.</param>
        private void createBackupFile(string ndlFilePath, string tempSaves)
        {
            SevenZipCompressor szComp = new SevenZipCompressor(userTempPath);
            szComp.ArchiveFormat = OutArchiveFormat.Zip;
            szComp.CompressionLevel = CompressionLevel.Normal;
            if (shock2)
                szComp.PreserveDirectoryRoot = false;
            else
                szComp.PreserveDirectoryRoot = true;

            szComp.CompressDirectory(tempSaves, ndlFilePath);
        }

        private void deleteTempSaves(string tempSavesPath)
        {
            FullDelete.DeleteDir(tempSavesPath, true);
        }

        private void btnImportINI_Click(object sender, EventArgs e)
        {
            DialogResult dR = openDarkloaderINI.ShowDialog();
            if (dR == DialogResult.OK)
            {
                //ini files
                INIFile oldINI = new INIFile(openDarkloaderINI.FileName);
                //Get sizes in bytes of each FM file
                string[] fullFMPaths = Directory.GetFiles(fmArchivePath, "*.*", SearchOption.AllDirectories);

                foreach (string file in fullFMPaths)
                {
                    FileInfo fI = new FileInfo(file);
                    long sizeBytes = fI.Length;

                    string ext = fI.Extension;
                    string simpleFilename = fI.Name;
                    string oldSectionName = simpleFilename;
                    bool fmIsArchive = false;

                    if (ext.Length != 0)
                    {
                        simpleFilename = fI.Name.Replace(ext, "");
                        oldSectionName = simpleFilename + "." + sizeBytes;
                        fmIsArchive = true;
                    }

                    string newSectionName = "FM=" + ArchiveExtract.ArchiveExtracedFolderName(simpleFilename);

                    string newNiceName = newINI.IniReadValue(newSectionName, nKeys.FMTitle);
                    if (newNiceName == simpleFilename || newNiceName == "")
                    {
                        string oldNiceName = oldINI.IniReadValue(oldSectionName, "title").Replace("\"", "");
                        if (oldNiceName != "")
                        {
                            newINI.IniWriteValue(newSectionName, nKeys.FMTitle, oldNiceName);
                        }
                    }

                    string newFinished = newINI.IniReadValue(newSectionName, nKeys.FinishedID);
                    if (newFinished == "")
                    {
                        string oldFinished;
                        if (fmIsArchive)
                            oldFinished = oldINI.IniReadValue(oldSectionName, "finished");
                        else
                            oldFinished = oldINI.INIReadValueNoSize(oldSectionName, "finished");

                        if (oldFinished != "")
                        {
                            newINI.IniWriteValue(newSectionName, nKeys.FinishedID, oldFinished);
                        }
                    }

                    oldDateToNewDate(oldINI, newINI, oldSectionName, newSectionName, DateType.Release, fmIsArchive);
                    oldDateToNewDate(oldINI, newINI, oldSectionName, newSectionName, DateType.LastPlayed, fmIsArchive);

                    string newComment = newINI.IniReadValue(newSectionName, nKeys.Comment);
                    if (newComment == "")
                    {
                        string oldComment;
                        if (fmIsArchive)
                            oldComment = oldINI.IniReadValue(oldSectionName, "comment").Replace("\"", "");
                        else
                            oldComment = oldINI.INIReadValueNoSize(oldSectionName, "comment").Replace("\"", "");
                        
                        if (oldComment != "")
                        {
                            newINI.IniWriteValue(newSectionName, nKeys.Comment, oldComment);
                        }
                    }
                }

                iniImported = true; //allows a property to report that the ini was imported so the main form can refresh the table.
            }
        }

        /// <summary>
        /// Updates the date in NewDarkLoader.ini with the date from Darkloader.ini if they are not the same. Assumes latter is correct.
        /// </summary>
        private void oldDateToNewDate(INIFile oldINI, INIFile newINI, string oldSectionName, string newSectionName, DateType relPlay, bool fmTypeArchive)
        {
            string oldINIDate;
            string newINIDate;

            if (relPlay == DateType.Release)
            {
                if (fmTypeArchive)
                    oldINIDate = oldINI.IniReadValue(oldSectionName, "misdate");
                else
                    oldINIDate = oldINI.INIReadValueNoSize(oldSectionName, "misdate");
                newINIDate = newINI.IniReadValue(newSectionName, nKeys.ReleaseDateInt);
            }
            else
            {
                if(fmTypeArchive)
                    oldINIDate = oldINI.IniReadValue(oldSectionName, "date");
                else
                    oldINIDate = oldINI.INIReadValueNoSize(oldSectionName, "date");
                newINIDate = newINI.IniReadValue(newSectionName, nKeys.LastPlayedInt);
            }

            if (oldINIDate != "")
            {
                DateTime oldDateTime = DateIntConverter.oldDateIntToDateTime(oldINIDate);

                if (newINIDate != "")
                {
                    DateTime newDateTime = DateIntConverter.dateFromHexString(newINIDate);
                    if (oldDateTime != newDateTime)
                    {
                        string hexDate = DateIntConverter.dateToHexString(oldDateTime);
                        writeDateToINI(newINI, newSectionName, relPlay, hexDate);
                    }
                }
                else
                {
                    string hexDate = DateIntConverter.dateToHexString(oldDateTime);
                    writeDateToINI(newINI, newSectionName, relPlay, hexDate);
                }
            }
        }

        private void writeDateToINI(INIFile i, string sectionName, DateType relPlay, string dateString)
        {
            string keyName;
            if (relPlay == DateType.Release)
                keyName = nKeys.ReleaseDateInt;
            else //DateType.LastPlayed
                keyName = nKeys.LastPlayedInt;

            i.IniWriteValue(sectionName, keyName, dateString);
        }

        enum DateType { Release, LastPlayed }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ImportedINI
        {
            get
            {
                return iniImported;
            }
        }
    }

    /// <summary>
    /// Key names used in NewDarkLoader.ini. This saves defining the strings again.
    /// </summary>
    public struct newKeyNames
    {
        public string FMTitle;
        public string FinishedID;
        public string ReleaseDateInt;
        public string LastPlayedInt;
        public string Comment;
    }

    public enum saveOverwriteType { Yes, YesToAll, No, NoToAll };
}