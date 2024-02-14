namespace MusicDLP.ViewModel.Commands;

public class StartCommand(MainVM vm) : CommandBase
{
    public override void Execute(object parameter) => vm.Start();
}
