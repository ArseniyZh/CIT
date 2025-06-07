using Agency.Models;
using System.Linq;
using System.Windows;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Agency.Windows
{
    public partial class DealsWindow : Window
    {
        private AgencyRealEstate _context = new AgencyRealEstate();

        public DealsWindow()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadDealsList();
        }

        private void LoadComboBoxes()
        {
            
            var freeDemands = _context.Demands
                .Include(d => d.Supplies)
                .Where(d => !d.Supplies.Any())
                .ToList();

          
            var freeSupplies = _context.Supplies
                .Include(s => s.Demands)
                .Include(s => s.RealEstate)
                .Where(s => !s.Demands.Any())
                .ToList();
            /// <summary>
            // Добавим удобный текст для отображения (используй NotMapped DisplayInfo)
            /// </summary>
            foreach (var d in freeDemands)
                d.DisplayInfo = $"{d.Address_City}, {d.Address_Street}, до {d.MaxPrice ?? 0} руб.";

            foreach (var s in freeSupplies)
                s.DisplayInfo = $"{s.RealEstate?.Addresses.Address_City ?? "Адрес не указан"}, цена: {s.Price} руб.";

            DemandComboBox.ItemsSource = freeDemands;
            SupplyComboBox.ItemsSource = freeSupplies;
        }

        private void CreateDeal_Click(object sender, RoutedEventArgs e)
        {
            var selectedDemand = DemandComboBox.SelectedItem as Demands;
            var selectedSupply = SupplyComboBox.SelectedItem as Supplies;

            if (selectedDemand == null || selectedSupply == null)
            {
                MessageBox.Show("Выберите и потребность, и предложение.");
                return;
            }

         
            selectedDemand.Supplies.Add(selectedSupply);

            _context.SaveChanges();

            MessageBox.Show("Сделка успешно создана!");

          
            LoadComboBoxes();
            LoadDealsList();
        }

        private void LoadDealsList()
        {
            /// <summary>
            // Загружаем все потребности, у которых есть связанные предложения (сделки)
            /// </summary>
            var deals = _context.Demands
                .Include(d => d.Supplies.Select(s => s.RealEstate))
                .Where(d => d.Supplies.Any())
                .ToList();

           
            var displayList = new List<DealDisplayItem>();

            foreach (var demand in deals)
            {
                foreach (var supply in demand.Supplies)
                {
                    displayList.Add(new DealDisplayItem
                    {
                        DemandDisplay = $"{demand.Address_City}, {demand.Address_Street}, до {demand.MaxPrice ?? 0} руб.",
                        SupplyDisplay = $"{supply.RealEstate?.Addresses.Address_City ?? "Адрес не указан"}, цена: {supply.Price} руб."
                    });
                }
            }

            DealsListView.ItemsSource = displayList;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AgencyWindow agencyWindow = new AgencyWindow();
            agencyWindow.Show();
            this.Close();
        }
    }

    public class DealDisplayItem
    {
        public string DemandDisplay { get; set; }
        public string SupplyDisplay { get; set; }
    }
}