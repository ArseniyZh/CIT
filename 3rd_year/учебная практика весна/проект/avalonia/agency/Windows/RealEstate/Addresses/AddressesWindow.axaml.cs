using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;
using Avalonia;

namespace agency.Windows;

public partial class AddressesWindow : Window
{
    private List<RealEstateAddressDto> _addresses = new();

    public AddressesWindow()
    {
        InitializeComponent();
        LoadAddresses();
    }

    private void LoadAddresses()
    {
        _addresses = new List<RealEstateAddressDto>
        {
            new RealEstateAddressDto { Id = 1, City = "Казань", Street = "Ленина", House = "10", Number = "А" },
            new RealEstateAddressDto { Id = 2, City = "Москва", Street = "Арбат", House = "5", Number = "" },
            new RealEstateAddressDto { Id = 3, City = "Петербург", Street = "Невский", House = "25", Number = "1Б" }
        };

        RenderAddresses();
    }

    private void RenderAddresses()
    {
        AddressesListPanel.Children.Clear();

        foreach (var addr in _addresses)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {addr.Id}, Город: {addr.City}, Улица: {addr.Street}, Дом: {addr.House}, Корпус: {addr.Number}",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            AddressesListPanel.Children.Add(border);
        }
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var back = new RealEstatesWindow();
        back.Show();
        Close();
    }

    private class RealEstateAddressDto
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
}
