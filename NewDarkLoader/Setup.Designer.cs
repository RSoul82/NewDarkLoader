namespace NewDarkLoader
{
    partial class Setup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbLang = new System.Windows.Forms.GroupBox();
            this.cBlang = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.brDir = new System.Windows.Forms.FolderBrowserDialog();
            this.gbDateFormat = new System.Windows.Forms.GroupBox();
            this.rdoMDY = new System.Windows.Forms.RadioButton();
            this.rdoDMY = new System.Windows.Forms.RadioButton();
            this.gbFMArchive = new System.Windows.Forms.GroupBox();
            this.btnBrArchivePath = new System.Windows.Forms.Button();
            this.tbFMArchivePath = new System.Windows.Forms.TextBox();
            this.gb7z = new System.Windows.Forms.GroupBox();
            this.chkUseNoWinExe = new System.Windows.Forms.CheckBox();
            this.lbl7zHelp = new System.Windows.Forms.Label();
            this.btnBr7zGexe = new System.Windows.Forms.Button();
            this.tb7zGexe = new System.Windows.Forms.TextBox();
            this.br7zGExe = new System.Windows.Forms.OpenFileDialog();
            this.gbSaveBackup = new System.Windows.Forms.GroupBox();
            this.rdoBkAlways = new System.Windows.Forms.RadioButton();
            this.rdoBkAsk = new System.Windows.Forms.RadioButton();
            this.gbReturn = new System.Windows.Forms.GroupBox();
            this.rdoRetAlways = new System.Windows.Forms.RadioButton();
            this.rdoRetAfterFM = new System.Windows.Forms.RadioButton();
            this.rdoRetNever = new System.Windows.Forms.RadioButton();
            this.gbDblClick = new System.Windows.Forms.GroupBox();
            this.chkDblClickDontAsk = new System.Windows.Forms.CheckBox();
            this.gbWebSearch = new System.Windows.Forms.GroupBox();
            this.chkSortIncludeArticles = new System.Windows.Forms.CheckBox();
            this.lblNoSite = new System.Windows.Forms.Label();
            this.lblSpecialWords = new System.Windows.Forms.Label();
            this.tbSpecialWords = new System.Windows.Forms.TextBox();
            this.tbWebSearch = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkRelaitvePaths = new System.Windows.Forms.CheckBox();
            this.gbLang.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbDateFormat.SuspendLayout();
            this.gbFMArchive.SuspendLayout();
            this.gb7z.SuspendLayout();
            this.gbSaveBackup.SuspendLayout();
            this.gbReturn.SuspendLayout();
            this.gbDblClick.SuspendLayout();
            this.gbWebSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLang
            // 
            this.gbLang.Controls.Add(this.cBlang);
            this.gbLang.Location = new System.Drawing.Point(9, 90);
            this.gbLang.Name = "gbLang";
            this.gbLang.Size = new System.Drawing.Size(357, 52);
            this.gbLang.TabIndex = 1;
            this.gbLang.TabStop = false;
            this.gbLang.Text = "Language";
            // 
            // cBlang
            // 
            this.cBlang.FormattingEnabled = true;
            this.cBlang.Location = new System.Drawing.Point(9, 19);
            this.cBlang.Name = "cBlang";
            this.cBlang.Size = new System.Drawing.Size(339, 21);
            this.cBlang.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 344);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 32);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(380, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 25);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.Location = new System.Drawing.Point(269, 3);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 25);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // brDir
            // 
            this.brDir.ShowNewFolderButton = false;
            // 
            // gbDateFormat
            // 
            this.gbDateFormat.Controls.Add(this.rdoMDY);
            this.gbDateFormat.Controls.Add(this.rdoDMY);
            this.gbDateFormat.Location = new System.Drawing.Point(8, 148);
            this.gbDateFormat.Name = "gbDateFormat";
            this.gbDateFormat.Size = new System.Drawing.Size(357, 70);
            this.gbDateFormat.TabIndex = 2;
            this.gbDateFormat.TabStop = false;
            this.gbDateFormat.Text = "Date Format";
            // 
            // rdoMDY
            // 
            this.rdoMDY.AutoSize = true;
            this.rdoMDY.Location = new System.Drawing.Point(122, 39);
            this.rdoMDY.Name = "rdoMDY";
            this.rdoMDY.Size = new System.Drawing.Size(106, 17);
            this.rdoMDY.TabIndex = 1;
            this.rdoMDY.TabStop = true;
            this.rdoMDY.Text = "Month/Day/Year";
            this.rdoMDY.UseVisualStyleBackColor = true;
            // 
            // rdoDMY
            // 
            this.rdoDMY.AutoSize = true;
            this.rdoDMY.Checked = true;
            this.rdoDMY.Location = new System.Drawing.Point(122, 16);
            this.rdoDMY.Name = "rdoDMY";
            this.rdoDMY.Size = new System.Drawing.Size(106, 17);
            this.rdoDMY.TabIndex = 0;
            this.rdoDMY.TabStop = true;
            this.rdoDMY.Text = "Day/Month/Year";
            this.rdoDMY.UseVisualStyleBackColor = true;
            // 
            // gbFMArchive
            // 
            this.gbFMArchive.Controls.Add(this.btnBrArchivePath);
            this.gbFMArchive.Controls.Add(this.tbFMArchivePath);
            this.gbFMArchive.Location = new System.Drawing.Point(9, 12);
            this.gbFMArchive.Name = "gbFMArchive";
            this.gbFMArchive.Size = new System.Drawing.Size(357, 52);
            this.gbFMArchive.TabIndex = 0;
            this.gbFMArchive.TabStop = false;
            this.gbFMArchive.Text = "FM Archive Folder (zip, 7z, rar...)";
            // 
            // btnBrArchivePath
            // 
            this.btnBrArchivePath.Location = new System.Drawing.Point(262, 18);
            this.btnBrArchivePath.Name = "btnBrArchivePath";
            this.btnBrArchivePath.Size = new System.Drawing.Size(86, 26);
            this.btnBrArchivePath.TabIndex = 1;
            this.btnBrArchivePath.Text = "Browse...";
            this.btnBrArchivePath.UseVisualStyleBackColor = true;
            this.btnBrArchivePath.Click += new System.EventHandler(this.btnBrowseArchivePath_Click);
            // 
            // tbFMArchivePath
            // 
            this.tbFMArchivePath.Location = new System.Drawing.Point(9, 22);
            this.tbFMArchivePath.Name = "tbFMArchivePath";
            this.tbFMArchivePath.Size = new System.Drawing.Size(247, 20);
            this.tbFMArchivePath.TabIndex = 0;
            // 
            // gb7z
            // 
            this.gb7z.Controls.Add(this.chkUseNoWinExe);
            this.gb7z.Controls.Add(this.lbl7zHelp);
            this.gb7z.Controls.Add(this.btnBr7zGexe);
            this.gb7z.Controls.Add(this.tb7zGexe);
            this.gb7z.Location = new System.Drawing.Point(372, 185);
            this.gb7z.Name = "gb7z";
            this.gb7z.Size = new System.Drawing.Size(357, 154);
            this.gb7z.TabIndex = 7;
            this.gb7z.TabStop = false;
            this.gb7z.Text = "Optional: Locate 7zG.exe";
            // 
            // chkUseNoWinExe
            // 
            this.chkUseNoWinExe.AutoSize = true;
            this.chkUseNoWinExe.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkUseNoWinExe.Location = new System.Drawing.Point(6, 118);
            this.chkUseNoWinExe.Name = "chkUseNoWinExe";
            this.chkUseNoWinExe.Size = new System.Drawing.Size(321, 30);
            this.chkUseNoWinExe.TabIndex = 14;
            this.chkUseNoWinExe.Text = "Use \"7z.exe\" for minor operations, e.g. accessing the readme. \r\nThis creates no w" +
    "indow.";
            this.chkUseNoWinExe.UseVisualStyleBackColor = true;
            // 
            // lbl7zHelp
            // 
            this.lbl7zHelp.Location = new System.Drawing.Point(6, 46);
            this.lbl7zHelp.Name = "lbl7zHelp";
            this.lbl7zHelp.Size = new System.Drawing.Size(339, 57);
            this.lbl7zHelp.TabIndex = 12;
            this.lbl7zHelp.Text = "If you have 7Zip installed, you can locate the \"7zG.exe\" file to imrpove FM insta" +
    "llation performance.\r\n7zG.exe shows a progress bar. Choose \"7z.exe\" if you want " +
    "things to be completely hidden.";
            // 
            // btnBr7zGexe
            // 
            this.btnBr7zGexe.Location = new System.Drawing.Point(263, 15);
            this.btnBr7zGexe.Name = "btnBr7zGexe";
            this.btnBr7zGexe.Size = new System.Drawing.Size(86, 26);
            this.btnBr7zGexe.TabIndex = 13;
            this.btnBr7zGexe.Text = "Browse...";
            this.btnBr7zGexe.UseVisualStyleBackColor = true;
            this.btnBr7zGexe.Click += new System.EventHandler(this.btbBr7zGexe_Click);
            // 
            // tb7zGexe
            // 
            this.tb7zGexe.Location = new System.Drawing.Point(6, 19);
            this.tb7zGexe.Name = "tb7zGexe";
            this.tb7zGexe.Size = new System.Drawing.Size(252, 20);
            this.tb7zGexe.TabIndex = 12;
            // 
            // br7zGExe
            // 
            this.br7zGExe.FileName = "7zG.exe";
            this.br7zGExe.Filter = "7zG.exe|*.exe";
            // 
            // gbSaveBackup
            // 
            this.gbSaveBackup.Controls.Add(this.rdoBkAlways);
            this.gbSaveBackup.Controls.Add(this.rdoBkAsk);
            this.gbSaveBackup.Location = new System.Drawing.Point(8, 222);
            this.gbSaveBackup.Name = "gbSaveBackup";
            this.gbSaveBackup.Size = new System.Drawing.Size(357, 69);
            this.gbSaveBackup.TabIndex = 3;
            this.gbSaveBackup.TabStop = false;
            this.gbSaveBackup.Text = "Backup Savegames and Screenshots when Uninstalling";
            // 
            // rdoBkAlways
            // 
            this.rdoBkAlways.AutoSize = true;
            this.rdoBkAlways.Location = new System.Drawing.Point(122, 41);
            this.rdoBkAlways.Name = "rdoBkAlways";
            this.rdoBkAlways.Size = new System.Drawing.Size(126, 17);
            this.rdoBkAlways.TabIndex = 1;
            this.rdoBkAlways.Text = "Always make backup";
            this.rdoBkAlways.UseVisualStyleBackColor = true;
            // 
            // rdoBkAsk
            // 
            this.rdoBkAsk.AutoSize = true;
            this.rdoBkAsk.Checked = true;
            this.rdoBkAsk.Location = new System.Drawing.Point(122, 19);
            this.rdoBkAsk.Name = "rdoBkAsk";
            this.rdoBkAsk.Size = new System.Drawing.Size(92, 17);
            this.rdoBkAsk.TabIndex = 0;
            this.rdoBkAsk.TabStop = true;
            this.rdoBkAsk.Text = "Ask each time";
            this.rdoBkAsk.UseVisualStyleBackColor = true;
            // 
            // gbReturn
            // 
            this.gbReturn.Controls.Add(this.rdoRetAlways);
            this.gbReturn.Controls.Add(this.rdoRetAfterFM);
            this.gbReturn.Controls.Add(this.rdoRetNever);
            this.gbReturn.Location = new System.Drawing.Point(372, 12);
            this.gbReturn.Name = "gbReturn";
            this.gbReturn.Size = new System.Drawing.Size(357, 81);
            this.gbReturn.TabIndex = 5;
            this.gbReturn.TabStop = false;
            this.gbReturn.Text = "Return to NewDarkLoader after Playing";
            // 
            // rdoRetAlways
            // 
            this.rdoRetAlways.AutoSize = true;
            this.rdoRetAlways.Location = new System.Drawing.Point(121, 60);
            this.rdoRetAlways.Name = "rdoRetAlways";
            this.rdoRetAlways.Size = new System.Drawing.Size(58, 17);
            this.rdoRetAlways.TabIndex = 10;
            this.rdoRetAlways.Text = "Always";
            this.rdoRetAlways.UseVisualStyleBackColor = true;
            // 
            // rdoRetAfterFM
            // 
            this.rdoRetAfterFM.AutoSize = true;
            this.rdoRetAfterFM.Location = new System.Drawing.Point(122, 39);
            this.rdoRetAfterFM.Name = "rdoRetAfterFM";
            this.rdoRetAfterFM.Size = new System.Drawing.Size(65, 17);
            this.rdoRetAfterFM.TabIndex = 9;
            this.rdoRetAfterFM.Text = "After FM";
            this.rdoRetAfterFM.UseVisualStyleBackColor = true;
            // 
            // rdoRetNever
            // 
            this.rdoRetNever.AutoSize = true;
            this.rdoRetNever.Checked = true;
            this.rdoRetNever.Location = new System.Drawing.Point(122, 19);
            this.rdoRetNever.Name = "rdoRetNever";
            this.rdoRetNever.Size = new System.Drawing.Size(57, 17);
            this.rdoRetNever.TabIndex = 8;
            this.rdoRetNever.TabStop = true;
            this.rdoRetNever.Text = "Never!";
            this.rdoRetNever.UseVisualStyleBackColor = true;
            // 
            // gbDblClick
            // 
            this.gbDblClick.Controls.Add(this.chkDblClickDontAsk);
            this.gbDblClick.Location = new System.Drawing.Point(8, 296);
            this.gbDblClick.Name = "gbDblClick";
            this.gbDblClick.Size = new System.Drawing.Size(358, 43);
            this.gbDblClick.TabIndex = 4;
            this.gbDblClick.TabStop = false;
            this.gbDblClick.Text = "Double-Click to Play FM";
            // 
            // chkDblClickDontAsk
            // 
            this.chkDblClickDontAsk.AutoSize = true;
            this.chkDblClickDontAsk.Location = new System.Drawing.Point(101, 19);
            this.chkDblClickDontAsk.Name = "chkDblClickDontAsk";
            this.chkDblClickDontAsk.Size = new System.Drawing.Size(146, 17);
            this.chkDblClickDontAsk.TabIndex = 0;
            this.chkDblClickDontAsk.Text = "Don\'t ask for confirmation";
            this.chkDblClickDontAsk.UseVisualStyleBackColor = true;
            // 
            // gbWebSearch
            // 
            this.gbWebSearch.Controls.Add(this.chkSortIncludeArticles);
            this.gbWebSearch.Controls.Add(this.lblNoSite);
            this.gbWebSearch.Controls.Add(this.lblSpecialWords);
            this.gbWebSearch.Controls.Add(this.tbSpecialWords);
            this.gbWebSearch.Controls.Add(this.tbWebSearch);
            this.gbWebSearch.Location = new System.Drawing.Point(372, 99);
            this.gbWebSearch.Name = "gbWebSearch";
            this.gbWebSearch.Size = new System.Drawing.Size(357, 82);
            this.gbWebSearch.TabIndex = 6;
            this.gbWebSearch.TabStop = false;
            this.gbWebSearch.Text = "Web Search Site";
            // 
            // chkSortIncludeArticles
            // 
            this.chkSortIncludeArticles.AutoSize = true;
            this.chkSortIncludeArticles.Location = new System.Drawing.Point(182, 57);
            this.chkSortIncludeArticles.Name = "chkSortIncludeArticles";
            this.chkSortIncludeArticles.Size = new System.Drawing.Size(173, 17);
            this.chkSortIncludeArticles.TabIndex = 15;
            this.chkSortIncludeArticles.Text = "Ignore when sorting the FM list.";
            this.chkSortIncludeArticles.UseVisualStyleBackColor = true;
            // 
            // lblNoSite
            // 
            this.lblNoSite.AutoSize = true;
            this.lblNoSite.Location = new System.Drawing.Point(6, 16);
            this.lblNoSite.Name = "lblNoSite";
            this.lblNoSite.Size = new System.Drawing.Size(146, 13);
            this.lblNoSite.TabIndex = 14;
            this.lblNoSite.Text = "Type in 0 (zero) to use no site";
            // 
            // lblSpecialWords
            // 
            this.lblSpecialWords.AutoSize = true;
            this.lblSpecialWords.Location = new System.Drawing.Point(181, 16);
            this.lblSpecialWords.Name = "lblSpecialWords";
            this.lblSpecialWords.Size = new System.Drawing.Size(148, 13);
            this.lblSpecialWords.TabIndex = 13;
            this.lblSpecialWords.Text = "Article list (type in 0 to disable)";
            // 
            // tbSpecialWords
            // 
            this.tbSpecialWords.Location = new System.Drawing.Point(182, 32);
            this.tbSpecialWords.Name = "tbSpecialWords";
            this.tbSpecialWords.Size = new System.Drawing.Size(165, 20);
            this.tbSpecialWords.TabIndex = 12;
            this.tbSpecialWords.Text = "the a an";
            this.toolTip1.SetToolTip(this.tbSpecialWords, "If searching on thiefmissions.com, words in this box will go at the end. E.g. Dry" +
        "mian Codex, The");
            // 
            // tbWebSearch
            // 
            this.tbWebSearch.Location = new System.Drawing.Point(9, 32);
            this.tbWebSearch.Name = "tbWebSearch";
            this.tbWebSearch.Size = new System.Drawing.Size(165, 20);
            this.tbWebSearch.TabIndex = 11;
            this.tbWebSearch.Text = "ttlg.com";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 9000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // chkRelaitvePaths
            // 
            this.chkRelaitvePaths.AutoSize = true;
            this.chkRelaitvePaths.Location = new System.Drawing.Point(18, 69);
            this.chkRelaitvePaths.Name = "chkRelaitvePaths";
            this.chkRelaitvePaths.Size = new System.Drawing.Size(101, 17);
            this.chkRelaitvePaths.TabIndex = 8;
            this.chkRelaitvePaths.Text = "Relative Paths?";
            this.chkRelaitvePaths.UseVisualStyleBackColor = true;
            this.chkRelaitvePaths.CheckedChanged += new System.EventHandler(this.chkRelaitvePaths_CheckedChanged);
            // 
            // Setup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(740, 381);
            this.Controls.Add(this.chkRelaitvePaths);
            this.Controls.Add(this.gbWebSearch);
            this.Controls.Add(this.gbDblClick);
            this.Controls.Add(this.gbReturn);
            this.Controls.Add(this.gbSaveBackup);
            this.Controls.Add(this.gb7z);
            this.Controls.Add(this.gbFMArchive);
            this.Controls.Add(this.gbDateFormat);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gbLang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup";
            this.gbLang.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbDateFormat.ResumeLayout(false);
            this.gbDateFormat.PerformLayout();
            this.gbFMArchive.ResumeLayout(false);
            this.gbFMArchive.PerformLayout();
            this.gb7z.ResumeLayout(false);
            this.gb7z.PerformLayout();
            this.gbSaveBackup.ResumeLayout(false);
            this.gbSaveBackup.PerformLayout();
            this.gbReturn.ResumeLayout(false);
            this.gbReturn.PerformLayout();
            this.gbDblClick.ResumeLayout(false);
            this.gbDblClick.PerformLayout();
            this.gbWebSearch.ResumeLayout(false);
            this.gbWebSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLang;
        private System.Windows.Forms.ComboBox cBlang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog brDir;
        private System.Windows.Forms.GroupBox gbDateFormat;
        private System.Windows.Forms.RadioButton rdoMDY;
        private System.Windows.Forms.RadioButton rdoDMY;
        private System.Windows.Forms.GroupBox gbFMArchive;
        private System.Windows.Forms.Button btnBrArchivePath;
        private System.Windows.Forms.TextBox tbFMArchivePath;
        private System.Windows.Forms.GroupBox gb7z;
        private System.Windows.Forms.Label lbl7zHelp;
        private System.Windows.Forms.Button btnBr7zGexe;
        private System.Windows.Forms.TextBox tb7zGexe;
        private System.Windows.Forms.OpenFileDialog br7zGExe;
        private System.Windows.Forms.GroupBox gbSaveBackup;
        private System.Windows.Forms.RadioButton rdoBkAlways;
        private System.Windows.Forms.RadioButton rdoBkAsk;
        private System.Windows.Forms.GroupBox gbReturn;
        private System.Windows.Forms.RadioButton rdoRetAlways;
        private System.Windows.Forms.RadioButton rdoRetAfterFM;
        private System.Windows.Forms.RadioButton rdoRetNever;
        private System.Windows.Forms.CheckBox chkUseNoWinExe;
        private System.Windows.Forms.GroupBox gbDblClick;
        private System.Windows.Forms.CheckBox chkDblClickDontAsk;
        private System.Windows.Forms.GroupBox gbWebSearch;
        private System.Windows.Forms.TextBox tbWebSearch;
        private System.Windows.Forms.TextBox tbSpecialWords;
        private System.Windows.Forms.Label lblSpecialWords;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblNoSite;
        private System.Windows.Forms.CheckBox chkSortIncludeArticles;
        private System.Windows.Forms.CheckBox chkRelaitvePaths;
    }
}