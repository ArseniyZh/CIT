using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace agency.Windows;

public partial class LandsWindow : Window
{
    public LandsWindow()
    {
        InitializeComponent();
        LoadLands();
    }

    private void LoadLands()
    {
        var list = new List<LandDto>
        {
            new LandDto { Id = 1, Address = "деревня Лесная, уч. 5", Area = 1500 },
            new LandDto { Id = 2, Address = "село Поляна, уч. 12", Area = 2000 }
        };

        LandsDataGrid.ItemsSource = list;
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var back = new RealEstatesWindow();
        back.Show();
        Close();
    }

    private class LandDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Area { get; set; } // в м²
    }
}
