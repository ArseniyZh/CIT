using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using agency.Models;
using agency.Data;
using System.Collections.Generic;
using Avalonia;

namespace agency.Windows;

public partial class DistrictsWindow : Window
{
    private List<DistrictDto> _districts = new();

    public DistrictsWindow()
    {
        InitializeComponent();
        LoadDistricts();
    }

    private void LoadDistricts()
    {
        _districts = new DistrictRepository().GetAllDistricts();
        RenderDistricts();
    }

    private void RenderDistricts()
    {
        DistrictsListPanel.Children.Clear();

        foreach (var district in _districts)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {district.Id}, Название: {district.Name}, Координаты: {district.Area}",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            DistrictsListPanel.Children.Add(border);
        }
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var back = new RealEstatesWindow();
        back.Show();
        Close();
    }
}
