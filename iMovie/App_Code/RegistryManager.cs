using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Security.AccessControl;

namespace iMovie
{ 
    public class RegistryManager
    {
        /// <summary>
        /// Sets the access to task manager
        /// </summary>
        /// <param name="value">
        /// Value indicating access to task manager. true = enable , false = disable</param>
        public static void EnableTaskManager(bool value)
        {
            try
            {
                int intValue = 0;

                if (value == true)
                {
                    intValue = 0;
                }
                else
                {
                    intValue = 1;
                }

                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue("DisableTaskMgr", intValue, RegistryValueKind.DWord);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Enables or disables Alt+Tab functionality for switching between open windows
        /// </summary>
        /// <param name="value">
        /// Value indicating this functionality is enable or not. true = enable , false = disable</param>
        public static void EnableAltTab(bool value)
        {
            try
            {
                int intValue = 0;

                if (value == true)
                {
                    intValue = 1;
                }
                else
                {
                    intValue = 0;
                }

                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"ControlPanel\Desktop", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue("CoolSwitch", intValue, RegistryValueKind.DWord);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the access to run command
        /// </summary>
        /// <param name="value">
        /// Value indicating access to run command. true = enable , false = disable</param>
        public static void EnableRunCommand(bool value)  
        {
            try
            {
                int intValue = 0;

                if (value == true)
                {
                    intValue = 0;
                }
                else
                {
                    intValue = 1;
                }

                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue("NoRun", intValue, RegistryValueKind.DWord);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the access to command prompt
        /// </summary>
        /// <param name="value">
        /// Value indicating access to command prompt. 0 = enable , 1 = disable , 2 = disable CMD & batch proccessing</param>
        public static void EnableCommandPrompt(int value)
        {
            try
            {
                if (value >= 0 && value <= 2)
                {
                    RegistryKey HKCU = Registry.CurrentUser;
                    RegistryKey key = HKCU.CreateSubKey(@"Software\Policies\Microsoft\Windows\System", RegistryKeyPermissionCheck.ReadWriteSubTree);

                    key.SetValue("DisableCMD", value, RegistryValueKind.DWord);

                    key.Close();
                    HKCU.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the access to command prompt
        /// </summary>
        /// <param name="value">
        /// Value indicating access to command prompt. true = enable , false = disable</param>
        public static void EnableCommandPrompt(bool value)
        {
            try
            {
                int intValue = 0;

                if (value == true)
                {
                    intValue = 0;
                }
                else
                {
                    intValue = 1;
                }

                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"Software\Policies\Microsoft\Windows\System", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue("DisableCMD", intValue, RegistryValueKind.DWord);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds a program to windows startup
        /// </summary>
        /// <param name="name">
        /// The startup name in registry</param>
        /// <param name="path">
        /// The startup path of application</param>
        public static void AddStartup(string name = "", string path = "") // f = 0 = add , f = 1 = remove
        {
            try
            {
                RegistryKey HKCU = Registry.LocalMachine;
                RegistryKey key = HKCU.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue(name, path, RegistryValueKind.String);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        /// <summary>
        /// Removes a program from windows startup
        /// </summary>
        /// <param name="name">
        /// The startup name of application in registry to be removed</param>
        public static void RemoveStartup(string name = "") // f = 0 = add , f = 1 = remove
        {
            try
            {
                RegistryKey HKCU = Registry.LocalMachine;
                RegistryKey key = HKCU.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (key.GetValue(name) != null)
                {
                    key.DeleteValue(name);
                }

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Blocks the desired drives according to input value
        /// </summary>
        /// <param name="value">
        /// The value indicating which drives should be blocked, the formula is:
        /// value = 2 ^ (disk number - 1), like C = 2 ^ (3 - 1) = 4,
        /// and 0 = access all</param>
        public static void BlockDrive(int value)
        {
            try
            {
                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue("NoViewOnDrive", value, RegistryValueKind.DWord);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Blocks access to specified application
        /// </summary>
        /// <param name="name">
        /// The name for application in registry</param>
        /// <param name="path">
        /// The application path</param>
        public static void BlockApplication(string name, string path)// f = 0 = Block , f = 1 = Allow
        {
            try
            {
                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\DisallowRun", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue(name, path, RegistryValueKind.String);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Allows access to specified application
        /// </summary>
        /// <param name="name">
        /// The name of application in registry</param>
        public static void AllowApplication(string name)// f = 0 = Block , f = 1 = Allow
        {
            try 
            {
                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\DisallowRun", RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (key.GetValue(name) != null)
                {
                    key.DeleteValue(name);
                }

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets access to control panel
        /// </summary>
        /// <param name="value">
        /// Value indicating access to control panel. true = enable , false = disable</param>
        public static void EnableControlPanel(bool value)
        {
            try
            {
                int intValue = 0;

                if (value == true)
                {
                    intValue = 0;
                }
                else
                {
                    intValue = 1;
                }

                RegistryKey HKCU = Registry.CurrentUser;
                RegistryKey key = HKCU.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", RegistryKeyPermissionCheck.ReadWriteSubTree);

                key.SetValue("RestrictCpl", intValue, RegistryValueKind.DWord);

                key.Close();
                HKCU.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the auto reset state of windows UI shell
        /// </summary>
        /// <param name="value">
        /// Value indicating auto reset state of windows UI shell. true = enable auto reset , false = disable auto reset</param>
        public static void EnableShellAutoReset(bool value)
        {
            try
            {
                int intValue = 0;

                if (value == true)
                {
                    intValue = 1;
                }
                else
                {
                    intValue = 0;
                }

                RegistryKey OurKey = Registry.LocalMachine;
                OurKey = OurKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                OurKey.SetValue("AutoRestartShell", intValue);

                OurKey.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns a value indicating that specified application is available in windows startup or not
        /// </summary>
        /// <param name="name">
        /// The key name of application that should be checked for startup</param>
        /// <returns>
        /// True for startup and false for none startup</returns>
        public static bool HasStartup(string name = "")
        {
            try
            {
                RegistryKey HKCU = Registry.LocalMachine;
                RegistryKey key = HKCU.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (key.GetValue(name) != null)
                {
                    HKCU.Close();
                    key.Close();

                    return true;
                }
                else
                {
                    HKCU.Close();
                    key.Close();

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Writes a value into specified registry key
        /// </summary>
        /// <param name="value">
        /// Value to be written</param>
        /// <param name="rootKey">
        /// Root registry key</param>
        /// <param name="subKey">
        /// Registry sub key</param>
        public static void WriteValue(string value, string rootKey, string subKey)
        {
            try 
            { 
                RegistryKey reg = Registry.LocalMachine.CreateSubKey(rootKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                reg.SetValue(subKey, value);

                reg.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets value from specified registry key
        /// </summary>
        /// <param name="rootKey">
        /// Root registry key</param>
        /// <param name="subKey">
        /// Registry sub key</param>
        /// <returns>
        /// Object value</returns>
        public static string GetValue(string rootKey, string subKey)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.CreateSubKey(rootKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                string value = "";

                if (reg.GetValue(subKey) != null)
                {
                    value = reg.GetValue(subKey).ToString();
                    reg.Close();

                    return value;
                }
                else
                {
                    reg.Close();

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Removes value from specified registry key
        /// </summary>
        /// <param name="rootKey">
        /// Root registry key</param>
        /// <param name="subKey">
        /// Registry sub key</param>
        public static void RemoveValue(string rootKey, string subKey)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.CreateSubKey(rootKey, RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (reg.GetValue(subKey) != null)
                {
                    reg.DeleteValue(subKey);
                }

                reg.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
