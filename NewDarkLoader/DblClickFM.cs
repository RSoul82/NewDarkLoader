using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDarkLoader
{
    public partial class DblClickFM : Form
    {
        public DblClickFM(INIFile langIni, string boxTitle, string question, string always)
        {
            InitializeComponent();

            if (langIni != null)
            {
                string secSaveImport = "DLSaveImport";

                this.Text = boxTitle;
                label1.Text = question;
                chkAlwaysPlay.Text = always;
                btnYes.Text = langIni.IniReadValue(secSaveImport, "Yes");
                btnNo.Text = langIni.IniReadValue(secSaveImport, "No");
            }
        }

        public bool AlwaysPlayFM
        {
            get
            {
                if (chkAlwaysPlay.Checked)
                    return true;
                else
                    return false;
            }
        }
    }
}
