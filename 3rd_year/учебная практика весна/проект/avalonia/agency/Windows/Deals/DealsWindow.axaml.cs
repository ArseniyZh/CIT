using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using agency.Models;
using agency.Data;
using System.Collections.Generic;
using Avalonia;

namespace agency.Windows;

public partial class DealsWindow : Window
{
    private List<DealDto> _deals = new();

    public DealsWindow()
    {
        InitializeComponent();
        LoadDeals();
    }

    private void LoadDeals()
    {
        _deals = new DealRepository().GetAllDeals();
        RenderDeals();
    }

    private void RenderDeals()
    {
        DealsListPanel.Children.Clear();

        foreach (var deal in _deals)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {deal.Id}, Название: {deal.Title}",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            DealsListPanel.Children.Add(border);
        }
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var back = new AgencyWindow();
        back.Show();
        Close();
    }
}
