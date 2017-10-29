using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVorbis;
using NAudio.Vorbis;
using NAudio.Wave;
using System.IO;

namespace NewDarkLoader
{
    class ConvertOGG
    {
        public ConvertOGG()
        {
            DirectoryInfo dInfo = new DirectoryInfo(@"C:\Games\Thief2\FMs\DCE_v1\snd\ogg");
            FileInfo[] oggFiles = dInfo.GetFiles("*.ogg", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < oggFiles.Length; i++)
            {
                //to do - figure out how to do this.
                VorbisReader vR = new VorbisReader(oggFiles[i].FullName);                
                long samples = vR.TotalSamples;
                float[] f = new float[samples];
                vR.ReadSamples(f, 0, f.Length);

                byte[] sndByte = new byte[f.Length];
                for (int j = 0; j < f.Length; j++)
                {
                    float fl = f[j];
                    sndByte[j] = (byte)fl;
                }
                
                WaveFormat wFormat = new WaveFormat();
                string wName = oggFiles[i].FullName.Replace(oggFiles[i].Extension, ".wav");
                WaveFileWriter writer = new WaveFileWriter(wName, wFormat);

                writer.Write(sndByte, 0, sndByte.Length);
            }
        }
    }
}
