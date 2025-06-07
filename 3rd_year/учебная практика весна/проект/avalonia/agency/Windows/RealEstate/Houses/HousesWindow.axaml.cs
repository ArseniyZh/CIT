using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;
using Avalonia;

namespace agency.Windows;

public partial class HousesWindow : Window
{
    private List<HouseDto> _houses = new();

    public HousesWindow()
    {
        InitializeComponent();
        LoadHouses();
    }

    private void LoadHouses()
    {
        _houses = new List<HouseDto>
        {
            new HouseDto { Id = 1, Address = "ул. Центральная, д. 1", Floors = 2, Area = 120.5 },
            new HouseDto { Id = 2, Address = "ул. Новая, д. 12", Floors = 1, Area = 95.0 }
        };

        RenderHouses();
    }

    private void RenderHouses()
    {
        HousesListPanel.Children.Clear();

        foreach (var house in _houses)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {house.Id}, Адрес: {house.Address}, Этажей: {house.Floors}, Площадь: {house.Area} м²",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            HousesListPanel.Children.Add(border);
        }
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
