using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using agency.Models;
using agency.Data;
using System.Collections.Generic;
using Avalonia;

namespace agency.Windows;

public partial class LandsWindow : Window
{
    private List<LandDto> _lands = new();

    public LandsWindow()
    {
        InitializeComponent();
        LoadLands();
    }

    private void LoadLands()
    {
        _lands = new LandRepository().GetAllLands();
        RenderLands();
    }

    private void RenderLands()
    {
        LandsListPanel.Children.Clear();

        foreach (var land in _lands)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {land.Id}, Площадь: {land.Area} м²",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            LandsListPanel.Children.Add(border);
        }
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var back = new RealEstatesWindow();
        back.Show();
        Close();
    }
}
