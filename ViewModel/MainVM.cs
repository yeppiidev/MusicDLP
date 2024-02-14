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





    public MainVM()
    {
            
    }
}
