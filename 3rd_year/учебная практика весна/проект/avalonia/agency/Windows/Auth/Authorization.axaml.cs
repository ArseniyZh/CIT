using Avalonia.Controls;
using Avalonia.Interactivity;

namespace agency.Windows;

public partial class Authorization : Window
{
    public Authorization()
    {
        InitializeComponent();
    }

    private void LoginBtn_Click(object? sender, RoutedEventArgs e)
    {
        string personIdText = Codetxtbox.Text?.Trim() ?? "";
        string password = Passwordtxtbox.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(personIdText) || string.IsNullOrWhiteSpace(password))
        {
            Codetxtbox.Background = Avalonia.Media.Brushes.MistyRose;
            Passwordtxtbox.Background = Avalonia.Media.Brushes.MistyRose;
            return;
        }

        if (!int.TryParse(personIdText, out int personId))
        {
            Codetxtbox.Background = Avalonia.Media.Brushes.MistyRose;
            return;
        }

        if (personId == 123 && password == "admin")
        {
            var agencyWindow = new AgencyWindow();
            agencyWindow.Show();
            Close();
        }
        else
        {
            Passwordtxtbox.Background = Avalonia.Media.Brushes.MistyRose;
        }
    }
}
