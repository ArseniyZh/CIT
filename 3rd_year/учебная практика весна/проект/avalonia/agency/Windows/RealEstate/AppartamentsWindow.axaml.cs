using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace agency.Windows;

public partial class AppartamentsWindow : Window
{
    public AppartamentsWindow()
    {
        InitializeComponent();
        LoadAppartments();
    }

    private void LoadAppartments()
    {
        var list = new List<AppartmentDto>
        {
            new AppartmentDto { Id = 1, Address = "ул. Пушкина, д. 10", Rooms = 2, Area = 55.3 },
            new AppartmentDto { Id = 2, Address = "ул. Ленина, д. 8", Rooms = 3, Area = 72.1 },
            new AppartmentDto { Id = 3, Address = "ул. Горького, д. 5", Rooms = 1, Area = 38.7 }
        };

        AppartamentsDataGrid.ItemsSource = list;
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var back = new RealEstatesWindow();
        back.Show();
        Close();
    }

    private class AppartmentDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Rooms { get; set; }
        public double Area { get; set; }
    }
}
