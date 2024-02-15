using Microsoft.Win32;
using MusicDLP;
using MusicDLP_WPF.View;
using MusicDLP_WPF.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MusicDLP_WPF.ViewModel;

public class MainVM : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;
    private void SetProperty<T>(ref T reference, T value, [CallerMemberName] string propertyName = "")
    {
        if (Equals(reference, value)) return;
        reference = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



    #region String properties
    private string _url = string.Empty;
    public string Url { get => _url; set => SetProperty(ref _url,  value); }

    private string _downloadTo = string.Empty;
    public string DownloadTo { get => _downloadTo; set => SetProperty(ref _downloadTo, value); }

    private string _source = string.Empty;
    public string Source { get => _source; set => SetProperty(ref _source, value); }

    private string _output = string.Empty;
    public string Output { get => _output; set => SetProperty(ref _output, value); }

    private string _log = string.Empty;
    public string Log { get => _log; set => SetProperty(ref _log, value); }
    #endregion

    public ObservableCollection<string> ConvertExtensions { get; set; } = ["MP3", "OGG", "WAV", "WebM"];


    public ChooseCommand ChooseCommand { get; set; }
    public Closecommand Closecommand { get; set; } = new();
    public OptionsCommand OptionsCommand { get; set; } = new();
    public StartCommand StartCommand { get; set; }



    public MainVM()
    {
        Log = "[log start]";

        DownloadTo = GlobalHelpers.GetLastDownloadFolderLocation();

        ChooseCommand = new(this);
        StartCommand = new(this);

        #region legacy code
        //downloadProgress.Visible = false;
        //rtbOutput.Height += downloadProgress.Height + (downloadProgress.Location.X - rtbOutput.Location.X);
        //MinimumSize = Size;
        #endregion
    }

    #region Command Methods
    internal static void Options() => new OptionsForm().Show();

    internal void Choose(object parameter)
    {
        if (parameter is not TextBox textBox) 
            return;

        switch (textBox.Name)
        {
            case "downloadTextBox":
                DownloadFolder_Select();
                break;
            case "sourceTextBox":

                break;
            case "outputTextBox":

                break;
        }
    }

    internal void Start()
    {
        CheckToolInstallationStatus();

        //if (tabControlMain.SelectedIndex == 0)
        //{
        //    if (txtUrl.Text == "")
        //    {
        //        MessageBox.Show("Please enter the URL of your video to start the download!", "Missing Arguments",
        //            MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if (txtDownloadFolder.Text == "")
        //    {
        //        MessageBox.Show("Please select a folder to download your music to!", "Missing Arguments",
        //            MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if (!Directory.Exists(txtDownloadFolder.Text))
        //    {
        //        MessageBox.Show("The folder you've selected does not seem to exist. Please choose another folder!", "Invalid Arguments",
        //            MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        return;
        //    }

        //    PreDownloadTasks();

        //    // You can also use an anonymous delegate to do this.
        //    Thread dlThread = new(() =>
        //    {
        //        using Process process = new();

        //        StringBuilder builder = new();

        //        ProcessStartInfo startInfo = new()
        //        {
        //            CreateNoWindow = !(bool)Properties.Settings.Default["showConsoleOutput"],
        //            FileName = GlobalHelpers.YTDLPDownloadPath,
        //            Arguments = $"{Url} --ignore-errors -f \"bestaudio[ext=m4a]\" " +
        //            $"--extract-audio --add-metadata --postprocessor-args \"-metadata date='${{year}}' " +
        //            $"-metadata artist='${{artist}}'\" --embed-thumbnail --ppa \"EmbedThumbnail+ffmpeg_o:-c:v mjpeg " +
        //            $"-vf crop=\"'if(gt(ih,iw),iw,ih)':'if(gt(iw,ih),ih,iw)'\"\" --convert-thumbnail jpg --parse-metadata " +
        //            $"\"playlist_index:%(track_number)s\" --parse-metadata \":(?P<webpage_url>)\" --parse-metadata \":(?P<synopsis>)\" " +
        //            $"--parse-metadata \":(?P<description>)\" -o \"{DownloadTo}\\%(title)s.%(ext)s\"",

        //            RedirectStandardError = true,
        //            RedirectStandardOutput = true,
        //            UseShellExecute = false
        //        };

        //        process.EnableRaisingEvents = true;
        //        process.OutputDataReceived += (snd, args) =>
        //        {
        //            Output += args.Data + "\r\n";

        //            builder.AppendLine(args.Data);
        //        };
        //        process.ErrorDataReceived += (snd, args) => builder.AppendLine(args.Data);

        //        process.StartInfo = startInfo;
        //        process.Start();

        //        process.BeginOutputReadLine();
        //        process.BeginErrorReadLine();

        //        process.WaitForExit();

        //        PostDownloadTasks(builder.ToString());

        //        if ((bool)Properties.Settings.Default["showDownloadOutput"])
        //            Process.Start("explorer.exe", DownloadTo);
        //    });

        //    dlThread.Start();
        //}
        //else if (tabControlMain.SelectedIndex == 1)
        //{
        //    if (tbConverterOutput.Text == "")
        //    {
        //        MessageBox.Show("Please select an output file!", "Missing Arguments",
        //            MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if (tbConverterSource.Text == "")
        //    {
        //        MessageBox.Show("Please select the file that you need to convert!", "Missing Arguments",
        //            MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if (cbChooseConvertFormat.Text == "")
        //    {
        //        MessageBox.Show("Please select a format that you want to convert your source file to!", "Missing Arguments",
        //            MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        return;
        //    }
        //}
    }
    #endregion

    public static void CheckToolInstallationStatus()
    {
        if (!File.Exists(GlobalHelpers.YTDLPDownloadPath))
        {
            MessageBox.Show("Please download yt-dlp from: Options > Additional Tools > Download yt-dlp", "yt-dlp is not installed!",
                MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        if (!File.Exists(GlobalHelpers.FFMPEGApplicationExecutablePath))
        {
            MessageBox.Show("Please download FFMPEG from: Options > Additional Tools > Download FFMPEG", "FFMPEG is not installed!",
                MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }

    private void DownloadFolder_Select()
    {
        OpenFolderDialog dialog = new()
        {
            InitialDirectory = DownloadTo
        };

        if (dialog.ShowDialog() == true)
        {
            DownloadTo = dialog.FolderName;

            GlobalHelpers.SetLastDownloadFolderLocation(dialog.FolderName);
        }
    }

    #region TODO port over code

    //public void PreDownloadTasks()
    //{
    //    downloadProgress.Visible = true;
    //    rtbOutput.Height -= downloadProgress.Height;
    //    btnStartDownload.Enabled = false;

    //    if ((bool)Properties.Settings.Default["clearPreviousOutput"])
    //    {
    //        rtbOutput.Text = "";
    //    }
    //}

    //public void PostDownloadTasks(string output)
    //{
    //    downloadProgress.Visible = false;

    //    rtbOutput.Text = output;
    //    rtbOutput.Height += downloadProgress.Height;
    //    btnStartDownload.Enabled = true;

    //    if (output.Contains("has already been downloaded"))
    //    {
    //        MessageBox.Show("Not downloading again as this video already exists in the selected folder", "Video already exists!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }
    //}



    //private void BtnStartDownload_Click(object sender, EventArgs e)
    //{

    //}

    //private void RtbOutput_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
    //{
    //    Process.Start(e.LinkText);
    //}

    //private void LblTitle_Click(object sender, EventArgs e)
    //{
    //    ProcessStartInfo info = new ProcessStartInfo()
    //    {
    //        UseShellExecute = true,
    //        FileName = "https://github.com/yeppiidev/MusicDLP/"
    //    };
    //    Process.Start(info);
    //}

    ////protected override void WndProc(ref Message msg)
    ////{
    ////    const int WM_SYSCOMMAND = 0x0112;
    ////    const int SC_CLOSE = 0xF060;

    ////    if (msg.Msg == WM_SYSCOMMAND) // this is sent even if a modal MessageBox is shown
    ////    {
    ////        if ((int)msg.WParam == SC_CLOSE)
    ////        {
    ////            GlobalHelpers.CloseModalWindows();
    ////            Application.Current.Shutdown();
    ////        }
    ////    }

    ////    base.WndProc(ref msg);
    ////}

    //private void CopyLogToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    if (rtbOutput.Text == null || rtbOutput.Text == "") return;

    //    Clipboard.SetText(rtbOutput.Text);
    //}

    //private void ClearLogToolStripMenuItem_Click(object sender, EventArgs e) => Output = "";

    //private void TxtUrl_TextChanged(object sender, EventArgs e)
    //{
    //}

    //private void TxtDownloadFolder_TextChanged(object sender, EventArgs e)
    //{
    //}

    //private void RtbOutput_TextChanged(object sender, EventArgs e)
    //{
    //    rtbOutput.SelectionStart = rtbOutput.Text.Length;
    //    rtbOutput.ScrollToCaret();
    //}

    //private void BtnConverterChooseSource_Click(object sender, EventArgs e)
    //{
    //    OpenFileDialog openFileDialog = new OpenFileDialog();

    //    openFileDialog.InitialDirectory = lblDownloadFolder.Text != "" ? lblDownloadFolder.Text : Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Music");
    //    openFileDialog.Filter = "Matroska Audio Files (*.m4a)|*.m4a";
    //    openFileDialog.FilterIndex = 0;
    //    openFileDialog.RestoreDirectory = true;
    //    openFileDialog.Title = "Select the input file...";

    //    if (openFileDialog.ShowDialog() == DialogResult.OK)
    //    {
    //        string selectedFileName = openFileDialog.FileName;
    //        tbConverterSource.Text = selectedFileName;
    //    }
    //}

    //private void BtnConverterChooseOutput_Click(object sender, EventArgs e)
    //{
    //    OpenFileDialog openFileDialog = new()
    //    {
    //        InitialDirectory = lblDownloadFolder.Text != "" ? lblDownloadFolder.Text : Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Music"),
    //        Filter = "Audio Files (*.mp3, *.webm, *.wav, *.ogg)|*.mp3;*.webm;*.ogg;*.wav",
    //        FilterIndex = 0,
    //        RestoreDirectory = true,
    //        Title = "Select the output file..."
    //    };

    //    if (openFileDialog.ShowDialog() == true)
    //    {
    //        string selectedFileName = openFileDialog.FileName;
    //        tbConverterOutput.Text = selectedFileName;
    //    }
    //}

    #endregion
}
