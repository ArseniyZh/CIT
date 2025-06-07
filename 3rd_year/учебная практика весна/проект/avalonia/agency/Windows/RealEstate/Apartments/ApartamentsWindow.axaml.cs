using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;
using Avalonia;

namespace agency.Windows;

public partial class ApartamentsWindow : Window
{
    private List<AppartmentDto> _apartments = new();

    public ApartamentsWindow()
    {
        InitializeComponent();
        LoadAppartments();
    }

    private void LoadAppartments()
    {
        _apartments = new List<AppartmentDto>
        {
            new AppartmentDto { Id = 1, Address = "ул. Пушкина, д. 10", Rooms = 2, Area = 55.3, Floor = 3 },
            new AppartmentDto { Id = 2, Address = "ул. Ленина, д. 8", Rooms = 3, Area = 72.1, Floor = 2 },
            new AppartmentDto { Id = 3, Address = "ул. Горького, д. 5", Rooms = 1, Area = 38.7, Floor = 5 }
        };

        RenderAppartments();
    }

    private void RenderAppartments()
    {
        AppartamentsListPanel.Children.Clear();

        foreach (var apt in _apartments)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {apt.Id}, Адрес: {apt.Address}, Комнат: {apt.Rooms}, Площадь: {apt.Area} м², Этаж: {apt.Floor}",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            AppartamentsListPanel.Children.Add(border);
        }
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
        public int Floor { get; set; }
    }
}
