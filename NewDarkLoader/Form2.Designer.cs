namespace NewDarkLoader
{
    partial class Form2
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
            this.lblAbsolute = new System.Windows.Forms.Label();
            this.tbToRelative = new System.Windows.Forms.TextBox();
            this.tbToAbsolute = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCurrentDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbOtherPath = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAbsolute
            // 
            this.lblAbsolute.AutoSize = true;
            this.lblAbsolute.Location = new System.Drawing.Point(28, 25);
            this.lblAbsolute.Name = "lblAbsolute";
            this.lblAbsolute.Size = new System.Drawing.Size(16, 13);
            this.lblAbsolute.TabIndex = 0;
            this.lblAbsolute.Text = "...";
            // 
            // tbToRelative
            // 
            this.tbToRelative.Location = new System.Drawing.Point(31, 121);
            this.tbToRelative.Name = "tbToRelative";
            this.tbToRelative.Size = new System.Drawing.Size(261, 20);
            this.tbToRelative.TabIndex = 1;
            // 
            // tbToAbsolute
            // 
            this.tbToAbsolute.Location = new System.Drawing.Point(31, 175);
            this.tbToAbsolute.Name = "tbToAbsolute";
            this.tbToAbsolute.Size = new System.Drawing.Size(261, 20);
            this.tbToAbsolute.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Path of program: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Converted to relative path: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Converted back to absolute path: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Directory";
            // 
            // tbCurrentDir
            // 
            this.tbCurrentDir.Location = new System.Drawing.Point(212, 25);
            this.tbCurrentDir.Name = "tbCurrentDir";
            this.tbCurrentDir.Size = new System.Drawing.Size(261, 20);
            this.tbCurrentDir.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Other Folder Absolute Path";
            // 
            // tbOtherPath
            // 
            this.tbOtherPath.Location = new System.Drawing.Point(31, 75);
            this.tbOtherPath.Name = "tbOtherPath";
            this.tbOtherPath.Size = new System.Drawing.Size(261, 20);
            this.tbOtherPath.TabIndex = 8;
            this.tbOtherPath.Text = "C:\\games\\Thief2FMs";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(316, 72);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(134, 123);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 217);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbOtherPath);
            this.Controls.Add(this.tbCurrentDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbToAbsolute);
            this.Controls.Add(this.tbToRelative);
            this.Controls.Add(this.lblAbsolute);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAbsolute;
        private System.Windows.Forms.TextBox tbToRelative;
        private System.Windows.Forms.TextBox tbToAbsolute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCurrentDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbOtherPath;
        private System.Windows.Forms.Button btnUpdate;
    }
}