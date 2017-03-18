using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NewDarkLoader
{
    public partial class Setup : Form
    {
        public Setup(INIFile iniFile, string optionsSecName, string archiveRootKeyName, string languageKeyName,
            string dateFormatKeyName, string backupTypeKeyName, string sevenZipGKeyName, string noWin7ZKeyName,
            string returnTypeKeyName, string dcDontAskKeyName,
            string setupTitle, string fmArchFolderBox, string folderWarning, string installedFMsPath, string browseButton, string langBox, string dateFormatBox,
            string dmyChk, string mdyChk, string saveBackupBox, string bkTypeAsk, string bkTypeAlways, string dbClFMBox,
            string dbClChk, string returnAfterBox, string retTypeNeverRdo, string afterFMRdo, string alwaysRdo,
            string opt7zBox, string help7z1, string help7z2, string use7zeChk1, string use7zeChk2, string okBtnText, string cancBtnText,
            string folderRequiredMsg, string fldrRequiredMsgTitle, string webSearchSiteBox, string noSiteLabel, string articleLabel, string articleTip, bool sortNoArticles, bool _firstRun)
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

            Text = setupTitle;
            gbFMArchive.Text = fmArchFolderBox;
            fmInstalledPath = installedFMsPath;
            archIsFMsWarning = folderWarning;
            btnBrArchivePath.Text = browseButton;
            gbLang.Text = langBox;
            gbDateFormat.Text = dateFormatBox;
            rdoDMY.Text = dmyChk;
            rdoMDY.Text = mdyChk;
            gbSaveBackup.Text = saveBackupBox;
            rdoBkAsk.Text = bkTypeAsk;
            rdoBkAlways.Text = bkTypeAlways;
            gbDblClick.Text = dbClFMBox;
            chkDblClickDontAsk.Text = dbClChk;
            gbReturn.Text = returnAfterBox;
            rdoRetNever.Text = retTypeNeverRdo;
            rdoRetAfterFM.Text = afterFMRdo;
            rdoRetAlways.Text = alwaysRdo;
            gb7z.Text = opt7zBox;
            btnBr7zGexe.Text = browseButton;
            StringBuilder help7zBld = new StringBuilder();
            help7zBld.AppendLine(help7z1);
            help7zBld.AppendLine(help7z2);
            lbl7zHelp.Text = help7zBld.ToString();

            StringBuilder use7zeBld = new StringBuilder();
            use7zeBld.AppendLine(use7zeChk1);
            use7zeBld.AppendLine(use7zeChk2);
            chkUseNoWinExe.Text = use7zeBld.ToString();
            btnOK.Text = okBtnText;
            btnCancel.Text = cancBtnText;

            folderRequired = folderRequiredMsg;
            fldrRequiredTitle = fldrRequiredMsgTitle;

            gbWebSearch.Text = webSearchSiteBox;
            lblNoSite.Text = noSiteLabel;
            lblSpecialWords.Text = articleLabel;
            toolTip1.SetToolTip(tbSpecialWords, articleTip);
            checkBox1.Checked = sortNoArticles;

            readFromINI();
        }

        SetupInfo sInfo = new SetupInfo();

        private INIFile i;
        private bool firstRun;
        private string fmInstalledPath = "";
        private string folderRequired = "";
        private string fldrRequiredTitle = "";
        private string archIsFMsWarning = "";

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
            //check that archive root has been set
            if (tbFMArchivePath.Text != "" && tbFMArchivePath.Text != fmInstalledPath)
            {
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
                sInfo.sortIgnoreArticles = checkBox1.Checked;

                sInfo.sevenZipGExe = tb7zGexe.Text;

                if (File.Exists(tb7zGexe.Text))
                {
                    FileInfo fInfo = new FileInfo(tb7zGexe.Text);
                    string parentDir = fInfo.DirectoryName;
                    sInfo.sevenZNoWinExe = parentDir + "\\7z.exe";

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
                else if (tbFMArchivePath.Text == fmInstalledPath)
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
    }
}