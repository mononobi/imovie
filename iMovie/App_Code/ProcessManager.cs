using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace iMovie
{
    public class ProcessManager
    { 
        /// <summary>
        /// Returns the count of running instances of specified process
        /// </summary>
        /// <param name="processName">
        /// Process name without extension</param>
        /// <returns>
        /// Count of running instances of one process</returns>
        public static int ProcessCount(string processName = "") 
        {
            try
            {
                int count = 0;

                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Equals(processName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        count++;
                    }
                }

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Kills the specified process
        /// </summary>
        /// <param name="processName">
        /// Process name without extension</param>
        public static void KillProcess(string processName = "")
        {
            try
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Equals(processName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        clsProcess.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Runs the application with specified path if its not running, otherwise shows its main window if its running
        /// </summary>
        /// <param name="path">
        /// Full path of application</param>
        public static void RunApplication(string path)
        {
            try
            {
                if (File.Exists(path) == true)
                {
                    string processName = Path.GetFileNameWithoutExtension(path);

                    bool isOpen = WindowManager.ShowWindow(processName, WindowState.Normal);

                    if (isOpen != true)
                    {
                        Process.Start(path);
                    }
                }
                else
                {
                    throw new Exception(Messages.InvalidTargetPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets duplicate process of specified process
        /// </summary>
        /// <param name="current">
        /// The current process to found its duplicate</param>
        /// <returns>
        /// Duplicate process or null value</returns>
        public static Process GetDuplicateProcess(Process current)
        {
            try
            {  
                string currentmd5 = Hash.MD5Hash(current.MainModule.FileName);
                Process[] processlist = Process.GetProcesses();

                foreach (Process process in processlist)
                {
                    if (process.Id != current.Id)
                    {
                        try
                        {
                            if (currentmd5 == Hash.MD5Hash(process.MainModule.FileName))
                            {
                                return process;
                            }
                        }
                        catch
                        {

                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
