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
 
    public partial class AddressesWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        public AddressesWindow()
        {
            InitializeComponent();
            LoadAddresses();
        }
        private void LoadAddresses()
        {
            var addressesdata = _context.RealEstate.Include("Addresses").ToList();
            AppartamentsDataGrid.ItemsSource = addressesdata;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            RealEstatesWindow realEstatesWindow = new RealEstatesWindow();
            realEstatesWindow.Show();
            this.Close();
        }
    }
}
