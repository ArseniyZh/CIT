using Avalonia.Controls;
using Avalonia.Interactivity;

namespace agency.Windows;

public partial class RealEstatesWindow : Window
{
    public RealEstatesWindow()
    {
        InitializeComponent();
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var main = new AgencyWindow();
        main.Show();
        Close();
    }

    private void HousesBtn_Click(object? sender, RoutedEventArgs e)
    {
        var housesWindow = new HousesWindow(); // предположим, ты сделаешь это окно
        housesWindow.Show();
        Close();
    }

    private void AppartamnetsBtn_Click(object? sender, RoutedEventArgs e)
    {
        // var apartmentsWindow = new ApartmentsWindow(); // предположим, ты сделаешь это окно
        // apartmentsWindow.Show();
        // Close();
    }

    private void LandsBtn_Click(object? sender, RoutedEventArgs e)
    {
        var landsWindow = new LandsWindow(); // предположим, ты сделаешь это окно
        landsWindow.Show();
        Close();
    }

    private void AddressesBtn_Click(object? sender, RoutedEventArgs e)
    {
        // var addressesWindow = new AddressesWindow(); // предположим, ты сделаешь это окно
        // addressesWindow.Show();
        // Close();
    }

    private void DistrictBtn_Click(object? sender, RoutedEventArgs e)
    {
        // var districtsWindow = new DistrictsWindow(); // предположим, ты сделаешь это окно
        // districtsWindow.Show();
        // Close();
    }
}
