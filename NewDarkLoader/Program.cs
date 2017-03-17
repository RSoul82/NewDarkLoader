using System;
using System.Windows.Forms;
using System.Threading;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;

namespace NewDarkLoader
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //T2 path hardcoded for testing
            //Application.Run(new Form1("C:\\Games\\ThiefG\\ThiefG.exe", false, "Thief Gold"));
            //Application.Run(new Form1("C:\\Games\\Thief2\\shock2.exe", false, "Thief 2"));//, 0));
            Application.Run(new Form1("C:\\Games\\Thief2\\Dromed.exe", false, "Dromed"));
            //Application.Run(new Form1("C:\\Games\\ThiefG\\Dromed.exe", false, "Dromed"));
            //Application.Run(new Form1("C:\\Games\\Thief - Deadly Shadows\\System\\Thief3.exe", false, "Thief 3"));
            //Application.Run(new Form2()); //Used for testing things without cluttering the main form
        }

        private static sFMSelectorData FMSelData;
        private static eFMSelReturn FMSelReturnValue = new eFMSelReturn();

        [DllExport(CallingConvention = CallingConvention.Cdecl, ExportName = "SelectFM")]
        public static int SelectFM([MarshalAs(UnmanagedType.Struct)] ref sFMSelectorData data)
        {
            string gameVersion = data.sGameVersion;
            byte[] sName = new byte[256];
            byte[] sModExcludePaths = new byte[256];
            byte[] sRootPath = new byte[512];
            FMSelData = data;
            string fol = "";
            string nomod = "";
            string fmPath = "";
            int runAfter = 0; //default value
            Thread thd = new Thread(() =>
            {
                //Full path of exe that calls this.
                string exePath = Process.GetCurrentProcess().MainModule.FileName;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 nForm = new Form1(exePath, true, gameVersion);//, s.ElapsedMilliseconds);
                //Form2 nForm = new Form2();
                //MessageBox.Show("Ready to show window.");
                DialogResult dR = nForm.ShowDialog();
                runAfter = nForm.returnAfterPlaying;

                if (dR == DialogResult.OK) //Play FM
                {
                    fmPath = nForm.instFMPath;
                    sRootPath = ASCIIEncoding.ASCII.GetBytes(fmPath + "\0");

                    fol = nForm.selectedFMName;
                    sName = ASCIIEncoding.ASCII.GetBytes(fol + "\0");

                    nomod = nForm.disabledMods;
                    sModExcludePaths = ASCIIEncoding.ASCII.GetBytes(nomod + "\0");

                    if (runAfter > 0)
                    {
                        runAfter = 1;
                    }
                    FMSelReturnValue = eFMSelReturn.kSelFMRet_OK;
                }
                else if (dR == DialogResult.Cancel) //Play Original
                {
                    FMSelReturnValue = eFMSelReturn.kSelFMRet_Cancel;
                    if (runAfter == 1) //1 = Return after FM only, so set it to 0 if player selected original game
                        runAfter = 0;
                    else if (runAfter == 2)
                        runAfter = 1;
                }
                else if (dR == DialogResult.Abort) //Exit
                {
                    runAfter = 0;
                    FMSelReturnValue = eFMSelReturn.kSelFMRet_ExitGame;
                }
            });

            thd.SetApartmentState(ApartmentState.STA);
            thd.Start();
            thd.Join();

            Marshal.Copy(sRootPath, 0, FMSelData.sRootPath, sRootPath.Length);
            Marshal.Copy(sName, 0, FMSelData.sName, sName.Length);
            Marshal.Copy(sModExcludePaths, 0, FMSelData.sModExcludePaths, sModExcludePaths.Length);
            data.bRunAfterGame = runAfter;

            return (int)FMSelReturnValue;
        }

        public enum eFMSelReturn
        {
            kSelFMRet_OK = 0, // run selected FM 'data->sName' (0-len string to run without an FM)
            kSelFMRet_Cancel = -1, // cancel FM selection And start game As-Is (no FM Or If defined In cam_mod.ini use that)
            kSelFMRet_ExitGame = 1 // abort And quit game
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct sFMSelectorData
        {
            //sizeof(sFMSelectorData)
            public int nStructSize;

            //game version string as returned by AppName() (ie. in the form "Thief 2 Final 1.19")
            public string sGameVersion;

            //supplied initial FM root path (the FM Selector may change this)
            public IntPtr sRootPath;
            public int nMaxRootLen;

            //buffer to copy the selected FM name
            public IntPtr sName;
            public int nMaxNameLen;

            //set to non-zero when selector Is invoked after game exit (if requested during game start)
            public int bExitedGame;

            //FM selector should set this to non-zero if it wants to be invoked after game exits (only done for FMs)
            public int bRunAfterGame;

            //optional list of paths to exclude from mod_path/uber_mod_path in + separated format And Like the config
            //vars, Or if "*" all Mod paths are excluded (leave buffer empty for no excludes)
            //the specified exclude paths work as if they had a "*\" wildcard prefix
            public IntPtr sModExcludePaths;
            public int nMaxModExcludeLen;

            public IntPtr sLanguage;
            public int nLanguageLen;
            public int bForceLanguage;
        }
    }
}
