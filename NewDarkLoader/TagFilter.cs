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
    public partial class TagFilter : Form
    {
        public TagFilter(List<catItem> globalCIList, List<string> globalCatList, List<catItem> restoreInclude, List<catItem> restoreExclude,
            string windowTitle, string availTagsText, string incTagsText, string excTagsText, string incBtnText, string excBtnText,
            string remBtnText, string remAllBtnText, string okBtnText, string cancBtnText, string remAllMsg, string remAllMsgTitle, string miscTagCatName)
        {
            InitializeComponent();

            foreach (catItem cI in globalCIList)
            {
                globalCatItems.Add(cI);
            }

            foreach (string s in globalCatList)
            {
                globalCats.Add(s);
            }

            allTags.Nodes.AddRange(FillTree.generateNodes(globalCatItems, globalCats));
            allTags.ExpandAll();

            //restore existing tag filter and get unique cat list from restored filters
            foreach (catItem cI in restoreInclude)
            {
                includeList.Add(cI);
                if (!includeCats.Contains(cI.cat))
                    includeCats.Add(cI.cat);
            }
            foreach (catItem cI in restoreExclude)
            {
                excludeList.Add(cI);
                if (!excludeCats.Contains(cI.cat))
                    excludeCats.Add(cI.cat);
            }
            addToList(includeList, tvInclude, includeCats);
            addToList(excludeList, tvExclude, excludeCats);

            //Set interface text
            this.Text = windowTitle;
            lblAvailTags.Text = availTagsText;
            lblInc.Text = incTagsText;
            lblExc.Text = excTagsText;
            btnInclude.Text = incBtnText;
            btnExclude.Text = excBtnText;
            btnRemove.Text = remBtnText;
            btnRemoveAll.Text = remAllBtnText;
            btnOK.Text = okBtnText;
            btnCancel.Text = cancBtnText;
            removeAllMessage = remAllMsg;
            removeAllMsgTitle = remAllMsgTitle;
            miscTagCat = miscTagCatName;
        }

        private List<catItem> globalCatItems = new List<catItem>();
        private List<string> globalCats = new List<string>();
        private List<catItem> includeList = new List<catItem>();
        private List<catItem> excludeList = new List<catItem>();
        private List<string> includeCats = new List<string>();
        private List<string> excludeCats = new List<string>();
        private string currentTree = "";
        private string removeAllMessage = "";
        private string removeAllMsgTitle = "";
        private string miscTagCat = "";
        
        private void btnInclude_Click(object sender, EventArgs e)
        {
            addToList(includeList, tvInclude, includeCats);
        }

        private void btnExclude_Click(object sender, EventArgs e)
        {
            addToList(excludeList, tvExclude, excludeCats);
        }

        private void removeFromList()
        {
            TreeView tv;
            List<catItem> lst;
            List<string> cats;
            if (currentTree == "tvInclude")
            {
                tv = tvInclude;
                lst = includeList;
                cats = includeCats;
            }
            else
            {
                tv = tvExclude;
                lst = excludeList;
                cats = excludeCats;
            }

            TreeNode selNode = tv.SelectedNode;

            if (selNode != null)
            {
                //List<string> remainingCats = new List<string>();
                catItem cI = new catItem();
                if (selNode.Parent != null)
                {
                    cI.cat = selNode.Parent.Text;
                    cI.item = selNode.Text;
                }
                lst.Remove(cI);

                //Get a list of categories that remain after the catItem was removed
                cats.Clear();
                foreach (catItem rmCatItem in lst)
                {
                    if (!cats.Contains(rmCatItem.cat))
                        cats.Add(rmCatItem.cat);
                }
                addNodesToTree(tv, FillTree.generateNodes(lst, cats));
            }
        }

        /// <summary>
        /// Adds a tag from available tags to include or exclude lists.
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="tv"></param>
        /// <param name="catList"></param>
        private void addToList(List<catItem> lst, TreeView tv, List<string> catList)
        {
            TreeNode selNode = allTags.SelectedNode;
            catItem selCatItem = new catItem();
            if (selNode != null && selNode.Parent != null)
            {
                selCatItem.cat = selNode.Parent.Text;
                selCatItem.item = selNode.Text;
                if (!lst.Contains(selCatItem))
                {
                    lst.Add(selCatItem);
                    if (!catList.Contains(selCatItem.cat))
                        catList.Add(selCatItem.cat);
                }
            }
            addNodesToTree(tv, FillTree.generateNodes(lst, catList));
            allTags.SelectedNode = null;
        }

        private void addNodesToTree(TreeView tv, TreeNode[] nodes)
        {
            tv.Nodes.Clear();
            tv.Nodes.AddRange(nodes);
            tv.ExpandAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            removeFromList();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show(removeAllMessage, removeAllMsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dR == DialogResult.Yes)
            {
                tvInclude.Nodes.Clear();
                tvExclude.Nodes.Clear();
                includeCats.Clear();
                includeList.Clear();
                excludeCats.Clear();
                excludeList.Clear();
            }
        }

        private void tvInclude_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            currentTree = tv.Name;
        }

        private void tvExclude_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            currentTree = tv.Name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public List<catItem> IncludedTags
        {
            get
            {
                return includeList;
            }
        }

        public List<catItem> ExcludedTags
        {
            get
            {
                return excludeList;
            }
        }

        public string FilterString
        {
            get
            {
                return TagStr.TagListToFilterString(includeList, excludeList, miscTagCat);
            }
        }

        private void allTags_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonState(true);
            TreeView masterTV = (TreeView)sender;
            TreeNode tN = masterTV.SelectedNode;

            if (nodeAlreadyInList(tN, tvInclude) || nodeAlreadyInList(tN, tvExclude))
                buttonState(false);
            else
                buttonState(true);
        }

        private bool nodeAlreadyInList(TreeNode tN, TreeView viewToCheck)
        {
            bool found = false;
            foreach (TreeNode parent in viewToCheck.Nodes)
            {
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Text == tN.Text && child.Parent.Text == tN.Parent.Text)
                    {
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        private void buttonState(bool state)
        {
            btnInclude.Enabled = state;
            btnExclude.Enabled = state;
        }
    }
}
