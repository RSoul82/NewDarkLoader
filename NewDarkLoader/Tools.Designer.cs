namespace NewDarkLoader
{
    partial class Tools
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
            this.btnImportSaves = new System.Windows.Forms.Button();
            this.btnImportINI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGamePath = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openDarkloaderINI = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportSaves
            // 
            this.btnImportSaves.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnImportSaves.Location = new System.Drawing.Point(35, 3);
            this.btnImportSaves.Name = "btnImportSaves";
            this.btnImportSaves.Size = new System.Drawing.Size(223, 26);
            this.btnImportSaves.TabIndex = 0;
            this.btnImportSaves.Text = "Import Darkloader Saves";
            this.btnImportSaves.UseVisualStyleBackColor = true;
            this.btnImportSaves.Click += new System.EventHandler(this.btnImportSaves_Click);
            // 
            // btnImportINI
            // 
            this.btnImportINI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnImportINI.Location = new System.Drawing.Point(11, 35);
            this.btnImportINI.Name = "btnImportINI";
            this.btnImportINI.Size = new System.Drawing.Size(271, 26);
            this.btnImportINI.TabIndex = 1;
            this.btnImportINI.Text = "Import FM data from Darkloader.ini...";
            this.btnImportINI.UseVisualStyleBackColor = true;
            this.btnImportINI.Click += new System.EventHandler(this.btnImportINI_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game Path:";
            // 
            // lblGamePath
            // 
            this.lblGamePath.AutoSize = true;
            this.lblGamePath.Location = new System.Drawing.Point(91, 5);
            this.lblGamePath.Name = "lblGamePath";
            this.lblGamePath.Size = new System.Drawing.Size(16, 13);
            this.lblGamePath.TabIndex = 3;
            this.lblGamePath.Text = "...";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(106, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 24);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnImportSaves, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImportINI, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 116);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 67);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(288, 14);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // openDarkloaderINI
            // 
            this.openDarkloaderINI.FileName = "darkloader.ini";
            this.openDarkloaderINI.Filter = "ini File|*.ini";
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(318, 149);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblGamePath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Old Darkloader Tools";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGamePath;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openDarkloaderINI;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnImportSaves;
        private System.Windows.Forms.Button btnImportINI;
    }
}