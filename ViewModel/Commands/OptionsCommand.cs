namespace MusicDLP.ViewModel.Commands;

public class OptionsCommand() : CommandBase
{
    public override void Execute(object parameter) => MainVM.Options();
}
