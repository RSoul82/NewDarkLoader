using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace NewDarkLoader
{
    class AddMissFlag
    {
        /// <summary>
        /// Scans an FMs installation dir (not the archive) and generates a missflag.str file if it's missing.
        /// </summary>
        /// <param name="tempPath">%temp%</param>
        /// <param name="fmArchiveFilePath">E.g. c:\...\ThiefFMs .</param>
        /// <param name="installedFMPath">E.g. c:\...\Thief2\FMs\name .</param>
        public static void addMissingMisflagFile(string tempPath, string installedFMPath)
        {
            List<int> missionNumbers = getMisFileNumbers(installedFMPath);
            if (missionNumbers.Count != 0)
            {
                generateMissFlagFile(tempPath, missionNumbers);
                addToDir(tempPath, installedFMPath);
            }
        }

        /// <summary>
        /// Adds a missflag.str file to the installed FMs folder. Assumes the original is in %temp%.
        /// </summary>
        /// <param name="fmDirPath"></param>
        private static void addToDir(string tempPath, string fmDirPath)
        {
            if (!Directory.Exists(fmDirPath + "\\strings"))
                Directory.CreateDirectory(fmDirPath + "\\strings");

            File.Copy(tempPath + "missflag.str", fmDirPath + "\\strings\\missflag.str", true);
            FullDelete.DeleteFile(tempPath + "missflag.str");
        }

        private static List<int> getMisFileNumbers(string fmRootPath)
        {
            string[] allFiles = Directory.GetFiles(fmRootPath); //only does the root
            List<int> missNumbers = new List<int>();

            foreach (string s in allFiles)
            {
                if (s.ToLower().EndsWith(".mis"))
                {
                    string testString = s.Replace(fmRootPath, "");
                    if (Regex.IsMatch(testString, "\\d+"))
                    {
                        Match m = Regex.Match(testString, "\\d+");
                        missNumbers.Add(Convert.ToInt32(m.Value));
                    }
                }
            }

            return missNumbers;
        }

        /// <summary>
        /// Generates a missflag.str file in %temp%
        /// </summary>
        private static void generateMissFlagFile(string tempPath, List<int> misFileNumbers)
        {
            int firstMis = misFileNumbers.Min();
            int lastMis = misFileNumbers.Max();

            string m = "miss_";
            string c = ": ";
            string q = "\"";
            string noBnoL = "no_briefing, no_loadout";
            string end = ", end";

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            StreamWriter sW = File.CreateText(tempPath + "missflag.str");

            //Add lines from miss1 to missN-1
            for (int i = 1; i < firstMis; i++)
            {
                sW.WriteLine(m + i + c + q + "skip" + q);
            }

            //Add line for no_briefing, no_loadout, end
            if (misFileNumbers.Count == 1)
            {
                sW.WriteLine(m + misFileNumbers[0] + c + q + noBnoL + end + q);
            }
            else
            {
                for (int i = firstMis; i < lastMis; i++)
                {
                    if (misFileNumbers.Contains(i))
                        //no_b, no_l
                        sW.WriteLine(m + i + c + q + noBnoL + q);
                    else
                        //skip
                        sW.WriteLine(m + i + c + q + "skip" + q);
                }
                //end
                sW.WriteLine(m + lastMis + c + q + noBnoL + end + q);
            }
            sW.Close();
        }
    }
}