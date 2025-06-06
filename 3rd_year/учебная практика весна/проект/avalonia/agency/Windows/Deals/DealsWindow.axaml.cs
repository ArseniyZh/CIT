using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace agency.Windows;

public partial class DealsWindow : Window
{
    public DealsWindow()
    {
        InitializeComponent();
        LoadDeals();
    }

    private void LoadDeals()
    {
        var deals = new List<DealDto>
        {
            new DealDto { Id = 1, Realtor = "Иванов", Client = "Петров", PropertyType = "Квартира", Price = 4500000 },
            new DealDto { Id = 2, Realtor = "Сидорова", Client = "Кузнецов", PropertyType = "Дом", Price = 7200000 }
        };

        DealsDataGrid.ItemsSource = deals;
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var main = new AgencyWindow();
        main.Show();
        Close();
    }

    private class DealDto
    {
        public int Id { get; set; }
        public string Realtor { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public string PropertyType { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}