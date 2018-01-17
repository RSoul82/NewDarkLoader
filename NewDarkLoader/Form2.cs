using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SevenZip;
using System.Runtime.InteropServices;

namespace NewDarkLoader
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            updateFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateFields();
        }

        private void updateFields()
        {
            lblAbsolute.Text = Path.Combine(Environment.CurrentDirectory, "NewDarkLoader.dll");

            tbCurrentDir.Text = Environment.CurrentDirectory;
            tbToRelative.Text = AbsRel.AbsoluteToRelative(tbOtherPath.Text);
            tbToAbsolute.Text = AbsRel.RelativeToAbsolute(tbToRelative.Text);
        }
    }
}