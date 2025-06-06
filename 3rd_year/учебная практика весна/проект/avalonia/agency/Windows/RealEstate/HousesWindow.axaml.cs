using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace agency.Windows;

public partial class HousesWindow : Window
{
    public HousesWindow()
    {
        InitializeComponent();
        LoadHouses();
    }

    private void LoadHouses()
    {
        var list = new List<HouseDto>
        {
            new HouseDto { Id = 1, Address = "ул. Центральная, д. 1", Floors = 2, Area = 120.5 },
            new HouseDto { Id = 2, Address = "ул. Новая, д. 12", Floors = 1, Area = 95.0 }
        };

        HousesDataGrid.ItemsSource = list;
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var back = new RealEstatesWindow();
        back.Show();
        Close();
    }

    private class HouseDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Floors { get; set; }
        public double Area { get; set; }
    }
}
