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
        public DblClickFM(string boxTitle, string question, string always, string yesButton, string noButton)
        {
            InitializeComponent();
            this.Text = boxTitle;
            label1.Text = question;
            chkAlwaysPlay.Text = always;
            btnYes.Text = yesButton;
            btnNo.Text = noButton;
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
