using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;
using System.Collections.Generic;
using System.Linq;

namespace agency.Windows
{
    public partial class DealsWindow : Window
    {
        private List<DemandDto> _demands = new();
        private List<SupplyDto> _supplies = new();
        private List<DealDisplayItem> _deals = new();

        public DealsWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _demands = new List<DemandDto>
            {
                new DemandDto { Id = 1, DisplayInfo = "Казань, Баумана, до 5 млн" },
                new DemandDto { Id = 2, DisplayInfo = "Уфа, Ленина, до 3 млн" },
            };

            _supplies = new List<SupplyDto>
            {
                new SupplyDto { Id = 1, DisplayInfo = "Казань, 4.5 млн" },
                new SupplyDto { Id = 2, DisplayInfo = "Уфа, 2.9 млн" },
            };

            DemandComboBox.ItemsSource = _demands;
            SupplyComboBox.ItemsSource = _supplies;
        }

        private void CreateDeal_Click(object? sender, RoutedEventArgs e)
        {
            if (DemandComboBox.SelectedItem is not DemandDto demand || SupplyComboBox.SelectedItem is not SupplyDto supply)
                return;

            _deals.Add(new DealDisplayItem
            {
                DemandDisplay = demand.DisplayInfo,
                SupplyDisplay = supply.DisplayInfo
            });

            _demands.Remove(demand);
            _supplies.Remove(supply);

            DemandComboBox.ItemsSource = _demands;
            SupplyComboBox.ItemsSource = _supplies;

            DealsListBox.ItemsSource = _deals.Select(d => $"Потребность: {d.DemandDisplay} | Предложение: {d.SupplyDisplay}");
        }

        private void BackBtn_Click(object? sender, RoutedEventArgs e)
        {
            var main = new AgencyWindow();
            main.Show();
            Close();
        }
    }

    public class DemandDto
    {
        public int Id { get; set; }
        public string DisplayInfo { get; set; } = string.Empty;
    }

    public class SupplyDto
    {
        public int Id { get; set; }
        public string DisplayInfo { get; set; } = string.Empty;
    }

    public class DealDisplayItem
    {
        public string DemandDisplay { get; set; } = string.Empty;
        public string SupplyDisplay { get; set; } = string.Empty;
    }
}