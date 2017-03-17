using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDarkLoader
{
    class TagStr
    {
        /// <summary>
        /// Takes two tag struct lists (include and exclude) and generates a string to show in the UI
        /// </summary>
        public static string TagListToFilterString(List<catItem> includeList, List<catItem> excludeList, string miscTagCat)
        {
            StringBuilder sBld = new StringBuilder();
            foreach (catItem cI in includeList)
            {
                sBld.Append("+");
                if (cI.cat != miscTagCat)
                    sBld.Append(cI.cat + ":" + cI.item);
                else
                    sBld.Append(cI.item);
                sBld.Append(", ");
            }

            foreach (catItem cI in excludeList)
            {
                sBld.Append("-");
                if (cI.cat != miscTagCat)
                    sBld.Append(cI.cat + ":" + cI.item);
                else
                    sBld.Append(cI.item);
                sBld.Append(", ");
            }

            string fString = sBld.ToString().Trim().Trim(',');

            return fString;
        }
    }
}
