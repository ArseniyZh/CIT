using Agency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Agency.Windows
{
    
    public partial class DistrictsWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        public DistrictsWindow()
        {
            InitializeComponent();
            LoadDistricts(); 
        }
        private void LoadDistricts()
        {
            var disrictsdata = _context.Districts.ToList();
            AppartamentsDataGrid.ItemsSource = disrictsdata;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            RealEstatesWindow realEstatesWindow = new RealEstatesWindow();
            realEstatesWindow.Show();
            this.Close();
        }
        private void AddDistrictBtn_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что введён id
            if (!int.TryParse(DistrictIdTextBox.Text.Trim(), out int newId))
            {
                MessageBox.Show("Введите корректный числовой код района.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string newName = DistrictNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Введите название района.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем уникальность кода
            bool exists = _context.Districts.Any(d => d.Id == newId);
            if (exists)
            {
                MessageBox.Show($"Район с кодом {newId} уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создаём новый район
            Districts newDistrict = new Districts()
            {
                Id = newId,
                Name = newName,
                Area = "" // можно добавить поле ввода для координат, или оставить пустым
            };

            try
            {
                _context.Districts.Add(newDistrict);
                _context.SaveChanges();
                MessageBox.Show("Район успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистка полей
                DistrictIdTextBox.Clear();
                DistrictNameTextBox.Clear();

                // Обновляем таблицу
                LoadDistricts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении района: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
