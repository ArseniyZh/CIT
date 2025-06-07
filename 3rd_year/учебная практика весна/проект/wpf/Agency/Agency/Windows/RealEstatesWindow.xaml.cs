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
    /// <summary>
    /// Логика взаимодействия для RealEstatesWindow.xaml
    /// </summary>
    public partial class RealEstatesWindow : Window
    {
        public RealEstatesWindow()
        {
            InitializeComponent();
        }

        private void AppartamnetsBtn_Click(object sender, RoutedEventArgs e)
        {
            AppartamentsWindow appartamentsWindow = new AppartamentsWindow();
            appartamentsWindow.Show();
            this.Close();
        }

        private void HousesBtn_Click(object sender, RoutedEventArgs e)
        {
            HousesWindow housesWindow = new HousesWindow();
            housesWindow.Show();
            this.Close();
        }

        private void LandBtn_Click(object sender, RoutedEventArgs e)
        {
            LandsWindow landsWindow = new LandsWindow();
            landsWindow.Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AgencyWindow agencyWindow = new AgencyWindow();
            agencyWindow.Show();
            this.Close();
        }

        private void AddressesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddressesWindow addressesWindow = new AddressesWindow();
            addressesWindow.Show();
            this.Close();
        }

        private void DistrictBtn_Click(object sender, RoutedEventArgs e)
        {
            DistrictsWindow districtsWindow = new DistrictsWindow();
            districtsWindow.Show();
            this.Close();
        }
    }
}
