using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia;
using System.Collections.Generic;

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
        _districts = new List<DistrictDto>
        {
            new DistrictDto { Id = 1, Name = "Советский", Area = "55.75, 49.14" },
            new DistrictDto { Id = 2, Name = "Вахитовский", Area = "55.78, 49.12" }
        };

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

    private class DistrictDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
    }
}
