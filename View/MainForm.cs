using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace MusicDLP
{
    public partial class MainForm : Form
    {
        public string InitialDownloadLocation;

        public MainForm()
        {
            InitializeComponent();

            InitialDownloadLocation = GlobalHelpers.GetLastDownloadFolderLocation();

            txtDownloadFolder.Text = InitialDownloadLocation;
            downloadProgress.Visible = false;
            rtbOutput.Height += downloadProgress.Height + (downloadProgress.Location.X - rtbOutput.Location.X);
            MinimumSize = Size;
        }

        public void PreDownloadTasks()
        {
            downloadProgress.Visible = true;
            rtbOutput.Height -= downloadProgress.Height;
            btnStartDownload.Enabled = false;

            if ((bool)Properties.Settings.Default["clearPreviousOutput"])
            {
                rtbOutput.Text = "";
            }
        }

        public void PostDownloadTasks(string output)
        {
            downloadProgress.Visible = false;

            rtbOutput.Text = output;
            rtbOutput.Height += downloadProgress.Height;
            btnStartDownload.Enabled = true;

            if (output.Contains("has already been downloaded"))
            {
                MessageBox.Show("Not downloading again as this video already exists in the selected folder", "Video already exists!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckToolInstallationStatus();
        }

        private void CheckToolInstallationStatus()
        {
            if (!File.Exists(GlobalHelpers.YTDLPDownloadPath))
            {
                MessageBox.Show("Please download yt-dlp from: Options > Additional Tools > Download yt-dlp", "yt-dlp is not installed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (!File.Exists(GlobalHelpers.FFMPEGApplicationExecutablePath))
            {
                MessageBox.Show("Please download FFMPEG from: Options > Additional Tools > Download FFMPEG", "FFMPEG is not installed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnChooseDownloadFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            dialog.InitialDirectory = InitialDownloadLocation;
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtDownloadFolder.Text = dialog.FileName;

                GlobalHelpers.SetLastDownloadFolderLocation(dialog.FileName);
            }
        }

        private void btnStartDownload_Click(object sender, EventArgs e)
        {
            CheckToolInstallationStatus();

            if (tabControlMain.SelectedIndex == 0)
            {
                if (txtUrl.Text == "")
                {
                    MessageBox.Show("Please enter the URL of your video to start the download!", "Missing Arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtDownloadFolder.Text == "")
                {
                    MessageBox.Show("Please select a folder to download your music to!", "Missing Arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Directory.Exists(txtDownloadFolder.Text))
                {
                    MessageBox.Show("The folder you've selected does not seem to exist. Please choose another folder!", "Invalid Arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PreDownloadTasks();

                // You can also use an anonymous delegate to do this.
                Thread dlThread = new Thread(() =>
                {
                    using (Process process = new Process())
                    {
                        StringBuilder builder = new StringBuilder();

                        ProcessStartInfo startInfo = new ProcessStartInfo();

                        startInfo.CreateNoWindow = !(bool)Properties.Settings.Default["showConsoleOutput"];
                        startInfo.FileName = GlobalHelpers.YTDLPDownloadPath;
                        startInfo.Arguments = $"{txtUrl.Text} --ignore-errors -f \"bestaudio[ext=m4a]\" --extract-audio --add-metadata --postprocessor-args \"-metadata date='${{year}}' -metadata artist='${{artist}}'\" --embed-thumbnail --ppa \"EmbedThumbnail+ffmpeg_o:-c:v mjpeg -vf crop=\"'if(gt(ih,iw),iw,ih)':'if(gt(iw,ih),ih,iw)'\"\" --convert-thumbnail jpg --parse-metadata \"playlist_index:%(track_number)s\" --parse-metadata \":(?P<webpage_url>)\" --parse-metadata \":(?P<synopsis>)\" --parse-metadata \":(?P<description>)\" -o \"{txtDownloadFolder.Text}\\%(title)s.%(ext)s\"";

                        startInfo.RedirectStandardError = true;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.UseShellExecute = false;

                        process.EnableRaisingEvents = true;
                        process.OutputDataReceived += (snd, args) =>
                        {
                            rtbOutput.Text += args.Data + "\r\n";

                            builder.AppendLine(args.Data);
                        };
                        process.ErrorDataReceived += (snd, args) => builder.AppendLine(args.Data);

                        process.StartInfo = startInfo;
                        process.Start();

                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();

                        process.WaitForExit();

                        PostDownloadTasks(builder.ToString());

                        if ((bool)Properties.Settings.Default["showDownloadOutput"])
                            Process.Start("explorer.exe", txtDownloadFolder.Text);
                    }
                });

                dlThread.Start();
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                if (tbConverterOutput.Text == "")
                {
                    MessageBox.Show("Please select an output file!", "Missing Arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tbConverterSource.Text == "")
                {
                    MessageBox.Show("Please select the file that you need to convert!", "Missing Arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbChooseConvertFormat.Text == "")
                {
                    MessageBox.Show("Please select a format that you want to convert your source file to!", "Missing Arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }

        private void rtbOutput_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yeppiidev/MusicDLP/");
        }

        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND) // this is sent even if a modal MessageBox is shown
            {
                if ((int)msg.WParam == SC_CLOSE)
                {
                    GlobalHelpers.CloseModalWindows();
                    Close();
                }
            }

            base.WndProc(ref msg);
        }

        private void copyLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbOutput.Text == null || rtbOutput.Text == "") return;

            Clipboard.SetText(rtbOutput.Text);
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbOutput.Text = "";
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDownloadFolder_TextChanged(object sender, EventArgs e)
        {
        }

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnConverterChooseSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = lblDownloadFolder.Text != "" ? lblDownloadFolder.Text : Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Music");
            openFileDialog.Filter = "Matroska Audio Files (*.m4a)|*.m4a";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Select the input file...";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                tbConverterSource.Text = selectedFileName;
            }
        }

        private void btnConverterChooseOutput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = lblDownloadFolder.Text != "" ? lblDownloadFolder.Text : Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Music");
            openFileDialog.Filter = "Audio Files (*.mp3, *.webm, *.wav, *.ogg)|*.mp3;*.webm;*.ogg;*.wav";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Select the output file...";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                tbConverterOutput.Text = selectedFileName;
            }
        }
    }
}