using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace MusicDLP
{
    public class GlobalHelpers
    {
        public static string DefaultToolDownloadPath = Environment.ExpandEnvironmentVariables("%APPDATA%\\MusicDLP\\Tools");
        public static string YTDLPDownloadPath = DefaultToolDownloadPath + "\\yt-dlp.exe";

        public static bool ExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        /// <summary>
        /// Attempt to close modal windows if there are any.
        /// </summary>
        public static void CloseModalWindows() {
            // get the main window
            AutomationElement root = AutomationElement.FromHandle(Process.GetCurrentProcess().MainWindowHandle);

            if (root == null)
                return;

            // it should implement the Window pattern
            object pattern;
            if (!root.TryGetCurrentPattern(WindowPattern.Pattern, out pattern))
                return;

            WindowPattern window = (WindowPattern) pattern;
            if (window.Current.WindowInteractionState != WindowInteractionState.ReadyForUserInteraction) {
                // get sub windows
                foreach (AutomationElement element in root.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window))) {
                    // hmmm... is it really a window?
                    if (element.TryGetCurrentPattern(WindowPattern.Pattern, out pattern)) {
                        // if it's ready, try to close it
                        WindowPattern childWindow = (WindowPattern) pattern;
                        if (childWindow.Current.WindowInteractionState == WindowInteractionState.ReadyForUserInteraction) {
                            childWindow.Close();
                        }
                    }
                }
            }
        }

        public static void SetLastDownloadFolderLocation(string newLocation) {
            Properties.Settings.Default["lastDownloadFolderLocation"] = newLocation;
            Properties.Settings.Default.Save();
        }

        public static string GetLastDownloadFolderLocation() {
            if ((string) Properties.Settings.Default["lastDownloadFolderLocation"] != "") {
                return (string) Properties.Settings.Default["lastDownloadFolderLocation"];
            } else {
                return Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Music");
            }
        }
    }
}
