namespace MusicDLP_WPF.ViewModel.Commands;

public class OptionsCommand() : CommandBase
{
    public override void Execute(object parameter) => MainVM.Options();
}
