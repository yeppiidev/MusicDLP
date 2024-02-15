namespace MusicDLP;

public static class PropertiesHelper
{
    public static bool ShowConsoleOutput
    {
        get => (bool)Properties.Settings.Default["showConsoleOutput"];
        set => Properties.Settings.Default["showConsoleOutput"] = value;
    }

    public static bool ClearPreviousOutput
    {
        get => (bool)Properties.Settings.Default["clearPreviousOutput"];
        set => Properties.Settings.Default["clearPreviousOutput"] = value;
    }

    public static bool ShowDownloadOutput
    {
        get => (bool)Properties.Settings.Default["showDownloadOutput"];
        set => Properties.Settings.Default["showDownloadOutput"] = value;
    }

    public static void Save() => Properties.Settings.Default.Save();
}
