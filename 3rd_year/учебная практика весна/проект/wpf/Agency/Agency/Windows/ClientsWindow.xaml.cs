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
   
    public partial class ClientsWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        public ClientsWindow()
        {
            InitializeComponent();
            LoadClients();
        }
        private List<Clients> _allClients;

        private void LoadClients()
        {
            _allClients = _context.Clients
                .Include("Persons") 
                .ToList();

            ClientsListView.ItemsSource = _allClients;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AgencyWindow agencyWindow = new AgencyWindow();
            agencyWindow.Show();
            this.Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для изменения данных о клиенте нужно нажать на него из списка.");
        }

        private void AddNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewClientWindow addNewClientWindow = new AddNewClientWindow();
            addNewClientWindow.Show();
            this.Close();
        }
        /// <summary>
        /// Алгоритм работы поиска Левенштейна
        /// </summary>
        private int LevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return t?.Length ?? 0;
            if (string.IsNullOrEmpty(t)) return s.Length;

            int[,] d = new int[s.Length + 1, t.Length + 1];

            for (int i = 0; i <= s.Length; i++) d[i, 0] = i;
            for (int j = 0; j <= t.Length; j++) d[0, j] = j;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    int cost = s[i - 1] == t[j - 1] ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[s.Length, t.Length];
        }

        private void SearchTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTxtbox.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ClientsListView.ItemsSource = _allClients;
                return;
            }

            var filtered = _allClients.Where(c =>
                c.Persons != null && (
                    LevenshteinDistance(c.Persons.FirstName?.ToLower() ?? "", searchText) <= 3 ||
                    LevenshteinDistance(c.Persons.MiddleName?.ToLower() ?? "", searchText) <= 3 ||
                    LevenshteinDistance(c.Persons.LastName?.ToLower() ?? "", searchText) <= 3
                )
            ).ToList();

            ClientsListView.ItemsSource = filtered;
        }

        private void ClientsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientsListView.SelectedItem is Clients selectedClient)
            {
                int personId = selectedClient.Person_Id;
                EditClientWindow editWindow = new EditClientWindow(personId);
                editWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Клиент не выбран.");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для удаления клиента нужно выбрать его из списка.");
        }
    }
}
