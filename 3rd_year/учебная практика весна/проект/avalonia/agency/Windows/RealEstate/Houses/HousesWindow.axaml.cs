using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using agency.Models;
using agency.Data;
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
        _houses = new HouseRepository().GetAllHouses();
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
                    Text = $"ID: {house.Id}, Этажей: {house.Floors}, Площадь: {house.Area} м²",
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
}
