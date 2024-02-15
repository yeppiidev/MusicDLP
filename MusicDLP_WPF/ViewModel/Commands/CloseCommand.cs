using System.Windows;

namespace MusicDLP_WPF.ViewModel.Commands;

public class Closecommand() : CommandBase
{
    public override void Execute(object parameter) => Application.Current.Shutdown();
}
