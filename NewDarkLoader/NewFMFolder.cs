using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace NewDarkLoader
{
    public partial class NewFMFolder : Form
    {
        private string FMsPath;
        private string safeFMName;
        /// <summary>
        /// New window allowing a new FM folder to be created.
        /// </summary>
        /// <param name="langIni">'language.ini' data object.</param>
        /// <param name="installedFMsPath">Full path to "FMs" folder. Does not end with \\</param>
        public NewFMFolder(INIFile langIni, string installedFMsPath)
        {
            InitializeComponent();
            if(langIni != null)
            {
                string newTitle = langIni.IniReadValue("FMTable", "NewFMButton");
                if (newTitle != "")
                    Text = newTitle;
                string newLalel = langIni.IniReadValue("FMTable", "NewFMName");
                if (newLalel != "")
                    label1.Text = newLalel;

                FMsPath = installedFMsPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            safeFMName = ArchiveExtract.ArchiveExtracedFolderName(tbNewFolder.Text);
            string newFMFolder = FMsPath + "\\" + safeFMName;
            if (!Directory.Exists(newFMFolder))
            {
                Directory.CreateDirectory(newFMFolder);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(tbNewFolder.Text + " already exists.");
            }
        }

        public string NewFMName
        {
            get
            {
                return safeFMName;
            }
        }
    }
}
