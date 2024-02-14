namespace MusicDLP.ViewModel.Commands;

public class Closecommand(MainVM vm) : CommandBase
{
    public override void Execute(object parameter) => vm.Close();
}
