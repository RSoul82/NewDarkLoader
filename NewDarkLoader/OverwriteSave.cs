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
    public partial class OverwriteSave : Form
    {
        public OverwriteSave(string message, string title, string y, string yToAll, string n, string nToAll)
        {
            InitializeComponent();
            this.Text = title;
            label1.Text = message;
            btnYes.Text = y;
            btnYesToAll.Text = yToAll;
            btnNo.Text = n;
            btnNoToAll.Text = nToAll;
        }

        private saveOverwriteType ovType = new saveOverwriteType();

        public saveOverwriteType OverwriteType
        {
            get
            {
                return ovType;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ovType = saveOverwriteType.Yes;
        }

        private void btnYesToAll_Click(object sender, EventArgs e)
        {
            ovType = saveOverwriteType.YesToAll;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            ovType = saveOverwriteType.No;
        }

        private void btnNoToAll_Click(object sender, EventArgs e)
        {
            ovType = saveOverwriteType.NoToAll;
        }
    }
}
