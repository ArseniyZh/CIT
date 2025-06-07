using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using agency.Data;
using agency.Models;
using System.Collections.Generic;

namespace agency.Windows;

public partial class ApartamentsWindow : Window
{
    private List<ApartmentDto> _apartments = new();

    public ApartamentsWindow()
    {
        InitializeComponent();
        LoadApartments();
    }

    private void LoadApartments()
    {
        _apartments = new ApartmentRepository().GetAllApartments();
        RenderApartments();
    }

    private void RenderApartments()
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
                    Text = $"ID: {apt.Id}, Комнат: {apt.Rooms}, Площадь: {apt.Area} м², Этаж: {apt.Floor}",
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
}
