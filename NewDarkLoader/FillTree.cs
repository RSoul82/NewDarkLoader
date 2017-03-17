using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDarkLoader
{
    class FillTree
    {
        /// <summary>
        /// Takes a list of cat-items and returns a set of tree nodes.
        /// </summary>
        /// <param name="tagList"></param>
        /// <param name="categories">Unique list of categories, used to create root nodes.</param>
        /// <returns></returns>
        public static TreeNode[] generateNodes(List<catItem> tagList, List<string> categories)
        {
            List<TreeNode> rootNodeList = new List<TreeNode>();
            foreach (string cat in categories)
            {
                //find all child nodes for this category
                List<TreeNode> childNodeList = new List<TreeNode>();
                foreach (catItem cI in tagList)
                {
                    if (cI.cat == cat)
                    {
                        TreeNode node = new TreeNode(cI.item);
                        node.Tag = cI; //store the actual tag with the node
                        childNodeList.Add(node);
                    }
                }
                TreeNode[] childNodes = new TreeNode[childNodeList.Count];
                childNodeList.CopyTo(childNodes);

                //Add root node for this category
                TreeNode rootNode = new TreeNode(cat, childNodes);
                rootNodeList.Add(rootNode);
            }
            TreeNode[] rootNodes = new TreeNode[rootNodeList.Count];
            rootNodeList.CopyTo(rootNodes);

            return rootNodes;
        }
    }
}
