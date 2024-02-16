using MusicDLP_WPF.ViewModel;
using System.Windows;

namespace MusicDLP_WPF.View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e) => MainVM.CheckToolInstallationStatus();
}