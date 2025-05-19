using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using TorchAutoBuild.UI;

namespace TorchAutoBuild;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Console.WriteLine(Environment.CurrentDirectory);
    }
    private void OpenTalentsWindow(object? sender, RoutedEventArgs e)
    {
        var window = new GodsOverviewWindow();
        window.Show();
    }
}