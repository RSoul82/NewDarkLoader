using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NewDarkLoader
{
    public partial class Setup : Form
    {
        public Setup(INIFile iniFile, INIFile langIni, string optionsSecName, string archiveRootKeyName, string languageKeyName, 
            string dateFormatKeyName, string backupTypeKeyName, string sevenZipGKeyName, string noWin7ZKeyName, 
            string returnTypeKeyName, string dcDontAskKeyName, string installedFMsPath, bool sortNoArticles, bool relativePaths, bool _firstRun)
        {
            InitializeComponent();

            foreach (string lang in LangList.getLanguageList())
            {
                cBlang.Items.Add(lang);
            }
            cBlang.SelectedIndex = 0;
            i = iniFile;
            firstRun = _firstRun;

            //set key names
            secOptions = optionsSecName;
            kArchive_root = archiveRootKeyName;
            kLanguage = languageKeyName;
            kDate_format = dateFormatKeyName;
            kBackup_type = backupTypeKeyName;
            kReturn_type = returnTypeKeyName;
            k7zipG = sevenZipGKeyName;
            k7zipNoWin = noWin7ZKeyName;
            kDCDontAsk = dcDontAskKeyName;

            fmInstalledPath = installedFMsPath;
            chkSortIncludeArticles.Checked = sortNoArticles;
            chkRelaitvePaths.Checked = relativePaths;

            readLangINI(langIni);
            readFromINI();
        }

        SetupInfo sInfo = new SetupInfo();

        private INIFile i;
        private bool firstRun;
        private string fmInstalledPath = "";
        private string folderRequired = "Archive folder required.";
        private string fldrRequiredTitle = "Error";
        private string archIsFMsWarning = "The selected archive folder is actually your installed FMs folder.";

        #region Key names
        private string secOptions = "";
        private string kArchive_root = "";
        private string kLanguage = "";
        private string kDate_format = "";
        private string kBackup_type = "";
        private string kReturn_type = "";
        private string k7zipG = "";
        private string k7zipNoWin = "";
        private string kDCDontAsk = "";
        #endregion

        /// <summary>
        /// Sets the interface text from the optional language ini file.
        /// </summary>
        /// <param name="langIni"></param>
        private void readLangINI(INIFile langIni)
        {
            if(langIni != null)
            {
                string secSetup = "Setup";
                Text = langIni.IniReadValue(secSetup, "SetupTitle");
                gbFMArchive.Text = langIni.IniReadValue(secSetup, "FmArchFolderBox");
                archIsFMsWarning = langIni.IniReadValue(secSetup, "FolderIsFMsWarning");
                btnBrArchivePath.Text = langIni.IniReadValue(secSetup, "BrowseButton");
                gbLang.Text = langIni.IniReadValue(secSetup, "LangBox");
                gbDateFormat.Text = langIni.IniReadValue(secSetup, "DateFormatBox");
                rdoDMY.Text = langIni.IniReadValue(secSetup, "DmyChk");
                rdoMDY.Text = langIni.IniReadValue(secSetup, "MdyChk");
                gbSaveBackup.Text = langIni.IniReadValue(secSetup, "SaveBackupBox");
                rdoBkAsk.Text = langIni.IniReadValue(secSetup, "BackupTypeAsk");
                rdoBkAlways.Text = langIni.IniReadValue(secSetup, "BackupTypeAlways");
                gbDblClick.Text = langIni.IniReadValue(secSetup, "DblClickFMBox");
                chkDblClickDontAsk.Text = langIni.IniReadValue(secSetup, "DblClChk");
                gbReturn.Text = langIni.IniReadValue(secSetup, "ReturnAfterBox");
                rdoRetNever.Text = langIni.IniReadValue(secSetup, "RetNever");
                rdoRetAfterFM.Text = langIni.IniReadValue(secSetup, "RetAfterFM");
                rdoRetAlways.Text = langIni.IniReadValue(secSetup, "RetAlways");
                gb7z.Text = langIni.IniReadValue(secSetup, "OptLocate7zBox");
                btnBr7zGexe.Text = langIni.IniReadValue(secSetup, "BrowseButton");
                StringBuilder help7zBld = new StringBuilder();
                help7zBld.AppendLine(langIni.IniReadValue(secSetup, "Help7z1"));
                help7zBld.AppendLine(langIni.IniReadValue(secSetup, "Help7z2"));
                lbl7zHelp.Text = help7zBld.ToString();

                StringBuilder use7zeBld = new StringBuilder();
                use7zeBld.AppendLine(langIni.IniReadValue(secSetup, "Use7zeChk1"));
                use7zeBld.AppendLine(langIni.IniReadValue(secSetup, "Use7zeChk2"));
                chkUseNoWinExe.Text = use7zeBld.ToString();

                string secTagFilter = "TagFilterWindow"; //this is just done to prevent duplicate button text entries.
                btnOK.Text = langIni.IniReadValue(secTagFilter, "OK");
                btnCancel.Text = langIni.IniReadValue(secTagFilter, "Cancel");

                folderRequired = langIni.IniReadValue(secSetup, "FolderRequired");
                fldrRequiredTitle = langIni.IniReadValue(secSetup, "FldrRequiredTitle");

                gbWebSearch.Text = langIni.IniReadValue(secSetup, "WebSearchSite");
                lblNoSite.Text = langIni.IniReadValue(secSetup, "NoSiteLabel");
                lblSpecialWords.Text = langIni.IniReadValue(secSetup, "ArticleLabel");
                toolTip1.SetToolTip(tbSpecialWords, langIni.IniReadValue(secSetup, "ArticleTip"));
            }
        }

        private void readFromINI()
        {
            tbFMArchivePath.Text = i.IniReadValue(secOptions, kArchive_root);

            //Read language, stored in ini as int, 1 indexed
            string readLang = i.IniReadValue(secOptions, kLanguage);
            if (readLang != "")
            {
                int langSelection = Convert.ToInt32(readLang);
                cBlang.SelectedIndex = langSelection - 1;
            }

            //Read date format, stored as int
            string readDate = i.IniReadValue(secOptions, kDate_format);
            if (readDate != "")
            {
                int dateNumber = Convert.ToInt32(readDate);
                if (dateNumber == 1)
                    rdoDMY.Checked = true;
                else if (dateNumber == 2)
                    rdoMDY.Checked = true;
            }

            string readBackupAsk = i.IniReadValue(secOptions, kBackup_type);
            if (readBackupAsk != "")
            {
                if (readBackupAsk == "Ask")
                    rdoBkAsk.Checked = true;
                else if (readBackupAsk == "Always")
                    rdoBkAlways.Checked = true;
            }

            string readReturnAfter = i.IniReadValue(secOptions, kReturn_type);
            if (readReturnAfter != "")
            {
                if (readReturnAfter == "0")
                    rdoRetNever.Checked = true;
                else if (readReturnAfter == "1")
                    rdoRetAfterFM.Checked = true;
                else if (readReturnAfter == "2")
                    rdoRetAlways.Checked = true;
            }

            if (!firstRun)
            {
                string site = i.IniReadValue(secOptions, "WebSearchSite");
                if (site == "") site = "ttlg.com";
                tbWebSearch.Text = site;
                string articleWords = i.IniReadValue(secOptions, "ArticleWords");
                if (articleWords == "") articleWords = "the an a";
                tbSpecialWords.Text = articleWords;
            }

            //Get 7zG location
            tb7zGexe.Text = i.IniReadValue(secOptions, k7zipG);

            string noWin7Zip = i.IniReadValue(secOptions, k7zipNoWin);
            if (noWin7Zip != "")
                chkUseNoWinExe.Checked = true;

            string dcDontAsk = i.IniReadValue(secOptions, kDCDontAsk);
            if (dcDontAsk != "" && dcDontAsk != "0")
            {
                chkDblClickDontAsk.Checked = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string archivePathLCTest = tbFMArchivePath.Text.ToLower();
            string installedPathLCTest = fmInstalledPath.ToLower();
            //check that archive root has been set
            if (tbFMArchivePath.Text != "" && archivePathLCTest != installedPathLCTest)
            {
                sInfo.relativePaths = chkRelaitvePaths.Checked;

                sInfo.archiveDir = tbFMArchivePath.Text;
                sInfo.lang = cBlang.SelectedIndex + 1;
                if (rdoDMY.Checked)
                    sInfo.dateFormat = 1;
                else
                    sInfo.dateFormat = 2;

                if (rdoBkAsk.Checked)
                    sInfo.backupType = "Ask";
                else
                    sInfo.backupType = "Always";

                if (chkDblClickDontAsk.Checked)
                    sInfo.dcDontAsk = true;
                else
                    sInfo.dcDontAsk = false;

                if (rdoRetNever.Checked)
                    sInfo.returnAfterPlaying = 0;
                else if (rdoRetAfterFM.Checked)
                    sInfo.returnAfterPlaying = 1;
                else
                    sInfo.returnAfterPlaying = 2;

                sInfo.webSearchSite = tbWebSearch.Text;
                sInfo.specialWords = tbSpecialWords.Text;
                sInfo.sortIgnoreArticles = chkSortIncludeArticles.Checked;

                sInfo.sevenZipGExe = tb7zGexe.Text;

                if (File.Exists(tb7zGexe.Text))
                {
                    FileInfo fInfo = new FileInfo(tb7zGexe.Text);
                    string parentDir = fInfo.DirectoryName;
                    sInfo.sevenZNoWinExe = Path.Combine(parentDir, "7z.exe");

                    if (chkUseNoWinExe.Checked)
                        sInfo.useNoWinExe = true;
                    else
                        sInfo.useNoWinExe = false;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (tbFMArchivePath.Text == "")
                    MessageBox.Show(folderRequired, fldrRequiredTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if (archivePathLCTest == installedPathLCTest)
                    MessageBox.Show(archIsFMsWarning, fldrRequiredTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //Custom dialogue result
        public SetupInfo getSetupInfo
        {
            get
            {
                return sInfo;
            }
        }

        private void btnBrowseArchivePath_Click(object sender, EventArgs e)
        {
            DialogResult dR = brDir.ShowDialog();

            if (dR == DialogResult.OK)
            {
                tbFMArchivePath.Text = brDir.SelectedPath;
                if (chkRelaitvePaths.Checked)
                {
                    tbFMArchivePath.Text = AbsRel.AbsoluteToRelative(tbFMArchivePath.Text);
                }
            }
        }

        private void btbBr7zGexe_Click(object sender, EventArgs e)
        {
            DialogResult dR = br7zGExe.ShowDialog();

            if (dR == DialogResult.OK)
            {
                tb7zGexe.Text = br7zGExe.FileName;
            }
        }

        private void chkRelaitvePaths_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRelaitvePaths.Checked)
            {
                tbFMArchivePath.Text = AbsRel.AbsoluteToRelative(tbFMArchivePath.Text);
                tb7zGexe.Text = AbsRel.AbsoluteToRelative(tb7zGexe.Text);
            }
            else
            {
                tbFMArchivePath.Text = AbsRel.RelativeToAbsolute(tbFMArchivePath.Text);
                tb7zGexe.Text = AbsRel.RelativeToAbsolute(tb7zGexe.Text);
            }
        }
    }

    public struct SetupInfo
    {
        public string archiveDir;
        public int lang;
        public int dateFormat;
        public string sevenZipGExe;
        public string sevenZNoWinExe;
        public bool useNoWinExe;
        public string backupType;
        public int returnAfterPlaying;
        public bool dcDontAsk;
        public string webSearchSite;
        public string specialWords;
        public bool sortIgnoreArticles;
        public bool relativePaths;
    }
}