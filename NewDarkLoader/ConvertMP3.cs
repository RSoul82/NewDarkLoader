using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;

namespace NewDarkLoader
{
    public partial class ConvertMP3 : Form
    {
        public ConvertMP3(string fmInstallationPath)
        {
            InitializeComponent();
            installedFMFullPath = fmInstallationPath;
        }

        private string installedFMFullPath = "";

        private void convertToWavs()
        {
            DirectoryInfo dInfo = new DirectoryInfo(installedFMFullPath);
            FileInfo[] fmFiles = dInfo.GetFiles("*.mp3", SearchOption.AllDirectories);

            for (int i = 0; i < fmFiles.Length; i++ )
            {
                using (Mp3FileReader mp3 = new Mp3FileReader(fmFiles[i].FullName))
                {
                    using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                    {
                        string outputFile = fmFiles[i].FullName.Replace(fmFiles[i].Extension, ".wav");
                        WaveFileWriter.CreateWaveFile(outputFile, pcm);
                    }
                }
                FullDelete.DeleteFile(fmFiles[i].FullName);
                
                double progress = ((double)(i+1) / fmFiles.Length) * 100;
                double rounded = Math.Round(progress, 0);
                backgroundWorker.ReportProgress(Convert.ToInt32(rounded));
            }
        }

        private void ConvertMP3_Load(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            convertToWavs();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
