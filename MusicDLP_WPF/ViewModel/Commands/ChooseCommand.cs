namespace MusicDLP_WPF.ViewModel.Commands;

public class ChooseCommand(MainVM vm) : CommandBase
{
    public override void Execute(object parameter) => vm.Choose(parameter);
}
