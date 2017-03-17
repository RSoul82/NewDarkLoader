using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDarkLoader
{
    static class LangList
    {
        public static List<string> getLanguageList()
        {
            List<string> langList = new List<string>();
            langList.Add("English");
            langList.Add("Francais");
            langList.Add("Deutsch");
            langList.Add("Italiano");
            langList.Add("Espanol");
            langList.Add("Norsk");
            langList.Add("Svenska");
            langList.Add("Russian");
            langList.Add("Suomi");
            langList.Add("Nederlands");
            langList.Add("Polski");

            return langList;
        }
    }
}
