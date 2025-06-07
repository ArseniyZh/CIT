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
   
    public partial class HousesWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        public HousesWindow()
        {
            InitializeComponent();
            LoadHouses();
        }
        private void LoadHouses()
        {
            var appartmentsdata = _context.Houses.ToList();
            AppartamentsDataGrid.ItemsSource = appartmentsdata;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            RealEstatesWindow realEstatesWindow = new RealEstatesWindow();
            realEstatesWindow.Show();
            this.Close();
        }
    }
}
