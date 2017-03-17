using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NewDarkLoader
{
    class ValidFileName
    {
        public static bool CheckValid(string filename)
        {
            string fnamePattern = "\\w+\\.\\w+";

            if (Regex.IsMatch(filename, fnamePattern))
                return true;
            else
                return false;
        }
    }
}
