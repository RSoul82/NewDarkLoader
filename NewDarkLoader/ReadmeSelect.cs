using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewDarkLoader
{
    public partial class ReadmeSelect : Form
    {
        private string selFilename;

        public ReadmeSelect(List<string> readmeFiles)
        {
            InitializeComponent();

            foreach(string readme in readmeFiles)
            {
                lbReadmeList.Items.Add(readme);
            }
            lbReadmeList.SelectedIndex = 0;
        }

        public string SelectedReadme
        {
            get
            {
                return selFilename;
            }
        }

        private void lbReadmeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFilename = lbReadmeList.SelectedItem.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
