using MusicDLP.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicDLP.ViewModel;

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
    public Closecommand Closecommand { get; set; }
    public OptionsCommand OptionsCommand { get; set; }
    public StartCommand StartCommand { get; set; }



    public MainVM()
    {
        Log = "[log start]";

        ChooseCommand = new(this);
        Closecommand = new(this);
        OptionsCommand = new(this);
        StartCommand = new(this);
    }

    #region Command Methods
    internal void Options()
    {
        throw new NotImplementedException();
    }

    internal void Choose(object parameter)
    {
        throw new NotImplementedException();
    }

    internal void Close()
    {
        throw new NotImplementedException();
    }

    internal void Start()
    {
        throw new NotImplementedException();
    }
    #endregion
}
