using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using System.Windows;

namespace iMovie
{
    public enum WindowState
    {
        Normal = 1,
        Minimized = 2, 
        Maximized = 3
    }

    public class WindowManager
    {
        [DllImport("user32.dll")] 
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")] 
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void SetWindowState(WindowState state, string ipclass, string ipwindow)
        {
            try
            { 
                //ipproccess
                //ipwindow 
                IntPtr hWnd = FindWindow(ipclass, ipwindow);

                if (!hWnd.Equals(IntPtr.Zero))
                {
                    ShowWindowAsync(hWnd, (int)state);
                }

                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Shows all windows that are open in specified state
        /// </summary>
        /// <param name="state">
        /// Window state</param>
        public static void ShowWindow(WindowState state) 
        {
            try
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    ShowWindowAsync(clsProcess.MainWindowHandle, (int)state);
                    SetForegroundWindow(clsProcess.MainWindowHandle);
                }

                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Shows the main window of specified process in specified state if its running
        /// </summary>
        /// <param name="processName">
        /// Process name without extension</param>
        /// <param name="state">
        /// Window state</param>
        /// <returns>
        /// True if process is running and false if process is not running</returns>
        public static bool ShowWindow(string processName, WindowState state)
        {
            try
            {
                bool isOpen = false;

                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Equals(processName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        ShowWindowAsync(clsProcess.MainWindowHandle, (int)state);
                        SetForegroundWindow(clsProcess.MainWindowHandle);
                        isOpen = true;
                    }
                }
                 
                return isOpen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
