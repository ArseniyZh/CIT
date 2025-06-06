using Avalonia.Controls;
using Avalonia.Interactivity;

namespace agency.Windows;

public partial class AgencyWindow : Window
{
    public AgencyWindow()
    {
        InitializeComponent();
    }

    private void ClientsBtn_Click(object? sender, RoutedEventArgs e)
    {
        var clientsWindow = new ClientsWindow();
        clientsWindow.Show();
        Close();
    }

    private void OpenAgents_Click(object? sender, RoutedEventArgs e)
    {
        var window = new AgentsWindow();
        window.Show();
        this.Close(); // или оставить открытым
    }

    private void RealEstatesBtn_Click(object? sender, RoutedEventArgs e)
    {
        var realEstatesWindow = new RealEstatesWindow();
        realEstatesWindow.Show();
        Close();
    }

    private void OpenDeals_Click(object? sender, RoutedEventArgs e)
    {
        // var dealsWindow = new DealsWindow();
        // dealsWindow.Show();
        // this.Close(); // если хочешь закрыть текущее окно
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var auth = new Authorization();
        auth.Show();
        Close();
    }
}
