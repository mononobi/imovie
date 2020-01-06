using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace iMovie
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {   
                Thread.Sleep(1500);

                bool isNew = false; 
                Mutex mutex = new Mutex(true, Messages.MutexName, out isNew);

                if (isNew == true)
                {
                    try
                    {
                        int flag = 0;

                        if (File.Exists(PathUtils.GetApplicationFontsPath() + "Adorable.TTF") == true)
                        {
                            iMovieBase.AppFonts.AddFontFile(PathUtils.GetApplicationFontsPath() + "Adorable.TTF");
                            flag++;
                        }

                        if (File.Exists(PathUtils.GetApplicationFontsPath() + "AllCaps.ttf") == true)
                        {
                            iMovieBase.AppFonts.AddFontFile(PathUtils.GetApplicationFontsPath() + "AllCaps.ttf");
                            flag++;
                        }

                        if (File.Exists(PathUtils.GetApplicationFontsPath() + "COPRGTB.TTF") == true)
                        {
                            iMovieBase.AppFonts.AddFontFile(PathUtils.GetApplicationFontsPath() + "COPRGTB.TTF");
                            flag++;
                        }

                        if (flag < 3)
                        {
                            MessageBox.Show(Messages.CouldNotLoadSomeFonts + Environment.NewLine + Messages.MissedFontFile, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Messages.CouldNotLoadSomeFonts + Environment.NewLine + ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                }
                else
                {
                    Process process = null;
                    process = ProcessManager.GetDuplicateProcess(Process.GetCurrentProcess());

                    if (MessageBox.Show(Messages.ApplicationIsOpen.Replace(@"\n", Environment.NewLine), Messages.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (process != null)
                        {
                            process.Kill();

                            Thread.Sleep(500);
                        }

                        Application.Restart();
                    }
                    else
                    {
                        if (process != null)
                        {
                            WindowManager.ShowWindow(process.ProcessName, WindowState.Normal);
                        }

                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
} 
