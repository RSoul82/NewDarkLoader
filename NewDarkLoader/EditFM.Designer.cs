namespace NewDarkLoader
{
    partial class EditFM
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
            this.tbDisabledMods = new System.Windows.Forms.TextBox();
            this.lblDisMods = new System.Windows.Forms.Label();
            this.chkNotPlayed = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.dtLastPlayed = new System.Windows.Forms.DateTimePicker();
            this.lblLastPlayed = new System.Windows.Forms.Label();
            this.dtReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblRelDate = new System.Windows.Forms.Label();
            this.gbFinished = new System.Windows.Forms.GroupBox();
            this.chkExtreme = new System.Windows.Forms.CheckBox();
            this.chkExpert = new System.Windows.Forms.CheckBox();
            this.chkHard = new System.Windows.Forms.CheckBox();
            this.chkNormal = new System.Windows.Forms.CheckBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGame = new System.Windows.Forms.ComboBox();
            this.lblReadme = new System.Windows.Forms.Label();
            this.cbReadme = new System.Windows.Forms.ComboBox();
            this.cbRating = new System.Windows.Forms.ComboBox();
            this.btnGetLastSaveDate = new System.Windows.Forms.Button();
            this.gbFinished.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDisabledMods
            // 
            this.tbDisabledMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisabledMods.Location = new System.Drawing.Point(99, 311);
            this.tbDisabledMods.Name = "tbDisabledMods";
            this.tbDisabledMods.Size = new System.Drawing.Size(360, 20);
            this.tbDisabledMods.TabIndex = 8;
            // 
            // lblDisMods
            // 
            this.lblDisMods.AutoSize = true;
            this.lblDisMods.Location = new System.Drawing.Point(13, 314);
            this.lblDisMods.Name = "lblDisMods";
            this.lblDisMods.Size = new System.Drawing.Size(77, 13);
            this.lblDisMods.TabIndex = 14;
            this.lblDisMods.Text = "Disabled Mods";
            this.lblDisMods.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNotPlayed
            // 
            this.chkNotPlayed.AutoSize = true;
            this.chkNotPlayed.Checked = true;
            this.chkNotPlayed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotPlayed.Location = new System.Drawing.Point(240, 256);
            this.chkNotPlayed.Name = "chkNotPlayed";
            this.chkNotPlayed.Size = new System.Drawing.Size(80, 17);
            this.chkNotPlayed.TabIndex = 6;
            this.chkNotPlayed.Text = "Not played.";
            this.chkNotPlayed.UseVisualStyleBackColor = true;
            this.chkNotPlayed.CheckedChanged += new System.EventHandler(this.chkNotPlayed_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(399, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(99, 337);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(61, 30);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(39, 288);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 12;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(100, 284);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(359, 20);
            this.tbComment.TabIndex = 7;
            // 
            // dtLastPlayed
            // 
            this.dtLastPlayed.Enabled = false;
            this.dtLastPlayed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtLastPlayed.Location = new System.Drawing.Point(100, 255);
            this.dtLastPlayed.Name = "dtLastPlayed";
            this.dtLastPlayed.Size = new System.Drawing.Size(131, 20);
            this.dtLastPlayed.TabIndex = 5;
            // 
            // lblLastPlayed
            // 
            this.lblLastPlayed.AutoSize = true;
            this.lblLastPlayed.Enabled = false;
            this.lblLastPlayed.Location = new System.Drawing.Point(28, 259);
            this.lblLastPlayed.Name = "lblLastPlayed";
            this.lblLastPlayed.Size = new System.Drawing.Size(62, 13);
            this.lblLastPlayed.TabIndex = 9;
            this.lblLastPlayed.Text = "Last Played";
            this.lblLastPlayed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtReleaseDate
            // 
            this.dtReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReleaseDate.Location = new System.Drawing.Point(100, 223);
            this.dtReleaseDate.Name = "dtReleaseDate";
            this.dtReleaseDate.Size = new System.Drawing.Size(131, 20);
            this.dtReleaseDate.TabIndex = 4;
            // 
            // lblRelDate
            // 
            this.lblRelDate.AutoSize = true;
            this.lblRelDate.Location = new System.Drawing.Point(18, 227);
            this.lblRelDate.Name = "lblRelDate";
            this.lblRelDate.Size = new System.Drawing.Size(72, 13);
            this.lblRelDate.TabIndex = 7;
            this.lblRelDate.Text = "Release Date";
            this.lblRelDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbFinished
            // 
            this.gbFinished.Controls.Add(this.chkExtreme);
            this.gbFinished.Controls.Add(this.chkExpert);
            this.gbFinished.Controls.Add(this.chkHard);
            this.gbFinished.Controls.Add(this.chkNormal);
            this.gbFinished.Location = new System.Drawing.Point(101, 101);
            this.gbFinished.Name = "gbFinished";
            this.gbFinished.Size = new System.Drawing.Size(93, 116);
            this.gbFinished.TabIndex = 3;
            this.gbFinished.TabStop = false;
            this.gbFinished.Text = "Finished";
            // 
            // chkExtreme
            // 
            this.chkExtreme.AutoSize = true;
            this.chkExtreme.Location = new System.Drawing.Point(6, 88);
            this.chkExtreme.Name = "chkExtreme";
            this.chkExtreme.Size = new System.Drawing.Size(64, 17);
            this.chkExtreme.TabIndex = 3;
            this.chkExtreme.Text = "Extreme";
            this.chkExtreme.UseVisualStyleBackColor = true;
            // 
            // chkExpert
            // 
            this.chkExpert.AutoSize = true;
            this.chkExpert.Location = new System.Drawing.Point(6, 65);
            this.chkExpert.Name = "chkExpert";
            this.chkExpert.Size = new System.Drawing.Size(56, 17);
            this.chkExpert.TabIndex = 2;
            this.chkExpert.Text = "Expert";
            this.chkExpert.UseVisualStyleBackColor = true;
            // 
            // chkHard
            // 
            this.chkHard.AutoSize = true;
            this.chkHard.Location = new System.Drawing.Point(6, 42);
            this.chkHard.Name = "chkHard";
            this.chkHard.Size = new System.Drawing.Size(49, 17);
            this.chkHard.TabIndex = 1;
            this.chkHard.Text = "Hard";
            this.chkHard.UseVisualStyleBackColor = true;
            // 
            // chkNormal
            // 
            this.chkNormal.AutoSize = true;
            this.chkNormal.Location = new System.Drawing.Point(6, 19);
            this.chkNormal.Name = "chkNormal";
            this.chkNormal.Size = new System.Drawing.Size(59, 17);
            this.chkNormal.TabIndex = 0;
            this.chkNormal.Text = "Normal";
            this.chkNormal.UseVisualStyleBackColor = true;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(52, 72);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(38, 13);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Rating";
            this.lblRating.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Location = new System.Drawing.Point(101, 42);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(359, 20);
            this.tbTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(63, 46);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game";
            this.label1.Visible = false;
            // 
            // cbGame
            // 
            this.cbGame.FormattingEnabled = true;
            this.cbGame.Items.AddRange(new object[] {
            "Unknown",
            "Thief 1",
            "Thief 2",
            "System Shock 2"});
            this.cbGame.Location = new System.Drawing.Point(289, 101);
            this.cbGame.Name = "cbGame";
            this.cbGame.Size = new System.Drawing.Size(152, 21);
            this.cbGame.TabIndex = 0;
            this.cbGame.Visible = false;
            // 
            // lblReadme
            // 
            this.lblReadme.AutoSize = true;
            this.lblReadme.Location = new System.Drawing.Point(43, 19);
            this.lblReadme.Name = "lblReadme";
            this.lblReadme.Size = new System.Drawing.Size(47, 13);
            this.lblReadme.TabIndex = 16;
            this.lblReadme.Text = "Readme";
            this.lblReadme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbReadme
            // 
            this.cbReadme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReadme.FormattingEnabled = true;
            this.cbReadme.Location = new System.Drawing.Point(100, 16);
            this.cbReadme.Name = "cbReadme";
            this.cbReadme.Size = new System.Drawing.Size(360, 21);
            this.cbReadme.TabIndex = 0;
            // 
            // cbRating
            // 
            this.cbRating.FormattingEnabled = true;
            this.cbRating.Items.AddRange(new object[] {
            "None",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbRating.Location = new System.Drawing.Point(100, 69);
            this.cbRating.Name = "cbRating";
            this.cbRating.Size = new System.Drawing.Size(64, 21);
            this.cbRating.TabIndex = 2;
            // 
            // btnGetLastSaveDate
            // 
            this.btnGetLastSaveDate.Enabled = false;
            this.btnGetLastSaveDate.Location = new System.Drawing.Point(323, 253);
            this.btnGetLastSaveDate.Name = "btnGetLastSaveDate";
            this.btnGetLastSaveDate.Size = new System.Drawing.Size(133, 23);
            this.btnGetLastSaveDate.TabIndex = 17;
            this.btnGetLastSaveDate.Text = "Get from savegames";
            this.btnGetLastSaveDate.UseVisualStyleBackColor = true;
            this.btnGetLastSaveDate.Click += new System.EventHandler(this.btnGetLastSaveDate_Click);
            // 
            // EditFM
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(475, 379);
            this.Controls.Add(this.btnGetLastSaveDate);
            this.Controls.Add(this.cbRating);
            this.Controls.Add(this.cbReadme);
            this.Controls.Add(this.lblReadme);
            this.Controls.Add(this.tbDisabledMods);
            this.Controls.Add(this.lblDisMods);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.chkNotPlayed);
            this.Controls.Add(this.cbGame);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.dtLastPlayed);
            this.Controls.Add(this.gbFinished);
            this.Controls.Add(this.lblLastPlayed);
            this.Controls.Add(this.lblRelDate);
            this.Controls.Add(this.dtReleaseDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditFM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit FM Details";
            this.gbFinished.ResumeLayout(false);
            this.gbFinished.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDisabledMods;
        private System.Windows.Forms.Label lblDisMods;
        private System.Windows.Forms.CheckBox chkNotPlayed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.DateTimePicker dtLastPlayed;
        private System.Windows.Forms.Label lblLastPlayed;
        private System.Windows.Forms.DateTimePicker dtReleaseDate;
        private System.Windows.Forms.Label lblRelDate;
        private System.Windows.Forms.GroupBox gbFinished;
        private System.Windows.Forms.CheckBox chkExtreme;
        private System.Windows.Forms.CheckBox chkExpert;
        private System.Windows.Forms.CheckBox chkHard;
        private System.Windows.Forms.CheckBox chkNormal;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGame;
        private System.Windows.Forms.Label lblReadme;
        private System.Windows.Forms.ComboBox cbReadme;
        private System.Windows.Forms.ComboBox cbRating;
        private System.Windows.Forms.Button btnGetLastSaveDate;
    }
}