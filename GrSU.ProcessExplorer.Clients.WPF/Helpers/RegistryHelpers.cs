using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Clients.WPF.Helpers
{
    public static class RegistryHelpers
    {
        private const string AutorunFolderKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public static void AddToAutorun(string appName, string path)
        {
            var autorunFolderKey = Registry.CurrentUser.OpenSubKey(AutorunFolderKey, true);
            var appAutorunKeyValue = autorunFolderKey.GetValue(appName);
            if (appAutorunKeyValue != null && appAutorunKeyValue is string && path.Equals((string)appAutorunKeyValue))
            {
                return;
            }

            autorunFolderKey.DeleteValue(appName, false);
            autorunFolderKey.SetValue(appName, path);
        }
    }
}
