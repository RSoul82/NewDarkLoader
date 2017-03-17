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
    public partial class AddExistingTag : Form
    {
        public AddExistingTag(string windowTitle, string okButtonText, string cancButtonText, 
            List<catItem> globalTags, List<string> globalCats)
        {
            InitializeComponent();
            this.Text = windowTitle;
            btnOK.Text = okButtonText;
            btnCancel.Text = cancButtonText;

            TreeNode[] allTags = FillTree.generateNodes(globalTags, globalCats);
            tvGlobalTags.Nodes.AddRange(allTags);
            tvGlobalTags.ExpandAll();
        }

        public string tagString
        {
            get
            {
                object nodeTag = tvGlobalTags.SelectedNode.Tag;
                if (nodeTag != null)
                {
                    catItem cI = (catItem)tvGlobalTags.SelectedNode.Tag;
                    return cI.ToString();
                }
                else
                    return null;
            }
        }
    }
}
