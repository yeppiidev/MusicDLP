using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Automation;

namespace MusicDLP
{
    public class GlobalHelpers
    {
        public static string DefaultToolDownloadPath = Environment.ExpandEnvironmentVariables("%APPDATA%\\MusicDLP\\Tools");
        public static string YTDLPDownloadPath = DefaultToolDownloadPath + "\\yt-dlp.exe";
        public static string FFMPEGDownloadPath = DefaultToolDownloadPath + "\\ffmpeg";
        public static string FFMPEGInstallerFilePath = DefaultToolDownloadPath + "\\ffmpeg.zip";
        public static string FFMPEGApplicationExecutablePath = FFMPEGDownloadPath + "\\ffmpeg-master-latest-win64-lgpl\\bin\\ffmpeg.exe";

        public static void ExtractZipFile(string archivePath, string password, string outFolder)
        {
            using (var fsInput = File.OpenRead(archivePath))
            using (var zf = new ZipFile(fsInput))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    // AES encrypted entries are handled automatically
                    zf.Password = password;
                }

                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        // Ignore directories
                        continue;
                    }
                    string entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:
                    //entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here
                    // to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    // Manipulate the output filename here as desired.
                    var fullZipToPath = Path.Combine(outFolder, entryFileName);
                    var directoryName = Path.GetDirectoryName(fullZipToPath);

                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    // 4K is optimum
                    var buffer = new byte[4096];

                    // Unzip file in buffered chunks. This is just as fast as unpacking
                    // to a buffer the full size of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (var zipStream = zf.GetInputStream(zipEntry))
                    using (Stream fsOutput = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, fsOutput, buffer);
                    }
                }
            }
        }

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
        public static void CloseModalWindows()
        {
            // get the main window
            AutomationElement root = AutomationElement.FromHandle(Process.GetCurrentProcess().MainWindowHandle);

            if (root == null)
                return;

            // it should implement the Window pattern
            object pattern;
            if (!root.TryGetCurrentPattern(WindowPattern.Pattern, out pattern))
                return;

            WindowPattern window = (WindowPattern)pattern;
            if (window.Current.WindowInteractionState != WindowInteractionState.ReadyForUserInteraction)
            {
                // get sub windows
                foreach (AutomationElement element in root.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)))
                {
                    // hmmm... is it really a window?
                    if (element.TryGetCurrentPattern(WindowPattern.Pattern, out pattern))
                    {
                        // if it's ready, try to close it
                        WindowPattern childWindow = (WindowPattern)pattern;
                        if (childWindow.Current.WindowInteractionState == WindowInteractionState.ReadyForUserInteraction)
                        {
                            childWindow.Close();
                        }
                    }
                }
            }
        }

        public static void SetLastDownloadFolderLocation(string newLocation)
        {
            Properties.Settings.Default["lastDownloadFolderLocation"] = newLocation;
            Properties.Settings.Default.Save();
        }

        public static string GetLastDownloadFolderLocation()
        {
            if ((string)Properties.Settings.Default["lastDownloadFolderLocation"] != "")
            {
                return (string)Properties.Settings.Default["lastDownloadFolderLocation"];
            }
            else
            {
                return Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Music");
            }
        }
    }
}