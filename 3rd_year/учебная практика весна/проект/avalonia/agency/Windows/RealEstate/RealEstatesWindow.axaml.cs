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
        var housesWindow = new HousesWindow();
        housesWindow.Show();
        Close();
    }

    private void AppartamnetsBtn_Click(object? sender, RoutedEventArgs e)
    {
        var apartmentsWindow = new ApartamentsWindow();
        apartmentsWindow.Show();
        Close();
    }

    private void LandsBtn_Click(object? sender, RoutedEventArgs e)
    {
        var landsWindow = new LandsWindow();
        landsWindow.Show();
        Close();
    }

    private void AddressesBtn_Click(object? sender, RoutedEventArgs e)
    {
        var addressesWindow = new AddressesWindow();
        addressesWindow.Show();
        Close();
    }

    private void DistrictBtn_Click(object? sender, RoutedEventArgs e)
    {
        var districtsWindow = new DistrictsWindow();
        districtsWindow.Show();
        Close();
    }
}
