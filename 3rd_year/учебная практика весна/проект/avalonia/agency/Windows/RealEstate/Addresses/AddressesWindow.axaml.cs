using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using agency.Data;
using agency.Models;
using System.Collections.Generic;

namespace agency.Windows;

public partial class AddressesWindow : Window
{
    private List<AddressDto> _addresses = new();

    public AddressesWindow()
    {
        InitializeComponent();
        LoadAddresses();
    }

    private void LoadAddresses()
    {
        _addresses = new AddressRepository().GetAllAddresses();
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
                    Text = $"ID: {addr.Id}, Город: {addr.City}, Улица: {addr.Street}, Дом: {addr.House}, Корпус: {addr.Building}",
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
}
