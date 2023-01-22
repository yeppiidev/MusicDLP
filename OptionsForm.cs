using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDLP
{
    public partial class OptionsForm : Form
    {
        private bool DownloadInProgress = false;

        public OptionsForm()
        {
            InitializeComponent();
        }

        public void LoadAllSettings() {
            cbShowOutputConsole.Checked = (bool) Properties.Settings.Default["showConsoleOutput"];
            cbClearPreviousOutput.Checked = (bool) Properties.Settings.Default["clearPreviousOutput"];
            cbShowDownloadOutput.Checked = (bool) Properties.Settings.Default["showDownloadOutput"];
        }

        public void SaveAllSettings() {
            Properties.Settings.Default["showConsoleOutput"] = cbShowOutputConsole.Checked;
            Properties.Settings.Default["clearPreviousOutput"] = cbClearPreviousOutput.Checked;
            Properties.Settings.Default["showDownloadOutput"] = cbShowDownloadOutput.Checked;

            Properties.Settings.Default.Save();
        }

        public void PreToolDownloadTasks() {
            btnCancel.Enabled = false;
            btnOK.Enabled = false;
            
            btnDownloadFfmpeg.Enabled = false;
            btnDownloadYtdlp.Enabled = false;

            DownloadInProgress = true;

            DialogResult = DialogResult.None;
        }

        public void PostToolDownloadTasks() {
            btnCancel.Enabled = true;
            btnOK.Enabled = true;

            btnDownloadFfmpeg.Enabled = true;
            btnDownloadYtdlp.Enabled = true;

            DownloadInProgress = false;
            downloadProgress.Visible = false;

            RecheckToolInstallationStatus();
        }

        public void RecheckToolInstallationStatus() {
            lblYtdlpInstalled.Text = File.Exists(GlobalHelpers.YTDLPDownloadPath) 
                ? "Installed!" 
                : "Not installed!";
            lblFfmpegInstalled.Text = File.Exists(GlobalHelpers.FFMPEGApplicationExecutablePath)
                ? "Installed!"
                : "Not installed!";

            btnRemoveYtdlp.Enabled = File.Exists(GlobalHelpers.YTDLPDownloadPath);
            btnRemoveFFMPEG.Enabled = File.Exists(GlobalHelpers.FFMPEGApplicationExecutablePath);
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            RecheckToolInstallationStatus();

            downloadProgress.Visible = false;

            LoadAllSettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Apply settings here
        }

        private void lnkLblYtdlp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/yt-dlp/yt-dlp/");
        }

        private void btnDownloadYtdlp_Click(object sender, EventArgs e)
        {
            DialogResult result = new CustomDialogBox("Download yt-dlp", 
                                                      "This application uses yt-dlp to extract and download music from a YouTube video. Do you want to download it now?", 
                                                      CustomDialogBoxButtons.YesNo)
                                                     .ShowDialog();

            if (result == DialogResult.Yes)
            {
                PreToolDownloadTasks();

                Directory.CreateDirectory(GlobalHelpers.DefaultToolDownloadPath);
                
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += DownloadProgressChanged; ;
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new Uri(URLConstants.ytdlpDownloadUrl),
                        // Param2 = Path to save
                        GlobalHelpers.YTDLPDownloadPath
                    );

                    lblYtdlpInstalled.Text = "Downloading...";
                    downloadProgress.Visible = true;
                }
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            PostToolDownloadTasks();

            if (e.Error != null)
            {
                MessageBox.Show("The operation did not complete successfully because of the following error: " + e.Error.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblYtdlpInstalled.Text = "Installation Failed!";
                return;
            }

            lblYtdlpInstalled.Text = "Installed!";

            DialogResult result = MessageBox.Show("yt-dlp was installed successfully!", "Operation Completed",  MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Process.Start("explorer.exe", GlobalHelpers.DefaultToolDownloadPath);
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgress.Value = e.ProgressPercentage;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            SaveAllSettings();
        }

        private void btnRemoveYtdlp_Click(object sender, EventArgs e) {
            File.Delete(GlobalHelpers.YTDLPDownloadPath);

            btnRemoveYtdlp.Enabled = File.Exists(GlobalHelpers.YTDLPDownloadPath);
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (DownloadInProgress) e.Cancel = true;
        }

        private void btnDownloadFfmpeg_Click(object sender, EventArgs e) {
            DialogResult result = new CustomDialogBox("Download FFMPEG", 
                                                      "FFMPEG is utilized by the converter utility. Do you want to download it now?", 
                                                      CustomDialogBoxButtons.YesNo)
                                                      .ShowDialog();
            
            if (result == DialogResult.Yes) {
                PreToolDownloadTasks();

                Directory.CreateDirectory(GlobalHelpers.DefaultToolDownloadPath);

                using (WebClient wc = new WebClient()) {
                    wc.DownloadProgressChanged += DownloadProgressChanged;
                    wc.DownloadFileCompleted += WCFFMPEGDownloadCompleted;

                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new Uri(URLConstants.FFMPEGDownloadUrl),
                        // Param2 = Path to save
                        GlobalHelpers.FFMPEGInstallerFilePath
                    );

                    lblFfmpegInstalled.Text = "Downloading...";
                    downloadProgress.Visible = true;
                }
            }
        }

        private void WCFFMPEGDownloadCompleted(object sender, AsyncCompletedEventArgs e) {
            if (e.Error != null) {
                MessageBox.Show("The operation did not complete successfully because of the following error: " + e.Error.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblFfmpegInstalled.Text = "Installation Failed!";
                return;
            } 

            CustomDialogBox customDialogBox = new CustomDialogBox("Extracting FFMPEG", "Extracting FFMPEG... Please wait for this operation to complete (this may take a while)", true);
            customDialogBox.Show();

            try {
                GlobalHelpers.ExtractZipFile(GlobalHelpers.FFMPEGInstallerFilePath, "", GlobalHelpers.FFMPEGDownloadPath);
            } catch (Exception ex) {
                MessageBox.Show("Unable to extract the FFMPEG archive: " + ex.Message, "FFMPEG Installation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            customDialogBox.Close();

            try { 
                File.Delete(GlobalHelpers.FFMPEGInstallerFilePath);
            } catch (Exception) { }

            PostToolDownloadTasks();
        }

        private void btnRemoveFFMPEG_Click(object sender, EventArgs e) {
            Directory.Delete(GlobalHelpers.FFMPEGDownloadPath, true);

            btnRemoveFFMPEG.Enabled = false;
            lblFfmpegInstalled.Text = "Not Installed!";
        }
    }
}
