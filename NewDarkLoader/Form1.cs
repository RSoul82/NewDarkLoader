﻿//#define screenSize
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SevenZip;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace NewDarkLoader
{
    public partial class Form1 : Form
    {
        #region Fields
        List<FanMission> foundFMs = new List<FanMission>();
        int fmSortColumn = 2; //Default
        SortOrder fmSortOrder = SortOrder.Ascending; //Default value

        bool NDLRunFromDLL = false;
        //Column name indices set here so I can add/remove colums from the table and
        //only need to change each column number once.
        /// <summary>
        /// Game icon image.
        /// </summary>
        const int ARCHIVE = 0;
        const int FM_SIZE = 1;
        const int TITLE = 2;
        const int RATING = 3;
        const int FINISHED = 4;
        const int RELEASE_DATE = 5;
        const int LAST_PLAYED = 6;
        const int COMMENT = 7;
        const int DISABLED_MODS = 8;
        const int INSTALLED = 9;

        string dirPath = System.Environment.CurrentDirectory; //No \\ at end
        string iniPath = "";
        /// <summary>
        /// Full path of game folder. Does not end with \\
        /// </summary>
        string gamePath = "";
        /// <summary>
        /// Exe filename without extension.
        /// </summary>
        string exeName = "";
        /// <summary>
        /// Friendly version of exe name. E.g. Thief2 => Thief 2
        /// </summary>
        string gameName = "";
        /// <summary>
        /// Full path to game's exe file. Used for running a new process.
        /// </summary>
        string exeFullPath = "";
        /// <summary>
        /// Does not end with \\
        /// </summary>
        string fmArchivePath = "";
        /// <summary>
        /// gamePath + \\FMs. Does not end with \\ OR value read from cam_mod.ini
        /// </summary>
        string fmInstalledPath;
        /// <summary>
        /// Short name, e.t. 3DA-v0_4
        /// </summary>
        string fmExtractionFolder;
        /// <summary>
        /// Language setting from NewDarkLoader's setup
        /// </summary>
        string langNDL = "";
        /// <summary>
        /// Language from darkinst.cfg/install.cfg
        /// </summary>
        string langGame = "english";

        int selFMID = -1;
        //string runCommand = "";
        /// <summary>
        /// Ends with \\
        /// </summary>
        string userTempFolder = System.IO.Path.GetTempPath();
        /// <summary>
        /// Readme stored in temp for archives, or FMs\[fm name] for directories
        /// </summary>
        string readmePath = "";
        /// <summary>
        /// HTML can't be deleted while it's being viewed, so this stores the path to be deleted afterwards.
        /// </summary>
        string htmlReadmePath = "";
        string dateFormat = "";
        /// <summary>
        /// "Ask" (default) or "Always"
        /// </summary>
        string backupType = "";
        /// <summary>
        /// Write this to the ini if no tags are found. Prevents NDL needlessly checking the archive later on.
        /// </summary>
        string emptyTag = "[none]";
        /// <summary>
        /// 0 = Never, 1 = After FM, 2 = Always
        /// </summary>
        int returnType = 0;
        /// <summary>
        /// Full path to 7zG.exe
        /// </summary>
        string sevenZipGExe = "";
        /// <summary>
        /// Full path to 7z.exe - program is run with no window.
        /// </summary>
        string sevenZipNoWin = "";
        bool use7zNoWin = false;
        /// <summary>
        /// Ignore leading The, An or A when sorting by title.
        /// </summary>
        bool sortIgnoreArticles = false;

        //int gameType = -1;
        private RichTextBoxStreamType readmeFileType = new RichTextBoxStreamType(); //rtf or txt
        private Size origReadmeSize;
        private Point origReadmeLoc;

        string titlesStr = "";
        string missflagStr = "";
        int misFileNumber = 0;

        int splCurrentDist = 0;

        DateTime releaseDate; //For the DataGridView cell

        #region Interface text
        string setupTitle = "Setup";
        string fmArchFolderBox = "FM Archive folder (zip, 7z, rar...)";
        string folderIsFMsWarning = "\"Archive path\" must not also be the \"installed FM path\".";
        string browseButton = "Browse...";
        string langBox = "Language";
        string dateFormatBox = "Date Format";
        string dmyChk = "Day/Month/Year";
        string mdyChk = "Month/Day/Year";
        string saveBackupBox = "Backup Savegames and Screenshots when Uninstalling";
        string bkTypeAsk = "Ask each time";
        string bkTypeAlways = "Always make backup";
        string dbClFMBox = "Double-Click to Play FM";
        string dbClChk = "Don't ask for confirmation";
        string returnAfterBox = "Return to NewDarkLoader after Playing";
        string retTypeNeverRdo = "Never!";
        string afterFMRdo = "After FM";
        string alwaysRdo = "Always";
        string opt7zBox = "Optional: Locate 7zG.exe";
        //Second browse button
        string help7z1 = "If you have 7Zip installed, you can locate the \"7zG.exe\" file to imrpove FM installation performance.";
        string help7z2 = "7zG.exe shows a progress bar. Choose \"7z.exe\" if you want things to be completely hidden.";
        string use7zeChk1 = "Use \"7z.exe\" for minor operations, e.g. accessing the readme.";
        string use7zeChk2 = "This creates no window.";
        string folderRequired = "FM archive folder required.";
        string errorTitle = "Error";
        string webSearchSite = "Web Search Target Site";
        string noSiteLabel = "Type in 0 (zero) to use no site";
        string articleLabel = "Article list";
        string articleTip = "If searching on thiefmissions.com, words in this box will go at the end. E.g. Drymian Codex, The";

        //OK/Cancel buttons

        //Columns headers and Edit FM labels
        string readmeLabel = "Readme";
        string colArchive = "Archive";
        string colTitle = "Title";
        string colRating = "Rating";
        string colFinished = "Finished";
        string diffT3Easy = "Easy";
        string diffNormal = "Normal";
        string diffHard = "Hard";
        string diffExpert = "Expert";
        string diffExtreme = "Extreme";
        string colReleaseDate = "Release Date";
        string colLastPlayed = "Last Played";
        string notPlayed = "NotPlayed";
        string getFromSaves = "Get from savegames";
        string colComment = "Comment";
        string colDisabledMods = "Disabled Mods";
        string colInstalled = "Installed";

        string noReadme = "No info file. You're on your own!";
        string badReadme = "Readme not formatted properly.";

        string scannedText = "Scanned";

        //Right click menu
        string scanAllMsg1 = "Get data from all FMs?";
        string scanAllMsg2 = "This may take a while depending on your PC and the number/size of the FMs.";
        string generateINI = "Generate FM.ini...";

        string editFMDetails = "Edit FM Details";
        string forceReinstall1 = "Force this FM to be re-installed?";
        string forceReinstall2 = "Re-install?";
        string cantReinstall1 = "Forced re-installation only possible with 7zip installed and selected in Setup.";
        string cantReinstall2 = "7zip not found.";
        string chooseFix1 = "Choose Fix file(s)?";
        string chooseFix2 = "Choose Fix(es)?";
        string fixesCopied1 = "Done";
        string fixesCopied2 = "Fix(es) copied to";
        string fixesCopied3 = "You can delete the original file(s).";
        string fixesCopied4 = "The fixes will be applied the next time you install the FM.";

        string rightClickTip = "Right-click to edit details";
        string refresh = "Press F5 to refresh.";
        string refreshButton = "Refresh (F5)";

        //Main buttons
        string playTextPart1 = "Play";
        string editText = "Edit";
        string installText = "Install Only";
        string uninstallText = "Uninstall";

        string dlWindowTitle = "Old Darkloader Tools";
        string dlGamePath = "Game Path:";
        string dlSavesImport = "Import Darkloader Saves";
        string dlIniImport = "Import FM data from Darkloader.ini...";

        string overwriteTitle = "Overwrite?";
        string overwriteLn1 = "Attempting to create";
        string overwriteLn2 = "This file already exists.";
        string overwriteLn3 = "File modified date is";
        string overwriteLn4 = "Darkloader save backup's modified date is";
        string overwriteLn5 = "Click Yes to replace the new-style backup with the Darkloader backup,";
        string overwriteLn6 = "or No to keep using it.";
        string yesBtn = "Yes";
        string yesToAllBtn = "Yes to all";
        string noBtn = "No";
        string noToAllBtn = "No to all";

        string dlClose = "Close";
        string dateMin = "Start Date";
        string dateMax = "End Date";
        string tagWindowTitle = "Tag Filter";
        string availTagsText = "Available Tags";
        string incTagsText = "Include (OR):";
        string excTagsText = "Exclude (NOT)";
        string incBtnText = "Include";
        string excBtnText = "Exclude";
        string remBtnText = "Remove";
        string remAllBtnText = "Remove All...";
        string remAllMessage = "Remove all tags from both lists?";
        string confirmBoxMsgTitle = "Confirm";
        string okBtnText = "OK";
        string cancBtnText = "Cancel";
        string miscTagCat = "misc";
        string remTagMsgStart = "Remove";
        string remAllCatMsgStart = "Remove all";
        string remAllCatMsgEnd = "tags";
        string tagError1 = "Tag not in right format.";
        string tagError2 = "It should be category:tag or just tag on its own.";

        string dCEQuestion = "Play FM?";
        string dCEAlwaysPlay = "Always play on Double Click/Enter";

        string saveBackupMsg = "Any saves/screenshots for this FM will be backed up automatically.";
        string noArchiveWarning = "Warning: This FM has no archive (.zip, .7z, .rar) file. If you uninstall it, you'll have to re-download the original archive.";
        string warningTitle = "Warning";
        string saveBackupQ1 = "Do you want to backup savegames and screenshots?";
        string saveBackupQ2 = "\"No\": Any existing backups will remain, but will not be updated.";
        string saveBackupTitle = "Savegames and Screenshots";
        #endregion

        bool gameIsThief3;
        bool gameIsShock2;
        bool alwaysPlayOnDC;

        /// <summary>
        /// True when being selected by user, fasle on all other occasions.
        /// </summary>
        bool showThisFM = true;

        INIFile i;
        #endregion

        #region Key names
        const string secOptions = "Config";
        const string kGame_type = "Type";
        const string kArchive_root = "ArchiveRoot";
        const string kReturn_type = "DebriefFM";
        const string kReturn_type_ed = "DebriefFMEd";
        const string kCWidths = "ColumnWidths";
        const string kFm_title = "NiceName";
        const string kRelease_date = "ReleaseDate";
        const string kLast_played = "LastCompleted";
        const string kArchive_name = "Archive";
        const string kFinished = "Finished";
        const string kLanguage = "Language";
        const string kDate_format = "DateFormat";
        const string kBackup_type = "BackupType";
        const string k7zipG = "sevenZipG";
        const string kSplitDist = "SplitDistance";
        const string kRating = "Rating";
        const string kComment = "Comment";
        const string kNo_mods = "ModExclude";
        const string kLast_fm = "LastFM";
        const string kTags = "Tags";
        const string kInfoFile = "InfoFile";
        const string kWindowState = "WindowState";
        const string kWindowPos = "WindowPos";
        const string kShowTags = "ShowTags";
        const string kUse7zNoWin = "Use7zNoWin";
        const string kSortCol = "SortColumn";
        const string kSortOrder = "SortOrder";
        const string kExtensions = "ValidExtensions";
        const string kAlwaysPlay = "DbClDontAsk";
        const string kNameFilter = "FilterName";
        const string kUnfinishedFilter = "FilterUnfinished";
        const string kStartDateFilter = "FilterStart";
        const string kEndDateFilter = "FilterEnd";
        const string kIncTagsFilter = "FilterTagsOR";
        const string kExcTagsFilter = "FilterTagsNOT";
        const string kSizeBytes = "FMSize";

        /// <summary>
        /// "Return" key name, which depends on whether it's the game or editor being used.
        /// </summary>
        string currentReturnType = kReturn_type;

        #endregion

        #region Tags for all FMs
        /// <summary>
        /// All tags from all FMs - no duplicates.
        /// </summary>
        List<catItem> globalCatItems = new List<catItem>();

        /// <summary>
        /// All the tag categories from all FMs - no duplicates.
        /// </summary>
        List<string> globalCategories = new List<string>();

        /// <summary>
        /// Tags an FM must have for it to be shown.
        /// </summary>
        List<catItem> includeTags = new List<catItem>();
        /// <summary>
        /// Tags an FM must not have for it to be shown.
        /// </summary>
        List<catItem> excludeTags = new List<catItem>();

        #endregion

        #region Constructor
        /// <summary>
        /// The form.
        /// </summary>
        /// <param name="exePath">Full path of .exe that called this form.</param>
        /// <param name="fromDLL">'Play Game' actions depend on whether this is called as a normal exe or as a dll.</param>
        /// <param name="gameVersion">sGameVersion obtained from FMSelectorData.</param>
        ///<param name="insPath">Install path, used for Thief 3.</param>
        public Form1(string exePath, bool fromDLL, string gameVersion, string insPath)
        {
            InitializeComponent();
            exeFullPath = exePath;
            NDLRunFromDLL = fromDLL;

            FileInfo gameExeInfo = new FileInfo(exePath);
            gamePath = gameExeInfo.DirectoryName;
            exeName = gameExeInfo.Name.Replace(gameExeInfo.Extension, "");
            setGameName(exeName);

            string version = ProductVersion.TrimEnd('.', '0');

            Text = "NewDarkLoader " + version + " - " + gameName;

            setHTMLReadmeSizeLoc();

            origReadmeLoc = readmeBox.Location;
            Size oSize = new Size();
            oSize.Width = readmeBox.Width;
            oSize.Height = readmeBox.Height; //This has to be measured at runtime because in VS it's very low.
            origReadmeSize = oSize;

            readINIFileToData(insPath);
            readINIData();
            readGameLanguage();

            setInterfaceText();

            cbMinMonth.SelectedIndex = 0;
            cbMinYear.SelectedIndex = 0;
            cbMaxMonth.SelectedIndex = 0;
            cbMaxYear.SelectedIndex = 0;

            //If there are missing options
            if (fmArchivePath == "" || dateFormat == "")
            {
                showSetup(true, false);
            }
            else
            {
                fillFMList();
            }

            setColumnWidths();

#if screenSize
        //fmTable.Width = fmTable.Columns[ARCHIVE].Width;
#else
            restoreWindowState();
#endif
            restoreShowTagState();
            restoreSortOrder();
            readAllTags();
            selectLastPlayed();
            loadFilterFromIni();

            aprMessages();
        }
        #endregion

        /// <summary>
        /// Look in darkinst.cfg to get the game's installation language
        /// </summary>
        private void readGameLanguage()
        {
            if (!gameIsThief3)
            {
                string insCfg = "darkinst.cfg";
                if (!File.Exists(gamePath + "\\" + insCfg))
                {
                    insCfg = "install.cfg";
                }

                string insPath = gamePath + "\\" + insCfg;
                string[] fileLines = File.ReadAllLines(insPath);

                foreach (string line in fileLines)
                {
                    if (line.ToLower().StartsWith("language"))
                    {
                        string[] split = line.Split(' ');
                        if (split.Length == 2)
                        {
                            langGame = split[1];
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Replaces all English text items with values read from text.
        /// </summary>
        private void setInterfaceText()
        {
            string langINIPath = fmInstalledPath + "\\" + langNDL + ".ini";
            if (File.Exists(langINIPath))
            {
                string secSetup = "Setup";
                string secCols = "Columns";
                string secRightClick = "RightClick";
                string secDClickEnter = "DoubleClickEnter";
                string secUninstall = "Uninstall";
                string secMainButtons = "MainButtons";
                string secFMTable = "FMTable";
                string secReadme = "Readme";
                string secFilter = "Filter";
                string secTagFilter = "TagFilterWindow";
                string secTags = "Tags";
                string secOldDLTools = "OldDarkloaderTools";
                string secSaveImport = "DLSaveImport";
                INIFile langIni = new INIFile(langINIPath);

                #region Get text from lang.ini
                //Setup window
                setupTitle = langIni.IniReadValue(secSetup, "SetupTitle");
                fmArchFolderBox = langIni.IniReadValue(secSetup, "FmArchFolderBox");
                folderIsFMsWarning = langIni.IniReadValue(secSetup, "FolderIsFMsWarning");
                browseButton = langIni.IniReadValue(secSetup, "BrowseButton");
                langBox = langIni.IniReadValue(secSetup, "LangBox");
                dateFormatBox = langIni.IniReadValue(secSetup, "DateFormatBox");
                dmyChk = langIni.IniReadValue(secSetup, "DmyChk");
                mdyChk = langIni.IniReadValue(secSetup, "MdyChk");
                saveBackupBox = langIni.IniReadValue(secSetup, "SaveBackupBox");
                bkTypeAsk = langIni.IniReadValue(secSetup, "BackupTypeAsk");
                bkTypeAlways = langIni.IniReadValue(secSetup, "BackupTypeAlways");
                dbClFMBox = langIni.IniReadValue(secSetup, "DblClickFMBox");
                dbClChk = langIni.IniReadValue(secSetup, "DblClChk");
                returnAfterBox = langIni.IniReadValue(secSetup, "ReturnAfterBox");
                retTypeNeverRdo = langIni.IniReadValue(secSetup, "RetNever");
                afterFMRdo = langIni.IniReadValue(secSetup, "RetAfterFM");
                alwaysRdo = langIni.IniReadValue(secSetup, "RetAlways");
                opt7zBox = langIni.IniReadValue(secSetup, "OptLocate7zBox");
                help7z1 = langIni.IniReadValue(secSetup, "Help7z1");
                help7z2 = langIni.IniReadValue(secSetup, "Help7z2");
                use7zeChk1 = langIni.IniReadValue(secSetup, "Use7zeChk1");
                use7zeChk2 = langIni.IniReadValue(secSetup, "Use7zeChk2");
                folderRequired = langIni.IniReadValue(secSetup, "FolderRequired");
                errorTitle = langIni.IniReadValue(secSetup, "FldrRequiredTitle");
                webSearchSite = langIni.IniReadValue(secSetup, "WebSearchSite");
                noSiteLabel = langIni.IniReadValue(secSetup, "NoSiteLabel");
                articleLabel = langIni.IniReadValue(secSetup, "ArticleLabel");
                articleTip = langIni.IniReadValue(secSetup, "ArticleTip");

                noReadme = langIni.IniReadValue(secReadme, "NoReadme");
                badReadme = langIni.IniReadValue(secReadme, "BadReadme");

                //Scan FM
                string secScan = "ScanAll";
                lblProgressTitle.Text = langIni.IniReadValue(secScan, "Progress");
                scannedText = langIni.IniReadValue(secScan, "Scanned");

                //Edit FM Data labels
                readmeLabel = langIni.IniReadValue(secCols, "Readme");
                colArchive = langIni.IniReadValue(secCols, "Archive");
                colTitle = langIni.IniReadValue(secCols, "Title");
                colRating = langIni.IniReadValue(secCols, "Rating");
                colFinished = langIni.IniReadValue(secCols, "Finished");
                diffT3Easy = langIni.IniReadValue(secCols, "T3Easy");
                diffNormal = langIni.IniReadValue(secCols, "Normal");
                diffHard = langIni.IniReadValue(secCols, "Hard");
                diffExpert = langIni.IniReadValue(secCols, "Expert");
                diffExtreme = langIni.IniReadValue(secCols, "Extreme");
                colReleaseDate = langIni.IniReadValue(secCols, "ReleaseDate");
                colLastPlayed = langIni.IniReadValue(secCols, "LastPlayed");
                notPlayed = langIni.IniReadValue(secCols, "NotPlayed");
                getFromSaves = langIni.IniReadValue(secCols, "GetFromSaves");
                colComment = langIni.IniReadValue(secCols, "Comment");
                colDisabledMods = langIni.IniReadValue(secCols, "DisabledMods");
                colInstalled = langIni.IniReadValue(secCols, "Installed"); //For FMs scanned on startup only

                //Update the Installed value in the table
                for (int x = 0; x < fmTable.Rows.Count; x++)
                {
                    if (fmTable.Rows[x].Cells[INSTALLED].Value.ToString() != "")
                    {
                        fmTable.Rows[x].Cells[INSTALLED].Value = colInstalled;
                    }
                }

                //Column headers
                fmTable.Columns[ARCHIVE].HeaderText = colArchive;
                fmTable.Columns[TITLE].HeaderText = colTitle;
                fmTable.Columns[RATING].HeaderText = colRating;
                fmTable.Columns[FINISHED].HeaderText = colFinished;
                fmTable.Columns[RELEASE_DATE].HeaderText = colReleaseDate;
                fmTable.Columns[LAST_PLAYED].HeaderText = colLastPlayed;
                fmTable.Columns[COMMENT].HeaderText = colComment;
                fmTable.Columns[DISABLED_MODS].HeaderText = colDisabledMods;
                fmTable.Columns[INSTALLED].HeaderText = colInstalled;

                //Right click menu
                editFMDetails = langIni.IniReadValue("EditFM", "EditDetailsTitle");
                rightClickFM.Items[0].Text = langIni.IniReadValue(secRightClick, "EditFMDetails");
                rightClickFM.Items[1].Text = langIni.IniReadValue(secRightClick, "ScanAllFMs");
                rightClickFM.Items[2].Text = langIni.IniReadValue(secRightClick, "ReScanThisFM");
                scanAllMsg1 = langIni.IniReadValue(secRightClick, "ScanAllMsg1");
                scanAllMsg2 = langIni.IniReadValue(secRightClick, "ScanAllMsg2");
                generateINI = langIni.IniReadValue(secRightClick, "GenerateINI");

                toolTip1.SetToolTip(btnRefresh, langIni.IniReadValue(secFMTable, "RefreshButton"));

                //Control key messages
                forceReinstall1 = langIni.IniReadValue(secFMTable, "ForceReinstall1");
                forceReinstall2 = langIni.IniReadValue(secFMTable, "ForceReinstall2");
                cantReinstall1 = langIni.IniReadValue(secFMTable, "CantReinstall1");
                cantReinstall2 = langIni.IniReadValue(secFMTable, "CantReinstall2");
                chooseFix1 = langIni.IniReadValue(secFMTable, "ChooseFix1");
                chooseFix2 = langIni.IniReadValue(secFMTable, "ChooseFix2");
                fixesCopied1 = langIni.IniReadValue(secFMTable, "FixesCopied1");
                fixesCopied2 = langIni.IniReadValue(secFMTable, "FixesCopied2");
                fixesCopied3 = langIni.IniReadValue(secFMTable, "FixesCopied3");
                fixesCopied4 = langIni.IniReadValue(secFMTable, "FixesCopied4");

                //Double click
                dCEQuestion = langIni.IniReadValue(secDClickEnter, "DbClEnterQuestion");
                dCEAlwaysPlay = langIni.IniReadValue(secDClickEnter, "AlwaysPlay");

                //Uninstall
                saveBackupMsg = langIni.IniReadValue(secUninstall, "SaveBackupMsg");
                noArchiveWarning = langIni.IniReadValue(secUninstall, "NoArchiveWarning");
                warningTitle = langIni.IniReadValue(secUninstall, "WarningTitle");
                saveBackupQ1 = langIni.IniReadValue(secUninstall, "SaveBackupQ1");
                saveBackupQ2 = langIni.IniReadValue(secUninstall, "SaveBackupQ2");
                saveBackupTitle = langIni.IniReadValue(secUninstall, "SaveBackupTitle");

                //Dynamic text, and lower buttons
                playTextPart1 = langIni.IniReadValue(secMainButtons, "PlayGameOrFMPart1");
                editText = langIni.IniReadValue(secMainButtons, "Edit");
                setGameName(exeName); //Sets play/edit button texts
                installText = langIni.IniReadValue(secMainButtons, "Install");
                uninstallText = langIni.IniReadValue(secMainButtons, "Uninstall");
                rightClickTip = langIni.IniReadValue(secFMTable, "TableTip");
                refresh = langIni.IniReadValue(secFMTable, "Refresh");
                refreshButton = langIni.IniReadValue(secFMTable, "RefreshButton");

                //Static buttons
                btnWebSearch.Text = langIni.IniReadValue(secMainButtons, "WebSearch");
                btnTools.Text = langIni.IniReadValue(secMainButtons, "OldDLTools");
                btnSetup.Text = langIni.IniReadValue(secMainButtons, "Setup");
                btnExit.Text = langIni.IniReadValue(secMainButtons, "Exit");

                //Readme
                btnFullScreenReadme.Text = langIni.IniReadValue(secReadme, "FullScreenReadme");
                btnShowInBrowser.Text = langIni.IniReadValue(secReadme, "ShowInBrowser");

                //Filters
                btnResetFilters.Text = langIni.IniReadValue(secFilter, "ResetFilters");
                chkUnfinished.Text = langIni.IniReadValue(secFilter, "UnfinishedOnly");
                dateMin = langIni.IniReadValue(secFilter, "MinDate");
                toolTip1.SetToolTip(cbMinMonth, dateMin);
                toolTip1.SetToolTip(cbMinYear, dateMin);
                dateMax = langIni.IniReadValue(secFilter, "MaxDate");
                toolTip1.SetToolTip(cbMaxMonth, dateMax);
                toolTip1.SetToolTip(cbMaxYear, dateMax);
                btnSetTagFilter.Text = langIni.IniReadValue(secFilter, "SetTagFilter");

                //Tag Filter Window
                tagWindowTitle = langIni.IniReadValue(secTagFilter, "WindowTitle");
                availTagsText = langIni.IniReadValue(secTagFilter, "AvailTags");
                incTagsText = langIni.IniReadValue(secTagFilter, "IncludeTags");
                excTagsText = langIni.IniReadValue(secTagFilter, "ExcludeTags");
                incBtnText = langIni.IniReadValue(secTagFilter, "IncludeBtn");
                excBtnText = langIni.IniReadValue(secTagFilter, "ExcludeBtn");
                remBtnText = langIni.IniReadValue(secTagFilter, "RemoveTag");
                remAllBtnText = langIni.IniReadValue(secTagFilter, "RemoveAll");
                remAllMessage = langIni.IniReadValue(secTagFilter, "RemoveAllMsg");
                confirmBoxMsgTitle = langIni.IniReadValue(secTagFilter, "RemoveAllMsgTitle");
                okBtnText = langIni.IniReadValue(secTagFilter, "OK");
                cancBtnText = langIni.IniReadValue(secTagFilter, "Cancel");

                //Tags
                gbTags.Text = langIni.IniReadValue(secTags, "TagBox");
                btnAddNewTag.Text = langIni.IniReadValue(secTags, "AddNewTag");
                btnAddExistTag.Text = langIni.IniReadValue(secTags, "AddExistingTag");
                lblFMTags.Text = langIni.IniReadValue(secTags, "FMsTags");
                btnRemoveTags.Text = langIni.IniReadValue(secTags, "RemoveTag");
                remTagMsgStart = langIni.IniReadValue(secTags, "RemTagMsgStart");
                remAllCatMsgStart = langIni.IniReadValue(secTags, "RemAllCatMsgStart");
                remAllCatMsgEnd = langIni.IniReadValue(secTags, "RemAllCatMsgEnd");

                toolTip1.SetToolTip(btnHideTags, langIni.IniReadValue(secTags, "TagButton"));

                //Tag menu
                miscTagCat = langIni.IniReadValue(secTags, "MiscTagName");
                btnTagPresets.Text = langIni.IniReadValue(secTags, "TagMenuName");
                authorToolStripMenuItem.Text = langIni.IniReadValue(secTags, "AuthorTag");
                contestToolStripMenuItem.Text = langIni.IniReadValue(secTags, "ContestTag");
                genreToolStripMenuItem.Text = langIni.IniReadValue(secTags, "GenreTag");
                customToolStripMenuItem.Text = langIni.IniReadValue(secTags, "CustomTag");
                actionToolStripMenuItem.Text = langIni.IniReadValue(secTags, "GenreAction");
                crimeToolStripMenuItem.Text = langIni.IniReadValue(secTags, "GenreCrime");
                horrorToolStripMenuItem.Text = langIni.IniReadValue(secTags, "GenreHorror");
                mysteryToolStripMenuItem.Text = langIni.IniReadValue(secTags, "GenreMystery");
                puzzleToolStripMenuItem.Text = langIni.IniReadValue(secTags, "GenrePuzzle");
                languageToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LanguageTag");
                customToolStripMenuItem1.Text = langIni.IniReadValue(secTags, "CustomTag");
                englishToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangEnglish");
                czechToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangCzech");
                dutchToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangDutch");
                frenchToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangFrench");
                germanToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangGerman");
                hungarianToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangHungarian");
                italianToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangItalian");
                japaneseToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangJapanese");
                polishToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangPolish");
                russianToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangRussian");
                spanishToolStripMenuItem.Text = langIni.IniReadValue(secTags, "LangSpanish");
                seriesToolStripMenuItem.Text = langIni.IniReadValue(secTags, "SeriesTag");
                campaignToolStripMenuItem.Text = langIni.IniReadValue(secTags, "CampaignTag");
                demoToolStripMenuItem.Text = langIni.IniReadValue(secTags, "DemoTag");
                otherProtagonistToolStripMenuItem.Text = langIni.IniReadValue(secTags, "OtherProtTag");
                unknownAuthorToolStripMenuItem.Text = langIni.IniReadValue(secTags, "UnkAuthorTag");

                //Tag error
                tagError1 = langIni.IniReadValue(secTags, "TagFormatError1");
                tagError2 = langIni.IniReadValue(secTags, "TagFormatError2");

                //Old Darkloader Tools
                dlWindowTitle = langIni.IniReadValue(secOldDLTools, "DLToolsTitle");
                dlGamePath = langIni.IniReadValue(secOldDLTools, "GamePath");
                dlSavesImport = langIni.IniReadValue(secOldDLTools, "ImportDLSaves");
                dlIniImport = langIni.IniReadValue(secOldDLTools, "ImportDLFMData");
                dlClose = langIni.IniReadValue(secOldDLTools, "DLToolsClose");

                //Import DL Saves
                overwriteTitle = langIni.IniReadValue(secSaveImport, "OverwriteTitle");
                overwriteLn1 = langIni.IniReadValue(secSaveImport, "OverwriteLn1");
                overwriteLn2 = langIni.IniReadValue(secSaveImport, "OverwriteLn2");
                overwriteLn3 = langIni.IniReadValue(secSaveImport, "OverwriteLn3");
                overwriteLn4 = langIni.IniReadValue(secSaveImport, "OverwriteLn4");
                overwriteLn5 = langIni.IniReadValue(secSaveImport, "OverwriteLn5");
                overwriteLn6 = langIni.IniReadValue(secSaveImport, "OverwriteLn6");
                yesBtn = langIni.IniReadValue(secSaveImport, "Yes");
                yesToAllBtn = langIni.IniReadValue(secSaveImport, "YesToAll");
                noBtn = langIni.IniReadValue(secSaveImport, "No");
                noToAllBtn = langIni.IniReadValue(secSaveImport, "NoToAll");
                #endregion
            }
        }

        private void loadFilterFromIni()
        {
            //name string
            tbFilter.Text = i.IniReadValue(secOptions, kNameFilter);
            //unifished string
            string unFinOnly = i.IniReadValue(secOptions, kUnfinishedFilter);
            if (unFinOnly != "" && unFinOnly != "0")
            {
                chkUnfinished.Checked = true;
            }
            //min date (stored as m,y)
            restoreMinDate(i.IniReadValue(secOptions, kStartDateFilter));
            //max date (stored as m,y)
            restoreMaxDate(i.IniReadValue(secOptions, kEndDateFilter));
            //read include and exlude tag lists
            string incTags = i.IniReadValue(secOptions, kIncTagsFilter);
            string excTags = i.IniReadValue(secOptions, kExcTagsFilter);

            generateTagData(incTags, includeTags, new List<string>());
            generateTagData(excTags, excludeTags, new List<string>());

            //Show filter in UI
            if (incTags != "" || excTags != "")
            {
                lblTagFilter.Text = TagStr.TagListToFilterString(includeTags, excludeTags, miscTagCat);
            }

            setFilter();
        }

        private void restoreMinDate(string monthYearString)
        {
            if (monthYearString != "")
            {
                string[] split = monthYearString.Split(',');
                if (split.Length == 2)
                {
                    int mInt = Convert.ToInt32(split[0]);
                    cbMinMonth.SelectedIndex = mInt;
                    cbMinYear.SelectedIndex = indexOfCBValue(cbMinYear, split[1]);
                }
            }
        }

        private void restoreMaxDate(string monthYearString)
        {
            if (monthYearString != "")
            {
                string[] split = monthYearString.Split(',');
                if (split.Length == 2)
                {
                    int mInt = Convert.ToInt32(split[0]);
                    cbMaxMonth.SelectedIndex = mInt;
                    cbMaxYear.SelectedIndex = indexOfCBValue(cbMaxYear, split[1]);
                }
            }
        }

        private int indexOfCBValue(ComboBox cB, string value)
        {
            int index = 0;
            for (int x = 0; x < cB.Items.Count; x++)
            {
                if (cB.Items[x].ToString().Equals(value))
                {
                    index = x;
                    break;
                }
            }
            return index;
        }

        private void restoreSortOrder()
        {
            //default, ascending
            int sortID = 1;

            string sortCol = i.IniReadValue(secOptions, kSortCol);
            string sortOrder = i.IniReadValue(secOptions, kSortOrder);
            if (sortCol != "")
            {
                int.TryParse(sortCol, out fmSortColumn);
                int.TryParse(sortOrder, out sortID);

                if (sortID == 2)
                    fmSortOrder = SortOrder.Descending;
            }

            setSort();
        }

        /// <summary>
        /// Sorts the list, nothing else.
        /// </summary>
        private void setSort()
        {
            switch (fmSortColumn)
            {
                case ARCHIVE:
                    foundFMs.Sort(new SortArchive(fmSortOrder));
                    break;
                case FM_SIZE:
                    foundFMs.Sort(new SortSize(fmSortOrder));
                    break;
                case TITLE:
                    foundFMs.Sort(new SortTitle(fmSortOrder, sortIgnoreArticles, i.IniReadValue(secOptions, "ArticleWords")));
                    break;
                case RATING:
                    foundFMs.Sort(new SortRating(fmSortOrder));
                    break;
                case FINISHED:
                    foundFMs.Sort(new SortFinished(fmSortOrder));
                    break;
                case RELEASE_DATE:
                    foundFMs.Sort(new SortRelDate(fmSortOrder));
                    break;
                case LAST_PLAYED:
                    foundFMs.Sort(new SortLastPlayed(fmSortOrder));
                    break;
                case COMMENT:
                    foundFMs.Sort(new SortComment(fmSortOrder));
                    break;
                case DISABLED_MODS:
                    foundFMs.Sort(new SortDisabledMods(fmSortOrder));
                    break;
                case INSTALLED:
                    foundFMs.Sort(new SortInstalled(fmSortOrder));
                    break;
                default:
                    foundFMs.Sort(new SortTitle(fmSortOrder, sortIgnoreArticles, i.IniReadValue(secOptions, "ArticleWords")));
                    break;
            }

            //Clear sort arrows
            for (int x = 0; x < fmTable.ColumnCount; x++)
            {
                fmTable.Columns[x].HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            fmTable.Columns[fmSortColumn].HeaderCell.SortGlyphDirection = fmSortOrder;

            setFilter();
        }

        private void restoreShowTagState()
        {
            string showTagsString = i.IniReadValue(secOptions, kShowTags);
            if (showTagsString == "0")
                hideTags();
            else //not specified or any non zero string
                showTags(true);
        }

        private void restoreWindowState()
        {
            string winState = i.IniReadValue(secOptions, kWindowState);
            if (winState == FormWindowState.Maximized.ToString())
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                string[] coordSplit = winState.Split(',');
                if (coordSplit.Length == 4)
                {
                    int w;
                    int h;
                    int x;
                    int y;

                    if (int.TryParse(coordSplit[0], out w)
                        && int.TryParse(coordSplit[1], out h)
                        && int.TryParse(coordSplit[2], out x)
                        && int.TryParse(coordSplit[3], out y))
                    {
                        Size = new Size(w, h);
                        Location = new Point(x, y);
                    }
                    else
                    {
                        WindowState = FormWindowState.Maximized;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the column widths by reading them from the ini file.
        /// </summary>
        private void setColumnWidths()
        {
            //Original format: width,width,width...
            string widthString = i.IniReadValue(secOptions, kCWidths);
            if (widthString != "")
            {
                //Count col widths specified in file
                string[] colStringCount = widthString.Split(',');
                int countFromFile = colStringCount.Length;

                if (countFromFile != fmTable.ColumnCount)
                {
                    //size added after archive
                    int comPos = widthString.IndexOf(',');
                    widthString = widthString.Insert(comPos + 1, "50,");
                }

                string[] colWidths = widthString.Split(',');

                int[] realWidths = Array.ConvertAll(colWidths, int.Parse);

                int x = 0;
                foreach (DataGridViewColumn col in fmTable.Columns)
                {
                    col.Width = realWidths[x];
                    x++;
                }
            }
        }

        /// <summary>
        /// In VS it's easier for the html window to be smaller than the readme box. This gives it the same size and location.
        /// </summary>
        private void setHTMLReadmeSizeLoc()
        {
            webBrowser1.Location = readmeBox.Location;
            webBrowser1.Size = readmeBox.Size;
        }

        /// <summary>
        /// Shows the setup window.
        /// </summary>
        /// <param name="firstRun">When there is no ini file, this is true.</param>
        /// <param name="alreadyRunning">True if the user has run setup via the button. Prevents file being re-read.</param>
        private void showSetup(bool firstRun, bool alreadyRunning)
        {
            Setup setupWindow = new Setup(i, secOptions, kArchive_root, kLanguage, kDate_format, kBackup_type, k7zipG, kUse7zNoWin, currentReturnType, kAlwaysPlay, setupTitle, fmArchFolderBox, folderIsFMsWarning, fmInstalledPath, browseButton, langBox, dateFormatBox, dmyChk, mdyChk, saveBackupBox, bkTypeAsk, bkTypeAlways, dbClFMBox, dbClChk, returnAfterBox, retTypeNeverRdo, afterFMRdo, alwaysRdo, opt7zBox, help7z1, help7z2, use7zeChk1, use7zeChk2, okBtnText, cancBtnText, folderRequired, errorTitle, webSearchSite, noSiteLabel, articleLabel, articleTip, sortIgnoreArticles, firstRun);
            DialogResult dR = setupWindow.ShowDialog();

            if (dR == DialogResult.OK)
            {
                //Remember previous values
                string oldArchiveRoot = fmArchivePath;
                string oldDateFormat = dateFormat;

                SetupInfo sInfo = setupWindow.getSetupInfo;
                i.IniWriteValue(secOptions, kArchive_root, sInfo.archiveDir);
                i.IniWriteValue(secOptions, kLanguage, sInfo.lang.ToString());
                i.IniWriteValue(secOptions, kDate_format, sInfo.dateFormat.ToString());
                if (sInfo.dcDontAsk)
                {
                    i.IniWriteValue(secOptions, kAlwaysPlay, "1");
                    alwaysPlayOnDC = true;
                }
                else
                {
                    i.IniWriteValue(secOptions, kAlwaysPlay, "0");
                    alwaysPlayOnDC = false;
                }

                i.IniWriteValue(secOptions, kBackup_type, sInfo.backupType);

                i.IniWriteValue(secOptions, currentReturnType, sInfo.returnAfterPlaying.ToString()); //write DebriefFM value

                i.IniWriteValue(secOptions, k7zipG, sInfo.sevenZipGExe);
                if (sInfo.useNoWinExe)
                    i.IniWriteValue(secOptions, kUse7zNoWin, "1");
                else
                    i.IniWriteValue(secOptions, kUse7zNoWin, null);

                i.IniWriteValue(secOptions, "WebSearchSite", sInfo.webSearchSite);
                i.IniWriteValue(secOptions, "ArticleWords", sInfo.specialWords.ToLower());
                i.IniWriteValue(secOptions, "SortIgnoreArticles", sInfo.sortIgnoreArticles.ToString());
                sortIgnoreArticles = sInfo.sortIgnoreArticles;

                readINIData();

                if (oldArchiveRoot != fmArchivePath || oldDateFormat != dateFormat)
                {
                    //reset table
                    fmTable.ClearSelection();
                    fmTable.Rows.Clear();
                    fillFMList();
                }

                setInterfaceText();
                //Change Play FM button text
                if (selFMID >= 0) //Don't do this on first startup when there is no selected FM.
                {
                    setPlayFMButtonText(foundFMs[selFMID].title);
                }
            }
        }

        /// <summary>
        /// Sets the game title to display in the Play Original button. Also sets program's icon.
        /// </summary>
        /// <param name="exeSimpleName">Filename without extension.</param>
        private void setGameName(string exeSimpleName)
        {
            gameName = "Original Game";

            if (exeSimpleName.ToLower() == "thief2")
            {
                gameName = "Thief 2";
                Icon = Properties.Resources.t2;
            }
            else if (exeSimpleName.ToLower() == "thief" || exeSimpleName.ToLower().Contains("gold"))
            {
                gameName = "Thief";
                Icon = Properties.Resources.t1;
            }
            else if (exeSimpleName.Contains('3'))
            {
                gameName = "Thief 3";
                Icon = Properties.Resources.t3;
                gameIsThief3 = true;
            }
            else if (exeSimpleName.ToLower() == "shock2")
            {
                gameName = "System Shock 2";
                Icon = Properties.Resources.Shock2;
                gameIsShock2 = true;
            }

            btnPlOriginal.Text = playTextPart1 + " " + gameName;

            if (exeSimpleName.ToLower().Contains("dromed"))
            {
                Icon = Properties.Resources.sp;
                playTextPart1 = editText;
                btnPlOriginal.Text = "DromEd";
                currentReturnType = kReturn_type_ed;
                generateFMiniToolStripMenuItem.Visible = true;
            }
            else if (exeSimpleName.ToLower().Contains("shocked"))
            {
                Icon = Properties.Resources.sp;
                playTextPart1 = editText;
                btnPlOriginal.Text = "ShockEd";
                currentReturnType = kReturn_type_ed;
                generateFMiniToolStripMenuItem.Visible = true;
            }
        }

        private List<string> archiveExtensions = new List<string>();

        /// <summary>
        /// Read values from the ini object and set global variables.
        /// </summary>
        /// <param name="alreadyRunning">True when the user has manually entered Setup. False on load, where the file will be read.</param>
        private void readINIData()
        {
            getExtensions();

            fmArchivePath = getStringFromINI(secOptions, kArchive_root, StringType.TextWithQuotesRemoved, i);
            langNDL = readLangFromINI();
            dateFormat = readDateFormatFromINI();
            backupType = getStringFromINI(secOptions, kBackup_type, StringType.TextWithQuotesRemoved, i);
            //returnType stays at 0 if string not found
            int.TryParse(getStringFromINI(secOptions, currentReturnType, StringType.SimpleNumber, i), out returnType);
            sevenZipGExe = getStringFromINI(secOptions, k7zipG, StringType.TextWithQuotesRemoved, i);
            if (sevenZipGExe != "" && i.IniReadValue(secOptions, kUse7zNoWin) != "")
            {
                use7zNoWin = true;
                sevenZipNoWin = sevenZipGExe.ToLower().Replace("7zg.exe", "7z.exe");
            }

            string dblClick = i.IniReadValue(secOptions, kAlwaysPlay);
            if (dblClick != "" && dblClick != "0")
                alwaysPlayOnDC = true;

            //Logger.LogThisLine("Reading 'Ignore Articles' option.");
            string sortNoArticles = i.IniReadValue(secOptions, "SortIgnoreArticles");
            if (sortNoArticles.ToLower() == "true")
                sortIgnoreArticles = true;

            string sort = i.IniReadValue(secOptions, kSortOrder);
            if (sort == "2")
                fmSortOrder = SortOrder.Descending;

            string splitString = i.IniReadValue(secOptions, kSplitDist);
            if (splitString != "")
            {
                double newDist;
                if (double.TryParse(splitString, out newDist))
                {
                    int realDist = Convert.ToInt32(Math.Round(splitContainer1.Height * newDist, 0));
                    splitContainer1.SplitterDistance = realDist;
                }
                else
                    defaultSplit();
            }
            else
                defaultSplit();
        }

        private void defaultSplit()
        {
            double def = splitContainer1.Height * 0.45;
            int rounded = Convert.ToInt32(Math.Round(def, 0));
            splitContainer1.SplitterDistance = rounded;
        }

        /// <summary>
        /// Read the ini file and save the sections/keys/values as an iniFile object.
        /// </summary>
        private void readINIFileToData(string t3insFMPath)
        {
            fmInstalledPath = gamePath + "\\FMs"; // default

            if (gameIsThief3)
            {
                btnTools.Visible = false;
                //Does not end with \\
                //string sneakyOptionsFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Documents\\Thief - Deadly Shadows\\Options\\SneakyOptions.ini";

                //INIFile snOptIni = new INIFile(sneakyOptionsFile);
                //fmInstalledPath = getStringFromINI("Loader", "InstallPath", StringType.TextWithQuotesRemoved, snOptIni);
                fmInstalledPath = t3insFMPath;
            }
            else
            {
                string newFMInstalledPath = getFMInsPathFromCam_Mod();
                if (newFMInstalledPath != "")
                    fmInstalledPath = newFMInstalledPath;

                titlesStr = userTempFolder + "titles.str";
            }

            if (!Directory.Exists(fmInstalledPath))
            {
                Directory.CreateDirectory(fmInstalledPath);
            }

            iniPath = fmInstalledPath + "\\NewDarkLoader.ini";

            if (!File.Exists(iniPath))
            {
                //Logger.LogThisLine("iniPath does not exist. Writing new file.");
                File.WriteAllText(iniPath, "[" + secOptions + "]");
            }

            i = new INIFile(iniPath);
        }

        private string getFMInsPathFromCam_Mod()
        {
            string userPath = "";
            string camModPath = gamePath + "\\cam_mod.ini";
            //Logger.LogThisLine("Reading cam_mod for alternate fm path.");
            string[] fileLines = File.ReadAllLines(camModPath, Encoding.Default);

            foreach (string line in fileLines)
            {
                if (line.ToLower().StartsWith("fm_path"))
                {
                    //Logger.LogThisLine("Found alternate fm path.");
                    int firstSpace = line.IndexOf(' ');
                    string pathFromIni = line.Substring(firstSpace + 1);
                    userPath = Path.GetFullPath(pathFromIni); //Only works when run from the .dll in the game's folder.
                    if (!NDLRunFromDLL) //For testing an an .exe, replace .\ with the game's .exe path.
                    {
                        if (pathFromIni.StartsWith(".\\"))
                        {
                            userPath = pathFromIni.Replace(".\\", gamePath + "\\");
                        }
                    }
                    break;
                }
            }
            return userPath;
        }

        /// <summary>
        /// Gets a list of valid archive file extensions.
        /// </summary>
        private void getExtensions()
        {
            //Logger.LogThisLine("Getting list of valid archive extensions.");
            string extString = i.IniReadValue(secOptions, kExtensions);

            if (extString == "")
            {
                extString = "zip,7z,rar"; //set defaults
                i.IniWriteValue(secOptions, kExtensions, extString);
            }

            string[] allExts = extString.Split(',');
            foreach (string ext in allExts)
            {
                archiveExtensions.Add("." + ext);
                //Logger.LogThisLine("Archive extension: " + ext);
            }
        }

        private string readDateFormatFromINI()
        {
            //Logger.LogThisLine("Reading date from ini.");
            string readDate = i.IniReadValue(secOptions, kDate_format);

            if (readDate == "2")
            {
                return "MM/dd/yyyy";
            }
            else if (readDate == "1")
            {
                return "dd/MM/yyyy";
            }
            else
            {
                return ""; //usually from date not set
            }
        }

        private string readLangFromINI()
        {
            //Logger.LogThisLine("Reading \"Language\" from ini.");
            int langNumber = 1; //Default: english
            string readLang = i.IniReadValue(secOptions, kLanguage);

            if (readLang != "")
                langNumber = Convert.ToInt32(readLang);

            return LangList.getLanguageList()[langNumber - 1];
        }

        private void fillFMList()
        {
            foundFMs.Clear();
            Stopwatch s = new Stopwatch();

            #region Archives
            //s.Start();
            string[] fullPaths = Directory.GetFiles(fmArchivePath, "*.*", SearchOption.AllDirectories);
            for (int x = 0; x < fullPaths.Length; x++)
            {
                string simpleName = Path.GetFileNameWithoutExtension(fullPaths[x]);
                string extension = Path.GetExtension(fullPaths[x]);
                string subFolder = Path.GetDirectoryName(fullPaths[x]).Replace(fmArchivePath, "").TrimEnd('\\');
                string sectionName = "FM=" + ArchiveExtract.ArchiveExtracedFolderName(simpleName);

                if (!simpleName.ToLower().Contains("fmselbak") && validArchiveExtension(simpleName + extension) && !subFolder.Contains(".fix"))
                    addFMToList(simpleName, subFolder, extension, sectionName, FMType.Archive);
            }
            //s.Stop();
            textBox1.AppendText("\r\nScan archives: " + s.ElapsedMilliseconds);
            s.Reset();
            #endregion

            #region look for fms with no archive
            //s.Start();
            string[] dirs = Directory.GetDirectories(fmInstalledPath);
            for (int x = 0; x < dirs.Length; x++)
            {
                string[] filesInDir = Directory.GetFiles(dirs[x], "*.*", SearchOption.AllDirectories);
                string dirName = Path.GetFileName(dirs[x]); //folder name without full path
                if (dirs[x].ToLower() != ".fmsel.cache" && filesInDir.Length != 0)
                {
                    if (dirNotInList(dirName))
                    {
                        string sectionName = "FM=" + dirName;
                        addFMToList(dirName, "", "", sectionName, FMType.Directory);
                    }
                }
            }
            //s.Stop();
            textBox1.AppendText("\r\nScan dirs: " + s.ElapsedMilliseconds);
            s.Reset();

            //s.Start();
            fmTable.RowCount = foundFMs.Count;
            //s.Stop();
            textBox1.AppendText("\r\nFM table filled: " + s.ElapsedMilliseconds);

            #endregion

            restoreSortOrder();

            fmTable.Select(); //allows uer to immediately use cursor keys to scroll down the table

            //updateAllCellTips();
        }

        /// <summary>
        /// Fills fmTable using the contents of the foundFMs list
        /// </summary>
        private void listToTable()
        {
            List<string> existingFMs = new List<string>(foundFMs.Count);

            for (int x = 0; x < foundFMs.Count; x++)
            {
                FanMission fm = foundFMs[x];
                string ratingString = "";
                if (fm.rating != 0)
                    ratingString = fm.rating.ToString();
                if (!existingFMs.Contains(fm.sectionName)) //Checks for duplicates
                {
                    fmTable.Rows.Add(fm.archive, fm.sizeMB, fm.title, ratingString, fm.imgFinished, fm.relDateString, fm.lastPlayedString,
                       fm.comment, fm.disabledMods, fm.installed, fm.sectionName, fm.gameID, fm.finishedID,
                       fm.relDateHex, fm.archiveOrDirectory, fm.extractionName, fm.saveBackupName, fm.darkloaderSaves, fm.lastPlayedHex,
                       fm.subFolder, fm.sizeBytes);
                }
                existingFMs.Add(fm.sectionName); //Prevents duplicates
            }
        }

        /// <summary>
        /// Adds the found FM to the foundFM list.
        /// </summary>
        /// <param name="simpleName">Archive name without extension, or folder name.</param>
        /// <param name="subFolder">Folders relative to fmArchivePath. Starts with \\, does not end with \\</param>
        /// <param name="extension">.zip, .7z etc.</param>
        /// <param name="sectionName">Value for the ini file.</param>
        private void addFMToList(string simpleName, string subFolder, string extension, string sectionName, FMType archOrDir)
        {
            //Create FM object with values ready for table
            FanMission nFM = new FanMission();
            nFM.archive = simpleName + extension;
            string sizeBytes = getStringFromINI(sectionName, kSizeBytes, StringType.SimpleNumber, i);
            nFM.sizeBytes = 0; //Placeholders
            nFM.sizeMB = "";
            if (sizeBytes != "")
            {
                nFM.sizeBytes = long.Parse(sizeBytes);
                nFM.sizeMB = getFMSizeInMB(nFM.sizeBytes);
            }
            nFM.title = getTitleFromINI(simpleName, sectionName);
            nFM.rating = getIntFromINI(sectionName, kRating, i, -1);
            nFM.finishedID = getIntFromINI(sectionName, kFinished, i, 0);
            nFM.imgFinished = getFinishedFromINI(sectionName);
            nFM.relDateString = getDateFromINI(sectionName, DateType.Release);
            nFM.relDateHex = getStringFromINI(sectionName, kRelease_date, StringType.TextWithQuotesRemoved, i);
            nFM.lastPlayedString = getDateFromINI(sectionName, DateType.LastPlayed);
            nFM.lastPlayedHex = getStringFromINI(sectionName, kLast_played, StringType.TextWithQuotesRemoved, i);
            nFM.comment = getStringFromINI(sectionName, kComment, StringType.TextWithQuotesRemoved, i);
            nFM.disabledMods = getStringFromINI(sectionName, kNo_mods, StringType.TextWithQuotesRemoved, i);
            if (Directory.Exists(fmInstalledPath + "\\" + ArchiveExtract.ArchiveExtracedFolderName(simpleName)))
                nFM.installed = colInstalled;
            else
                nFM.installed = "";
            nFM.sectionName = sectionName;
            nFM.gameID = ""; //unused
            nFM.archiveOrDirectory = archOrDir;
            if (archOrDir == FMType.Archive)
                nFM.extractionName = ArchiveExtract.ArchiveExtracedFolderName(simpleName);
            else
            {
                nFM.extractionName = simpleName;
            }
            nFM.saveBackupName = simpleName + ".FMSelBak.zip";
            nFM.darkloaderSaves = simpleName + "_saves.zip";
            nFM.subFolder = subFolder;
            nFM.fmTags = getFMTags(nFM.sectionName);

            foundFMs.Add(nFM);
        }

        /// <summary>
        /// Sets tooltips for all cells, and right click hint.
        /// </summary>
        private void updateAllCellTips()
        {
            for (int x = 0; x < fmTable.Rows.Count; x++)
            {
                for (int y = 0; y < fmTable.Rows[x].Cells.Count; y++)
                {
                    setCellTip(x, y);
                }
            }
        }

        /// <summary>
        /// Sets tooltip for specific cell, and right click hint.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        private void setCellTip(int row, int col)
        {
            //string tip = rightClickTip;
            //string content = "";
            //if(cellString(col, row) !=null)
            //{
            //    string cellValue = "";
            //    if (col == FINISHED)
            //    {
            //        cellValue = getFinishedText(cellString(FINISHED_ID, row));
            //    }
            //    else
            //    {
            //        cellValue = cellString(col, row);
            //    }

            //    if (cellValue != "")
            //        content = cellValue + "\n";
            //}
            //fmTable.Rows[row].Cells[col].ToolTipText = content + tip + "\n" + refresh;
        }

        /// <summary>
        /// Get something like "Normal, Hard" for some finsished ID string, e.g. "3".
        /// </summary>
        /// <param name="finID">Value from FINISHED_ID.</param>
        private string getFinishedText(int finID)
        {
            string normal = diffNormal;
            string hard = diffHard;
            string expert = diffExpert;
            string extreme = diffExtreme;

            if (gameIsThief3)
            {
                normal = diffT3Easy;
                hard = diffNormal;
                expert = diffHard;
                extreme = diffExpert;
            }

            switch (finID)
            {
                case 0:
                    return "";
                case 1:
                    return normal;
                case 2:
                    return hard;
                case 3:
                    return normal + ", " + hard;
                case 4:
                    return expert;
                case 5:
                    return normal + ", " + expert;
                case 6:
                    return hard + ", " + expert;
                case 7:
                    return normal + ", " + hard + ", " + expert;
                default:
                    return extreme;
            }
        }

        /// <summary>
        /// True if the specified file has an extension that's in the list generated by reading from ndl.ini.
        /// </summary>
        private bool validArchiveExtension(string filename)
        {
            bool valid = false;

            foreach (string ext in archiveExtensions)
            {
                if (filename.ToLower().EndsWith(ext))
                {
                    valid = true;
                    break;
                }
            }

            return valid;
        }

        /// <summary>
        /// Gets the 'last played' FM name from the ini file and scrolls to it.
        /// </summary>
        private void selectLastPlayed()
        {
            //Select previously played FM
            string lastSelFM = "FM=" + i.IniReadValue(secOptions, kLast_fm);
            if (lastSelFM != "FM=" && lastSelFM != "")
            {
                selectRow(lastSelFM);
            }
            else selectRow(foundFMs[0].sectionName);
        }

        /// <summary>
        /// Selects a row that has the given section name. If it's not visible (filtered out) it selects the first visible FM.
        /// </summary>
        /// <param name="sectionName">FM=something</param>
        private void selectRow(string sectionName)
        {
            fmTable.CurrentCell = null;
            //fmTable.ClearSelection();

            int rowID = 0;
            for (int x = 0; x < foundFMs.Count; x++)
            {
                if (foundFMs[x].sectionName == sectionName)
                {
                    rowID = x;
                    break;
                }
            }

            if (fmTable.Rows[rowID].Visible)
            {
                //fmTable.Rows[rowID].Selected = true;
                fmTable.CurrentCell = fmTable.Rows[rowID].Cells[0];
                //fmTable.FirstDisplayedScrollingRowIndex = fmTable.SelectedRows[0].Index;
            }
            else
            {
                for (int x = 0; x < fmTable.RowCount; x++)
                {
                    if (fmTable.Rows[x].Visible)
                    {
                        fmTable.CurrentCell = fmTable.Rows[x].Cells[0];
                        //fmTable.FirstDisplayedScrollingRowIndex = fmTable.SelectedRows[0].Index;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Archives already added. This returns true if no 'extraction names' match this folder.
        /// </summary>
        /// <param name="dirName">Simple folder name.</param>
        /// <returns></returns>
        private bool dirNotInList(string dirName)
        {
            bool notFound = true;
            foreach (FanMission fm in foundFMs)
            {
                if (fm.extractionName == dirName)
                {
                    notFound = false;
                    break;
                }
            }
            return notFound;
        }

        private string getDateFromINI(string sectionName, DateType relPlay)
        {
            string iniDate;

            if (relPlay == DateType.Release)
                iniDate = i.IniReadValue(sectionName, kRelease_date);
            else //DateType.LastPlayed
                iniDate = i.IniReadValue(sectionName, kLast_played);

            if (iniDate != "" && iniDate != null)
            {
                return DateIntConverter.dateStringFromHexString(iniDate, dateFormat);
            }
            else return "";
        }

        private void writeDateToINI(string sectionName, DateType relPlay, string dateString)
        {
            string keyName;
            if (relPlay == DateType.Release)
                keyName = kRelease_date;
            else //DateType.LastPlayed
                keyName = kLast_played;

            i.IniWriteValue(sectionName, keyName, DateIntConverter.dateStringToHexString(dateString));
        }

        private enum DateType { Release, LastPlayed }

        /// <summary>
        /// Looks in NDL's ini to see if the name has been defined. If not, returns the archive's simple name.
        /// </summary>
        /// <param name="simpleName">Archive simple filename.</param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        private string getTitleFromINI(string simpleName, string sectionName)
        {
            string fmName = i.IniReadValue(sectionName, kFm_title);

            if (fmName != "") return fmName;
            else return simpleName;
        }

        /// <summary>
        /// Reads the ini and returns the value as an int. No value returns -1.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="key"></param>
        /// <param name="ini"></param>
        /// <param name="defaultValue">Value to return if no text is found.</param>
        /// <returns></returns>
        private int getIntFromINI(string sectionName, string key, INIFile ini, int defaultValue)
        {
            string result = ini.IniReadValue(sectionName, key);
            int converted = defaultValue;
            if (result != "")
            {
                converted = int.Parse(result);
            }
            return converted;
        }

        private string getStringFromINI(string sectionName, string key, StringType sType, INIFile ini)
        {
            //Logger.LogThisLine("Reading [" + sectionName + "], " + key + " from ini file.");
            string result = ini.IniReadValue(sectionName, key);

            if (sType == StringType.TextWithQuotesRemoved)
            {
                if (result != "" && result != null)
                {
                    result = result.Replace("\"", "");
                }
            }
            //Logger.LogThisLine("\tValue: " + result);

            return result;
        }

        private enum StringType { SimpleNumber, TextWithQuotesRemoved }

        private Image getFinishedFromINI(string sectionName)
        {
            Image finishedState = NewDarkLoader.Properties.Resources.blank; //default

            string finishString = i.IniReadValue(sectionName, kFinished);

            int fNumber;

            if (Int32.TryParse(finishString, out fNumber))
            {
                if (fNumber == 1) finishedState = NewDarkLoader.Properties.Resources.normal;
                else if (fNumber == 2) finishedState = NewDarkLoader.Properties.Resources.hard;
                else if (fNumber == 3) finishedState = NewDarkLoader.Properties.Resources.nh;
                else if (fNumber == 4) finishedState = NewDarkLoader.Properties.Resources.expert;
                else if (fNumber == 5) finishedState = NewDarkLoader.Properties.Resources.nexp;
                else if (fNumber == 6) finishedState = NewDarkLoader.Properties.Resources.hexp;
                else if (fNumber == 7) finishedState = NewDarkLoader.Properties.Resources.nhexp;
                else if (fNumber >= 8) finishedState = NewDarkLoader.Properties.Resources.extreme;
            }
            return finishedState;
        }

        public string getFMNameFromDir(string fmFolderName, string sectionName, bool overwriteTitle = false)
        {
            string fmFolderPath = fmInstalledPath + "\\" + fmFolderName;
            string foundName = "";
            //Look for niceName in ini file
            string niceName = i.IniReadValue(sectionName, kFm_title);

            if (!gameIsThief3) //might not even need this
            {
                findTitlesStr(fmFolderPath);
                string foundTitle = "";

                if (niceName != "" && !overwriteTitle) foundName = niceName;
                else
                {
                    if (File.Exists(titlesStr))
                    {
                        Point nums = numMisFilesInDir(fmFolderPath);
                        foundTitle = getNameFromTitlesStr(nums.X, nums.Y, false);
                    }
                }

                if (foundTitle == "")
                {
                    foundName = readmeTitleSearch();
                    if (foundName == "")
                        foundName = fmFolderName; //useful for demo missions that have no titles.str or readme.
                }
                else foundName = foundTitle;
            }

            return foundName;
        }

        /// <summary>
        /// Set the filenames of titles.str and missflag.str, if they exist.
        /// </summary>
        /// <param name="fmFolderPath"></param>
        private void findTitlesStr(string fmFolderPath)
        {
            bool found = false;
            DirectoryInfo dI = new DirectoryInfo(fmFolderPath);
            FileInfo[] allFiles = dI.GetFiles("*.*", SearchOption.AllDirectories);
            //look for language first
            foreach (FileInfo fI in allFiles)
            {
                if (fI.FullName.ToLower().EndsWith("strings\\" + langGame.ToLower() + "\\titles.str"))
                {
                    titlesStr = fI.FullName;
                    found = true;
                    break;
                }
            }

            //only look for non-language specific if language str is not found
            if (!found)
            {
                foreach (FileInfo fI in allFiles)
                {
                    if (fI.FullName.ToLower().EndsWith("strings\\titles.str"))
                    {
                        titlesStr = fI.FullName;
                        break;
                    }
                }
            }

            //look for missflag.str
            foreach (FileInfo fI in allFiles)
            {
                if (fI.FullName.ToLower().EndsWith("strings\\missflag.str"))
                {
                    missflagStr = fI.FullName;
                    break;
                }
            }
        }

        /// <summary>
        /// Work out the name of this FM. And show it in table.
        /// </summary>
        /// <param name="simpleFilename">FM archive name, no extension. Or folder name, no path.</param>
        /// <param name="sectionName">Section in INI file.</param>
        /// <param name="fNameWithExt">FM archive name, with extension.</param>
        /// <param name="overwriteTitle">True if archive is to be re-scanned rather than getting it from the ini.</param>
        /// <returns></returns>
        private string getFMNameFromArchive(string simpleFilename, string sectionName, string fNameWithExt, string subFolder, bool overwriteTitle = false)
        {
            string foundName = "";
            //Look for niceName in ini file
            string niceName = i.IniReadValue(sectionName, kFm_title);

            if (!gameIsThief3)
            {
                extractTitlesStr(subFolder, fNameWithExt);

                string foundTitle = "";

                if (niceName != "" && !overwriteTitle) foundName = niceName;
                else
                {
                    if (File.Exists(titlesStr))
                    {
                        Point misNumbers = numMisFilesInArchive(subFolder, fNameWithExt);
                        foundTitle = getNameFromTitlesStr(misNumbers.X, misNumbers.Y, true);
                        FullDelete.DeleteFile(titlesStr);
                    }
                }

                if (foundTitle == "")
                {
                    foundName = readmeTitleSearch();
                    if (foundName == "")
                        foundName = simpleFilename; //useful for demo missions that have no titles.str or readme.
                }
                else foundName = foundTitle;
            }
            else
            {
                foundName = getT3FMTitle(simpleFilename, sectionName, fNameWithExt, subFolder);
            }

            return foundName;
        }

        private string getT3FMTitle(string simpleFilename, string sectionName, string fNameWithExt, string subFolder)
        {
            return "Something";
        }

        //private string getT3FMTitle(string simpleFilename, string sectionName, string fNameWithExt, string subFolder)
        //{
        //    SevenZipExtractor ext = new SevenZipExtractor(fmArchivePath + subFolder + "\\" + fNameWithExt);

        //    //FM ini already looked for
        //    //NDL ini already looked in
        //    //Look for GLML file and GLTITLE tags
        //    //Extract glml file
        //    string foundTitle = "";
        //    string glFile = userTempFolder + "readme.glml";
        //    bool found = false;
        //    for (int x = 0; x < ext.ArchiveFileNames.Count; x++ )
        //    {
        //        if (ext.ArchiveFileNames[x].ToLower().EndsWith(".glml"))
        //        {
        //            if (sevenZipGExe == "")
        //            {
        //                FileStream glFS = new FileStream(glFile, FileMode.Create);
        //                ext.ExtractFile(x, glFS);
        //                glFS.Close();
        //            }
        //            else
        //            {
        //                SevenZipGExtract.ExtractFile(choose7ZProg(), fmArchivePath, subFolder, fNameWithExt, userTempFolder, ext.ArchiveFileNames[x], false);
        //                //Filename coulde be "folder\\something.glml" or just something.glml
        //                string[] fNameSplit = ext.ArchiveFileNames[x].Split('\\');
        //                string basicFilename = fNameSplit[fNameSplit.Length - 1]; //get the last part, even if there's only 1 element.
        //                glFile = userTempFolder + basicFilename;
        //            }

        //            //read the glml file to find the GLTITLe tags
        //            string[] fileLines = File.ReadAllLines(glFile);
        //            foreach (string line in fileLines)
        //            {
        //                if (line.Contains("GLTITLE"))
        //                {
        //                    foundTitle = extractString(line, "GLTITLE");
        //                    found = true;
        //                    break;
        //                }
        //                else if (line.Contains("gltitle"))
        //                {
        //                    foundTitle = extractString(line, "gltitle");
        //                    found = true; 
        //                    break;
        //                }
        //            }
        //        }
        //        if (found) break;
        //    }

        //    if (!found) //look in each text file if title was not found in glml, or glml did not exist
        //    {
        //        string infoFile = i.IniReadValue(sectionName, kInfoFile);
        //        for (int x = 0; x < ext.ArchiveFileNames.Count; x++)
        //        {
        //            if(infoFile != "") //start by looking in the specified InfoFile (saves time when there are multiple texts)
        //            {
        //                if (ext.ArchiveFileNames[x] == infoFile)
        //                {
        //                    foundTitle = getTitleFromText(ext, fNameWithExt, x, sectionName);
        //                    break;
        //                }
        //            }
        //            else if (textFile(ext.ArchiveFileNames[x])) //If no InfoFile specified, look through each text file.
        //            {
        //                foundTitle = getTitleFromText(ext, fNameWithExt, x, sectionName);
        //                break;
        //            }
        //        }
        //    }

        //    return foundTitle;
        //}

        private bool textFile(string pathInArchive)
        {
            bool extMatches = false;
            List<string> extensions = new List<string>(4);
            extensions.Add(".txt");
            extensions.Add(".rtf");
            extensions.Add(".html");
            extensions.Add(".html");

            foreach (string e in extensions)
            {
                if (pathInArchive.ToLower().EndsWith(e))
                {
                    extMatches = true;
                    break;
                }
            }

            return extMatches;
        }

        private string getTitleFromText(SevenZipExtractor ext, string archiveFilename, int fileIndex, string sectionName)
        {
            string title = "";
            string archPath = userTempFolder + archiveFilename;

            string[] fNameSplit = ext.ArchiveFileNames[fileIndex].Split('\\');
            string basicFilename = fNameSplit[fNameSplit.Length - 1]; //get the last part, even if there's only 1 element.
            string readmeFilename = userTempFolder + basicFilename;

            extractReadme(archiveFilename, readmeFilename, sectionName);

            title = readmeTitleSearch();

            return title;
        }

        /// <summary>
        /// Searches a readme (assumes already extracted) for a Title : ... line.
        /// </summary>
        private string readmeTitleSearch()
        {
            string title = "";
            string[] fileLines = File.ReadAllLines(readmePath);

            if (fileIsRTF(fileLines))
            {
                RichTextBox tempBox = new RichTextBox();
                tempBox.Rtf = File.ReadAllText(readmePath);
                string pText = tempBox.Text;
                pText = pText.Replace("\t", "");
                string[] plainLines = pText.Split('\n');
                title = titleFromStringArray(plainLines);
            }
            else
            {
                title = titleFromStringArray(fileLines);
            }

            return title;
        }

        private string titleFromStringArray(string[] fileLines)
        {
            string title = "";
            foreach (string line in fileLines)
            {
                if (!line.ToLower().Contains("titles") && line.ToLower().Contains("title") && line.Contains(":"))
                {
                    int colonLoc = line.IndexOf(':');
                    title = line.Substring(colonLoc + 1).Trim().Replace("\"", "");
                    break;
                }
            }
            return title;
        }

        // Extract text between GLTITLE tags
        private string extractString(string s, string tag)
        {
            var startTag = "[" + tag + "]";
            int startIndex = s.IndexOf(startTag) + startTag.Length;
            int endIndex = s.IndexOf("[/" + tag + "]", startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Extract titles.str to temp folder. Also extracts missflag in case that's needed.
        /// </summary>
        /// <param name="fileNameWithExt">FM's archvie filename, no path.</param>
        private void extractTitlesStr(string subFolder, string fNameWithExt)
        {
            if (File.Exists(fmArchivePath + subFolder + "\\" + fNameWithExt))
            {
                SevenZipExtractor ext = new SevenZipExtractor(fmArchivePath + subFolder + "\\" + fNameWithExt);

                //Find titles.str - extraction is case sensitive so the exact name must be found first
                List<string> fnames = new List<string>(); //dummy list, only needed for below
                System.Collections.ObjectModel.ReadOnlyCollection<string> archFiles = new System.Collections.ObjectModel.ReadOnlyCollection<string>(fnames);

                archFiles = ext.ArchiveFileNames;

                //store as lowercase for searching
                foreach (string s in archFiles)
                {
                    fnames.Add(s.ToLower());
                }

                bool extracted = false;

                extracted = findTitlesInArchive(subFolder, fNameWithExt, ext, fnames, "strings\\" + langGame.ToLower() + "\\titles.str");

                //only look for non-language specific if language str is not found
                if (!extracted)
                {
                    extracted = findTitlesInArchive(subFolder, fNameWithExt, ext, fnames, "strings\\titles.str");
                }

                //if still not found, look in English
                if (!extracted)
                {
                    extracted = findTitlesInArchive(subFolder, fNameWithExt, ext, fnames, "strings\\english\\titles.str");
                }

                //look for missflag.str
                for (int x = 0; x < fnames.Count; x++)
                {
                    if (fnames[x].ToLower() == "strings\\missflag.str")
                    {
                        correctStrName(ext, x, strType.missflag);
                        if (sevenZipGExe == "")
                        {
                            extractStrInternal(ext, x, strType.missflag);
                        }
                        else
                            extractStrExternal(subFolder, fNameWithExt, ext, x, strType.missflag);
                        break;
                    }
                }
            }
        }

        private bool findTitlesInArchive(string subFolder, string fNameWithExt, SevenZipExtractor ext, List<string> fnames, string titlesPathInArchive)
        {
            bool extracted = false;
            //look for language first
            for (int x = 0; x < fnames.Count; x++)
            {
                if (fnames[x].ToLower() == titlesPathInArchive)
                {
                    correctStrName(ext, x, strType.titles);
                    extracted = true;
                    if (sevenZipGExe == "")
                    {
                        extractStrInternal(ext, x, strType.titles);
                    }
                    else
                        extractStrExternal(subFolder, fNameWithExt, ext, x, strType.titles);
                    break;
                }
            }
            return extracted;
        }

        /// <summary>
        /// Returns the path to 7zG.exe or 7z.exe
        /// </summary>
        /// <returns></returns>
        private string choose7ZProg()
        {
            if (use7zNoWin)
                return sevenZipNoWin;
            else
                return sevenZipGExe;
        }

        private enum strType { titles, missflag }

        private void extractStrExternal(string subFolder, string fNameWithExt, SevenZipExtractor ext, int fileIndex, strType titlesOrMissflag)
        {
            int exitCode = SevenZipGExtract.ExtractFile(choose7ZProg(), fmArchivePath, subFolder, fNameWithExt, userTempFolder, ext.ArchiveFileNames[fileIndex], false);
            if (exitCode != 0)
            {
                extractStrInternal(ext, fileIndex, titlesOrMissflag);
            }
        }

        private void extractStrInternal(SevenZipExtractor ext, int fileIndex, strType titlesOrMissflag)
        {
            string extPath = "";
            if (titlesOrMissflag == strType.titles)
                extPath = titlesStr;
            else
                extPath = missflagStr;

            FileStream fS_str = new FileStream(extPath, FileMode.Create);
            ext.ExtractFile(fileIndex, fS_str);
            fS_str.Close();
        }

        /// <summary>
        /// Makes sure the case is right so the file can be accessed.
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="fileIndex"></param>
        private void correctStrName(SevenZipExtractor ext, int fileIndex, strType titlesOrMissflag)
        {
            string[] split = ext.ArchiveFileNames[fileIndex].Split('\\');
            string correctStrPath = userTempFolder + split[split.Length - 1];

            if (titlesOrMissflag == strType.titles)
                titlesStr = correctStrPath;
            else
                missflagStr = correctStrPath;
        }

        private string getNameFromTitlesStr(int numMisFiles, int maxMission, bool missflagFromArchive)
        {
            string[] fileLines = File.ReadAllLines(titlesStr);

            string maxTitle = "";
            foreach (string s in fileLines)
            {
                if (s.ToLower().StartsWith("title_0"))
                {
                    maxTitle = parseTitle(s);
                    break;
                }
                else if (s.ToLower().Contains("title_" + maxMission) && !s.StartsWith("//"))
                {
                    maxTitle = parseTitle(s);
                    if (numMisFiles == 1)
                        break;
                    else
                    {
                        //look in missflag.str
                        if (lastMissionIsSkipped(maxMission, missflagFromArchive))
                            break;
                        else
                            maxTitle = ""; //reset if miss_max is not a dummy
                    }
                }
            }

            return maxTitle;
        }

        /// <summary>
        /// True if miss_## line is "skip"
        /// </summary>
        /// <param name="deleteMissflag">If true, file is deleted after being read.</param>
        /// <returns></returns>
        private bool lastMissionIsSkipped(int maxNum, bool missflagFromArchive)
        {
            bool skip = false;
            if (File.Exists(missflagStr)) //just in case FM doesn't have it
            {
                string[] fileLines = File.ReadAllLines(missflagStr);

                foreach (string line in fileLines)
                {
                    string lcLine = line.ToLower();
                    if (lcLine.Contains("miss_" + maxNum) && !lcLine.StartsWith("//"))
                    {
                        if (lcLine.Contains("skip"))
                        {
                            skip = true;
                            break;
                        }
                    }
                }

                if (missflagFromArchive)
                    FullDelete.DeleteFile(missflagStr);
            }

            return skip;
        }

        private string parseTitle(string s)
        {
            string[] split = s.Split('\"');
            return split[1].Replace('�', '\'');
        }

        //Get number of mis files and max valid mis number.
        private Point numMisFilesInDir(string fmDir)
        {
            int count = 0;
            int max = 0;
            List<int> numbers = new List<int>();

            if (File.Exists(titlesStr) && File.Exists(missflagStr))
            {
                misFileNumber = 0;

                DirectoryInfo dI = new DirectoryInfo(fmDir);
                FileInfo[] rootFiles = dI.GetFiles();
                foreach (FileInfo fI in rootFiles)
                {
                    if (fI.Name.ToLower().StartsWith("miss") && fI.Name.ToLower().EndsWith(".mis"))
                    {
                        count++;
                        string numFromFileName = Regex.Match(fI.Name, @"\d+").Value;
                        misFileNumber = Convert.ToInt32(numFromFileName);
                        numbers.Add(misFileNumber);
                    }
                }
            }

            if (count != 0)
                max = numbers.Max();

            Point result = new Point(count, max);
            return result;
        }

        /// <summary>
        /// Counts the number of mis files in the archive and sets misFileNumber for the last one. Used for searching in titles.str.
        /// </summary>
        /// <param name="archive">FM archive.</param>
        /// <returns></returns>
        private Point numMisFilesInArchive(string subFolder, string archive)
        {
            int count = 0;
            int max = 0;
            List<int> numbers = new List<int>();
            if (File.Exists(fmArchivePath + subFolder + "\\" + archive))
            {
                misFileNumber = 0;
                SevenZipExtractor ext = new SevenZipExtractor(fmArchivePath + subFolder + "\\" + archive);

                //Get list of all files in archive
                List<string> fnames = new List<string>();
                System.Collections.ObjectModel.ReadOnlyCollection<string> archFiles = new System.Collections.ObjectModel.ReadOnlyCollection<string>(fnames);
                archFiles = ext.ArchiveFileNames;

                foreach (string s in archFiles)
                {
                    if (s.ToLower().StartsWith("miss") && s.ToLower().EndsWith(".mis"))
                    {
                        count++;
                        string numFromFileName = Regex.Match(s, @"\d+").Value;
                        misFileNumber = Convert.ToInt32(numFromFileName);
                        numbers.Add(misFileNumber);
                    }
                }
            }

            if (count != 0)
                max = numbers.Max();

            Point result = new Point(count, max);

            return result;
        }

        private bool readmeRootArchive(string filePathInArchive)
        {
            bool correctRoot = false;
            if (!gameIsThief3) //readme is in root if game is Dark Engine.
            {
                if (!filePathInArchive.Contains("\\"))
                    correctRoot = true;
            }
            else //readme can be in root or specific subfolder.
            {
                if (filePathInArchive.ToLower().Replace(" ", "").StartsWith("fanmissionextras\\") || !filePathInArchive.Contains("\\"))
                    correctRoot = true;
            }
            return correctRoot;
        }

        private bool readmeRootDir(string filePath, string fmInstPath)
        {
            FileInfo fI = new FileInfo(filePath);
            bool correctRoot = false;
            if (!gameIsThief3) //Readme must be in FMs\[fm name] only
            {
                if (fI.DirectoryName.ToLower() == fmInstPath.ToLower())
                    correctRoot = true;
            }
            else //T3
            {
                if (fI.DirectoryName.ToLower().Replace(" ", "") == fmInstPath.ToLower().Replace(" ", "") + "\\fanmissionextras"
                    || fI.DirectoryName.ToLower() == fmInstPath.ToLower())
                {
                    correctRoot = true;
                }
            }
            return correctRoot;
        }

        /// <summary>
        /// Gets data for a readme in the FMs folder. Sets 'readmePath' and 'releaseDate'
        /// </summary>
        /// <param name="readmeDir">Folder name full path to readme's root folder. No \\ at end.</param>
        /// <param name="readmeFilename">Filename, e.g. info.txt.</param>
        /// <param name="sectionName"></param>
        private void scanReadme(string readmeDir, string readmeFilename, string sectionName = "")
        {
            List<ReadmeFileData> textFiles = new List<ReadmeFileData>();
            List<ReadmeFileData> rtfFiles = new List<ReadmeFileData>();
            List<ReadmeFileData> htmlFiles = new List<ReadmeFileData>();

            DirectoryInfo dI = new DirectoryInfo(readmeDir);
            FileInfo[] allFiles = dI.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo fI in allFiles)
            {
                ReadmeFileData data = new ReadmeFileData();
                if (readmeRootDir(fI.FullName, readmeDir) && readmeExtension(fI.Name))
                    if (readmeFilename == "" || fI.Name == readmeFilename)
                    {
                        data = storeReadmeData(fI.FullName, textFiles, rtfFiles, htmlFiles);
                    }
            }

            string fName = ""; //filename of readme, no path.
            if (rtfFiles.Count != 0)
            {
                fName = rtfFiles[0].fileName;
                releaseDate = rtfFiles[0].lastModified;
            }
            else if (textFiles.Count != 0)
            {
                fName = textFiles[0].fileName;
                releaseDate = textFiles[0].lastModified;
            }
            else if (htmlFiles.Count != 0)
            {
                fName = htmlFiles[0].fileName;
                releaseDate = htmlFiles[0].lastModified;
                htmlReadmePath = readmeDir + "\\" + fName;
            }
            else
            {
                DirectoryInfo dI2 = new DirectoryInfo(readmeDir);
                releaseDate = dI2.LastWriteTime;
                goto noreadme;
            }

            //Store the InfoFile name in NDL.ini
            if (sectionName != "")
                i.IniWriteValue(sectionName, kInfoFile, fName);

            //Set full path of readme file
            readmePath = readmeDir + "\\" + fName;
            return;

        noreadme:
            dummyReadme();
        }

        /// <summary>
        /// Extract named file. If "", extracts the first rtf, or the first txt file it finds, to the user's temp folder.
        /// Sets 'readmePath'. Also sets 'releaseDate' in case that's needed later.
        /// </summary>
        /// <param name="archive">Filename with extension. Path relative to fmArchivePath.</param>
        /// <param name="readmeFilename">readme.txt, info.rtf, etc. Can be "".</param>
        /// <returns></returns>
        private void extractReadme(string subFolder, string archive, string readmeFilename, string sectionName = "")
        {
            if (File.Exists(fmArchivePath + subFolder + "\\" + archive))
            {
                //Prepare to extract files
                SevenZipExtractor ext = new SevenZipExtractor(fmArchivePath + subFolder + "\\" + archive);

                //Get list of all rtf and txt and html files in archive
                List<string> fnames = new List<string>();
                System.Collections.ObjectModel.ReadOnlyCollection<string> archFiles = new System.Collections.ObjectModel.ReadOnlyCollection<string>(fnames);
                archFiles = ext.ArchiveFileNames;

                List<ReadmeFileData> textFiles = new List<ReadmeFileData>();
                List<ReadmeFileData> rtfFiles = new List<ReadmeFileData>();
                List<ReadmeFileData> htmlFiles = new List<ReadmeFileData>();

                List<int> vldFiles = new List<int>();

                int fileIndex = -1;
                foreach (string s in archFiles)
                {
                    fileIndex++;
                    ReadmeFileData data = new ReadmeFileData();
                    if (readmeRootArchive(s) && readmeExtension(s)) //don't allow files within other folders
                    {
                        //Store data of all possible readmes, or a specifically named readme.
                        if (readmeFilename == "" || s.ToLower().EndsWith(readmeFilename.ToLower()))
                            data = storeReadmeData(ext, textFiles, rtfFiles, htmlFiles, fileIndex, s);
                    }
                }

                string fName = ""; //filename of readme, no path.
                bool html = false;

                if (rtfFiles.Count != 0)
                {
                    fName = rtfFiles[0].fileName;
                    releaseDate = rtfFiles[0].lastModified;
                    vldFiles.Add(rtfFiles[0].index);
                }
                else if (textFiles.Count != 0)
                {
                    fName = textFiles[0].fileName;
                    releaseDate = textFiles[0].lastModified;
                    vldFiles.Add(textFiles[0].index);
                }
                else if (htmlFiles.Count != 0)
                {
                    fName = htmlFiles[0].fileName;
                    releaseDate = htmlFiles[0].lastModified;
                    htmlReadmePath = userTempFolder + fName;
                    vldFiles.Add(htmlFiles[0].index);
                    html = true;
                    webBrowser1.Url = null;
                }
                else
                {
                    FileInfo fI = new FileInfo(fmArchivePath + subFolder + "\\" + archive);
                    releaseDate = fI.LastWriteTime;
                    goto noreadme;
                }

                string fullName = userTempFolder + fName;

                //Store the InfoFile name in NDL.ini
                if (sectionName != "")
                    i.IniWriteValue(sectionName, kInfoFile, fName);

                //Extract the readme file to temp
                if (sevenZipGExe == "")
                {
                    extractReadmeInternal(ext, vldFiles, html);
                }
                else
                {
                    int exitCode = extractReadmeExternal(subFolder, archive, fName, html);
                    if (exitCode != 0)
                        extractReadmeInternal(ext, vldFiles, html);
                }

                //Set full path of readme file (in temp folder)
                readmePath = fullName;
                return;

            noreadme:
                dummyReadme();
            }
        }

        private int extractReadmeExternal(string subFolder, string archive, string fName, bool html)
        {
            int exitCode1 = 0;
            int exitCode2 = 0;
            exitCode1 = SevenZipGExtract.ExtractFile(choose7ZProg(), fmArchivePath, subFolder, archive, userTempFolder, fName);
            if (html)
            {
                exitCode2 = SevenZipGExtract.ExtractFile(choose7ZProg(), fmArchivePath, subFolder, archive, userTempFolder, "r_data\\*");
            }

            return exitCode1 + exitCode2;
        }

        //vldFiles will already contain the basic readme
        private void extractReadmeInternal(SevenZipExtractor ext, List<int> vldFiles, bool html)
        {
            if (html)
            {
                for (int x = 0; x < ext.ArchiveFileNames.Count; x++)
                {
                    if (ext.ArchiveFileNames[x].StartsWith("r_data\\"))
                    {
                        if (!Directory.Exists(userTempFolder + "r_data"))
                            Directory.CreateDirectory(userTempFolder + "r_data");

                        vldFiles.Add(x);
                    }
                }
            }

            if (vldFiles.Count > 0)
            {
                int[] validFiles = new int[vldFiles.Count];
                vldFiles.CopyTo(validFiles);

                try
                {
                    ext.ExtractFiles(userTempFolder, validFiles);
                }
                catch
                {
                    File.WriteAllText(userTempFolder + ext.ArchiveFileNames[validFiles[0]], badReadme);
                }
            }
        }

        /// <summary>
        /// True if file has a 'readme' extension (rtf, txt, html or htm)
        /// </summary>
        /// <param name="readmeFile">Path or filename.</param>
        /// <returns></returns>
        private bool readmeExtension(string readmeFile)
        {
            string[] extensions = { ".rtf", ".txt", ".html", ".htm" };
            bool match = false;

            foreach (string ext in extensions)
            {
                if (readmeFile.ToLower().EndsWith(ext))
                {
                    match = true;
                    break;
                }
            }

            return match;
        }

        /// <summary>
        /// Stores data of a readme that exists in a folder.
        /// </summary>
        /// <param name="readmePath">Full path.</param>
        /// <returns></returns>
        private ReadmeFileData storeReadmeData(string readmePath, List<ReadmeFileData> textFiles, List<ReadmeFileData> rtfFiles, List<ReadmeFileData> htmlFiles)
        {
            FileInfo fI = new FileInfo(readmePath);
            ReadmeFileData data = new ReadmeFileData();
            data.fileName = fI.Name;
            data.lastModified = fI.LastWriteTime;

            if (!readmePath.Contains("script debug file for obj") && readmePath.ToLower().EndsWith(".txt"))
                textFiles.Add(data);
            else if (readmePath.ToLower().EndsWith(".rtf"))
                rtfFiles.Add(data);
            else if (readmePath.ToLower().EndsWith(".htm") || readmePath.ToLower().EndsWith(".html"))
                htmlFiles.Add(data);

            return data;
        }

        /// <summary>
        /// Stores data of a readme found inside an archive.
        /// </summary>
        /// <param name="ext">SZExtractor object.</param>
        /// <param name="s">Filename.</param>
        /// <param name="data"></param>
        /// <returns></returns>
        private ReadmeFileData storeReadmeData(SevenZipExtractor ext, List<ReadmeFileData> textFiles, List<ReadmeFileData> rtfFiles, List<ReadmeFileData> htmlFiles, int fileIndex, string s)
        {
            ReadmeFileData data = new ReadmeFileData();
            data.fileName = s;
            data.lastModified = getLastWriteTime(ext, fileIndex);
            data.index = fileIndex;

            if (!s.Contains("script debug file for obj") && s.ToLower().EndsWith(".txt"))
                textFiles.Add(data);
            else if (s.ToLower().EndsWith(".rtf"))
                rtfFiles.Add(data);
            else if (s.ToLower().EndsWith(".htm") || s.ToLower().EndsWith(".html"))
                htmlFiles.Add(data);
            return data;
        }

        /// <summary>
        /// Write a fake readme file to Temp and set path
        /// </summary>
        private void dummyReadme()
        {
            readmePath = userTempFolder + "readme.txt";
            File.WriteAllText(readmePath, noReadme);
        }

        struct ReadmeFileData
        {
            public int index;
            public string fileName;
            public DateTime lastModified;
        }

        private DateTime getLastWriteTime(SevenZipExtractor ext, int fileIndex)
        {
            return ext.ArchiveFileData[fileIndex].LastWriteTime;
        }

        /// <summary>
        /// Shows readme in a rich text box.
        /// </summary>
        /// <param name="deleteAfterShowing">True if file was extracted from archive. False if read from dir.</param>
        private void showReadme(bool deleteAfterShowing)
        {
            if (readmePath.ToLower().EndsWith(".htm") || readmePath.ToLower().EndsWith(".html"))
            {
                webBrowser1.BringToFront();
                webBrowser1.Url = new Uri("file:///" + readmePath);
                btnShowInBrowser.BringToFront(); //Main form, not browser
            }
            else if (readmePath.ToLower().EndsWith(".txt") || readmePath.ToLower().EndsWith(".rtf"))
            {
                string[] fLines = File.ReadAllLines(readmePath);
                if (fileIsRTF(fLines))
                    readmeFileType = RichTextBoxStreamType.RichText;
                else
                    readmeFileType = RichTextBoxStreamType.PlainText;

                readmeBox.BringToFront();
                readmeBox.LoadFile(readmePath, readmeFileType);
                btnShowInBrowser.SendToBack();

                readmeBox.ScrollToCaret();

                if (deleteAfterShowing)
                    FullDelete.DeleteFile(readmePath);

                //Deletes any possible html readme from the **previous** FM -i.e. triggered by selecting another FM
                deleteHTMLReadme();
            }
            btnFullScreenReadme.BringToFront();
        }

        /// <summary>
        /// Looks at the code in the first line - can't always rely on extension.
        /// </summary>
        /// <param name="fLines">Array of lines that have been read from the file as text.</param>
        /// <returns></returns>
        private static bool fileIsRTF(string[] fLines)
        {
            if (fLines.Length > 0)
                return fLines[0].StartsWith("{\\rtf1");
            return false;
        }

        private void deleteHTMLReadme()
        {
            if (htmlReadmePath.StartsWith(userTempFolder))
            {
                if (File.Exists(htmlReadmePath))
                    FullDelete.DeleteFile(htmlReadmePath);

                if (Directory.Exists(userTempFolder + "r_data"))
                {
                    DirectoryInfo dI = new DirectoryInfo(userTempFolder + "r_data");
                    FileInfo[] dFiles = dI.GetFiles();

                    foreach (FileInfo fI in dFiles)
                    {
                        FullDelete.DeleteFile(fI.FullName);
                    }
                    FullDelete.DeleteDir(userTempFolder + "r_data");
                }
            }
        }

        private void item1_Click(object sender, EventArgs e)
        {
            if (readmeBox.SelectedText != "")
                Clipboard.SetText(readmeBox.SelectedText);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private class fmIniData
        {
            public string niceName;
            public string releaseDate;
            public string relDateHex;
            public string tags;
            public string infoFile;
        }

        /// <summary>
        /// Try to extract fm.ini from the archive, and generate fmIniData from it (Title, release date etc). Null if not found.
        /// </summary>
        /// <param name="archive">Archive's filename.</param>
        /// <returns></returns>
        private fmIniData extractFMini(string subFolder, string archive)
        {
            string path = fmArchivePath + subFolder + "\\" + archive;
            string fmIni = "fm.ini";
            string extractedIni = userTempFolder + fmIni;
            bool foundIni = false;
            fmIniData data = null;

            SevenZipExtractor iniExtract = new SevenZipExtractor(path); //use this to look in the file
            for (int x = 0; x < iniExtract.ArchiveFileNames.Count; x++)
            {
                if (iniExtract.ArchiveFileNames[x].ToLower().EndsWith(fmIni)) //EndsWith allows for the file in a subfolder
                {
                    if (sevenZipGExe == "")
                    {
                        FileStream iniStream = new FileStream(extractedIni, FileMode.Create);
                        iniExtract.ExtractFile(x, iniStream);
                        iniStream.Close();
                    }
                    else
                    {
                        SevenZipGExtract.ExtractFile(choose7ZProg(), fmArchivePath, subFolder, archive,
                            userTempFolder, iniExtract.ArchiveFileNames[x], false);
                    }
                    foundIni = true;
                    break;
                }
            }
            if (foundIni)
            {
                data = getDataFromFMini(data, extractedIni);
                if (!iniExtract.ArchiveFileNames.Contains(data.infoFile))
                    data.infoFile = "";
            }

            return data;
        }

        /// <summary>
        /// Look for fm.ini in the FM's folder, and generate fmIniData from it (Title, release date etc). Null if not found.
        /// </summary>
        /// <param name="simpleFolder">Folder name.</param>
        /// <returns></returns>
        private fmIniData readFMini(string simpleFolder)
        {
            string path = fmInstalledPath + "\\" + simpleFolder + "\\fm.ini";
            fmIniData data = null;

            if (File.Exists(path))
                data = getDataFromFMini(data, path);

            return data;
        }

        private fmIniData getDataFromFMini(fmIniData data, string iniPath)
        {
            data = new fmIniData();
            string[] fileLines = File.ReadAllLines(iniPath, Encoding.Default);
            data.niceName = getValue(kFm_title, fileLines);
            data.relDateHex = getValue(kRelease_date, fileLines);
            if (data.relDateHex != "")
            {
                DateTimeConverter c = new DateTimeConverter();
                try
                {
                    object o = c.ConvertFromString(data.relDateHex);
                    DateTime dt = (DateTime)o;
                    string hexString = DateIntConverter.dateToHexString(dt);
                    data.releaseDate = DateIntConverter.dateStringFromHexString(hexString, dateFormat);
                    data.relDateHex = hexString;
                }
                catch (FormatException)
                {
                    try
                    {
                        data.releaseDate = DateIntConverter.dateStringFromHexString(data.relDateHex, dateFormat);
                    }
                    catch
                    {
                        data.releaseDate = "";
                    }
                }
            }
            data.tags = getValue(kTags, fileLines).Replace(';', ',').Replace(" ", "");
            data.infoFile = getValue(kInfoFile, fileLines);
            return data;
        }

        private string getValue(string key, string[] fileLines)
        {
            string retValue = "";
            foreach (string s in fileLines)
            {
                if (s.ToLower().StartsWith(key.ToLower()))
                {
                    string[] keyValue = s.Split('=');
                    if (keyValue.Length == 2)
                    {
                        retValue = keyValue[1];
                        break;
                    }
                }
            }
            return retValue;
        }

        private void fmTable_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView v = (DataGridView)sender;
            DataGridViewSelectedRowCollection selRows = v.SelectedRows;
            if (selRows.Count != 0)
            {
                Cursor = Cursors.WaitCursor;
                using (DataGridViewRow row = selRows[0])
                {
                    selFMID = row.Index;
                }

                getFMDetails(selFMID, false);

                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Scans every archive and fills the table. Like selecting an FM but it doesn't show the readme or tags.
        /// </summary>
        private void getAllFMDetails(bool overwriteData = false)
        {
            Cursor = Cursors.WaitCursor;
            pnlProgress.Visible = true;
            allEnabledToggle(false);

            int current = 0;
            int total = fmTable.RowCount;
            for (int x = 0; x < foundFMs.Count; x++)
            {
                getFMDetails(x, overwriteData);
                current++;
                lblProgress.Text = scannedText + " " + current + "/" + total;
                lblArchive.Text = foundFMs[x].archive;
                pnlProgress.Refresh();
            }

            Cursor = Cursors.Default;
            allEnabledToggle(true);
            pnlProgress.Visible = false;
            fmTable.Refresh();
            restoreSortOrder();
        }

        private void allEnabledToggle(bool enabled)
        {
            btnResetFilters.Enabled = enabled;
            tbFilter.Enabled = enabled;
            chkUnfinished.Enabled = enabled;
            cbMinMonth.Enabled = enabled;
            cbMinYear.Enabled = enabled;
            cbMaxMonth.Enabled = enabled;
            cbMaxYear.Enabled = enabled;
            btnResetFilters.Enabled = enabled;
            btnSetTagFilter.Enabled = enabled;
            lblTagFilter.Enabled = enabled;
            btnHideTags.Enabled = enabled;
            btnRefresh.Enabled = enabled;
            gbTags.Enabled = enabled;
            btnFullScreenReadme.Enabled = enabled;
            btnShowInBrowser.Enabled = enabled;
            btnPlOriginal.Enabled = enabled;
            btnPlFM.Enabled = enabled;
            btnInstallOnly.Enabled = enabled;
            btnWebSearch.Enabled = enabled;
            btnTools.Enabled = enabled;
            btnSetup.Enabled = enabled;
            btnExit.Enabled = enabled;
        }

        /// <summary>
        /// Fill in the row of the currently selected FM. Archive is read if no value found in ini.
        /// </summary>
        /// <param name="currentFMID">Index of selected row.</param>
        /// <param name="showThisFM">True if this method is called by changing the selcted row (show readme, tags etc).
        /// False if just updating the table.</param>
        /// <param name="overwriteData"></param>
        private void getFMDetails(int currentFMID, bool overwriteData)
        {
            FanMission selFM = foundFMs[currentFMID];
            string selArchive = selFM.archive;
            string sectionName = selFM.sectionName;
            string subFolder = selFM.subFolder;

            if (File.Exists(fmArchivePath + subFolder + "\\" + selArchive) || Directory.Exists(fmInstalledPath + "\\" + selArchive))
            {
                fmExtractionFolder = selFM.extractionName;

                bool fmIsArchive = false;
                if (selFM.archiveOrDirectory == FMType.Archive)
                    fmIsArchive = true;

                //Readme always needs to be scanned/extracted for display in the window
                if (fmIsArchive)
                {
                    if (subFolder != "") subFolder += "\\";
                    extractReadme(subFolder, selArchive, i.IniReadValue(sectionName, kInfoFile), sectionName);
                }
                else
                    scanReadme(fmInstalledPath + "\\" + selArchive, i.IniReadValue(sectionName, kInfoFile), sectionName);

                string infoFileFromINI = i.IniReadValue(sectionName, kInfoFile);
                string titleFromINI = i.IniReadValue(sectionName, kFm_title);
                string tagsFromINI = i.IniReadValue(sectionName, kTags);
                string releaseDateFromINI = i.IniReadValue(sectionName, kRelease_date);

                #region Get or update values by looking in the ini or the archive/folder
                if (overwriteData || infoFileFromINI == "" || titleFromINI == "" || releaseDateFromINI == "" || tagsFromINI == "")
                {
                    fmIniData fmIni = null;
                    //read fm.ini
                    if (fmIsArchive)
                        fmIni = extractFMini(subFolder, selArchive); //Only do this if a value is missing, or user is re-scanning
                    else
                        fmIni = readFMini(selArchive);//Only do this if a value is missing, or user is re-scanning
                    #region If fm.ini exists
                    if (fmIni != null) //Use any values found to update the table/ini file
                    {
                        if (fmIni.infoFile != null && fmIni.infoFile != "")
                        {
                            if (overwriteData || infoFileFromINI == "") //leave it alone if not re-scan and value exists
                            {
                                i.IniWriteValue(sectionName, kInfoFile, fmIni.infoFile);
                            }
                        }
                        if (fmIni.niceName != null && fmIni.niceName != "")
                        {
                            if (overwriteData || titleFromINI == "")//leave it alone if not re-scan and value exists
                            {
                                i.IniWriteValue(sectionName, kFm_title, fmIni.niceName);
                                selFM.title = fmIni.niceName;
                            }
                        }
                        else //if NiceName not found/not valid
                        {
                            if (overwriteData || titleFromINI == "")
                            {
                                selFM.title = setFMNameFromEither(currentFMID, overwriteData, selArchive, subFolder, sectionName, fmIsArchive, titleFromINI);
                            }
                        }
                        if (fmIni.relDateHex != null && fmIni.relDateHex != ""
                            && fmIni.releaseDate != null && fmIni.releaseDate != "") //this line is in case date conversion had an error
                        {
                            if (overwriteData || releaseDateFromINI == "")//leave it alone if not re-scan and value exists
                            {
                                i.IniWriteValue(sectionName, kRelease_date, fmIni.relDateHex);
                                selFM.relDateHex = fmIni.relDateHex;
                                selFM.relDateString = fmIni.releaseDate;
                            }
                        }
                        else //if ReleaseDate not found/not valid
                        {
                            if (overwriteData || releaseDateFromINI == "")
                            {
                                StringPair sP = setReleaseDate(currentFMID, sectionName);
                                selFM.relDateHex = sP.dHex;
                                selFM.relDateString = sP.dString;
                            }
                        }
                        if (fmIni.tags != null && fmIni.tags != "")
                        {
                            if (overwriteData || tagsFromINI == "")//leave it alone if not re-scan and value exists
                            {
                                i.IniWriteValue(sectionName, kTags, fmIni.tags);
                                readAllTags();
                                showTagsForFM(selFM.sectionName);
                            }
                        }
                        else //write a special empty tag if fm.ini has no tags. This prevents further fm.ini searches unless re-scanning.
                        {
                            if (overwriteData || tagsFromINI == "")//leave it alone if not re-scan and value exists
                                i.IniWriteValue(sectionName, kTags, emptyTag);
                        }
                    }
                    #endregion
                    else // or fm.ini is null
                    {
                        if (overwriteData || titleFromINI == "" || releaseDateFromINI == "") //If title or date are missing or re-scanning
                        {
                            selFM.title = setFMNameFromEither(currentFMID, overwriteData, selArchive, subFolder, sectionName, fmIsArchive, titleFromINI);

                            if (overwriteData || releaseDateFromINI == "") //Don't update rel date if title was the only blank thing.
                            {
                                StringPair sP = setReleaseDate(currentFMID, sectionName);
                                selFM.relDateHex = sP.dHex;
                                selFM.relDateString = sP.dString;
                            }
                        }
                        else //simple selection, no missing values
                        {
                            //re-read the ini in case it's been changed
                            selFM.title = titleFromINI;
                            selFM.relDateHex = releaseDateFromINI;
                            string dString = DateIntConverter.dateStringFromHexString(releaseDateFromINI, dateFormat);
                            selFM.relDateString = dString;
                        }

                        //Always write empty tag to prevent future searches
                        i.IniWriteValue(sectionName, kTags, emptyTag);
                    }
                }
                else //if not overwriteData and infoFile, title, relDate and tags are not empty
                {
                    selFM.title = titleFromINI;
                    selFM.relDateHex = releaseDateFromINI;
                    string dString = DateIntConverter.dateStringFromHexString(releaseDateFromINI, dateFormat);
                    selFM.relDateString = dString;
                }
                #endregion

                //get last played
                string lastPlayedFromINI = i.IniReadValue(sectionName, kLast_played);
                if (overwriteData) //Don't check for ini being "" because some players will want to reset it.
                {
                    string saveBackupPath = fmArchivePath + subFolder + "\\" + selFM.saveBackupName;
                    string fmPath = fmInstalledPath + "\\" + selFM.extractionName;
                    if (DateFromSavegames.FMHasSaves(fmPath, saveBackupPath, gameIsThief3))
                    {
                        bool compareDates = false; //Date in table can only be compared with if it's already been set.

                        DateTime currentTableDate = new DateTime();
                        if (lastPlayedFromINI != "")
                        {
                            currentTableDate = DateIntConverter.dateFromHexString(lastPlayedFromINI);
                            compareDates = true;
                        }

                        DateTime savegameDate = DateFromSavegames.MostRecentSavegame(fmPath, saveBackupPath, gameIsThief3);
                        DateTime lastPlayed;

                        if (compareDates) //If date already exists, compare
                        {
                            if (currentTableDate > savegameDate)
                                lastPlayed = currentTableDate;
                            else
                                lastPlayed = savegameDate;
                        }
                        else //If date doesn't already exist, just use the found value
                            lastPlayed = savegameDate;

                        string lPHex = DateIntConverter.dateToHexString(lastPlayed);
                        string lpString = DateIntConverter.dateStringFromHexString(lPHex, dateFormat);
                        selFM.lastPlayedString = lpString;
                        selFM.lastPlayedHex = lPHex;
                        i.IniWriteValue(sectionName, kLast_played, lPHex);
                    }
                }

                //get FM size
                string sizeBytesFromINI = i.IniReadValue(sectionName, kSizeBytes);
                if (overwriteData || sizeBytesFromINI == "")
                {
                    long sizeInBytes = 0;
                    if (fmIsArchive)
                    {
                        FileInfo fI = new FileInfo(fmArchivePath + subFolder + "\\" + selArchive);
                        sizeInBytes = fI.Length;
                    }
                    else
                    {
                        //Get size of folder
                        string[] fmFiles = Directory.GetFiles(fmInstalledPath + "\\" + selArchive, "*.*", SearchOption.AllDirectories);

                        foreach (string s in fmFiles)
                        {
                            FileInfo fI = new FileInfo(s);
                            sizeInBytes += fI.Length;
                        }
                    }

                    selFM.sizeBytes = sizeInBytes;

                    selFM.sizeMB = getFMSizeInMB(sizeInBytes);
                    i.IniWriteValue(sectionName, kSizeBytes, sizeInBytes.ToString());
                }

                if (showThisFM) //True for user selecting it, false when the auto-update method was called.
                {
                    //Change Play FM button text
                    setPlayFMButtonText(selFM.title);

                    bool deleteReadmeAfterShowing = true;
                    if (!fmIsArchive || readmePath.ToLower().EndsWith(".html") || readmePath.ToLower().EndsWith(".htm"))
                        deleteReadmeAfterShowing = false; //never delete it from a folder

                    showReadme(deleteReadmeAfterShowing);

                    if (selFM.installed == colInstalled)
                    {
                        btnInstallOnly.Text = uninstallText;
                    }
                    else
                    {
                        btnInstallOnly.Text = installText;
                    }

                    showTagsForFM(selFM.sectionName);
                }
                foundFMs[currentFMID] = selFM;
                fmTable.Refresh();
            }
            else //if selected fm doesn't exist
            {
                if (selFM.archiveOrDirectory == FMType.Archive)
                    foundFMs.RemoveAt(currentFMID);
                else
                    if (!Directory.Exists(fmInstalledPath + "\\" + selFM.archive))
                    foundFMs.RemoveAt(currentFMID);
                fmTable.Refresh();
            }
        }

        /// <summary>
        /// Takes size in bytes and returns it as string: size MB
        /// </summary>
        /// <param name="currentFMID"></param>
        /// <param name="sectionName"></param>
        /// <param name="sizeInBytes"></param>
        private string getFMSizeInMB(long sizeInBytes)
        {
            double sMB = sizeInBytes / 1024f / 1024f;
            double rounded = Math.Round(sMB, 1);
            return rounded + " MB";
        }

        /// <summary>
        /// Writes Release Date to ini object and returns a StringPair for updating a selected FanMission object.
        /// </summary>
        /// <param name="currentFMID"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        private StringPair setReleaseDate(int currentFMID, string sectionName)
        {
            string dHex = DateIntConverter.dateToHexString(releaseDate); //date already set when scanning readme
            string dString = DateIntConverter.dateStringFromHexString(dHex, dateFormat);
            i.IniWriteValue(sectionName, kRelease_date, dHex);

            StringPair sP = new StringPair();
            sP.dHex = dHex;
            sP.dString = dString;

            return sP;
        }

        private struct StringPair
        {
            public string dHex;
            public string dString;
        }

        /// <summary>
        /// Causes the readme, titles.str and missflag.str to be extracted (or scanned). Sets readmeFilename, sets releaseDate.
        /// </summary>
        private string setFMNameFromEither(int currentFMID, bool overwriteData, string selArchive, string subFolder, string sectionName, bool fmIsArchive, string titleFromINI)
        {
            //get title from titles.str or scan from readme
            if (fmIsArchive)
            {
                //Run this anyway to get the date
                FileInfo fI = new FileInfo(fmArchivePath + subFolder + "\\" + selArchive);
                string foundTitle = getFMNameFromArchive(fI.Name.Replace(fI.Extension, ""), sectionName, fI.Name, subFolder, overwriteData);
                if (overwriteData || titleFromINI == "") //Don't update title if release date is the only blank thing.
                {
                    i.IniWriteValue(sectionName, kFm_title, foundTitle);
                }
                return foundTitle;
            }
            else
            {
                string foundTitle = getFMNameFromDir(selArchive, sectionName, overwriteData);
                if (overwriteData || titleFromINI == "")
                {
                    i.IniWriteValue(sectionName, kFm_title, foundTitle);
                }
                return foundTitle;
            }
        }

        /// <summary>
        /// Writes tags found in fm.ini to NewDarkLoader.ini, or writes placeholder for no tags.
        /// </summary>
        /// <param name="sectionName">[FM=...]</param>
        /// <param name="fmData">Struct initialized by reading readme file.</param>
        private void updateFMTags(string sectionName, fmIniData fmData)
        {
            if (fmData != null)
            {
                i.IniWriteValue(sectionName, kTags, fmData.tags);

                if (fmData.tags.Length != 0)
                {
                    readAllTags(); //update main set of lists
                }
                else i.IniWriteValue(sectionName, kTags, emptyTag);
            }
            else
                i.IniWriteValue(sectionName, kTags, emptyTag);
        }

        /// <summary>
        /// Get tags for the selected FM
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        private List<catItem> getFMTags(string sectionName)
        {
            List<catItem> cIList = new List<catItem>();
            string tagsFromINI = i.IniReadValue(sectionName, kTags);

            List<string> uniqueTags = new List<string>();
            List<string> uniqueCategories = new List<string>();

            if (tagsFromINI != "" && tagsFromINI != emptyTag)
            {
                string[] tags = tagsFromINI.Split(',');
                foreach (string tag in tags)
                {
                    if (!uniqueTags.Contains(tag))
                        uniqueTags.Add(tag);
                }

                string noCatName = miscTagCat;

                foreach (string s in uniqueTags)
                {
                    if (s.Contains(':'))
                    {
                        string[] getCat = s.Split(':');
                        catItem ncI = new catItem();
                        ncI.cat = getCat[0];
                        ncI.item = getCat[1];
                        cIList.Add(ncI);
                        if (!uniqueCategories.Contains(ncI.cat))
                            uniqueCategories.Add(ncI.cat);
                    }
                    else
                    {
                        catItem ncI = new catItem();
                        ncI.cat = noCatName;
                        ncI.item = s;
                        cIList.Add(ncI);
                        if (!uniqueCategories.Contains(ncI.cat))
                            uniqueCategories.Add(ncI.cat);
                    }
                }
                uniqueCategories.Sort();
                //Sorting may put 'misc' in the middle. This will put it at the end while everything else is still sorted.
                if (uniqueCategories.Contains(noCatName))
                {
                    uniqueCategories.Remove(noCatName);
                    uniqueCategories.Add(noCatName);
                }
            }
            return cIList;
        }

        private List<string> getFMCats(List<catItem> tags)
        {
            List<string> cats = new List<string>();
            foreach (catItem cI in tags)
            {
                if (!cats.Contains(cI.cat))
                    cats.Add(cI.cat);
            }
            return cats;
        }

        /// <summary>
        /// Fills the FM's Tags tree with data read from file.
        /// </summary>
        private void showTagsForFM(string secName)
        {
            tagTree.Nodes.Clear();

            List<catItem> fmTags = getFMTags(secName);
            List<string> fmCats = getFMCats(fmTags);

            //Logger.LogThisLine("Showing tags for " + secName);
            if (fmTags.Count != 0)
            {
                fillTagTree(tagTree, fmTags, fmCats);
            }
        }

        /// <summary>
        /// Stores the global tags for all FMs
        /// </summary>
        private void readAllTags()
        {
            ////Logger.LogThisLine("Reading tags for each FM.");
            ////reset everything
            //allFMTags.Clear();
            //allFMCats.Clear();
            globalCatItems.Clear();
            globalCategories.Clear();

            string result = i.getAllTags(emptyTag);

            generateTagData(result, globalCatItems, globalCategories);

            //for(int x = 0; x < fmTable.Rows.Count; x++)
            //{
            //    string sectionName = cellString(SECTION_NAME, x);
            //    allFMTags.Add(getFMTags(sectionName));
            //}
        }

        /// <summary>
        /// Read tags string and organise them into categories and items.
        /// </summary>
        /// <param name="tagsFromINI">Tags string read from INI file.</param>
        /// <param name="catItemList">Struct list to update.</param>
        /// <param name="uniqueCategories">List of categories only.</param>
        private void generateTagData(string tagsFromINI, List<catItem> catItemList, List<string> uniqueCategories)
        {
            //Logger.LogThisLine("Generating tag data from " + tagsFromINI);
            //example
            //author:author:cardia1,author:someone else,contest:NewDark 64 cubed,campaign,myMission
            //Get list of tree roots (categories)
            if (tagsFromINI != "")
            {
                string[] tags = tagsFromINI.Split(',');

                List<string> uniqueTags = new List<string>();
                foreach (string tag in tags)
                {
                    if (!uniqueTags.Contains(tag))
                        uniqueTags.Add(tag);
                }

                string noCatName = miscTagCat;

                foreach (string s in uniqueTags)
                {
                    if (s.Contains(':'))
                    {
                        string[] getCat = s.Split(':');
                        catItem ncI = new catItem();
                        ncI.cat = getCat[0];
                        ncI.item = getCat[1];
                        catItemList.Add(ncI);
                        if (!uniqueCategories.Contains(ncI.cat))
                            uniqueCategories.Add(ncI.cat);
                    }
                    else
                    {
                        catItem ncI = new catItem();
                        ncI.cat = noCatName;
                        ncI.item = s;
                        catItemList.Add(ncI);
                        if (!uniqueCategories.Contains(ncI.cat))
                            uniqueCategories.Add(ncI.cat);
                    }
                }
                uniqueCategories.Sort();
                //Sorting may put 'misc' in the middle. This will put it at the end while everything else is still sorted.
                if (uniqueCategories.Contains(noCatName))
                {
                    uniqueCategories.Remove(noCatName);
                    uniqueCategories.Add(noCatName);
                }
            }
        }

        /// <summary>
        /// Uses categories and items to fill the tagTree for a specific FM.
        /// </summary>
        /// <param name="catItemList"></param>
        /// <param name="uniqueCategories"></param>
        private void fillTagTree(TreeView tree, List<catItem> catItemList, List<string> uniqueCategories)
        {
            TreeNode[] rootNodes = FillTree.generateNodes(catItemList, uniqueCategories);

            tree.Nodes.AddRange(rootNodes);

            tree.ExpandAll();
        }

        /// <summary>
        /// Write the tags of a specific FM to its entry in the INI file
        /// </summary>
        /// <param name="fmTags"></param>
        private void writeTagsToINI(string sectionName, List<catItem> fmTags, string tagKeyName)
        {
            string tagString = tagsToString(fmTags);

            if (tagString.Length == 0 && sectionName != secOptions)
                tagString = emptyTag;

            i.IniWriteValue(sectionName, tagKeyName, tagString);
        }

        /// <summary>
        /// Tags a list of catItem structs and converts them to a string suitable for an ini file.
        /// </summary>
        /// <param name="fmTags"></param>
        /// <returns></returns>
        private string tagsToString(List<catItem> fmTags)
        {
            StringBuilder tags = new StringBuilder();

            foreach (catItem cI in fmTags)
            {
                if (cI.cat != miscTagCat)
                    tags.Append(cI.cat + ":" + cI.item + ",");
                else
                    tags.Append(cI.item + ",");
            }

            string tagString = tags.ToString().TrimEnd(',');
            return tagString;
        }

        private void setPlayFMButtonText(string fmTitle)
        {
            btnPlFM.Text = playTextPart1 + " " + fmTitle;
            int newInsButtonX = btnPlFM.Location.X + btnPlFM.Size.Width + 4;
            btnInstallOnly.Location = new Point(newInsButtonX, btnInstallOnly.Location.Y);

            int newWebSearchButtonX = btnInstallOnly.Location.X + btnInstallOnly.Size.Width + 4;
            btnWebSearch.Location = new Point(newWebSearchButtonX, btnWebSearch.Location.Y);
        }

        /// <summary>
        /// Adds a list of valid text files to the Edit FM drop down box.
        /// </summary>
        /// <param name="archiveFilename">No path.</param>
        /// <returns></returns>
        private List<string> getFMTextFiles(string subFolder, string archiveFilename)
        {
            List<string> textFiles = new List<string>();

            if (File.Exists(fmArchivePath + subFolder + "\\" + archiveFilename))
            {
                SevenZipExtractor ex = new SevenZipExtractor(fmArchivePath + subFolder + "\\" + archiveFilename);
                foreach (string s in ex.ArchiveFileNames)
                {
                    if (readmeRootArchive(s))
                        if (readmeExtension(s))
                            textFiles.Add(s);
                }
            }
            else if (Directory.Exists(fmInstalledPath + "\\" + archiveFilename))
            {
                string[] allFiles = Directory.GetFiles(fmInstalledPath + "\\" + archiveFilename);

                foreach (string s in allFiles)
                {
                    if (readmeRootDir(s, fmInstalledPath + "\\" + archiveFilename))
                    {
                        if (readmeExtension(s))
                        {
                            FileInfo fI = new FileInfo(s);
                            textFiles.Add(fI.Name);
                        }
                    }
                }
            }

            return textFiles;
        }

        private void editFMDetails_Click(object sender, EventArgs e)
        {
            FanMission fm = foundFMs[selFMID];
            List<string> fmTextFiles = getFMTextFiles(fm.subFolder, fm.archive);
            string secName = fm.sectionName;

            bool fmIsArchive = true;
            if (fm.archiveOrDirectory == FMType.Directory)
                fmIsArchive = false;

            EditFM edFM = new EditFM(fm.title, fm.rating, fm.finishedID, fm.comment, fm.disabledMods, fm.relDateHex,
                fm.lastPlayedHex, fmTextFiles, i.IniReadValue(secName, kInfoFile), gameIsThief3,
                fmArchivePath + fm.subFolder + "\\" + fm.saveBackupName,
                fmInstalledPath + "\\" + fm.extractionName, editFMDetails,
                readmeLabel, colArchive, colTitle, colRating, colFinished, diffT3Easy, diffNormal, diffHard, diffExpert, diffExtreme,
                colReleaseDate, colLastPlayed, notPlayed, getFromSaves, colComment, colDisabledMods, colInstalled, okBtnText, cancBtnText);

            DialogResult dR = edFM.ShowDialog();

            if (dR == DialogResult.OK)
            {
                FMData editedData = edFM.EditedData;

                i.IniWriteValue(secName, kInfoFile, editedData.fmReadme);
                if (editedData.fmReadme != "")
                {
                    if (fmIsArchive)
                        extractReadme(fm.subFolder, fm.archive, editedData.fmReadme);
                    else
                        scanReadme(fmInstalledPath + "\\" + fm.extractionName, edFM.EditedData.fmReadme, secName);

                    //update release date
                    string dHex = editedData.hexRelDate;
                    string dString = DateIntConverter.dateStringFromHexString(dHex, dateFormat);
                    i.IniWriteValue(secName, kRelease_date, dHex);

                    fm.relDateHex = dHex;
                    fm.relDateString = dString;

                    bool htmlReadme = false;
                    if (readmePath.ToLower().EndsWith(".html") || readmePath.ToLower().EndsWith(".html"))
                        htmlReadme = true;

                    showReadme(fmIsArchive && !htmlReadme);
                }

                i.IniWriteValue(secName, kFm_title, editedData.title);
                fm.title = editedData.title;
                setPlayFMButtonText(editedData.title);

                if (editedData.rating >= 0)
                    i.IniWriteValue(secName, kRating, editedData.rating.ToString());
                else
                    i.IniWriteValue(secName, kRating, null);
                fm.rating = editedData.rating;

                if (editedData.finished == 0)
                {
                    i.IniWriteValue(secName, kFinished, null); //clear it
                    fm.imgFinished = NewDarkLoader.Properties.Resources.blank;
                }
                else
                {
                    i.IniWriteValue(secName, kFinished, editedData.finished.ToString());
                    fm.imgFinished = getFinishedFromINI(secName);
                }
                fm.finishedID = editedData.finished; //always store the finished ID

                i.IniWriteValue(secName, kRelease_date, editedData.hexRelDate);
                fm.relDateString = getDateFromINI(secName, DateType.Release);
                fm.relDateHex = editedData.hexRelDate;

                if (editedData.hexLastPlayed != "")
                {
                    i.IniWriteValue(secName, kLast_played, editedData.hexLastPlayed);
                    fm.lastPlayedString = getDateFromINI(secName, DateType.LastPlayed);
                    fm.lastPlayedHex = editedData.hexLastPlayed;
                }
                else
                {
                    i.IniWriteValue(secName, kLast_played, null);
                    fm.lastPlayedString = "";
                    fm.lastPlayedHex = "";
                }

                fm.comment = editedData.comment;
                if (editedData.comment != "")
                {
                    i.IniWriteValue(secName, kComment, editedData.comment);
                }
                else
                {
                    i.IniWriteValue(secName, kComment, null);
                }

                fm.disabledMods = editedData.disabledMods;
                if (editedData.disabledMods != "")
                {
                    i.IniWriteValue(secName, kNo_mods, editedData.disabledMods);
                }
                else
                {
                    i.IniWriteValue(secName, kNo_mods, null);
                }

                foundFMs[selFMID] = fm;

                //update tooltips for each cell in this row
                for (int y = 0; y < fmTable.Columns.Count; y++)
                {
                    setCellTip(selFMID, y);
                }
                fmTable.Refresh();
            }
        }

        private void chkShowT1_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chkShowT2_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chkShowSS2_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chkShowUnknown_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            tbFilter.Text = "";
            chkUnfinished.Checked = false;
            cbMinMonth.SelectedIndex = 0;
            cbMinYear.SelectedIndex = 0;
            cbMaxMonth.SelectedIndex = 0;
            cbMaxYear.SelectedIndex = 0;

            resetTagFilter();

            scrollToSelectedRow();
        }

        private void resetTagFilter()
        {
            includeTags.Clear();
            excludeTags.Clear();
            lblTagFilter.Text = "[none]";
            setFilter();
        }

        private void chkUnfinished_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        bool fullReadme = false;

        private void fullScreenReadme_Click(object sender, EventArgs e)
        {
            setHTMLReadmeSizeLoc();

            #region Set TableLayoutPanel Sizes
            if (!fullReadme) //Enlarge
            {
                fullReadme = true;
                splCurrentDist = splitContainer1.SplitterDistance;
                splitContainer1.SplitterDistance = 0;
            }
            else //Shrink
            {
                fullReadme = false;
                splitContainer1.SplitterDistance = splCurrentDist;
                fmTable.Select();
            }
            #endregion
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                setFilter();
        }

        /// <summary>
        /// Clears lastFM value from ini file
        /// </summary>
        private void noLastFM()
        {
            i.IniWriteValue(secOptions, kLast_fm, null);
        }

        private void btnShowInBrowser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(htmlReadmePath);
        }

        #region Properties
        public string selectedFMName
        {
            get
            {
                return foundFMs[selFMID].extractionName;
            }
        }

        public string disabledMods
        {
            get
            {
                return foundFMs[selFMID].disabledMods;
            }
        }

        public int returnAfterPlaying
        {
            get
            {
                return returnType;
            }
        }

        public string instFMPath
        {
            get
            {
                return fmInstalledPath;
            }
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            //get fm names and sizes from table
            List<DarkLoaderFMData> dataList = new List<DarkLoaderFMData>();

            for (int x = 0; x < fmTable.Rows.Count; x++)
            {
                DarkLoaderFMData fmData = new DarkLoaderFMData();
                fmData.archiveOrDirName = foundFMs[x].archive;
                fmData.sizeByteString = foundFMs[x].sizeBytes.ToString();
                dataList.Add(fmData);
            }

            newKeyNames keys = new newKeyNames();
            keys.FMTitle = kFm_title;
            keys.FinishedID = kFinished;
            keys.ReleaseDateInt = kRelease_date;
            keys.LastPlayedInt = kLast_played;
            keys.Comment = kComment;

            Tools nTools = new Tools(gamePath, fmArchivePath, sevenZipGExe, userTempFolder, dataList, keys, i, archiveExtensions, dlWindowTitle, dlGamePath, dlSavesImport, dlIniImport, dlClose,
                overwriteTitle, overwriteLn1, overwriteLn2, overwriteLn3, overwriteLn4, overwriteLn5, overwriteLn6,
                yesBtn, yesToAllBtn, noBtn, noToAllBtn, gameIsShock2);

            nTools.ShowDialog();

            if (nTools.ImportedINI)
            {
                //get section name from current row selection
                string secName = foundFMs[selFMID].sectionName;

                fmTable.ClearSelection();
                fmTable.Rows.Clear();
                fillFMList(); //Changing some FM titles may reorder the table and cause the tags list to come out of synch.

                selectRow(secName);
            }
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCustomTag(authorToolStripMenuItem.Text);
        }

        private void contestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCustomTag(contestToolStripMenuItem.Text);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCustomTag(genreToolStripMenuItem.Text);
        }

        /// <summary>
        /// Sets category but user has to set the item value
        /// </summary>
        /// <param name="presetText">Of the form cat:</param>
        private void addCustomTag(string presetText)
        {
            string getCat = "";

            if (presetText.EndsWith(":"))
                getCat = presetText.Replace(":", "");
            else
                getCat = miscTagCat;

            tbAddTag.Text = presetText;
            tbAddTag.Select();
            tbAddTag.Select(tbAddTag.Text.Length, 0);
        }

        /// <summary>
        /// Adds tag to FM and updates all lists and TreeViews
        /// </summary>
        /// <param name="fullTagString"></param>
        private void addTag(string fullTagString)
        {
            if (fullTagString != "" && !fullTagString.StartsWith(":") && !fullTagString.EndsWith(":") && countColons(fullTagString) <= 1)
            {
                hideTagSelectionList();
                string[] tagData = fullTagString.Split(':');
                string cat = ""; //required for updating the drop down list before global tags have been updated.
                catItem newCI = new catItem();
                if (tagData.Length == 2)
                {
                    newCI.cat = tagData[0].Trim();
                    cat = newCI.cat;
                    newCI.item = tagData[1].Trim();
                }
                else if (tagData.Length == 1)
                {
                    newCI.cat = miscTagCat;
                    cat = newCI.cat;
                    newCI.item = tagData[0].Trim();
                }
                List<catItem> currentTags = foundFMs[selFMID].fmTags;

                if (!currentTags.Contains(newCI))
                {
                    currentTags.Add(newCI); //Also updates list in allFMTags - reference type.
                }

                string sectionName = foundFMs[selFMID].sectionName;

                writeTagsToINI(sectionName, currentTags, kTags);

                readAllTags();
                showTagsForFM(foundFMs[selFMID].sectionName);
            }
            else
                MessageBox.Show(tagError1 + "\n" + tagError2, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private int countColons(string tagString)
        {
            int colons = 0;
            char[] cArray = tagString.ToCharArray();
            foreach (char c in cArray)
            {
                if (c == ':')
                    colons++;
            }
            return colons;
        }

        #region genre tags
        private void addGenreTag(object senderFromMenu)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)senderFromMenu;
            addTag(genreToolStripMenuItem.Text + menuItem.Text);
        }


        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addGenreTag(sender);
        }

        private void crimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addGenreTag(sender);
        }

        private void horrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addGenreTag(sender);
        }

        private void mysteryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addGenreTag(sender);
        }

        private void puzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addGenreTag(sender);
        }
        #endregion

        #region language tags
        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addCustomTag(languageToolStripMenuItem.Text);
        }


        private void addLanguageTag(object senderFromMenu)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)senderFromMenu;
            //addTag(languageToolStripMenuItem.Text + menuItem.Text);
            addCustomTag(languageToolStripMenuItem.Text + menuItem.Text);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void czechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void dutchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void germanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void hugarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void italianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void japaneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void polishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addLanguageTag(sender);
        }
        #endregion

        #region simple tags
        private void addSimpleTag(object senderFromMenu)
        {
            ToolStripMenuItem mItem = (ToolStripMenuItem)senderFromMenu;
            addTag(mItem.Text);
        }

        private void seriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSimpleTag(sender);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSimpleTag(sender);
        }

        private void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSimpleTag(sender);
        }

        private void otherProtagonistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSimpleTag(sender);
        }

        private void unknownAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSimpleTag(sender);
        }
        #endregion

        private void btnRemoveTags_Click(object sender, EventArgs e)
        {
            deleteTag();
        }

        private void deleteTag()
        {
            TreeNode node = tagTree.SelectedNode;
            if (node != null)
            {
                catItem selCatItem = new catItem();
                if (node.Parent != null)
                {
                    selCatItem.cat = node.Parent.Text;
                    selCatItem.item = node.Text;

                    string tagText = "";
                    if (selCatItem.cat != miscTagCat)
                        tagText = selCatItem.cat + ":" + selCatItem.item;
                    else
                        tagText = selCatItem.item;

                    DialogResult dR = MessageBox.Show(remTagMsgStart + " " + tagText + "?", confirmBoxMsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dR == DialogResult.Yes)
                    {
                        List<catItem> currentTags = foundFMs[selFMID].fmTags;
                        currentTags.Remove(selCatItem);
                        writeTagsToINI(foundFMs[selFMID].sectionName, currentTags, kTags);
                        readAllTags();
                        showTagsForFM(foundFMs[selFMID].sectionName);
                    }
                }
                else
                {
                    string cat = node.Text;
                    DialogResult dR = MessageBox.Show(remAllCatMsgStart + " " + cat + " " + remAllCatMsgEnd + "?", confirmBoxMsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dR == DialogResult.Yes)
                    {
                        List<catItem> currentTags = foundFMs[selFMID].fmTags;
                        int tagCount = currentTags.Count;
                        for (int x = tagCount - 1; x >= 0; x--)
                        {
                            if (currentTags[x].cat == cat)
                            {
                                currentTags.Remove(currentTags[x]);
                            }
                        }
                        writeTagsToINI(foundFMs[selFMID].sectionName, currentTags, kTags);
                        readAllTags();
                        showTagsForFM(foundFMs[selFMID].sectionName);
                    }
                }
            }
        }

        private void btnSetTagFilter_Click(object sender, EventArgs e)
        {
            TagFilter tFilter = new TagFilter(globalCatItems, globalCategories, includeTags, excludeTags,
                tagWindowTitle, availTagsText, incTagsText, excTagsText, incBtnText, excBtnText, remBtnText, remAllBtnText,
                okBtnText, cancBtnText, remAllMessage, confirmBoxMsgTitle, miscTagCat);

            DialogResult dR = tFilter.ShowDialog();

            if (dR == DialogResult.OK)
            {
                includeTags = tFilter.IncludedTags;
                excludeTags = tFilter.ExcludedTags;
                string filterString = tFilter.FilterString;
                if (filterString.Length != 0)
                    lblTagFilter.Text = filterString;
                else
                    lblTagFilter.Text = "[none]";

                setFilter();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mainButtonClicked)
                this.DialogResult = DialogResult.Abort;

#if showColumns
#else
            storeColumnWidths();
#endif
#if screenSize
#else
            storeWindowState();
#endif
            storeShowTagState();
            storeSortState();

            storeFilterState();

            i.writeIniDataToFile();
        }

        private void storeFilterState()
        {
            //name string
            i.IniWriteValue(secOptions, kNameFilter, tbFilter.Text);
            //unifished string
            if (chkUnfinished.Checked)
                i.IniWriteValue(secOptions, kUnfinishedFilter, "1");
            else
                i.IniWriteValue(secOptions, kUnfinishedFilter, null);

            //Min date set
            if (cbMinYear.SelectedIndex != 0)
                i.IniWriteValue(secOptions, kStartDateFilter, (cbMinMonth.SelectedIndex) + "," + cbMinYear.Items[cbMinYear.SelectedIndex]);
            else
                i.IniWriteValue(secOptions, kStartDateFilter, null);

            //Max date set.
            if (cbMaxYear.SelectedIndex != 0)
                i.IniWriteValue(secOptions, kEndDateFilter, (cbMaxMonth.SelectedIndex) + "," + cbMaxYear.Items[cbMaxYear.SelectedIndex]);
            else
                i.IniWriteValue(secOptions, kEndDateFilter, null);

            //write include and exlude tag lists to file
            writeTagsToINI(secOptions, includeTags, kIncTagsFilter);
            writeTagsToINI(secOptions, excludeTags, kExcTagsFilter);
        }

        private void storeSortState()
        {
            i.IniWriteValue(secOptions, kSortCol, fmSortColumn.ToString());
            int saveOrder = (int)fmSortOrder;
            i.IniWriteValue(secOptions, kSortOrder, saveOrder.ToString());
        }

        private void storeShowTagState()
        {
            if (gbTags.Visible)
                i.IniWriteValue(secOptions, kShowTags, "1");
            else
                i.IniWriteValue(secOptions, kShowTags, "0");
        }

        private void storeWindowState()
        {
            FormWindowState st = this.WindowState;
            if (st == FormWindowState.Maximized)
            {
                i.IniWriteValue(secOptions, kWindowState, st.ToString());
            }
            else if (st == FormWindowState.Normal)
            {
                i.IniWriteValue(secOptions, kWindowState,
                    this.Width + "," +
                    this.Height + "," +
                    this.Location.X + "," +
                    this.Location.Y);
            }
        }

        private void storeColumnWidths()
        {
            StringBuilder cWidths = new StringBuilder();
            //Will save column widths to ini
            foreach (DataGridViewColumn col in fmTable.Columns)
            {
                cWidths.Append(col.Width);
                cWidths.Append(",");
            }
            string cString = cWidths.ToString().TrimEnd(',');
            i.IniWriteValue(secOptions, kCWidths, cString);
        }

        private bool stringCell(int columnIndex)
        {
            int[] sCells = { ARCHIVE, TITLE, COMMENT, DISABLED_MODS, INSTALLED };
            if (sCells.Contains<int>(columnIndex))
                return true;
            else
                return false;
        }

        private int compareByName(int rowIndex1, int rowIndex2)
        {
            string title1 = foundFMs[rowIndex1].title;
            string title2 = foundFMs[rowIndex2].title;
            return title1.CompareTo(title2);
        }

        /// <summary>
        /// Does not change the selection, but scrolls up or down until it is visible.
        /// </summary>
        private void scrollToSelectedRow()
        {
            if (selFMID >= 0)
            {
                string section = foundFMs[selFMID].sectionName;
                selectRow(section);
            }
        }

        private void btnHideTags_Click(object sender, EventArgs e)
        {
            if (gbTags.Visible)
            {
                hideTags();
            }
            else
            {
                showTags();
            }
        }

        private void showTags(bool dontResize = false)
        {
            int bHPos = btnHideTags.Location.X;
            gbTags.Visible = true;
            if (!dontResize)
            {
                fmTable.Width -= gbTags.Width;
                bHPos -= gbTags.Width;
                btnHideTags.Location = new Point(bHPos, btnHideTags.Location.Y);
            }
            btnHideTags.Text = ">";
            btnRefresh.Location = new Point(bHPos, btnRefresh.Location.Y);
        }

        private void hideTags()
        {
            int bHPos = btnHideTags.Location.X + gbTags.Width;
            btnHideTags.Location = new Point(bHPos, btnHideTags.Location.Y);
            gbTags.Visible = false;
            fmTable.Width += gbTags.Width;
            btnHideTags.Text = "<";

            btnRefresh.Location = new Point(bHPos, btnRefresh.Location.Y);
        }

        private void dtMin_MonthChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dtMin_YearChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dtMax_MonthChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dtMax_YearChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            setFilter();
            tbFilter.Select();
        }

        /// <summary>
        /// Get a list of cells within the selected row that are visible (e.g. Game column is hidden)
        /// </summary>
        /// <returns></returns>
        private List<int> getVisibleCols()
        {
            List<int> visibleCols = new List<int>();
            foreach (DataGridViewColumn col in fmTable.Columns)
            {
                if (col.Visible)
                    visibleCols.Add(col.Index);
            }
            return visibleCols;
        }

        /// <summary>
        /// Gets a list of rows in fmTable that are currently visible
        /// </summary>
        /// <returns></returns>
        private List<int> getVisibleRows()
        {
            List<int> visibleRows = new List<int>();
            foreach (DataGridViewRow row in fmTable.Rows)
            {
                if (row.Visible)
                    visibleRows.Add(row.Index);
            }
            return visibleRows;
        }

        private void fmTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                playDClickEnter();
            }
        }

        private void playDClickEnter()
        {
            if (alwaysPlayOnDC)
                userSelectsPlayFM();
            else
            {
                DblClickFM dClickFM = new DblClickFM(confirmBoxMsgTitle, dCEQuestion, dCEAlwaysPlay, yesBtn, noBtn);
                DialogResult dR = dClickFM.ShowDialog();

                if (dClickFM.AlwaysPlayFM)
                {
                    alwaysPlayOnDC = true;
                    i.IniWriteValue(secOptions, kAlwaysPlay, "1");
                }

                if (dR == DialogResult.Yes)
                {
                    userSelectsPlayFM();
                }
            }
        }

        private void fmTable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = fmTable.HitTest(e.X, e.Y);
                fmTable.ClearSelection();
                if (hti.ColumnIndex >= 0 && hti.RowIndex >= 0)
                    fmTable.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void scanAllFMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showThisFM = false;
            StringBuilder scanAllBuilder = new StringBuilder();
            scanAllBuilder.AppendLine(scanAllMsg1);
            scanAllBuilder.AppendLine(scanAllMsg2);

            DialogResult dR = MessageBox.Show(scanAllBuilder.ToString(), confirmBoxMsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dR == DialogResult.Yes)
            {
                getAllFMDetails(true);
            }
            showThisFM = true;
        }

        private void rescanThisFMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getFMDetails(selFMID, true);
            fmTable.Refresh();
        }

        private void tbAddTag_TextChanged(object sender, EventArgs e)
        {
            int defHeight = 17;
            //lbTags.Height = defHeight;
            lbTags.Items.Clear();
            if (tbAddTag.Text != "")
            {
                foreach (catItem cI in globalCatItems)
                {
                    if (cI.ToString().ToLower().StartsWith(tbAddTag.Text.ToLower()))
                    {
                        lbTags.Visible = true;
                        lbTags.Items.Add(cI);
                        lbTags.Height = defHeight * (lbTags.Items.Count);
                    }
                }
            }
            else
            {
                hideTagSelectionList();
            }
        }

        private void lbTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectTag();
            }
        }

        /// <summary>
        /// Takes a tag selection from lbTags and adds the text to tbAddTag
        /// </summary>
        private void selectTag()
        {
            tbAddTag.Text = lbTags.SelectedItem.ToString();
            selectAddTagBox();
            hideTagSelectionList();
        }

        private void selectAddTagBox()
        {
            tbAddTag.Select();
            tbAddTag.Select(tbAddTag.Text.Length + 1, 0);
        }

        private void hideTagSelectionList()
        {
            lbTags.Items.Clear();
            lbTags.Visible = false;
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            addTag(tbAddTag.Text);
        }

        private void lbTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectTag();
        }

        private void btnAddExistTag_Click(object sender, EventArgs e)
        {
            AddExistingTag addExist = new AddExistingTag(btnAddExistTag.Text, okBtnText, cancBtnText,
                globalCatItems, globalCategories);
            DialogResult dR = addExist.ShowDialog();

            if (dR == DialogResult.OK)
            {
                string chosenTag = addExist.tagString;
                if (chosenTag != null)
                {
                    addTag(chosenTag);
                }
            }
        }

        private void tagTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteTag();
            }
        }

        private void btnTagPresets_Click(object sender, EventArgs e)
        {
            tagPresetToolStripMenuItem.ShowDropDown();
        }

        //[System.Runtime.InteropServices.DllImport("User32.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        //private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool Repaint);

        private void Form1_Load(object sender, EventArgs e)
        {
#if screenSize
            this.MaximumSize = new Size(5000, 5000);
            bool Result = MoveWindow(this.Handle, this.Left, this.Top, 1980, 1080, true);
#endif

            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
        }

        private void btnWebSearch_Click(object sender, EventArgs e)
        {
            string fmTitle = foundFMs[selFMID].title;
            string webSearchSite = i.IniReadValue(secOptions, "WebSearchSite");
            if (webSearchSite != "")
            {
                if (webSearchSite == "0")
                    webSearchSite = "";
                else
                    webSearchSite = " site:" + webSearchSite;
                if (webSearchSite.ToLower().Contains("thiefmissions.com"))
                {
                    string[] words = fmTitle.Split(' ');
                    if (wordIsArticle(words[0]))
                    {
                        fmTitle = removeArticle(words);
                    }
                }
            }

            string humanSearchTerm = "\"" + fmTitle + "\"" + webSearchSite;

            string browserSearchTerm = Uri.EscapeDataString(humanSearchTerm);

            StringBuilder url = new StringBuilder("https://www.google.com/search?q=");
            url.Append(browserSearchTerm);

            System.Diagnostics.Process.Start(url.ToString());
        }

        /// <summary>
        /// True if word is in article list. Default The, An, A.
        /// </summary>
        /// <param name="firstWord"></param>
        /// <returns></returns>
        bool wordIsArticle(string firstWord)
        {
            string articleWords = i.IniReadValue(secOptions, "ArticleWords");
            if (articleWords.Length != 0 && articleWords != "0")
            {
                string[] spArray = articleWords.Split(' ');
                if (spArray.Contains<string>(firstWord.ToLower()))
                    return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Removes the first word from a string and puts it on the end.
        /// </summary>
        /// <param name="allWords">Every word from an FM's title.</param>
        /// <returns></returns>
        private string removeArticle(string[] allWords)
        {
            StringBuilder newTitle = new StringBuilder();
            for (int w = 1; w < allWords.Length; w++)
            {
                newTitle.Append(allWords[w] + " ");
            }
            return newTitle.ToString().Trim() + ", " + allWords[0];
        }

        private void generateFMiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FanMission fm = foundFMs[selFMID];
            string titleExport = fm.title;
            string infoFileExport = i.IniReadValue(fm.sectionName, kInfoFile);
            string relDateExport = fm.relDateHex;
            string tagsExport = tagsToString(fm.fmTags);

            StringBuilder generate = new StringBuilder();

            if (titleExport != "")
                generate.AppendLine(kFm_title + "=" + titleExport);
            if (infoFileExport != "")
                generate.AppendLine(kInfoFile + "=" + infoFileExport);
            if (relDateExport != "")
                generate.AppendLine(kRelease_date + "=" + relDateExport);
            if (tagsExport != "")
                generate.AppendLine(kTags + "=" + tagsExport);

            dlgSaveFMINI.InitialDirectory = gamePath;

            if (fm.installed == colInstalled)
            {
                dlgSaveFMINI.InitialDirectory = fmInstalledPath + "\\" + fm.extractionName;
            }

            DialogResult dR = dlgSaveFMINI.ShowDialog();

            if (dR == DialogResult.OK)
            {
                File.WriteAllText(dlgSaveFMINI.FileName, generate.ToString());
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            FanMission fm = foundFMs[selFMID];
            List<int> rowsVisible = getVisibleRows();
            List<int> colsVisible = getVisibleCols();

            if (e.KeyCode == Keys.Home)
            {
                string firstSecionName = foundFMs[rowsVisible.Min()].sectionName;
                selectRow(firstSecionName);
            }
            else if (e.KeyCode == Keys.End)
            {
                string lastSectionName = foundFMs[rowsVisible.Max()].sectionName;
                selectRow(lastSectionName);
            }
            else if (e.KeyCode == Keys.Left)
            {
                DataGridViewRow row = fmTable.SelectedRows[0];
                row.Cells[colsVisible.Min()].Selected = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                DataGridViewRow row = fmTable.SelectedRows[0];
                row.Cells[colsVisible.Max()].Selected = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbAddTag.Focused)
                {
                    addTag(tbAddTag.Text);
                    hideTagSelectionList();
                }
                else
                    playDClickEnter();
            }
            else if (e.KeyCode == Keys.Down && lbTags.Items.Count > 0)
            {
                if (tbAddTag.Focused)
                {
                    lbTags.Select();
                    lbTags.SelectedIndex = 0;
                }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
            {
                if (sevenZipGExe != "")
                {
                    if (fm.installed == colInstalled)
                    {
                        DialogResult dR = MessageBox.Show(forceReinstall1, forceReinstall2, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dR == DialogResult.Yes)
                        {
                            userPlayFM = false;
                            installationChoice();
                        }
                    }
                }
                else
                    MessageBox.Show(cantReinstall1, cantReinstall2, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
            {
                DialogResult dR = MessageBox.Show(chooseFix1, chooseFix2, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dR == DialogResult.Yes)
                {
                    DialogResult selFix = dlgSelectFixFile.ShowDialog();
                    if (selFix == DialogResult.OK)
                    {
                        string fixPath = setFMFixPath();
                        if (!Directory.Exists(fixPath))
                            Directory.CreateDirectory(fixPath);

                        foreach (string file in dlgSelectFixFile.FileNames)
                        {
                            FileInfo f = new FileInfo(file);
                            File.Copy(file, fixPath + "\\" + f.Name, true);
                        }

                        string doneMessage = fixesCopied2 + " " + fixPath + "\n" + fixesCopied3 + "\n\n" + fixesCopied4;

                        MessageBox.Show(doneMessage, fixesCopied1);
                    }
                }
            }

            else if (e.KeyCode == Keys.F5)
            {
                refreshFMTable();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshFMTable();
        }

        /// <summary>
        /// Stores the current FM selection, deletes and refills the table, and selects the current FM again.
        /// </summary>
        private void refreshFMTable()
        {
            string currentFM = foundFMs[selFMID].sectionName;
            fmTable.ClearSelection();
            fmTable.Rows.Clear();
            fillFMList();
            selectRow(currentFM);
        }

        private void fmTable_MouseEnter(object sender, EventArgs e)
        {
            fmTable.Focus();
        }

        private void tagTree_MouseEnter(object sender, EventArgs e)
        {
            tagTree.Focus();
        }

        private void readmeBox_MouseEnter(object sender, EventArgs e)
        {
            readmeBox.Focus();
        }

        /// <summary>
        /// Fills the FM table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmTable_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            FanMission fm = foundFMs[e.RowIndex];

            switch (fmTable.Columns[e.ColumnIndex].Name)
            {
                case "ArchiveOrDir":
                    e.Value = fm.archive;
                    break;
                case "ArchiveSize":
                    e.Value = fm.sizeMB;
                    break;
                case "TitleHeading":
                    e.Value = fm.title;
                    break;
                case "Rating_":
                    if (fm.rating >= 0)
                        e.Value = fm.rating;
                    else
                        e.Value = "";
                    break;
                case "Finished_":
                    e.Value = fm.imgFinished;
                    break;
                case "ReleaseDate_":
                    e.Value = fm.relDateString;
                    break;
                case "LstPlayed":
                    e.Value = fm.lastPlayedString;
                    break;
                case "Cmnt":
                    e.Value = fm.comment;
                    break;
                case "NoMod":
                    e.Value = fm.disabledMods;
                    break;
                case "Ins":
                    e.Value = fm.installed;
                    break;
            }
        }

        private void fmTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == fmSortColumn) //if clicked column is current column
            {
                if (fmSortOrder == SortOrder.Ascending)
                    fmSortOrder = SortOrder.Descending;
                else fmSortOrder = SortOrder.Ascending;
            }
            else
            {
                fmSortColumn = e.ColumnIndex;
                fmSortOrder = SortOrder.Ascending;
            }
            setSort();
            fmTable.Refresh();
        }

        private void aprMessages()
        {
            if (DateTime.Today.Hour < 12 && DateTime.Today.Day == 1 && DateTime.Today.Month == 4)
            {
                //Logger.LogThisLine("\tYes you taffer!");
                string message = "The Trickster is behind you!";
                toolTip1.SetToolTip(btnAddNewTag, message);
                toolTip1.SetToolTip(btnAddExistTag, message);
                toolTip1.SetToolTip(btnRemoveTags, message);
                toolTip1.SetToolTip(btnHideTags, message);
            }
        }

        private void setFilter()
        {
            string[] searchTerms = tbFilter.Text.Split(',');
            List<int> matchedRows = new List<int>();
            for (int x = 0; x < fmTable.RowCount; x++) //find which rows match search criteria
            {
                foreach (string term in searchTerms)
                {
                    if (term.Replace(" ", "") != "") //if not just spaces
                    {
                        string simpleTitle = foundFMs[x].title.ToLower();
                        string filterText = term.ToLower();
                        if (simpleTitle.Contains(filterText) && finishedMatches(x) && dateMatches(x) && tagsMatch(x))
                        {
                            matchedRows.Add(x);
                        }
                    }
                    else if (finishedMatches(x) && dateMatches(x) && tagsMatch(x))
                    {
                        matchedRows.Add(x);
                    }
                }
            }

            for (int x = 0; x < fmTable.Rows.Count; x++) //show the rows that match search criteria
            {
                if (matchedRows.Contains(x))
                    fmTable.Rows[x].Visible = true;
                else
                    fmTable.Rows[x].Visible = false;
            }

            fmTable.Select();

            scrollToSelectedRow();

            setTagLabelTip();
        }

        private void setTagLabelTip()
        {
            if (lblTagFilter.Text != emptyTag)
                toolTip1.SetToolTip(lblTagFilter, lblTagFilter.Text);
        }

        private bool tagsMatch(int currentRow)
        {
            if (includeMatches(currentRow) && excludeMatches(currentRow))
                return true;
            else
                return false;
        }

        private bool includeMatches(int currentRow)
        {
            bool match = true;

            foreach (catItem incTag in includeTags)
            {
                if (foundFMs[currentRow].fmTags.Contains(incTag))
                {
                    match = true;
                    break;
                }
                else
                    match = false;
            }

            return match;
        }

        private bool excludeMatches(int currentRow)
        {
            bool match = true;

            foreach (catItem excTag in excludeTags)
            {
                if (!foundFMs[currentRow].fmTags.Contains(excTag))
                    match = true;
                else
                {
                    match = false;
                    break;
                }
            }

            return match;
        }

        private bool dateMatches(int currentRow)
        {
            string relDate = foundFMs[currentRow].relDateString;
            if (relDate == "") return true; //always show when there's no release date

            DateTime convToDate = DateTime.ParseExact(relDate, dateFormat, null);

            int fMonthMin = 1; //Default, Jan
            if (cbMinMonth.SelectedIndex != 0)
                fMonthMin = cbMinMonth.SelectedIndex;
            int fYearMin = 1066;
            if (cbMinYear.SelectedIndex != 0)
                fYearMin = Convert.ToInt32(cbMinYear.Items[cbMinYear.SelectedIndex]);

            DateTime min = new DateTime(fYearMin, fMonthMin, 1);

            int fMonthMax = 12;//Default, Dec
            if (cbMaxMonth.SelectedIndex > 0)
                fMonthMax = cbMaxMonth.SelectedIndex;
            int fYearMax = 7510;
            if (cbMaxYear.SelectedIndex > 0)
                fYearMax = Convert.ToInt32(cbMaxYear.Items[cbMaxYear.SelectedIndex]);

            DateTime max = new DateTime(fYearMax, fMonthMax, DateTime.DaysInMonth(fYearMax, fMonthMax)); //gets the last day

            if (convToDate >= min && convToDate <= max)
                return true;
            else
                return false;
        }

        private bool finishedMatches(int currentRow)
        {
            if (chkUnfinished.Checked)
            {
                if (foundFMs[currentRow].finishedID == 0)
                {
                    return true;
                }
                else return false;
            }
            else return true;
        }

        bool mainButtonClicked = false;

        private void btnPlOriginal_Click(object sender, EventArgs e)
        {
            noLastFM();
            mainButtonClicked = true;
            if (!NDLRunFromDLL)
            {
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();

                psi.FileName = exeFullPath;
                psi.WorkingDirectory = Path.GetDirectoryName(exeFullPath);
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;

                p.StartInfo = psi;
                p.Start();

                p.WaitForExit();
                p.Close();
            }
        }

        bool userPlayFM = false;
        /// <summary>
        /// True if 7zip is used
        /// </summary>
        bool externalInstallation = false;

        private void setExtractionPath()
        {
            extractToPath = fmInstalledPath + "\\" + foundFMs[selFMID].extractionName;
        }

        private void btnPlFM_Click(object sender, EventArgs e)
        {
            userSelectsPlayFM();
        }

        private void userSelectsPlayFM()
        {
            userPlayFM = true;
            string installStatus = foundFMs[selFMID].installed;
            if (installStatus == "") //FM not installed
            {
                installationChoice();
            }
            else
            {
                setExtractionPath();
                checkForFixes();
            }
        }

        private void btnInstallOnly_Click(object sender, EventArgs e)
        {
            userPlayFM = false;
            if (btnInstallOnly.Text == installText)
            {
                installationChoice();
            }
            else
            {
                uninstallFM();
            }
        }

        private void backgroundInstallFM_DoWork(object sender, DoWorkEventArgs e)
        {
            installFMinternal();
        }

        /// <summary>
        /// Full path of FMs installation folder. E.g. C:\games\thief2\fms\something
        /// </summary>
        string extractToPath = "";

        /// <summary>
        /// Install FM. If 7Zip is installed, that is used. If not the program uses its own installer.
        /// </summary>
        private void installationChoice()
        {
            setExtractionPath();
            if (sevenZipGExe == "") //If 7zip not installed
            {
                progBar.BringToFront();
                progBar.Visible = true;
                installFMinternal();
            }
            else
            {
                installFMExternal();
            }
        }

        /// <summary>
        /// Converts any mp3 files to wav and deletes the mp3s.
        /// </summary>
        private void convertMp3s()
        {
            ConvertMP3 convMp3 = new ConvertMP3(extractToPath);
            convMp3.ShowDialog();
        }

        /// <summary>
        /// Installs FM using program's own method. Slower but requires no external programs.
        /// </summary>
        private void installFMinternal()
        {
            FanMission fm = foundFMs[selFMID];
            externalInstallation = false;
            //Extract archive
            string archiveFullPath = fmArchivePath + fm.subFolder + "\\" + fm.archive;

            if (!Directory.Exists(extractToPath))
                Directory.CreateDirectory(extractToPath);

            #region SevenZipSharp code
            //Extract FM
            SevenZipExtractor fmExtract = new SevenZipExtractor(archiveFullPath);
            fmExtract.Extracting += new EventHandler<ProgressEventArgs>(extracting);
            fmExtract.ExtractionFinished += new EventHandler<EventArgs>(extFMFinished);
            fmExtract.BeginExtractArchive(extractToPath); //async method
            #endregion
        }

        #region Event handlers for internal 7z extraction
        private void extracting(object sender, ProgressEventArgs e)
        {
            byte b = e.PercentDone;
            int per = (int)b;

            progBar.Value = per;
        }

        private void extFMFinished(object sender, EventArgs e)
        {
            FanMission fm = foundFMs[selFMID];
            convertMp3s();
            //When FM has been extracted, look for saves file and extract that.
            string saveArchivePath = fmArchivePath + fm.subFolder + "\\" + fm.saveBackupName;
            if (File.Exists(saveArchivePath))
            {
                SevenZipExtractor saveExtract = new SevenZipExtractor(saveArchivePath);
                saveExtract.Extracting += new EventHandler<ProgressEventArgs>(extracting);
                saveExtract.ExtractionFinished += new EventHandler<EventArgs>(saveExtFinished);
                saveExtract.BeginExtractArchive(extractToPath);
            }
            else
            {
                checkForFixes();
            }
        }

        private bool missflagExists(string fmInsDir)
        {
            string[] strFolderFiles = Directory.GetFiles(fmInsDir, "missflag.str", SearchOption.AllDirectories);
            if (strFolderFiles.Length > 0)
                return true;
            else
                return false;
        }

        private void saveExtFinished(object sender, EventArgs e)
        {
            checkForFixes();
        }
        #endregion

        /// <summary>
        /// Checks for the existence of missflag.str, then looks for FM fixes (e.g. dmls) Then plays FM is user has chosen to.
        /// </summary>
        private void checkForFixes()
        {
            if (!missflagExists(extractToPath))
            {
                AddMissFlag.addMissingMisflagFile(userTempFolder, extractToPath);
            }

            string fmFixPath = setFMFixPath();
            if (Directory.Exists(fmFixPath))
            {
                List<string> archives = getFixFileList(fmFixPath);

                if (archives.Count > 0)
                {
                    //extract fixes
                    foreach (string file in archives)
                    {
                        SevenZipExtractor fixExtract = new SevenZipExtractor(file);
                        try
                        {
                            fixExtract.ExtractArchive(extractToPath);
                        }
                        catch
                        {
                            //nothing
                        }
                    }
                }
            }

            playFMTest();
        }

        private List<string> getFixFileList(string fmFixPath)
        {
            string[] fixFiles = Directory.GetFiles(fmFixPath);

            List<string> archives = new List<string>(); //only allow files with the right extension
            foreach (string file in fixFiles)
            {
                if (validArchiveExtension(file))
                    archives.Add(file);
            }
            return archives;
        }

        /// <summary>
        /// Looks at the archive value from the table, and returns the full path of the .fix subfolder.
        /// </summary>
        /// <returns></returns>
        private string setFMFixPath()
        {
            FileInfo fInfo = new FileInfo(foundFMs[selFMID].archive);
            string basicName = "";
            if (fInfo.Extension.Length != 0)
                basicName = fInfo.Name.Replace(fInfo.Extension, "");
            else basicName = fInfo.Name; //use folder name if there's no archive
            string fmFixPath = fmArchivePath + "\\.fix\\" + basicName;
            return fmFixPath;
        }

        /// <summary>
        /// Hide progress bar. Play FM if the user has chosen to.
        /// </summary>
        /// <param name="externalInstallation">False if installed internally. Used to hide the progress bar.</param>
        private void playFMTest()
        {
            markFMInstalled();
            if (!externalInstallation)
                progBar.Visible = false;
            if (userPlayFM)
                playFM();
        }

        private void installFMExternal()
        {
            FanMission fm = foundFMs[selFMID];
            externalInstallation = true;
            string fmArchiveName = fm.archive;
            string subfolder = fm.subFolder;
            string fmExtractionPath = fmInstalledPath + "\\" + fm.extractionName;
            SevenZipGExtract.ExtractArchive(sevenZipGExe, fmArchivePath, subfolder + "\\" + fmArchiveName, fmExtractionPath);

            convertMp3s();

            string savesFile = fmArchivePath + subfolder + "\\" + fm.saveBackupName;

            if (File.Exists(savesFile))
            {
                SevenZipGExtract.ExtractArchive(sevenZipGExe, fmArchivePath + subfolder, fm.saveBackupName, fmExtractionPath);
            }

            checkForFixes();
        }

        private void markFMInstalled()
        {
            FanMission fm = foundFMs[selFMID];
            fm.installed = colInstalled;
            foundFMs[selFMID] = fm;
            fmTable.Refresh();
            btnInstallOnly.Text = uninstallText;
        }

        /// <summary>
        /// Looks for .fix files and extracts them, then plays the FM.
        /// </summary>
        private void playFM()
        {
            FanMission fm = foundFMs[selFMID];
            i.IniWriteValue(secOptions, kLast_fm, fm.sectionName.Replace("FM=", ""));
            DateTime lastPlayed = DateTime.Today;
            fm.lastPlayedString = lastPlayed.ToString(dateFormat);
            i.IniWriteValue(fm.sectionName, kLast_played, DateIntConverter.dateToHexString(lastPlayed));
            foundFMs[selFMID] = fm;

            if (!NDLRunFromDLL)
            {
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();

                psi.FileName = exeFullPath;
                psi.WorkingDirectory = Path.GetDirectoryName(exeFullPath);
                psi.Arguments = "-fm=" + fm.extractionName;
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;

                p.StartInfo = psi;
                p.Start();

                p.WaitForExit();
                p.Close();
            }
            else
            {
                mainButtonClicked = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void uninstallFM()
        {
            FanMission fm = foundFMs[selFMID];

            string backupZipPath = fmArchivePath + fm.subFolder + "\\" + fm.saveBackupName;
            string currentFMPath = fmInstalledPath + "\\" + fm.extractionName;

            string savesPath = "";
            string screensPath = "";

            if (!gameIsThief3)
            {
                if (gameIsShock2)
                    savesPath = currentFMPath + "\\save_"; //save_## (0 - 14)
                else
                    savesPath = currentFMPath + "\\saves";
                screensPath = currentFMPath + "\\screenshots";
            }
            else
            {
                savesPath = currentFMPath + "\\SaveGames";
                screensPath = currentFMPath + "\\ScreenShots";
            }

            //Check if FM is from an archive or folder only
            bool fmIsArchive = false;
            if (fm.archiveOrDirectory == FMType.Archive)
                fmIsArchive = true;

            DialogResult dR = DialogResult.None;
            if (!fmIsArchive)
            {
                string saveBackupNote = "";
                if (backupType == "Always")
                    saveBackupNote = "\n" + saveBackupMsg;
                dR = MessageBox.Show(noArchiveWarning + saveBackupNote,
                    warningTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

            if (dR == DialogResult.Yes || fmIsArchive)
            {
                prepareToDeleteFMFolder(backupZipPath, currentFMPath, savesPath, screensPath);
                if (!fmIsArchive)
                    foundFMs.RemoveAt(selFMID);
            }
        }

        /// <summary>
        /// Handles the process of making a save backup (optional) and then deleting the FM's folder.
        /// </summary>
        /// <param name="backupZipPath">Full path of [name].FMSelBak.zip</param>
        /// <param name="currentFMPath">C:\....FMs\[fm name]</param>
        /// <param name="savesPath">C:\....FMs\[fm name]\saves</param>
        /// <param name="screensPath">C:\....FMs\[fm name]\screenshots</param>
        private void prepareToDeleteFMFolder(string backupZipPath, string currentFMPath, string savesPath, string screensPath)
        {
            if ((gameIsShock2 || Directory.Exists(savesPath) || Directory.Exists(screensPath)))
            {
                if (backupType == "Always")
                {
                    saveBackup(currentFMPath, savesPath, screensPath, backupZipPath);
                    deleteFMFolder(currentFMPath);
                }
                else //"Ask" (default)
                {
                    DialogResult dR = MessageBox.Show(saveBackupQ1 + "\n" + saveBackupQ2, saveBackupTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dR == DialogResult.Yes)
                    {
                        saveBackup(currentFMPath, savesPath, screensPath, backupZipPath);
                        deleteFMFolder(currentFMPath);
                    }
                    else if (dR == DialogResult.No)
                    {
                        deleteFMFolder(currentFMPath);
                    }
                    else if (dR == DialogResult.Cancel)
                        return;
                }
            }
            else
            {
                deleteFMFolder(currentFMPath);
            }
        }

        private void saveBackup(string currentFMPath, string savesPath, string screensPath, string backupZipPath)
        {
            SevenZipCompressor szComp = new SevenZipCompressor(userTempFolder);
            szComp.ArchiveFormat = OutArchiveFormat.Zip;
            szComp.CompressionLevel = CompressionLevel.Normal;
            szComp.PreserveDirectoryRoot = true;

            if (gameIsShock2)
            {
                string[] saveDirs = Directory.GetDirectories(currentFMPath);
                for (int x = 0; x < saveDirs.Length; x++)
                {
                    if (saveDirs[x].Contains(savesPath) || saveDirs[x].ToLower().EndsWith("current"))
                    {
                        szComp.CompressDirectory(saveDirs[x], backupZipPath); //New file created
                        szComp.CompressionMode = CompressionMode.Append; //Next dir will be added
                    }
                }
            }

            else //thief, thief2 or thief3
            {
                if (Directory.Exists(savesPath))
                {
                    DirectoryInfo dI = new DirectoryInfo(savesPath);
                    if (dI.GetFiles().Length != 0)
                    {
                        szComp.CompressDirectory(savesPath, backupZipPath); //New file created
                        szComp.CompressionMode = CompressionMode.Append; //Next dir will be added
                    }
                }
            }

            if (Directory.Exists(screensPath))
            {
                DirectoryInfo dI = new DirectoryInfo(screensPath);
                if (dI.GetFiles().Length != 0)
                    szComp.CompressDirectory(screensPath, backupZipPath);
            }
        }

        private void deleteFMFolder(string fmPath)
        {

            //clear all read only flags
            foreach (string file in Directory.GetFiles(fmPath, "*.*", SearchOption.AllDirectories))
            {
                FileInfo fI = new FileInfo(file);
                fI.IsReadOnly = false;
            }
            foreach (string dir in Directory.GetDirectories(fmPath, "*.*", SearchOption.AllDirectories))
            {
                DirectoryInfo dI = new DirectoryInfo(dir);
                FileAttributes fA = FileAttributes.Normal;
                dI.Attributes = fA;
            }

            try
            {
                allEnabledToggle(false);
                Cursor = Cursors.WaitCursor;
                noLastFM();

                FullDelete.DeleteDir(fmPath, true);
                FanMission fm = foundFMs[selFMID];
                fm.installed = "";
                foundFMs[selFMID] = fm;
                btnInstallOnly.Text = installText;

                fmTable.Refresh();
                Cursor = Cursors.Default;
                allEnabledToggle(true);
            }
            catch (Exception e)
            {
                fmTable.Refresh();
                Cursor = Cursors.Default;
                allEnabledToggle(true);
                MessageBox.Show(e.Message);
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            showSetup(false, true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            deleteHTMLReadme();
            mainButtonClicked = true;
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double pos = (double)splitContainer1.SplitterDistance / (double)splitContainer1.Height;
            double rounded = Math.Round(pos, 2);

            i.IniWriteValue(secOptions, kSplitDist, rounded.ToString());
        }

        private void fmTable_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (foundFMs.Count != 0 && e.RowIndex >= 0)
            {
                int col = e.ColumnIndex;
                int row = e.RowIndex;

                string tip = rightClickTip;
                string content = "";
                //if(cellString(col, row) !=null)
                //{
                string cellValue = "";
                if (col == FINISHED)
                {
                    cellValue = getFinishedText(foundFMs[row].finishedID);
                }
                else
                {
                    cellValue = getCellValue(row, col);
                }

                if (cellValue != "")
                    content = cellValue + "\n";

                e.ToolTipText = content + tip + "\n" + refresh;
            }
        }

        private string getCellValue(int row, int col)
        {
            string cValue = "";

            switch (col)
            {
                case ARCHIVE:
                    cValue = foundFMs[row].archive;
                    break;
                case FM_SIZE:
                    cValue = foundFMs[row].sizeMB;
                    break;
                case TITLE:
                    cValue = foundFMs[row].title;
                    break;
                case RATING:
                    cValue = foundFMs[row].rating.ToString();
                    break;
                case FINISHED:
                    cValue = getFinishedText(foundFMs[row].finishedID);
                    break;
                case RELEASE_DATE:
                    cValue = foundFMs[row].relDateString;
                    break;
                case LAST_PLAYED:
                    cValue = foundFMs[row].lastPlayedString;
                    break;
                case COMMENT:
                    cValue = foundFMs[row].comment;
                    break;
                case DISABLED_MODS:
                    cValue = foundFMs[row].disabledMods;
                    break;
                case INSTALLED:
                    cValue = foundFMs[row].installed;
                    break;
                default:
                    cValue = "";
                    break;
            }

            return cValue;
        }

        private void cbMinMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void cbMinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void cbMaxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void cbMaxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }
    }

    //public enum SortDirection { Ascending, Descending };

    /// <summary>
    /// Info needed for looking for fm data in old Darkloader.ini file.
    /// </summary>
    public struct DarkLoaderFMData
    {
        public string archiveOrDirName;
        public string sizeByteString;
    }

    public struct catItem
    {
        public string cat;
        public string item;

        public override string ToString()
        {
            if (cat.ToLower() != "misc")
                return cat + ":" + item;
            else return item;
        }
    }

    public enum FMType { Archive, Directory }

    public struct FanMission
    {
        //Visible columns
        public string archive;//
        //Size is generated
        public string sizeMB;//
        public string title;//
        public int rating;//
        //Finished is generated
        public Image imgFinished;//
        //Release Date is generated
        public string relDateString;//
        //Last Played is generated
        public string lastPlayedString;//
        public string comment;//
        public string disabledMods;//
        public string installed;//

        //Hidden columns
        public string sectionName;//
        //game id not used
        public string gameID;//
        public int finishedID;//
        public string relDateHex;//
        public FMType archiveOrDirectory;//
        public string extractionName;//
        public string saveBackupName;//
        public string darkloaderSaves;//
        public string lastPlayedHex;//
        public string subFolder;
        public long sizeBytes;//
        public List<catItem> fmTags;
    }

    public static class MainSort
    {
        private static string articleWords = "";
        public static int Sort(int colID, SortOrder order, FanMission fm1, FanMission fm2, bool sortIgnoreArticles = false, string articleWordString = "")
        {
            int sortResult = 0;
            switch (colID)
            {
                case 0:
                    sortResult = fm1.archive.CompareTo(fm2.archive);
                    break;
                case 1:
                    sortResult = fm1.sizeBytes.CompareTo(fm2.sizeBytes);
                    break;
                case 2:
                    string t1 = fm1.title;
                    string t2 = fm2.title;
                    sortResult = titleSort(t1, t2, sortIgnoreArticles, articleWordString);
                    break;
                case 3:
                    sortResult = fm1.rating.CompareTo(fm2.rating);
                    break;
                case 4:
                    sortResult = fm1.finishedID.CompareTo(fm2.finishedID);
                    break;
                case 5:
                    if (fm1.relDateHex == "" && fm2.relDateHex != "")
                        sortResult = -1; //date 1 is less than date 2.
                    else if (fm1.relDateHex != "" && fm2.relDateHex == "")
                        sortResult = 1; //date 1 is greater than date 2.
                    else if (fm1.relDateHex == "" && fm2.relDateHex == "")
                        sortResult = 0;
                    else
                    {
                        DateTime rd1 = DateIntConverter.dateFromHexString(fm1.relDateHex);
                        DateTime rd2 = DateIntConverter.dateFromHexString(fm2.relDateHex);
                        sortResult = rd1.CompareTo(rd2);
                    }
                    break;
                case 6:
                    if (fm1.lastPlayedHex == "" && fm2.lastPlayedHex != "")
                        sortResult = -1; //date 1 is less than date 2.
                    else if (fm1.lastPlayedHex != "" && fm2.lastPlayedHex == "")
                        sortResult = 1; //date 1 is greater than date 2.
                    else if (fm1.lastPlayedHex == "" && fm2.lastPlayedHex == "")
                        sortResult = 0;
                    else
                    {
                        DateTime lp1 = DateIntConverter.dateFromHexString(fm1.lastPlayedHex);
                        DateTime lp2 = DateIntConverter.dateFromHexString(fm2.lastPlayedHex);
                        sortResult = lp1.CompareTo(lp2);
                    }
                    break;
                case 7:
                    sortResult = fm1.comment.CompareTo(fm2.comment);
                    break;
                case 8:
                    sortResult = fm1.disabledMods.CompareTo(fm2.disabledMods);
                    break;
                case 9:
                    sortResult = fm1.installed.CompareTo(fm2.installed);
                    break;
            }

            //Do a title sort when colum is not Title and sorted values are equal
            if (colID != 2 && sortResult == 0)
                sortResult = titleSort(fm1.title, fm2.title, sortIgnoreArticles, articleWordString);

            if (order == SortOrder.Descending)
                sortResult *= -1;

            return sortResult;
        }

        private static int titleSort(string t1, string t2, bool sortIgnoreArticles, string articleWordString)
        {
            int sortResult;

            if (sortIgnoreArticles)
            {
                articleWords = articleWordString;
                string[] title1Split = t1.Split(' ');
                string[] title2Split = t2.Split(' ');

                if (wordIsArticle(title1Split[0]))
                    t1 = removeArticle(title1Split);
                if (wordIsArticle(title2Split[0]))
                    t2 = removeArticle(title2Split);
            }

            sortResult = t1.CompareTo(t2);
            return sortResult;
        }

        /// <summary>
        /// True if word is in article list. Default The, An, A.
        /// </summary>
        /// <param name="firstWord"></param>
        /// <returns></returns>
        private static bool wordIsArticle(string firstWord)
        {
            //string articleWords = i.IniReadValue(secOptions, "ArticleWords");
            if (articleWords.Length != 0 && articleWords != "0")
            {
                string[] spArray = articleWords.Split(' ');
                if (spArray.Contains<string>(firstWord.ToLower()))
                    return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Removes the first word from a string and puts it on the end.
        /// </summary>
        /// <param name="allWords">Every word from an FM's title.</param>
        /// <returns></returns>
        private static string removeArticle(string[] allWords)
        {
            StringBuilder newTitle = new StringBuilder();
            for (int w = 1; w < allWords.Length; w++)
            {
                newTitle.Append(allWords[w] + " ");
            }
            return newTitle.ToString().Trim() + ", " + allWords[0];
        }
    }

    public class SortArchive : IComparer<FanMission>
    {
        private SortOrder sOrder;

        public SortArchive(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(0, sOrder, fm1, fm2);
        }
    }

    public class SortSize : IComparer<FanMission>
    {
        private SortOrder sOrder;

        public SortSize(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(1, sOrder, fm1, fm2);
        }
    }

    public class SortTitle : IComparer<FanMission>
    {
        private SortOrder sOrder;
        private bool igArticles;
        private string artclWords;

        public SortTitle(SortOrder order, bool ignoreArticles, string articleWordString)
        {
            sOrder = order;
            igArticles = ignoreArticles;
            artclWords = articleWordString;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(2, sOrder, fm1, fm2, igArticles, artclWords);
        }
    }

    public class SortRating : IComparer<FanMission>
    {
        private SortOrder sOrder;
        public SortRating(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(3, sOrder, fm1, fm2);
        }
    }

    public class SortFinished : IComparer<FanMission>
    {
        private SortOrder sOrder;
        public SortFinished(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(4, sOrder, fm1, fm2);
        }
    }

    public class SortRelDate : IComparer<FanMission>
    {
        private SortOrder sOrder;
        public SortRelDate(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(5, sOrder, fm1, fm2);
        }
    }

    public class SortLastPlayed : IComparer<FanMission>
    {
        private SortOrder sOrder;
        public SortLastPlayed(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(6, sOrder, fm1, fm2);
        }
    }

    public class SortComment : IComparer<FanMission>
    {
        private SortOrder sOrder;
        public SortComment(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(7, sOrder, fm1, fm2);
        }
    }

    public class SortDisabledMods : IComparer<FanMission>
    {
        private SortOrder sOrder;
        public SortDisabledMods(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(8, sOrder, fm1, fm2);
        }
    }

    public class SortInstalled : IComparer<FanMission>
    {
        private SortOrder sOrder;
        public SortInstalled(SortOrder order)
        {
            sOrder = order;
        }

        public int Compare(FanMission fm1, FanMission fm2)
        {
            return MainSort.Sort(9, sOrder, fm1, fm2);
        }
    }
}