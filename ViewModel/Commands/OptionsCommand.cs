namespace MusicDLP.ViewModel.Commands;

public class OptionsCommand(MainVM vm) : CommandBase
{
    public override void Execute(object parameter) => vm.Options();
}
