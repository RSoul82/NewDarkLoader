using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewDarkLoader
{
    public partial class EditFM : Form
    {
        /// <summary>
        /// Initialized using strings read from the table.
        /// </summary>
        public EditFM(
            INIFile langIni, 
            string _fmTitle, int _rating, int _finished, string _comment, 
            string _disabledMods, string _hexRelDate, string _hexLastPlayed, 
            List<string> _textFiles, string currentReadme, bool _gameIsT3, 
            string _savegameFilePath, string _fmInstPath, string notPlayedText)
        {
            InitializeComponent();
            tbTitle.Text = _fmTitle;
            selectRating(_rating);
            setFinishedCheckboxes(_finished);
            setReleaseDate(_hexRelDate);
            setLastPlayed(_hexLastPlayed);
            tbComment.Text = _comment;
            tbDisabledMods.Text = _disabledMods;
            textFiles = _textFiles;
            savegameFilePath = _savegameFilePath;
            fmSavesPath = "";
            gameIsT3 = _gameIsT3;
            foreach (string file in textFiles)
            {
                cbReadme.Items.Add(file);
            }
            if (cbReadme.Items.Count > 0)
            {
                if (currentReadme != "")
                {
                    for (int i = 0; i < cbReadme.Items.Count; i++)
                    {
                        if (textFiles[i] == currentReadme)
                        {
                            cbReadme.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                    cbReadme.SelectedIndex = 0;
            }

            fmInstalledPath = _fmInstPath;

            string secCols = "Columns";
            //Set interface text from lang ini
            if (langIni != null)
            {
                Text = langIni.IniReadValue("EditFM", "EditDetailsTitle");
                lblReadme.Text = langIni.IniReadValue(secCols, "Readme");
                lblTitle.Text = langIni.IniReadValue(secCols, "Title");
                lblRating.Text = langIni.IniReadValue(secCols, "Rating");
                gbFinished.Text = langIni.IniReadValue(secCols, "Finished");

                if (gameIsT3)
                {
                    chkNormal.Text = langIni.IniReadValue(secCols, "T3Easy");
                    chkHard.Text = langIni.IniReadValue(secCols, "Normal");
                    chkExpert.Text = langIni.IniReadValue(secCols, "Hard");
                    chkExtreme.Text = langIni.IniReadValue(secCols, "Expert");
                    fmSavesPath = _fmInstPath + "\\savegames";
                }
                else
                {
                    chkNormal.Text = langIni.IniReadValue(secCols, "Normal");
                    chkHard.Text = langIni.IniReadValue(secCols, "Hard");
                    chkExpert.Text = langIni.IniReadValue(secCols, "Expert");
                    chkExtreme.Text = langIni.IniReadValue(secCols, "Expert");
                    fmSavesPath = _fmInstPath + "\\saves";
                }

                lblRelDate.Text = langIni.IniReadValue(secCols, "ReleaseDate");
                lblLastPlayed.Text = langIni.IniReadValue(secCols, "LastPlayed");
                chkNotPlayed.Text = notPlayedText;
                btnGetLastSaveDate.Text = langIni.IniReadValue(secCols, "GetFromSaves");
                lblComment.Text = langIni.IniReadValue(secCols, "Comment");
                lblDisMods.Text = langIni.IniReadValue(secCols, "DisabledMods");
                btnOK.Text = langIni.IniReadValue("TagFilterWindow", "OK");
                btnCancel.Text = langIni.IniReadValue("TagFilterWindow", "Cancel");
            }
            checkForSaves();
        }

        private List<string> textFiles = new List<string>();
        private string savegameFilePath = "";
        private string fmInstalledPath = "";
        private string fmSavesPath = "";
        private bool gameIsT3 = false;

        /// <summary>
        /// Enables or disables 'get last played from saves' button if there are any savegames.
        /// </summary>
        private void checkForSaves()
        {
            if (DateFromSavegames.FMHasSaves(fmInstalledPath, savegameFilePath, gameIsT3))
            {
                btnGetLastSaveDate.Enabled = true;
            }
        }
 
        private void selectRating(int rating)
        {
            cbRating.SelectedIndex = rating + 1;
        }

        private void setFinishedCheckboxes(int finValue)
        {
            clearCheckBoxes(); //reset them all

            if (finValue == 1)
                chkNormal.Checked = true;
            else if (finValue == 2)
                chkHard.Checked = true;
            else if (finValue == 3)
            {
                chkNormal.Checked = true;
                chkHard.Checked = true;
            }
            else if (finValue == 4)
            {
                chkExpert.Checked = true;
            }
            else if (finValue == 5)
            {
                chkNormal.Checked = true;
                chkExpert.Checked = true;
            }
            else if (finValue == 6)
            {
                chkHard.Checked = true;
                chkExpert.Checked = true;
            }
            else if (finValue == 7)
            {
                chkNormal.Checked = true;
                chkHard.Checked = true;
                chkExpert.Checked = true;
            }
            else if (finValue == 8)
            {
                chkExtreme.Checked = true;
            }
            else if (finValue == 9)
            {
                chkNormal.Checked = true;
                chkExtreme.Checked = true;
            }
            else if (finValue == 10)
            {
                chkHard.Checked = true;
                chkExtreme.Checked = true;
            }
            else if (finValue == 11)
            {
                chkNormal.Checked = true;
                chkHard.Checked = true;
                chkExtreme.Checked = true;
            }
            else if (finValue == 12)
            {
                chkExpert.Checked = true;
                chkExtreme.Checked = true;
            }
            else if (finValue == 13)
            {
                chkNormal.Checked = true;
                chkExpert.Checked = true;
                chkExtreme.Checked = true;
            }
            else if (finValue == 14)
            {
                chkHard.Checked = true;
                chkExpert.Checked = true;
                chkExtreme.Checked = true;
            }
            else if (finValue == 15)
            {
                chkNormal.Checked = true;
                chkHard.Checked = true;
                chkExpert.Checked = true;
                chkExtreme.Checked = true;
            }
        }

        private void clearCheckBoxes()
        {
            chkNormal.Checked = false;
            chkHard.Checked = false;
            chkExpert.Checked = false;
            chkExtreme.Checked = false;
        }

        private DateTime stringToDateTime(string dateHexString)
        {
            DateTime convertedDate = DateIntConverter.dateFromHexString(dateHexString);
            return convertedDate;
        }

        private void setReleaseDate(string relDateString)
        {
            if (relDateString != "")
            {
                dtReleaseDate.Value = stringToDateTime(relDateString);
            }
        }

        private void setLastPlayed(string lastPlayedString)
        {
            if (lastPlayedString != "")
            {
                dtLastPlayed.Value = stringToDateTime(lastPlayedString);
                chkNotPlayed.Checked = false;
            }
            else
            {
                dtLastPlayed.Value = DateTime.Today;
                chkNotPlayed.Checked = true;
            }
        }

        private void chkNotPlayed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotPlayed.Checked)
            {
                lblLastPlayed.Enabled = false;
                dtLastPlayed.Enabled = false;
            }
            else
            {
                lblLastPlayed.Enabled = true;
                dtLastPlayed.Enabled = true;
            }
        }

        public FMData EditedData
        {
            get
            {
                FMData data = new FMData();
                data.title = tbTitle.Text;
                data.rating = cbRating.SelectedIndex - 1;
                data.finished = getFinishedValue();
                data.comment = tbComment.Text;
                data.disabledMods = tbDisabledMods.Text;
                data.hexRelDate = DateIntConverter.dateToHexString(dtReleaseDate.Value);
                if (!chkNotPlayed.Checked) 
                    data.hexLastPlayed = DateIntConverter.dateToHexString(dtLastPlayed.Value);
                else 
                    data.hexLastPlayed = "";
                if (cbReadme.Items.Count > 0)
                    data.fmReadme = textFiles[cbReadme.SelectedIndex];
                else
                    data.fmReadme = "";

                return data;
            }
        }

        private string getRatingString()
        {
            string ratString = cbRating.Items[cbRating.SelectedIndex].ToString();

            if (ratString == "None") return "";
            else return ratString;
        }

        private int getFinishedValue()
        {
            int finishedValue = 0;
            if (chkNormal.Checked) finishedValue += 1;
            if (chkHard.Checked) finishedValue += 2;
            if (chkExpert.Checked) finishedValue += 4;
            if (chkExtreme.Checked) finishedValue += 8;
            return finishedValue;
        }

        private void btnGetLastSaveDate_Click(object sender, EventArgs e)
        {
            chkNotPlayed.Checked = false;
            dtLastPlayed.Value = DateFromSavegames.MostRecentSavegame(fmInstalledPath, savegameFilePath, gameIsT3);
        }   
    }
    public struct FMData
    {
        public string title, comment, disabledMods, hexRelDate, hexLastPlayed, fmReadme;
        public int rating, finished;
    }
}
