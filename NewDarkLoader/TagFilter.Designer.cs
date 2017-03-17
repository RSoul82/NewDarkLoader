namespace NewDarkLoader
{
    partial class TagFilter
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
            this.allTags = new System.Windows.Forms.TreeView();
            this.lblAvailTags = new System.Windows.Forms.Label();
            this.btnInclude = new System.Windows.Forms.Button();
            this.btnExclude = new System.Windows.Forms.Button();
            this.tvInclude = new System.Windows.Forms.TreeView();
            this.lblInc = new System.Windows.Forms.Label();
            this.lblExc = new System.Windows.Forms.Label();
            this.tvExclude = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // allTags
            // 
            this.allTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.allTags.Location = new System.Drawing.Point(12, 25);
            this.allTags.Name = "allTags";
            this.allTags.Size = new System.Drawing.Size(240, 469);
            this.allTags.TabIndex = 0;
            this.allTags.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.allTags_AfterSelect);
            // 
            // lblAvailTags
            // 
            this.lblAvailTags.AutoSize = true;
            this.lblAvailTags.Location = new System.Drawing.Point(12, 9);
            this.lblAvailTags.Name = "lblAvailTags";
            this.lblAvailTags.Size = new System.Drawing.Size(80, 13);
            this.lblAvailTags.TabIndex = 0;
            this.lblAvailTags.Text = "Available Tags:";
            // 
            // btnInclude
            // 
            this.btnInclude.Location = new System.Drawing.Point(258, 25);
            this.btnInclude.Name = "btnInclude";
            this.btnInclude.Size = new System.Drawing.Size(97, 23);
            this.btnInclude.TabIndex = 1;
            this.btnInclude.Text = "Include";
            this.btnInclude.UseVisualStyleBackColor = true;
            this.btnInclude.Click += new System.EventHandler(this.btnInclude_Click);
            // 
            // btnExclude
            // 
            this.btnExclude.Location = new System.Drawing.Point(258, 54);
            this.btnExclude.Name = "btnExclude";
            this.btnExclude.Size = new System.Drawing.Size(97, 23);
            this.btnExclude.TabIndex = 2;
            this.btnExclude.Text = "Exlcude";
            this.btnExclude.UseVisualStyleBackColor = true;
            this.btnExclude.Click += new System.EventHandler(this.btnExclude_Click);
            // 
            // tvInclude
            // 
            this.tvInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvInclude.Location = new System.Drawing.Point(361, 25);
            this.tvInclude.Name = "tvInclude";
            this.tvInclude.Size = new System.Drawing.Size(191, 469);
            this.tvInclude.TabIndex = 3;
            this.tvInclude.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvInclude_AfterSelect);
            // 
            // lblInc
            // 
            this.lblInc.AutoSize = true;
            this.lblInc.Location = new System.Drawing.Point(358, 9);
            this.lblInc.Name = "lblInc";
            this.lblInc.Size = new System.Drawing.Size(70, 13);
            this.lblInc.TabIndex = 3;
            this.lblInc.Text = "Include (OR):";
            // 
            // lblExc
            // 
            this.lblExc.AutoSize = true;
            this.lblExc.Location = new System.Drawing.Point(658, 9);
            this.lblExc.Name = "lblExc";
            this.lblExc.Size = new System.Drawing.Size(80, 13);
            this.lblExc.TabIndex = 5;
            this.lblExc.Text = "Exclude (NOT):";
            // 
            // tvExclude
            // 
            this.tvExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvExclude.Location = new System.Drawing.Point(661, 25);
            this.tvExclude.Name = "tvExclude";
            this.tvExclude.Size = new System.Drawing.Size(191, 469);
            this.tvExclude.TabIndex = 5;
            this.tvExclude.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvExclude_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 500);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 35);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(440, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.Location = new System.Drawing.Point(325, 6);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(558, 25);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(558, 54);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(97, 23);
            this.btnRemoveAll.TabIndex = 7;
            this.btnRemoveAll.Text = "Remove All...";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // TagFilter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(868, 538);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblExc);
            this.Controls.Add(this.tvExclude);
            this.Controls.Add(this.lblInc);
            this.Controls.Add(this.tvInclude);
            this.Controls.Add(this.btnExclude);
            this.Controls.Add(this.btnInclude);
            this.Controls.Add(this.lblAvailTags);
            this.Controls.Add(this.allTags);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(879, 45);
            this.Name = "TagFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tag Filter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAvailTags;
        public System.Windows.Forms.TreeView allTags;
        private System.Windows.Forms.Button btnInclude;
        private System.Windows.Forms.Button btnExclude;
        public System.Windows.Forms.TreeView tvInclude;
        private System.Windows.Forms.Label lblInc;
        private System.Windows.Forms.Label lblExc;
        public System.Windows.Forms.TreeView tvExclude;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRemoveAll;
    }
}